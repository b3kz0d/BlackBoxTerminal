using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BlackBoxTerminal.Model;
using System.Collections.Generic;

namespace BlackBoxTerminal.Controls
{
    class Output : Control, INotifyPropertyChanged
    {
        #region DataModelList Property

        public ObservableCollection<DataModel> DataModelList
        {
            get { return (ObservableCollection<DataModel>)GetValue(DataModelProperty); }
            set { SetValue(DataModelProperty, value); }
        }

        public static readonly DependencyProperty DataModelProperty =
            DependencyProperty.Register("DataModelList", typeof(ObservableCollection<DataModel>), typeof(Output));

        #endregion

        #region Public Properties

        private bool _showAscii = true;
        public bool ShowAscii
        {
            get
            {
                if (ShowHex || ShowBinary)
                    return _showAscii;
                else
                    return _showAscii = true;
            }
            set
            {
                _showAscii = value;
                OnPropertyChanged("ShowAscii");
            }
        }

        private bool _showHex = false;
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

        private bool _showBinary = false;
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

        private TextBox _textBoxTemplate;
        public TextBox TextBoxTemplate
        {
            get { return _textBoxTemplate; }
            set
            {
                _textBoxTemplate = value;
                OnPropertyChanged("TextBoxTemplate");
            }
        }

        #endregion

        public Output()
        {
            _textBoxTemplate=new TextBox();
            _textBoxTemplate.SelectionStart = 0;
            _textBoxTemplate.SelectionLength = _textBoxTemplate.Text.Length;
            _textBoxTemplate.SelectionBrush=Brushes.Blue;
            _textBoxTemplate.TextChanged += _textBoxTemplate_TextChanged;
            _textBoxTemplate.PreviewKeyDown += _textBoxTemplate_PreviewKeyDown;
            DataContext = this;
        }

        private void _textBoxTemplate_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

        private void _textBoxTemplate_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private bool IsHex(IEnumerable<char> chars)
        {
            bool isHex;
            foreach (var c in chars)
            {
                isHex = ((c >= '0' && c <= '9') ||
                         (c >= 'a' && c <= 'f') ||
                         (c >= 'A' && c <= 'F'));

                if (!isHex)
                    return false;
            }
            return true;
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
