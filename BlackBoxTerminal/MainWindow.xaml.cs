using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using System.Xml.Serialization;
using BlackBoxTerminal.Common;
using BlackBoxTerminal.Controls;
using BlackBoxTerminal.Model;

using BlackBoxTerminal.Services;
using Microsoft.Win32;
using System.Text;

namespace BlackBoxTerminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window,INotifyPropertyChanged
    {
        private ContextMenuItems _menuItems;
        private Stopwatch _inputDelayTimer;
        private Stopwatch _outputDelayTimer;
        internal ComPortService UserPortService;
        private bool IsRunning = true;

        #region DataModelList Property

        public ObservableCollection<DataModel> InputList
        {
            get { return (ObservableCollection<DataModel>)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public ObservableCollection<DataModel> OutputList
        {
            get { return (ObservableCollection<DataModel>)GetValue(OutputProperty); }
            set { SetValue(OutputProperty, value); }
        }

        public DeviceCollection DeviceCollection
        {
            get { return (DeviceCollection)GetValue(DeviceCollectionProperty); }
            set { SetValue(DeviceCollectionProperty, value); }
        }

        public static readonly DependencyProperty InputProperty =
            DependencyProperty.Register("InputList", typeof(ObservableCollection<DataModel>), typeof(MainWindow));

        public static readonly DependencyProperty OutputProperty =
            DependencyProperty.Register("OutputList", typeof(ObservableCollection<DataModel>), typeof(MainWindow));

        public static readonly DependencyProperty DeviceCollectionProperty =
           DependencyProperty.Register("DeviceCollection", typeof(DeviceCollection), typeof(MainWindow));

        #endregion

        public ContextMenuItems MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; }
        }

        public bool IsConnected
        {
            get
            {
                if(UserPortService!=null)
                return UserPortService.SelectedPort.IsOpen;
                else
                    return false;
            }
        }

        private bool _isSettingsVisible = true;
        public bool IsSettingsVisible
        {
            get { return _isSettingsVisible; }
            set
            {
                _isSettingsVisible = value;
                OnPropertyChanged("IsSettingsVisible");
            }
        }

        private DataType _dataType;
        public DataType DataType
        {
            get { return _dataType; }
            set
            {
                _dataType = value;
                OnPropertyChanged("DataType");
            }
        }

        
        public string SampleByte
        {
            get
            {
                var e = Encoding.GetEncoding("iso-8859-1");
                var s = e.GetString(new byte[] { 127 });
                return s;
            }
           
        }

        

        public MainWindow()
        {
            InitializeComponent();
            BindingCommands();
            BindingContextMenuItems();
            DataContext = this;
            InputList = new ObservableCollection<DataModel>();
            OutputList = new ObservableCollection<DataModel>();
            DeviceCollection=new DeviceCollection();
            _inputDelayTimer=new Stopwatch();
            _outputDelayTimer = new Stopwatch();
            Loaded += MainWindow_Loaded;
            //SampleDeviceCollection();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            IsRunning = false;
            base.OnClosing(e);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UserPortService=new ComPortService();
            SetInitialPortParameters();

            if (ComPortService.ComPortExists)
            {
                UserPortService.SelectedPort.PortName = Properties.Settings.Default.ComPort;
            }

            ComPortService.UserInterfaceData += AccessFormMarshal;

            InitRepeatRules();
        }

        private delegate void AccessFormMarshalDelegate(string action, object data);

        private void AccessFormMarshal(string action, object data)
        {
            AccessFormMarshalDelegate accessFormMarshalDelegate = AccessForm;

            object[] args = { action, data };

            //  Call AccessForm, passing the parameters in args.

            Dispatcher.BeginInvoke(accessFormMarshalDelegate,args);
            
        }

        private void AccessForm(string action, object data)
        {
            switch (action)
            {
                case "AppendToMonitorInput":
                    ModifyMatchData((byte[])data);
                    break;
                case "AppendToMonitorOutput":
                    ModifyOutMessageData((byte[])data);
                    break;
                case "DisplayStatus":
                    break;

                case "DisplayCurrentSettings":
                    break;

                default:

                    break;
            }
        }

        private void ModifyMatchData(byte[] data)
        {
            if (_inputDelayTimer.IsRunning) _inputDelayTimer.Stop();
            //var delay = _inputDelayTimer.Elapsed;
            var dataModel = new DataModel{Data = data};
            dataModel.Time = _inputDelayTimer.ElapsedMilliseconds > 0 ? _inputDelayTimer.ElapsedMilliseconds.ToString("0000") : String.Empty;
            var matchedRule = DeviceControl.SelectedDevice.RuleCollection.CheckMatchRule(data);
            if (matchedRule != null)
            {
                dataModel.Color = matchedRule.MatchColor;
                if (matchedRule.OutMessage.Length > 0)
                {
                    var addSendMessageQueue = new Thread(() => AddOutMessageQueue(matchedRule));
                    addSendMessageQueue.Start();
                }
            }
            InputList.Add(dataModel);
            _inputDelayTimer.Reset();
            _inputDelayTimer.Start();
        }

        private void AddOutMessageQueue(RuleModel rule)
        {
            Thread.Sleep(rule.Interval);
            AccessFormMarshal("AppendToMonitorOutput", rule.OutMessage);
        }

        private void AddOutMessage(RuleModel rule)
        {
            Thread.Sleep(rule.Interval);
            AccessFormMarshal("AppendToMonitorOutput", rule.Match);
        }

        private void InitRepeatRules()
        {
            var thread = new Thread(RepeatRules);
            thread.Start();
        }

        private void RepeatRules()
        {
            while (IsRunning)
            {
                if (DeviceControl.SelectedDevice != null&&DeviceControl.SelectedDevice.IsMaster==true)
                {
                    var rules = DeviceControl.SelectedDevice.RuleCollection;
                    var repeatRules = rules.Where(r => r.Enabled).ToList();
                    foreach (var rule in repeatRules)
                    {
                        AddOutMessage(rule);
                    }
                }
            }
        }

        private void ModifyOutMessageData(byte[] data)
        {
            if (_outputDelayTimer.IsRunning) _outputDelayTimer.Stop();
            var dataModel = new DataModel{Data = data};
            dataModel.Time = _outputDelayTimer.ElapsedMilliseconds > 0
                ? _outputDelayTimer.ElapsedMilliseconds.ToString("0000")
                : String.Empty;
            var matchedRule = DeviceControl.SelectedDevice.RuleCollection.CheckOutMessageRule(data);
            if (matchedRule != null)
            {
                dataModel.Color = matchedRule.OutMessageColor;
            }
            UserPortService.WriteToComPort(data);
            OutputList.Add(dataModel);
            _outputDelayTimer.Reset();
            _outputDelayTimer.Start();
        }

        private void GetPreferences()
        {
            UserPortService.SavedPortName = Properties.Settings.Default.ComPort;
            UserPortService.SavedBitRate = Properties.Settings.Default.BitRate;
            UserPortService.SavedHandshake = Properties.Settings.Default.Handshake;
        }

        private void SetInitialPortParameters()
        {
            GetPreferences();

            ComPortService.FindComPorts(); 

            if (ComPortService.ComPortExists)
            {
                //  Select a COM port and bit rate using stored preferences if available.

                UsePreferencesToSelectParameters();

                //  Save the selected indexes of the combo boxes.

                
            }
            else
            {
                //  No COM ports have been detected. Watch for one to be attached.

                //tmrLookForPortChanges.Start();
                //DisplayStatus(ComPorts.noComPortsMessage, Color.Red);
            }
            UserPortService.ParameterChanged = false;
        }

        private void UsePreferencesToSelectParameters()
        {
            //int myPortIndex = 0;

            UserPortService.SelectedPort.BaudRate = Properties.Settings.Default.BitRate;


            UserPortService.SelectedPort.Handshake = Properties.Settings.Default.Handshake;

        }

        //public void Settings()
        //{
        //    Dialogs.RulesDialog settings = new Dialogs.RulesDialog();
        //    settings.Owner = this;
        //    settings.ShowDialog();
        //}

        #region ContextMenuItems


        public ICommand OpenCommand
        {
            get { return new RelayCommand(param => Open()); }
        }

        public ICommand SaveCommand
        {
            get { return new RelayCommand(param => Save(param)); }
        }

        public ICommand SettingsCommand()
        {
            return new RelayCommand(param => Setting());
        }

        public ICommand DevicesCommand()
        {
            return new RelayCommand(param => Devices());
        }

        public ICommand ConnectCommand()
        {
            return new RelayCommand(param=>Connect());
        }

        public ICommand DisconnectCommand()
        {
            return new RelayCommand(param=>Disconnect());
        }

        public ICommand SendCommand
        {
            get { return new RelayCommand(param=>Send(param)); }
        }

        public ICommand ClearCommand
        {
            get { return new RelayCommand(param => Clear(param)); }
        }

        public ICommand DataTypeCommand
        {
            get { return new RelayCommand(param => Clear(param)); }
        }

        private void Open()
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "Device (*.dev)|*.dev|Received data (*.rec)|*.rec";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (ofd.ShowDialog() == true)
                {
                    if (ofd.CheckFileExists)
                    {
                        var fileInfo = new FileInfo(ofd.FileName);
                        switch (fileInfo.Extension)
                        {
                            case ".rec":
                                OpenInput(ofd.FileName);
                                break;
                            case ".dev":
                                OpenDevice(ofd.FileName);
                                break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }
            
        }

        private void OpenInput(string fileName)
        {
            var serializer = new XmlSerializer(typeof(ObservableCollection<DataModel>));
            var fs = new FileStream(fileName, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            InputList = (ObservableCollection<DataModel>)serializer.Deserialize(reader);
            fs.Close();
        }

        private void OpenDevice(string fileName)
        {
            var serializer = new XmlSerializer(typeof(DeviceCollection));
            var fs = new FileStream(fileName, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            DeviceCollection = (DeviceCollection)serializer.Deserialize(reader);
            fs.Close();
            _savedFileName = fileName;
        }

        private void Save(object param)
        {
            var par = param.ToString();
            switch (par)
            {
                case "Input":
                    if(InputList.Count>0)
                        SaveInput();
                    break;
                case "Device":
                    if (DeviceCollection.Count > 0)
                        SaveDevice();
                    break;
            }
        }

        private void SaveInput()
        {
            var fsd = new SaveFileDialog();
            fsd.Filter = "Received data (*.rec)|*.rec";
            fsd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            if (fsd.ShowDialog(this) == true)
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<DataModel>));
                TextWriter writer = new StreamWriter(fsd.FileName);
                serializer.Serialize(writer, InputList);
                writer.Close();
            }
        }

        private string _savedFileName = String.Empty;

        private void SaveDevice()
        {
            if (string.IsNullOrEmpty(_savedFileName))
            {
                var fsd = new SaveFileDialog
                {
                    Filter = "Device (*.dev)|*.dev",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };

                if (fsd.ShowDialog(this) != true) return;
                _savedFileName = fsd.FileName;
            }
            
            {
                var serializer = new XmlSerializer(typeof(DeviceCollection));
                TextWriter writer = new StreamWriter(_savedFileName);
                serializer.Serialize(writer, DeviceCollection);
                writer.Close();
            }
        }

        private void Setting()
        {
            IsSettingsVisible = !IsSettingsVisible;
        }

        private void Devices()
        {

        }

        private void Connect()
        {
            if (UserPortService.SelectedPort.IsOpen)
            {
                UserPortService.CloseComPort(UserPortService.SelectedPort);
                OnPropertyChanged("IsConnected");
                powerItem.StatusColor = Brushes.Silver;
                powerItem.Title = "Connect";
            }
            else
            {
                UserPortService.SelectedPort.PortName = Properties.Settings.Default.ComPort;
                if (UserPortService.OpenComPort())
                {
                    OnPropertyChanged("IsConnected");
                    powerItem.StatusColor = Brushes.LimeGreen;
                    powerItem.Title = "Disconnect";
                }
            }
        }

        private void Disconnect()
        {

        }

        private void Send(object obj)
        {
            var txtBox = obj as TextBox;
            if (txtBox==null||string.IsNullOrEmpty(txtBox.Text)||!UserPortService.SelectedPort.IsOpen) return;
            char[] charArray = txtBox.Text.ToCharArray();
            decimal decVal = charArray[0];
            byte[] data = ComPortService.GetBytes(txtBox.Text);
            ModifyOutMessageData(data);
            txtBox.Text = string.Empty;
            //var sp=new SoundPlayer(Properties.Resources.beep_07);
            //sp.PlaySync();
        }

        private void Clear(object type)
        {
            if((string)type=="Output")
            OutputList.Clear();
            else
            InputList.Clear();
        }

        private ContextMenuItem powerItem;

        private void BindingContextMenuItems()
        {
            _menuItems = new ContextMenuItems
            {
                new ContextMenuItem
                {
                    Command=OpenCommand,
                    Title="Open",
                    StatusColor=Brushes.Orange,
                    ImagePath = Geometry.Parse("M5.388822,5.0339882L22.943006,5.0339882 18.721215,15.256989 1.6100047,15.256989z M0,0L6.6660105,0 8.0000125,2.9348083 18.70703,2.9348083 18.70403,3.8337495 4.5530072,3.8337495 0.33200061,15.257004 0,15.257004z"),
                },

                 new ContextMenuItem
                 {
                    Command = SaveCommand,
                    Parameter = "Device",
                    Title="Save",
                    StatusColor=Brushes.DodgerBlue,
                    ImagePath = Geometry.Parse("M8.1099597,36.94997L8.1099597,41.793968 39.213959,41.793968 39.213959,36.94997z M12.42,0.049999889L18.4,0.049999889 18.4,12.252 12.42,12.252z M0,0L7.9001866,0 7.9001866,14.64218 39.210766,14.64218 39.210766,0 47.401001,0 47.401001,47.917 0,47.917z"),
                },

                new ContextMenuItem
                {
                    Command=SettingsCommand(),
                    Title="Settings",
                    StatusColor=Brushes.Silver,
                    ImagePath = Geometry.Parse("M383.518,230.427C299.063,230.427 230.355,299.099 230.355,383.554 230.355,468.009 299.063,536.644 383.518,536.644 467.937,536.644 536.645,468.009 536.645,383.554 536.645,299.099 467.937,230.427 383.518,230.427z M340.229,0L426.771,0C436.838,0,445.035,8.19732,445.035,18.2643L445.035,115.303C475.165,122.17,503.532,133.928,529.634,150.43L598.306,81.6869C601.721,78.3074 606.359,76.3653 611.213,76.3653 616.031,76.3653 620.704,78.3074 624.12,81.6869L685.278,142.916C692.397,150.035,692.397,161.648,685.278,168.767L616.677,237.402C633.108,263.54,644.866,291.907,651.733,322.001L748.736,322.001C758.803,322.001,767,330.198,767,340.265L767,426.806C767,436.873,758.803,445.07,748.736,445.07L651.769,445.07C644.901,475.235,633.108,503.531,616.677,529.669L685.278,598.305C688.694,601.72 690.635,606.358 690.635,611.212 690.635,616.102 688.694,620.705 685.278,624.12L624.085,685.313C620.525,688.872 615.851,690.67 611.177,690.67 606.503,690.67 601.865,688.872 598.269,685.313L529.67,616.678C503.567,633.109,475.2,644.937,445.035,651.804L445.035,748.771C445.035,758.838,436.838,767,426.771,767L340.229,767C330.162,767,321.965,758.838,321.965,748.771L321.965,651.804C291.8,644.937,263.433,633.109,237.366,616.678L168.731,685.313C165.315,688.693 160.677,690.67 155.823,690.67 151.005,690.67 146.296,688.693 142.916,685.313L81.7221,624.12C74.6033,617.036,74.6033,605.424,81.7221,598.305L150.323,529.669C133.892,503.603,122.099,475.235,115.267,445.07L18.2643,445.07C8.19734,445.07,0,436.873,0,426.806L0,340.265C0,330.198,8.19734,322.001,18.2643,322.001L115.267,322.001C122.135,291.907,133.892,263.54,150.323,237.402L81.7221,168.767C78.3064,165.351 76.3655,160.713 76.3655,155.859 76.3655,150.97 78.3064,146.332 81.7221,142.916L142.916,81.7582C146.476,78.1988 151.149,76.4016 155.823,76.4016 160.497,76.4016 165.171,78.1988 168.731,81.7582L237.366,150.43C263.469,133.928,291.837,122.17,321.965,115.303L321.965,18.2643C321.965,8.19732,330.162,0,340.229,0z"),
                },


            };

            powerItem = new ContextMenuItem
            {
                Command = ConnectCommand(),
                Title = "Connect",
                StatusColor = Brushes.Silver,
                ImagePath =
                    Geometry.Parse(
                        "M14.800615,5.6499605L14.800615,14.800346C10.630442,17.910477 7.8903284,22.840685 7.8903284,28.44092 7.9003286,37.871319 15.530646,45.511639 24.961039,45.521641 34.391431,45.511639 42.011749,37.871319 42.04175,28.44092 42.03175,22.840685 39.291636,17.910477 35.121462,14.800346L35.121462,5.6599612C43.841825,9.5601254,49.912077,18.280493,49.912077,28.44092L49.922077,28.44092C49.912077,42.231503 38.741611,53.391972 24.961039,53.391972 11.170465,53.391972 0,42.231503 0,28.44092 0,18.270493 6.0902529,9.5501251 14.800615,5.6499605z M19.570043,0L30.237043,0 30.237043,33.917 19.570043,33.917z"),
            };

            _menuItems.Add(powerItem);




        }

        #endregion

        #region INotifyChangedProperty

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
                Properties.Settings.Default.Save();
            }
        }

        #endregion

        #region MainWindowCommands

        private void BindingCommands()
        {
            this.CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
            this.CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand,
                OnMaximizeWindow,
                OnCanResizeWindow));
            this.CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand,
                OnMinimizeWindow,
                OnCanMinimizeWindow));
            this.CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand,
                OnRestoreWindow,
                OnCanResizeWindow));
        }

        private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.ResizeMode == ResizeMode.CanResize ||
                           this.ResizeMode == ResizeMode.CanResizeWithGrip;
        }

        private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.ResizeMode != ResizeMode.NoResize;
        }

        private void OnCloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        private void OnMaximizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        private void OnMinimizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void OnRestoreWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        #endregion

        
    }
}
