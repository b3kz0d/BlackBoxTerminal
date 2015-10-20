using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace BlackBoxTerminal.Model
{
    [ValueConversion(typeof(object), typeof(string))]
    public class ByteArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var byteArray = value as byte[];
            if(byteArray!=null)
            return System.Text.Encoding.ASCII.GetString((byte[]) value);
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                        System.Globalization.CultureInfo culture)
        {
            var editedText = value as string;
            if(editedText!=null)
                return System.Text.Encoding.ASCII.GetBytes(editedText);
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(string))]
    public class ByteArrayToBinaryStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal dec =((string)value).ToArray()[0];
            return dec.ToString("000");
            //return System.Text.Encoding.Unicode.GetString((byte[])value);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                        System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(string))]
    public class ByteArrayToHexStringConverter : IValueConverter
    {
        private static readonly uint[] Lookup32Unsafe = CreateLookup32Unsafe();
        private static unsafe readonly uint* Lookup32UnsafeP = (uint*)GCHandle.Alloc(Lookup32Unsafe, GCHandleType.Pinned).AddrOfPinnedObject();

        private static uint[] CreateLookup32Unsafe()
        {
            var result = new uint[256];
            for (int i = 0; i < 256; i++)
            {
                string s = i.ToString("X2");
                if (BitConverter.IsLittleEndian)
                    result[i] = ((uint)s[0]) + ((uint)s[1] << 16);
                else
                    result[i] = ((uint)s[1]) + ((uint)s[0] << 16);
            }
            return result;
        }

        public static unsafe string ByteArrayToHexViaLookup32Unsafe(byte[] bytes)
        {
            var lookupP = Lookup32UnsafeP;
            var result = new char[bytes.Length * 2];
            fixed (byte* bytesP = bytes)
            fixed (char* resultP = result)
            {
                var resultP2 = (uint*)resultP;
                for (int i = 0; i < bytes.Length; i++)
                {
                    resultP2[i] = lookupP[bytesP[i]];
                }
            }
            return new string(result);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bytes = System.Text.Encoding.ASCII.GetBytes((string)value);
            return ByteArrayToHexViaLookup32Unsafe(bytes);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                        CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(string))]
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selectedColor = value as string;
            
            if (selectedColor != null)
            {
                var color = (Color)System.Windows.Media.ColorConverter.ConvertFromString(selectedColor);
                if (color != null)
                {
                    if ((string)parameter == "Brush")
                    {
                        return new SolidColorBrush(color);
                    }
                    return color;
                }
            }
              
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                        System.Globalization.CultureInfo culture)
        {
            var c =(Color)value;
            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", c.A, c.R, c.G, c.B);
            return null;
        }
    }

    [ValueConversion(typeof(object), typeof(string))]
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var totalSeconds = (int)value;
            TimeSpan t = TimeSpan.FromSeconds(totalSeconds);
            string answer = string.Format("{0:D2}:{1:D2}:{2:D2}",
                            t.Hours,
                            t.Minutes,
                            t.Seconds);


            return answer;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                        System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class HexStringConverter : IValueConverter
    {
        private string lastValidValue;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ret = null;

            if (value != null && value is string)
            {
                var valueAsString = (string)value;
                var parts = valueAsString.ToCharArray();
                var formatted = parts.Select((p, i) => (++i) % 2 == 0 ? String.Concat(p.ToString(), " ") : p.ToString());
                ret = String.Join(String.Empty, formatted).Trim();
            }

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object ret = null;
            if (value != null && value is string)
            {
                var valueAsString = ((string)value).Replace(" ", String.Empty).ToUpper();
                ret = lastValidValue = IsHex(valueAsString) ? valueAsString : lastValidValue;
            }

            return ret;
        }


        private bool IsHex(string text)
        {
            var reg = new System.Text.RegularExpressions.Regex("^[0-9A-Fa-f]*$");
            return reg.IsMatch(text);
        }
    }
}
