using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Controls;

namespace BlackBoxTerminal.Controls
{
    public class Settings : Control, INotifyPropertyChanged
    {
        private string _comPort;
        private int _bitRate;
        private Handshake _handshake;
        private Parity _parity;
        private StopBits _stopBits;
        private int _dataBit;
        private bool _dtr;
        private bool _rts;

        public string ComPort
        {
            get { return Properties.Settings.Default.ComPort;  }
            set
            {
                Properties.Settings.Default.ComPort = value;
                OnPropertyChanged("ComPort");
            }
        }

        public int BitRate
        {
            get { return Properties.Settings.Default.BitRate; }
            set
            {
                Properties.Settings.Default.BitRate = value;
                OnPropertyChanged("BitRate");
            }
        }

        public int DataBit
        {
            get { return Properties.Settings.Default.DataBit; }
            set
            {
                Properties.Settings.Default.DataBit = value;
                OnPropertyChanged("DataBit");
            }
        }

        public Handshake Handshake
        {
            get { return Properties.Settings.Default.Handshake; }
            set
            {
                Properties.Settings.Default.Handshake = value;
                OnPropertyChanged("Handshake");
            }
        }

        public Parity Parity
        {
            get { return Properties.Settings.Default.Parity; }
            set
            {
                Properties.Settings.Default.Parity = value;
                OnPropertyChanged("Parity");
            }
        }

        public StopBits StopBits
        {
            get { return Properties.Settings.Default.StopBits; }
            set
            {
                Properties.Settings.Default.StopBits = value;
                OnPropertyChanged("StopBits");
            }
        }

        

        public bool DTR
        {
            get { return Properties.Settings.Default.DTR; }
            set
            {
                Properties.Settings.Default.DTR = value;
                OnPropertyChanged("DTR");
            }
        }

        public bool RTS
        {
            get { return Properties.Settings.Default.RTS; }
            set
            {
                Properties.Settings.Default.RTS = value;
                OnPropertyChanged("RTS");
            }
        }

        public Settings()
        {
            //_comPort = Properties.Settings.Default.ComPort;
            //_bitRate = Properties.Settings.Default.BitRate;
            //_handshake = Properties.Settings.Default.Handshake;
            //_parity = Properties.Settings.Default.Parity;
            //_stopBits = Properties.Settings.Default.StopBits;
            //_dataBit = Properties.Settings.Default.DataBit;
            //_dtr = Properties.Settings.Default.DTR;
            //_rts = Properties.Settings.Default.RTS;
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
