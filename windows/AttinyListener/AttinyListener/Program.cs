using System;
using System.Linq;
using System.IO.Ports;
using System.Threading;
using System.Net;
using System.Collections.Generic;
using System.Management;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;

namespace AttinyListener
{
	class MainClass
	{
        private static ISubmiter submiter;
        public static ISubmiter Submiter 
        {
            get
            {
                if (submiter == null)
                {
                    submiter = new ThingspeakSubmiter(
                        Properties.Settings.Default.ThingspeakApiKey,
                        Properties.Settings.Default.ThingspeakChannelId,
                        Properties.Settings.Default.ThingspeakSubmitFieldName,
                        Properties.Settings.Default.ThingspeakSubmitInterval
                    );
                }
                return submiter;
            }
        }

        private static IConnection connection;
        public static IConnection Connection 
        {
            get
            {
                if (connection == null)
                {
                    connection = new AttinyConnection(
                        Submiter,
                        Properties.Settings.Default.SerialPort,
                        Properties.Settings.Default.SerialTimeout
                    );
                }
                
                return connection;
            }        
        }

        private static SettingsForm settingsFormInstance;
        private static SettingsForm settingsForm
        {
            get
            {
                if (settingsFormInstance != null && settingsFormInstance.Visible)
                {
                    return settingsFormInstance;
                }
                return (settingsFormInstance = new SettingsForm());
            }
        }

        private static NotifyIcon trayInstance;
        private static NotifyIcon tray
        {
            get
            {
                if (trayInstance != null)
                {
                    return trayInstance;
                }
                return (trayInstance = new NotifyIcon());
            }
        }

        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);           

            using (tray)
            {
                //icon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                tray.Icon = Properties.Resources.Icon;               

                updateTrayIcon(0);
                updateTrayText("Start");

                tray.ContextMenu = new ContextMenu(
                    new MenuItem[] {
                        new MenuItem("Settings", (s, e) => {
                            Connection.Close();
                            updateTrayText("Settings");
                            MainClass.settingsForm.Show(); 
                        }),
                        new MenuItem("-"),
                        new MenuItem("Restart", (s, e) => {
                            Connection.Close();
                            Application.Restart();
                        }),
                        new MenuItem("Exit", (s, e) => {
                            Connection.Close();
                            Application.Exit(); 
                        })                       
                    }
                );
                tray.Visible = true;               

                if (!ValidateSettings())
                {
                    MainClass.settingsForm.Show(); 
                }
                else
                {
                    Connection.Open();
                }

                Application.Run();
                tray.Visible = false;
            }
        }

        public static void updateTrayText(string text)
        {
            tray.Text = Application.ProductName + " - " + text;
        }      

        public static void updateTrayIcon(int temperature = 0) 
        {
            Color color = Color.Black;

            // determine a color for the temperature value
            if (temperature < 15)
            {
                color = Color.DeepSkyBlue;
            }
            else if (temperature >= 15 && temperature < 20)
            {
                color = Color.Green;
            }
            else if (temperature >= 20 && temperature < 25)
            {
                color = Color.Yellow;
            }
            else if (temperature >= 25 && temperature < 30)
            {
                color = Color.Orange;
            }
            else if (temperature >= 30)
            {
                color = Color.Red;
            }

            // draw the number into a bitmap            
            Bitmap bitmap = new Bitmap(32, 32);
            Graphics graphics   = Graphics.FromImage(bitmap);

            graphics.DrawString(temperature.ToString(), new Font("Arial", 18), new SolidBrush(color), 0, 4);

            // generate ico from bitmap
            IntPtr hIcon    = bitmap.GetHicon();
            Icon ico        = Icon.FromHandle(hIcon);

            // set the new icon
            tray.Icon       = ico;
        }

        public static bool TestSubmiter()
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.ThingspeakApiKey))
            {
                MessageBox.Show("Please enter a thingspeak ApiKey");
                return false;
            }

            if (String.IsNullOrEmpty(Properties.Settings.Default.ThingspeakChannelId))
            {
                MessageBox.Show("Please enter a thingspeak Channel ID");
                return false;
            }

            return Submiter.TestConnection(); 
        }

        public static bool TestConnection()
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.SerialPort))
            {
                MessageBox.Show("Please select a serial port");
                return false;
            }
            return Connection.Test(); 
        }

        public static string[] AvailablePorts()
        {
            return Connection.AvailablePorts;
        }

        private static void openConnection()
        {                   
            Connection.Open();
        }

        public static bool ValidateSettings()
        {
            if(String.IsNullOrEmpty(Properties.Settings.Default.SerialPort)
                || String.IsNullOrEmpty(Properties.Settings.Default.ThingspeakApiKey)
                || String.IsNullOrEmpty(Properties.Settings.Default.ThingspeakChannelId))
            {                
                settingsForm.Show();
                return false;                
            }          

            return true;
        }
	}
}
