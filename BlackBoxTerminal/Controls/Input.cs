using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using BlackBoxTerminal.Model;

namespace BlackBoxTerminal.Controls
{
    public class Input:Control,INotifyPropertyChanged
    {
        #region DataModelList Property

        public ObservableCollection<DataModel> DataModelList
        {
            get { return (ObservableCollection<DataModel>)GetValue(DataModelProperty); }
            set { SetValue(DataModelProperty, value); }
        }

        public static readonly DependencyProperty DataModelProperty =
            DependencyProperty.Register("DataModelList", typeof(ObservableCollection<DataModel>), typeof(Input));

        #endregion

        #region Public Properties

        private bool _showAscii=true;
        public bool ShowAscii
        {
            get
            {
                if(ShowHex||ShowBinary)
                    return _showAscii;
                else
                    return _showAscii=true;
            }
            set
            {
                _showAscii = value;
                OnPropertyChanged("ShowAscii");
            }
        }

        private bool _showHex=false;
        public bool ShowHex
        {
            get { return _showHex; }
            set
            {
                _showHex = value;
                OnPropertyChanged("ShowHex");
                OnPropertyChanged("ShowAscii");
            }
        }

        private bool _showBinary=false;
        public bool ShowBinary
        {
            get { return _showBinary; }
            set
            {
                _showBinary = value;
                OnPropertyChanged("ShowBinary");
                OnPropertyChanged("ShowAscii");
            }
        }

        #endregion

        public Input()
        {
            DataContext = this;
        }

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
    }
}
