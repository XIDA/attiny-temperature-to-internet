using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AttinyListener
{
    class AttinyConnection : IConnection
    {

        private SerialPort serialPort;        

        private string portName;
        public string PortName
        {
            get
            {
                return this.portName;
            }
            set
            {
                this.portName = value;

                Boolean isOpen = serialPort.IsOpen;
                if (isOpen)
                {
                    this.Close();
                }

                this.serialPort.PortName = value;

                if (isOpen)
                {
                    this.Open();
                }
            }
        }

        private int timeout;
        public int Timeout
        {
            get
            {
                return this.timeout;
            }
            set
            {
                this.timeout = value;

                Boolean isOpen = serialPort.IsOpen;
                if (isOpen)
                {
                    this.Close();
                }

                this.serialPort.ReadTimeout = value;
                this.serialPort.WriteTimeout = value;

                if (isOpen)
                {
                    this.Open();
                }
            }
        }

        public string[] AvailablePorts
        {
            get
            {                
                return SerialPort.GetPortNames();
            }
        }
        
        private ISubmiter submiter;        
        private List<double> temperatureList = new List<double>();

        public AttinyConnection(ISubmiter submiter, string portName, int timeout = 500)
        {
            this.portName = portName;
            this.timeout = timeout;
            this.submiter = submiter;

            
            if (!this.AvailablePorts.Contains(portName))
            {
                this.portName = this.AvailablePorts.First();
            }

            // Create a new SerialPort object with default settings.
            this.serialPort = new SerialPort();
            this.serialPort.PortName = this.portName;

            // Allow the user to set the appropriate properties.
            this.serialPort.BaudRate = 9600;
			this.serialPort.Parity = Parity.None;
			this.serialPort.StopBits = StopBits.One;
			this.serialPort.DataBits = 8;
			this.serialPort.Handshake = Handshake.None;

			// Set the read/write timeouts
			this.serialPort.ReadTimeout = timeout;
			this.serialPort.WriteTimeout = timeout;

            this.serialPort.DataReceived    += new SerialDataReceivedEventHandler(DataReceivedHandler);
            this.serialPort.ErrorReceived   += new SerialErrorReceivedEventHandler(ErrorReceivedHandler);
        }

        public bool Test()
        {
            bool result = this.Open();
            this.Close();
            return result;
        }

        public bool Open() {
            if (this.serialPort.IsOpen)
            {
                return true;
            }

            try
            {
                this.serialPort.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
                //Console.WriteLine("Serial connection error " + e.Message);
            }           
        }	

        public bool Close() {
            if(this.serialPort.IsOpen) 
            {
                this.serialPort.Close();
                return true;
            }
            return false;
        }

        private void reconnect()
        {
            this.Close();
            this.Open();
        }

        private void ErrorReceivedHandler(object sender, SerialErrorReceivedEventArgs e)
        {
            //Console.WriteLine("Error!");
            //Console.WriteLine(e.EventType);
            this.reconnect();
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            
            try
            {
                string indata = sp.ReadLine();                
                double temperature;
                
                if (Double.TryParse(indata.Replace(".", ","), out temperature))
                {                    
                    this.temperatureList.Add(temperature);
                    
                    MainClass.updateTrayIcon((int)Math.Round(temperature));
                    MainClass.updateTrayText("Temperature: " + temperature + "°");
                    
                    if (temperatureList.Count == submiter.SubmitInterval)
                    {
                        this.submiter.SubmitData(temperatureList.Average().ToString().Replace(",", "."));
                        this.temperatureList.Clear();
                    }                    
                }
            }
            catch (TimeoutException exception)
            {
                //Console.WriteLine("Timeout exception " + exception.Message);
                //MessageBox.Show("Timeout exception " + exception.Message);
                // reconnect on timeout
                this.reconnect();
            }
        }       
    }
}
