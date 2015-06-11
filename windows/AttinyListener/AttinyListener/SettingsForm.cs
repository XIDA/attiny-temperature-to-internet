using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AttinyListener
{
    public partial class SettingsForm : Form
    {
        // The path to the key where Windows looks for startup applications
        private RegistryKey regKeyStartup = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public SettingsForm()
        {
            InitializeComponent();
            
            InputSerialPort.Items.AddRange(MainClass.AvailablePorts());            
            if (!String.IsNullOrEmpty(Properties.Settings.Default.SerialPort))
            {
                foreach (string item in InputSerialPort.Items)
                {
                    if (Properties.Settings.Default.SerialPort == item)
                    {
                        InputSerialPort.SelectedItem = item;
                        break;
                    }
                }
            }
            // if the port was not found, select the first one as default
            if (InputSerialPort.SelectedItem == null) {
                InputSerialPort.SelectedItem = InputSerialPort.Items[0];
            }

            if (regKeyStartup.GetValue(Application.ProductName) == null)
            {
                // The value doesn't exist, the application is not set to run at startup
                CheckBoxStartup.Checked = false;
            }
            else
            {
                // The value exists, the application is set to run at startup
                CheckBoxStartup.Checked = true;
            }

            InputSerialTimeout.Value = Properties.Settings.Default.SerialTimeout;
            InputThingspeakApiKey.Text = Properties.Settings.Default.ThingspeakApiKey;
            InputThingspeakSubmitFieldName.Text = Properties.Settings.Default.ThingspeakSubmitFieldName;
            InputThingspeakChannelId.Text = Properties.Settings.Default.ThingspeakChannelId;

            this.UpdateForm();
        }

        private void ButtonSerialTest_Click(object sender, EventArgs e)
        {
            GroupSerialSettings.Enabled = false;
            if (MainClass.TestConnection())
            {
                MessageBox.Show("Success!");
            }
            else
            {
                MessageBox.Show("Could not connect to " + MainClass.Connection.PortName);
            }
            GroupSerialSettings.Enabled = true;
        }

        private void ButtonThingspeakTest_Click(object sender, EventArgs e)
        {
            GroupThingspeakSettings.Enabled = false;            
            if (MainClass.TestSubmiter())
            {
                MessageBox.Show("Success!");
            }
            else
            {
                MessageBox.Show("Could not connect to thingspeak api");
            }
            GroupThingspeakSettings.Enabled = true;
        }

        private void InputSerialPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string serialPortName = InputSerialPort.SelectedItem.ToString();
            if (!String.IsNullOrEmpty(serialPortName))
            {                
                MainClass.Connection.PortName = serialPortName;
                Properties.Settings.Default.SerialPort = serialPortName;
                this.UpdateForm();
            }
        }

        private void InputSerialTimeout_ValueChanged(object sender, EventArgs e)
        {
            MainClass.Connection.Timeout = (int)InputSerialTimeout.Value;
            Properties.Settings.Default.SerialTimeout = (int)InputSerialTimeout.Value;
            this.UpdateForm();
        }

        private void InputThingspeakSubmitInterval_ValueChanged(object sender, EventArgs e)
        {
            MainClass.Submiter.SubmitInterval = (int)InputThingspeakSubmitInterval.Value;
            Properties.Settings.Default.ThingspeakSubmitInterval = (int)InputThingspeakSubmitInterval.Value;
            this.UpdateForm();
        }

        private void InputThingspeakSubmitFieldName_TextChanged(object sender, EventArgs e)
        {
            string text = InputThingspeakSubmitFieldName.Text;
            if (!String.IsNullOrEmpty(text))
            {
                MainClass.Submiter.FieldName = text;
                Properties.Settings.Default.ThingspeakSubmitFieldName = text;
                this.UpdateForm();
            }
        }

        private void InputThingspeakApiKey_TextChanged(object sender, EventArgs e)
        {
            string text = InputThingspeakApiKey.Text;
            if (!String.IsNullOrEmpty(text))
            {
                MainClass.Submiter.ApiKey = text;
                Properties.Settings.Default.ThingspeakApiKey = text;
                this.UpdateForm();
            }
        }

        private void InputThingspeakChannelId_TextChanged(object sender, EventArgs e)
        {
            string text = InputThingspeakChannelId.Text;
            if (!String.IsNullOrEmpty(text))
            {
                MainClass.Submiter.ChannelId = text;
                Properties.Settings.Default.ThingspeakChannelId = text;
                this.UpdateForm();
            }
        }

        private void UpdateForm()
        {
            // validate serial section
            if (InputSerialPort.SelectedItem == null)
            {
                ButtonSerialTest.Enabled = false;
            }
            else
            {
                ButtonSerialTest.Enabled = true;
            }

            // validate thing speak section
            if (String.IsNullOrWhiteSpace(InputThingspeakChannelId.Text) 
                || String.IsNullOrWhiteSpace(InputThingspeakApiKey.Text) 
                || String.IsNullOrWhiteSpace(InputThingspeakSubmitFieldName.Text))
            {
                ButtonThingspeakTest.Enabled = false;                
            }
            else
            {
                ButtonThingspeakTest.Enabled = true;
            }

            // enable the save button if thingspeak section && serial port section are valid
            if (ButtonThingspeakTest.Enabled && ButtonSerialTest.Enabled)
            {
                ButtonSave.Enabled = true;
            }
            else
            {
                ButtonSave.Enabled = false;
            }
        }

        private void SaveForm()
        {
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.SaveForm();
            //Application.Exit();

            if (MainClass.ValidateSettings())
            {
                MainClass.Connection.Open();
            }
            else
            {
                MessageBox.Show("Settings Invalid.");
                Application.Exit();
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            this.SaveForm();
            this.Close();

            if (MainClass.ValidateSettings())
            {                
                MainClass.Connection.Open();
            }
        }

        private void CheckBoxStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxStartup.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                this.regKeyStartup.SetValue(Application.ProductName, Application.ExecutablePath.ToString());
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                this.regKeyStartup.DeleteValue(Application.ProductName, false);
            }
        }        
    }
}
