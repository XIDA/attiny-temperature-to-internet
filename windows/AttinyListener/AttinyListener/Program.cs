using System;
using System.IO.Ports;
using System.Threading;
using System.Net;

namespace TestCom
{
	class MainClass
	{
		static bool _continue;
		static SerialPort _serialPort;
		static int _transmitValue = 60;
		static int _counter = 0;
		static double _sum;

		public static void Main (string[] args)
		{
			string name;
			string message;
			StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
			Thread readThread = new Thread(Read);

			// Create a new SerialPort object with default settings.
			_serialPort = new SerialPort();

			// Allow the user to set the appropriate properties.
			_serialPort.PortName = "COM3";
			_serialPort.BaudRate = 9600;
			_serialPort.Parity = Parity.None;
			_serialPort.StopBits = StopBits.One;
			_serialPort.DataBits = 8;
			_serialPort.Handshake = Handshake.None;

			// Set the read/write timeouts
			_serialPort.ReadTimeout = 500;
			_serialPort.WriteTimeout = 500;

			_serialPort.Open();
			_continue = true;
			readThread.Start();

			name = Console.ReadLine();

			//C onsole.WriteLine("Type QUIT to exit");

			while (_continue)
			{
				message = Console.ReadLine();

				if (stringComparer.Equals("quit", message))
				{
					_continue = false;
				}
				else
				{
					//_serialPort.WriteLine(String.Format("<{0}>: {1}", name, message));
				}
			}

			readThread.Join();
			_serialPort.Close();
		}


		public static void Read()
		{
			while (_continue)
			{
				try
				{
					string message = _serialPort.ReadLine();
					//C onsole.WriteLine(message);

					double cVal;
					double.TryParse(message.Replace(".", ","), out cVal);
					Console.WriteLine(cVal);
					_sum += cVal;
					//C onsole.WriteLine("_sum " + _sum);

					if(_counter >= _transmitValue) {
						_counter = 0;
						double cAverage = _sum / (_transmitValue + 1);
						Math.Round(cAverage, 1);
						_sum = 0.0;

						Console.WriteLine("cAverage " + cAverage);
						string URI = "http://api.thingspeak.com/update?key=";

						string cSendVal = cAverage.ToString().Replace(",", ".");
						string myParameters = "field1=" + cAverage;

						using (WebClient wc = new WebClient())
						{
							wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
							string HtmlResult = wc.UploadString(URI, myParameters);
						}
					}
					_counter++;

				}
				catch (TimeoutException) { }
			}
		}
	}
}
