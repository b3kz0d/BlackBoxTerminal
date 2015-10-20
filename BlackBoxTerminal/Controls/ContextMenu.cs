using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BlackBoxTerminal.Controls
{
    public class ContextMenuItem:INotifyPropertyChanged
    {
        private SolidColorBrush _statusColor;
        private string _title;
        public ICommand Command { get; set; }
        public object Parameter { get; set; }
        public Geometry ImagePath { get; set; }

        public SolidColorBrush StatusColor
        {
            get { return _statusColor; }
            set
            {
                _statusColor = value;
                OnPropertyChanged("StatusColor");
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class ContextMenuItems : List<ContextMenuItem> { }

    public class ContextMenu : Control
    {
        public static readonly DependencyProperty ContextItemProperty =
           DependencyProperty.Register("Items", typeof(ContextMenuItems), typeof(ContextMenu));

        public ContextMenuItems Items
        {
            get { return (ContextMenuItems)GetValue(ContextItemProperty); }
            set { SetValue(ContextItemProperty, value); }
        }
    }
}
