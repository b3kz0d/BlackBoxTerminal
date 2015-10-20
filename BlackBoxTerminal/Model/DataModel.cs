using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoxTerminal.Model
{
    public class DataModel
    {
        public string Time { get; set; }
        public byte[] Data { get; set; }
        public string Color { get; set; }
    }

    public class DataModelList : ObservableCollection<DataModel>
    {
        
    }

    public struct DataStruct
    {
        public object Data { get; set; }
        public DataType DataType { get; set; } 
    }

    public enum DataType
    {
        Ascii = 0,
        Hex = 1,
        Dec = 2,
    }


}
