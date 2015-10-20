using System;
using System.IO.Ports;
using System.Windows.Markup;

namespace BlackBoxTerminal.Extensions
{

    public class ComPortsExtension : MarkupExtension
    {
        public ComPortsExtension() { }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return SerialPort.GetPortNames(); 
        }
    }

    public class HandshakeExtension: MarkupExtension
    {
        public HandshakeExtension() { }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(typeof(Handshake));
        }
    }

    public class DataBitsExtension : MarkupExtension
    {
        public int[] DataBits = new int[4];
        public DataBitsExtension()
        {
            DataBits[0] = 5;
            DataBits[1] = 6;
            DataBits[2] = 7;
            DataBits[3] = 8;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return DataBits;
        }
    }

    public class ParityExtension : MarkupExtension
    {
        public ParityExtension(){}
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(typeof(Parity));
        }
    }

    public class StopBitsExtension : MarkupExtension
    {
        public StopBitsExtension() { }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(typeof(StopBits));
        }
    }

    public class BitRatesExtension : MarkupExtension
    {
        public int[] BitRates =new int[11];

        public BitRatesExtension()
        {
            BitRates[0] = 300;
            BitRates[1] = 600;
            BitRates[2] = 1200;
            BitRates[3] = 2400;
            BitRates[4] = 9600;
            BitRates[5] = 14400;
            BitRates[6] = 19200;
            BitRates[7] = 38400;
            BitRates[8] = 57600;
            BitRates[9] = 115200;
            BitRates[10] = 128000; 
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return BitRates;
        }
    }
}
