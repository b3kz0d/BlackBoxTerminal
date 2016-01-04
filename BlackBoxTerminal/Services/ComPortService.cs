using System;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using BlackBoxTerminal.Model;
using System.IO;

namespace BlackBoxTerminal.Services
{    
    /// <summary>
    /// Routines for finding and accessing COM ports.
    /// </summary>

    public class ComPortService  
    {  
        private const string ModuleName = "ComPorts"; 
        
        //  Shared members - do not belong to a specific instance of the class.
        
        internal static bool ComPortExists; 
        internal static string[] MyPortNames; 
        internal static string NoComPortsMessage = "No COM ports found. Please attach a COM-port device.";

        internal delegate void UserInterfaceDataEventHandler(string action, object data); 
        internal static event UserInterfaceDataEventHandler UserInterfaceData; 
        
        //  Non-shared members - belong to a specific instance of the class.
        
        //internal delegate void SerialDataReceivedEventHandlerDelegate( object sender, SerialDataReceivedEventArgs e );
        //internal delegate void SerialErrorReceivedEventHandlerDelegate( object sender, SerialErrorReceivedEventArgs e );
        internal delegate bool WriteToComPortDelegate( string textToWrite );
              
        internal WriteToComPortDelegate WriteToComPortDelegate1;      
        
        //  Local variables available as Properties.

        private bool _mParameterChanged;
        private bool _mPortChanged;
        private bool _mPortOpen;
        private SerialPort _mPreviousPort = new SerialPort();
        private int _mReceivedDataLength;
        private int _mSavedBitRate = 9600;
        private Handshake _mSavedHandshake = Handshake.None ;
        private string _mSavedPortName = "";
        private SerialPort _mSelectedPort = new SerialPort();
        private Stopwatch _mDelayTimer;
        private Stopwatch _mDataReceivedTimer;
               
        internal bool ParameterChanged 
        { 
            get 
            { 
                return _mParameterChanged; 
            } 
            set 
            { 
                _mParameterChanged = value; 
            } 
        } 
        
        internal bool PortChanged 
        { 
            get 
            { 
                return _mPortChanged; 
            } 
            set 
            { 
                _mPortChanged = value; 
            } 
        }         
      
        internal bool PortOpen 
        { 
            get 
            { 
                return _mPortOpen; 
            } 
            set 
            { 
                _mPortOpen = value; 
            } 
        }         
       
        internal SerialPort PreviousPort 
        { 
            get 
            { 
                return _mPreviousPort; 
            } 
            set 
            { 
                _mPreviousPort = value; 
            } 
        }         
       
        internal int ReceivedDataLength 
        { 
            get 
            { 
                return _mReceivedDataLength; 
            } 
            set 
            { 
                _mReceivedDataLength = value; 
            } 
        }         
       
        internal int SavedBitRate 
        { 
            get 
            { 
                return _mSavedBitRate; 
            } 
            set 
            { 
                _mSavedBitRate = value; 
            } 
        }         
        
        internal Handshake SavedHandshake 
        { 
            get 
            { 
                return _mSavedHandshake; 
            } 
            set 
            { 
                _mSavedHandshake = value; 
            } 
        }         
       
        internal string SavedPortName 
        { 
            get 
            { 
                return _mSavedPortName; 
            } 
            set 
            { 
                _mSavedPortName = value; 
            } 
        }         
       
        internal SerialPort SelectedPort 
        { 
            get 
            { 
                return _mSelectedPort; 
            } 
            set 
            { 
                _mSelectedPort = value; 
            } 
        } 
        
        private SerialDataReceivedEventHandler _serialDataReceivedEventHandler1;        
        private SerialErrorReceivedEventHandler _serialErrorReceivedEventHandler1; 
        
        /// <summary>
        /// If the COM port is open, close it.
        /// </summary>
        /// 
        /// <param name="portToClose"> the SerialPort object to close </param>  

        internal void CloseComPort( SerialPort portToClose ) 
        { 
            try 
            { 
                if ( null != UserInterfaceData ) UserInterfaceData( "DisplayStatus", null ); 
                
                object transTemp0 = portToClose; 
                if (  transTemp0 != null ) 
                {                     
                    if ( portToClose.IsOpen ) 
                    {                         
                        portToClose.Close();
                        SelectedPort.DataReceived -= _serialDataReceivedEventHandler1;
                        SelectedPort.ErrorReceived -= _serialErrorReceivedEventHandler1; 
                        if (null != UserInterfaceData) UserInterfaceData("DisplayCurrentSettings", null);                         
                    } 
                }                
           }
                                      
            catch ( InvalidOperationException ex ) 
            {                 
                ParameterChanged = true; 
                PortChanged = true; 
                DisplayException( ModuleName, ex );                 
            } 
            catch ( UnauthorizedAccessException ex ) 
            {                 
                ParameterChanged = true; 
                PortChanged = true; 
                DisplayException( ModuleName, ex );                 
            } 
            catch ( System.IO.IOException ex ) 
            {                 
                ParameterChanged = true; 
                PortChanged = true; 
                DisplayException( ModuleName, ex ); 
            }             
        }

        private RuleCollection _rules;

        public RuleCollection Rules
        {
            get
            {
                return _rules;
            }
            set
            {
                _rules = value;
            }
        }

        /// <summary>
        /// Called when data is received on the COM port.
        /// Reads and displays the data.
        /// See FindPorts for the AddHandler statement for this routine.
        /// </summary>
        MemoryStream _memoryStream;
        System.Timers.Timer _delayTimer;
        internal void DataReceived( object sender, SerialDataReceivedEventArgs e ) 
        {
            try 
            { 
                //Get data from the COM port.

                //SelectedPort.DtrEnable = true;
                //SelectedPort.RtsEnable = true;

                int bytes = SelectedPort.BytesToRead;
                byte[] buffer = new byte[bytes];
                SelectedPort.Read(buffer, 0, bytes);
                

                if(_memoryStream==null) _memoryStream = new MemoryStream();
                if (_delayTimer == null)
                {
                    _delayTimer = new System.Timers.Timer();
                    _delayTimer.Interval = 2000;
                    _delayTimer.Elapsed += _delayTimer_Elapsed;
                    _delayTimer.AutoReset = true;
                }
                _memoryStream.Write(buffer, 0, buffer.Length);
                _delayTimer.Stop();
                _delayTimer.Start();
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( ModuleName, ex ); 
            } 
        }

        private void _delayTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var buffer=_memoryStream.ToArray();
            if (null != UserInterfaceData)
                UserInterfaceData("AppendToMonitorInput", buffer);
            _memoryStream = null;
            _delayTimer.Stop();

        }

        public static void Reset(System.Timers.Timer timer)
        {
            timer.Stop();
            timer.Start();
        }

        public static string GetString(byte[] bytes)
        {
            //var chars = new char[bytes.Length / sizeof(char)];
            //Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return System.Text.Encoding.ASCII.GetString(bytes); //new string(chars);
        }

        public static byte[] GetBytes(string str)
        {
            //byte[] bytes = new byte[str.Length * sizeof(char)];
            //System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            var bytes = System.Text.Encoding.ASCII.GetBytes(str);
            return bytes;
        }

       

        /// <summary>
        /// Provide a central mechanism for displaying exception information.
        /// Display a message that describes the exception.
        /// </summary>
        /// 
        /// <param name="ex"> The exception </param> 
        /// <param name="moduleName" > the module where the exception was raised. </param>
        
        private void DisplayException( string moduleName, Exception ex )
        {
            var errorMessage = "Exception: " + ex.Message + " Module: " + moduleName + ". Method: " + ex.TargetSite.Name;

            if (null != UserInterfaceData) UserInterfaceData("DisplayStatus", new DataModel() { Data =GetBytes(errorMessage)  }); 
            
            //  To display errors in a message box, uncomment this line:
            //  MessageBox.Show(errorMessage)
        }

        /// <summary>
        /// Respond to error events.
        /// </summary>
        
        private void ErrorReceived( object sender, SerialErrorReceivedEventArgs e )
        {
            var serialErrorReceived1 = e.EventType;

            switch ( serialErrorReceived1 ) 
            {
                case SerialError.Frame:
                    Console.WriteLine( @"Framing error." ); 
                    
                    break;
                case SerialError.Overrun:
                    Console.WriteLine( @"Character buffer overrun." ); 
                    
                    break;
                case SerialError.RXOver:
                    Console.WriteLine( @"Input buffer overflow." ); 
                    
                    break;
                case SerialError.RXParity:
                    Console.WriteLine( @"Parity error." ); 
                    
                    break;
                case SerialError.TXFull:
                    Console.WriteLine( @"Output buffer full." ); 
                    break;
            }
        }

        /// <summary>
        /// Find the PC's COM ports and store parameters for each port.
        /// Use saved parameters if possible, otherwise use default values.  
        /// </summary>
        /// 
        /// <remarks> 
        /// The ports can change if a USB/COM-port converter is attached or removed,
        /// so this routine may need to run multiple times.
        /// </remarks>
        
       internal static void FindComPorts() 
        { 
            MyPortNames = SerialPort.GetPortNames(); 
            
            //  Is there at least one COM port?
            
            if ( MyPortNames.Length > 0 ) 
            {                 
                ComPortExists = true; 
                Array.Sort( MyPortNames );                 
            } 
            else 
            { 
                //  No COM ports found.
                
                ComPortExists = false; 
            }             
        } 

        /// <summary>
        /// Open the SerialPort object selectedPort.
        /// If open, close the SerialPort object previousPort.
        /// </summary>
                
        internal bool OpenComPort() 
        { 
            var success = false;
            _serialDataReceivedEventHandler1 = DataReceived;
            _serialErrorReceivedEventHandler1 = ErrorReceived; 

            try 
            { 
                if ( ComPortExists ) 
                {                     
                    //  The system has at least one COM port.
                    //  If the previously selected port is still open, close it.
                    
                    if ( PreviousPort.IsOpen ) 
                    { 
                        CloseComPort( PreviousPort ); 
                    } 
                    
                    if ( ( !( ( SelectedPort.IsOpen ) ) | PortChanged ) ) 
                    {                         
                        SelectedPort.Open(); 
                        
                        if ( SelectedPort.IsOpen ) 
                        {                             
                            //  The port is open. Set additional parameters.
                            //  Timeouts are in milliseconds.
                            
                            SelectedPort.ReadTimeout = 5000; 
                            SelectedPort.WriteTimeout = 5000;
                            System.Text.Encoding iso_8859_1 = System.Text.Encoding.GetEncoding("iso-8859-1");
                            SelectedPort.Encoding = System.Text.Encoding.GetEncoding(28591);
                            //SelectedPort.Encoding = Encoding.GetEncoding("Windows-1252");
                            //  Specify the routines that run when a DataReceived or ErrorReceived event occurs.
                           
                            SelectedPort.DataReceived += _serialDataReceivedEventHandler1; 
                            SelectedPort.ErrorReceived += _serialErrorReceivedEventHandler1; 
                           
                            //  Send data to other modules.
                            
                            if ( null != UserInterfaceData ) UserInterfaceData( "DisplayCurrentSettings", new DataModel() ); 
                            if ( null != UserInterfaceData ) UserInterfaceData( "DisplayStatus",new DataModel()); 
                            
                            success = true; 
                            
                            //  The port is open with the current parameters.
                            
                            PortChanged = false;                             
                        } 
                    }                    
                }                 
            }
            
            catch ( InvalidOperationException ex ) 
            {                 
                ParameterChanged = true; 
                PortChanged = true; 
                DisplayException( ModuleName, ex );                 
            } 
            catch ( UnauthorizedAccessException ex ) 
            {                 
                ParameterChanged = true; 
                PortChanged = true; 
                DisplayException( ModuleName, ex );                 
            } 
            catch ( System.IO.IOException ex ) 
            {                 
                ParameterChanged = true; 
                PortChanged = true; 
                DisplayException( ModuleName, ex ); 
            } 
            
            return success;             
        } 

        /// <summary>
        ///  Executes when WriteToComPortDelegate1 completes.
        /// </summary>
        /// <param name="ar"> the value returned by the delegate's BeginInvoke method </param> 
                
        internal void WriteCompleted( IAsyncResult ar ) 
        {
            //  Extract the value returned by BeginInvoke (optional).
            
            var msg =Convert.ToString( ar.AsyncState ); 
            
            //  Get the value returned by the delegate.
            
            var deleg = ( ( WriteToComPortDelegate )( ( ( AsyncResult )( ar ) ).AsyncDelegate ) ); 
            
            var success = deleg.EndInvoke( ar ); 
            
            if ( success ) 
            { 
                if ( null != UserInterfaceData ) UserInterfaceData( "UpdateStatusLabel", new DataModel() ); 
            } 
            
            //  Add any actions that need to be performed after a write to the COM port completes.
            //  This example displays the value passed to the BeginInvoke method
            //  and the value returned by EndInvoke.
            
            Console.WriteLine( @"Write operation began: " + msg ); 
            Console.WriteLine( @"Write operation succeeded: " + success );             
        } 

        /// <summary>
        /// Write a string to the SerialPort object selectedPort.
        /// </summary>
        /// 
        /// <param name="textToWrite"> A string to write </param>
                
        internal bool WriteToComPort( string textToWrite ) 
        { 
            var success = false;
           
            try 
            { 
                //  Open the COM port if necessary.
                
                if ( ( !( ( SelectedPort == null ) ) ) ) 
                { 
                    if ( ( ( !( SelectedPort.IsOpen ) ) | PortChanged ) ) 
                    {                         
                        //  Close the port if needed and open the selected port.
                        
                        PortOpen = OpenComPort();                         
                    } 
                } 
                
                if ( SelectedPort != null && SelectedPort.IsOpen ) 
                { 
                    SelectedPort.Write( textToWrite ); 
                    success = true; 
                }                 
            }           
            catch ( TimeoutException ex ) 
            { 
                DisplayException( ModuleName, ex ); 
                
            } 
            catch ( InvalidOperationException ex ) 
            { 
                DisplayException( ModuleName, ex ); 
                ParameterChanged = true; 
                if ( null != UserInterfaceData ) UserInterfaceData( "DisplayCurrentSettings", new DataModel() );                 
            } 
            catch ( UnauthorizedAccessException ex ) 
            { 
                DisplayException( ModuleName, ex ); 
                CloseComPort( SelectedPort ); 
                ParameterChanged = true; 
                if ( null != UserInterfaceData ) UserInterfaceData( "DisplayCurrentSettings", new DataModel() );                 
            }             
            return success;             
        }

        internal bool WriteToComPort(byte[] textToWrite)
        {
            var success = false;

            try
            {
                //  Open the COM port if necessary.

                if ((!((SelectedPort == null))))
                {
                    if (((!(SelectedPort.IsOpen)) | PortChanged))
                    {
                        //  Close the port if needed and open the selected port.

                        PortOpen = OpenComPort();
                    }
                }

                if (SelectedPort != null && SelectedPort.IsOpen)
                {
                    SelectedPort.Write(textToWrite,0,textToWrite.Length);
                    
                    success = true;
                }
            }
            catch (TimeoutException ex)
            {
                DisplayException(ModuleName, ex);

            }
            catch (InvalidOperationException ex)
            {
                DisplayException(ModuleName, ex);
                ParameterChanged = true;
                if (null != UserInterfaceData) UserInterfaceData("DisplayCurrentSettings", new DataModel());
            }
            catch (UnauthorizedAccessException ex)
            {
                DisplayException(ModuleName, ex);
                CloseComPort(SelectedPort);
                ParameterChanged = true;
                if (null != UserInterfaceData) UserInterfaceData("DisplayCurrentSettings", new DataModel());
            }
            return success;
        }                
    }     
} 
