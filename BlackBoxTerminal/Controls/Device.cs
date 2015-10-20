using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BlackBoxTerminal.Common;
using BlackBoxTerminal.Model;

namespace BlackBoxTerminal.Controls
{
    public class Device : Control,INotifyPropertyChanged
    {
        #region DataModelList Property

        public DeviceCollection DeviceCollection
        {
            get { return (DeviceCollection)GetValue(DeviceCollectionProperty); }
            set { SetValue(DeviceCollectionProperty, value); }
        }

        public static readonly DependencyProperty DeviceCollectionProperty =
            DependencyProperty.Register("DeviceCollection", typeof(DeviceCollection), typeof(Device));

        #endregion

        #region Public Property

        private DeviceModel _selectedDevice;
        public DeviceModel SelectedDevice
        {
            get { return _selectedDevice; }
            set
            {
                if(_selectedDevice==value) return;
                IsEditMode = false;
                _selectedDevice = value;
                OnPropertyChanged("SelectedDevice");
            }
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                _isEditMode = value;
                OnPropertyChanged("IsEditMode");
            }
        }

        public ICommand AddCommand
        {
            get { return new RelayCommand(param => AddNew()); }
        }

        public ICommand SaveCommand
        {
            get { return new RelayCommand(param => AddNew()); }
        }

        public ICommand EditCommand
        {
            get { return new RelayCommand(param => Edit()); }
        }

        public ICommand RemoveCommand
        {
            get { return new RelayCommand(param => Remove()); }
        }


        #endregion

        #region Public Methods

        public Device()
        {
            DataContext = this;
            _selectedDevice=new DeviceModel();
        }

        #endregion

        #region Private Methods

        private void AddNew()
        {
            var newDevice = new DeviceModel {Name = "New Device"};
            DeviceCollection.Insert(0,newDevice);
            SelectedDevice = newDevice;
            IsEditMode = true;
        }

        private void Edit()
        {
            IsEditMode = !IsEditMode;
        }

        private void Save()
        {
            //IsEditMode = false;
        }

        private void Remove()
        {
            DeviceCollection.Remove(_selectedDevice);
            SelectedDevice = DeviceCollection.FirstOrDefault();
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
    }
}
