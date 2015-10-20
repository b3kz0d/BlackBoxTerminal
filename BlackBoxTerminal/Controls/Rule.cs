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
    public class Rule : Control, INotifyPropertyChanged
    {
        #region DataModelList Property

        public DeviceModel Device
        {
            get { return (DeviceModel)GetValue(DeviceProperty); }
            set { SetValue(DeviceProperty, value); }
        }

        public static readonly DependencyProperty DeviceProperty =
            DependencyProperty.Register("Device", typeof(DeviceModel), typeof(Rule));

        public RuleCollection RuleCollection
        {
            get { return (RuleCollection)GetValue(RuleCollectionProperty); }
            set { SetValue(RuleCollectionProperty, value); }
        }

        public static readonly DependencyProperty RuleCollectionProperty =
            DependencyProperty.Register("RuleCollection", typeof(RuleCollection), typeof(Rule));

        #endregion

        #region Public Property

        private RuleModel _selectedRule;
        public RuleModel SelectedRule
        {
            get { return _selectedRule; }
            set
            {
                if (_selectedRule == value) return;
                IsEditMode = false;
                _selectedRule = value;
                OnPropertyChanged("SelectedRule");
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

        public Rule()
        {
            DataContext = this;
            _selectedRule = new RuleModel();
        }

        #endregion

        #region Private Methods

        private void AddNew()
        {
            var newRule = new RuleModel() {};
            Device.RuleCollection.Add(newRule);
            SelectedRule = newRule;
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
            Device.RuleCollection.Remove(_selectedRule);
            SelectedRule = Device.RuleCollection.FirstOrDefault();
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
