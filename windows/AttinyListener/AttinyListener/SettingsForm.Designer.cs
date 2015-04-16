namespace AttinyListener
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.InputSerialPort = new System.Windows.Forms.ComboBox();
            this.labelCOMPort = new System.Windows.Forms.Label();
            this.GroupSerialSettings = new System.Windows.Forms.GroupBox();
            this.ButtonSerialTest = new System.Windows.Forms.Button();
            this.InputSerialTimeout = new System.Windows.Forms.NumericUpDown();
            this.labelSerialTimeout = new System.Windows.Forms.Label();
            this.GroupThingspeakSettings = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InputThingspeakChannelId = new System.Windows.Forms.TextBox();
            this.ButtonThingspeakTest = new System.Windows.Forms.Button();
            this.labelThingspeakApiKey = new System.Windows.Forms.Label();
            this.InputThingspeakApiKey = new System.Windows.Forms.TextBox();
            this.labelThingspeakSubmitFieldName = new System.Windows.Forms.Label();
            this.InputThingspeakSubmitFieldName = new System.Windows.Forms.TextBox();
            this.InputThingspeakSubmitInterval = new System.Windows.Forms.NumericUpDown();
            this.labelThingspeakSubmitInterval = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.CheckBoxStartup = new System.Windows.Forms.CheckBox();
            this.GroupGeneralSettings = new System.Windows.Forms.GroupBox();
            this.GroupSerialSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputSerialTimeout)).BeginInit();
            this.GroupThingspeakSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputThingspeakSubmitInterval)).BeginInit();
            this.GroupGeneralSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputSerialPort
            // 
            resources.ApplyResources(this.InputSerialPort, "InputSerialPort");
            this.InputSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InputSerialPort.FormattingEnabled = true;
            this.InputSerialPort.Name = "InputSerialPort";
            this.InputSerialPort.SelectedIndexChanged += new System.EventHandler(this.InputSerialPort_SelectedIndexChanged);
            // 
            // labelCOMPort
            // 
            resources.ApplyResources(this.labelCOMPort, "labelCOMPort");
            this.labelCOMPort.Name = "labelCOMPort";
            // 
            // GroupSerialSettings
            // 
            this.GroupSerialSettings.Controls.Add(this.ButtonSerialTest);
            this.GroupSerialSettings.Controls.Add(this.InputSerialTimeout);
            this.GroupSerialSettings.Controls.Add(this.labelSerialTimeout);
            this.GroupSerialSettings.Controls.Add(this.labelCOMPort);
            this.GroupSerialSettings.Controls.Add(this.InputSerialPort);
            resources.ApplyResources(this.GroupSerialSettings, "GroupSerialSettings");
            this.GroupSerialSettings.Name = "GroupSerialSettings";
            this.GroupSerialSettings.TabStop = false;
            // 
            // ButtonSerialTest
            // 
            resources.ApplyResources(this.ButtonSerialTest, "ButtonSerialTest");
            this.ButtonSerialTest.Name = "ButtonSerialTest";
            this.ButtonSerialTest.UseVisualStyleBackColor = true;
            this.ButtonSerialTest.Click += new System.EventHandler(this.ButtonSerialTest_Click);
            // 
            // InputSerialTimeout
            // 
            resources.ApplyResources(this.InputSerialTimeout, "InputSerialTimeout");
            this.InputSerialTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.InputSerialTimeout.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.InputSerialTimeout.Name = "InputSerialTimeout";
            this.InputSerialTimeout.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.InputSerialTimeout.ValueChanged += new System.EventHandler(this.InputSerialTimeout_ValueChanged);
            // 
            // labelSerialTimeout
            // 
            resources.ApplyResources(this.labelSerialTimeout, "labelSerialTimeout");
            this.labelSerialTimeout.Name = "labelSerialTimeout";
            // 
            // GroupThingspeakSettings
            // 
            this.GroupThingspeakSettings.Controls.Add(this.label1);
            this.GroupThingspeakSettings.Controls.Add(this.InputThingspeakChannelId);
            this.GroupThingspeakSettings.Controls.Add(this.ButtonThingspeakTest);
            this.GroupThingspeakSettings.Controls.Add(this.labelThingspeakApiKey);
            this.GroupThingspeakSettings.Controls.Add(this.InputThingspeakApiKey);
            this.GroupThingspeakSettings.Controls.Add(this.labelThingspeakSubmitFieldName);
            this.GroupThingspeakSettings.Controls.Add(this.InputThingspeakSubmitFieldName);
            this.GroupThingspeakSettings.Controls.Add(this.InputThingspeakSubmitInterval);
            this.GroupThingspeakSettings.Controls.Add(this.labelThingspeakSubmitInterval);
            resources.ApplyResources(this.GroupThingspeakSettings, "GroupThingspeakSettings");
            this.GroupThingspeakSettings.Name = "GroupThingspeakSettings";
            this.GroupThingspeakSettings.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // InputThingspeakChannelId
            // 
            resources.ApplyResources(this.InputThingspeakChannelId, "InputThingspeakChannelId");
            this.InputThingspeakChannelId.Name = "InputThingspeakChannelId";
            this.InputThingspeakChannelId.TextChanged += new System.EventHandler(this.InputThingspeakChannelId_TextChanged);
            // 
            // ButtonThingspeakTest
            // 
            resources.ApplyResources(this.ButtonThingspeakTest, "ButtonThingspeakTest");
            this.ButtonThingspeakTest.Name = "ButtonThingspeakTest";
            this.ButtonThingspeakTest.UseVisualStyleBackColor = true;
            this.ButtonThingspeakTest.Click += new System.EventHandler(this.ButtonThingspeakTest_Click);
            // 
            // labelThingspeakApiKey
            // 
            resources.ApplyResources(this.labelThingspeakApiKey, "labelThingspeakApiKey");
            this.labelThingspeakApiKey.Name = "labelThingspeakApiKey";
            // 
            // InputThingspeakApiKey
            // 
            resources.ApplyResources(this.InputThingspeakApiKey, "InputThingspeakApiKey");
            this.InputThingspeakApiKey.Name = "InputThingspeakApiKey";
            this.InputThingspeakApiKey.TextChanged += new System.EventHandler(this.InputThingspeakApiKey_TextChanged);
            // 
            // labelThingspeakSubmitFieldName
            // 
            resources.ApplyResources(this.labelThingspeakSubmitFieldName, "labelThingspeakSubmitFieldName");
            this.labelThingspeakSubmitFieldName.Name = "labelThingspeakSubmitFieldName";
            // 
            // InputThingspeakSubmitFieldName
            // 
            resources.ApplyResources(this.InputThingspeakSubmitFieldName, "InputThingspeakSubmitFieldName");
            this.InputThingspeakSubmitFieldName.Name = "InputThingspeakSubmitFieldName";
            this.InputThingspeakSubmitFieldName.TextChanged += new System.EventHandler(this.InputThingspeakSubmitFieldName_TextChanged);
            // 
            // InputThingspeakSubmitInterval
            // 
            resources.ApplyResources(this.InputThingspeakSubmitInterval, "InputThingspeakSubmitInterval");
            this.InputThingspeakSubmitInterval.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.InputThingspeakSubmitInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.InputThingspeakSubmitInterval.Name = "InputThingspeakSubmitInterval";
            this.InputThingspeakSubmitInterval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.InputThingspeakSubmitInterval.ValueChanged += new System.EventHandler(this.InputThingspeakSubmitInterval_ValueChanged);
            // 
            // labelThingspeakSubmitInterval
            // 
            resources.ApplyResources(this.labelThingspeakSubmitInterval, "labelThingspeakSubmitInterval");
            this.labelThingspeakSubmitInterval.Name = "labelThingspeakSubmitInterval";
            // 
            // ButtonSave
            // 
            resources.ApplyResources(this.ButtonSave, "ButtonSave");
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // CheckBoxStartup
            // 
            resources.ApplyResources(this.CheckBoxStartup, "CheckBoxStartup");
            this.CheckBoxStartup.Name = "CheckBoxStartup";
            this.CheckBoxStartup.UseVisualStyleBackColor = true;
            this.CheckBoxStartup.CheckedChanged += new System.EventHandler(this.CheckBoxStartup_CheckedChanged);
            // 
            // GroupGeneralSettings
            // 
            this.GroupGeneralSettings.Controls.Add(this.CheckBoxStartup);
            resources.ApplyResources(this.GroupGeneralSettings, "GroupGeneralSettings");
            this.GroupGeneralSettings.Name = "GroupGeneralSettings";
            this.GroupGeneralSettings.TabStop = false;
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupGeneralSettings);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.GroupThingspeakSettings);
            this.Controls.Add(this.GroupSerialSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.GroupSerialSettings.ResumeLayout(false);
            this.GroupSerialSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputSerialTimeout)).EndInit();
            this.GroupThingspeakSettings.ResumeLayout(false);
            this.GroupThingspeakSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputThingspeakSubmitInterval)).EndInit();
            this.GroupGeneralSettings.ResumeLayout(false);
            this.GroupGeneralSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox InputSerialPort;
        private System.Windows.Forms.Label labelCOMPort;
        private System.Windows.Forms.GroupBox GroupSerialSettings;
        private System.Windows.Forms.Label labelSerialTimeout;
        private System.Windows.Forms.NumericUpDown InputSerialTimeout;
        private System.Windows.Forms.GroupBox GroupThingspeakSettings;
        private System.Windows.Forms.Label labelThingspeakSubmitInterval;
        private System.Windows.Forms.Label labelThingspeakSubmitFieldName;
        private System.Windows.Forms.TextBox InputThingspeakSubmitFieldName;
        private System.Windows.Forms.NumericUpDown InputThingspeakSubmitInterval;
        private System.Windows.Forms.Label labelThingspeakApiKey;
        private System.Windows.Forms.TextBox InputThingspeakApiKey;
        private System.Windows.Forms.Button ButtonSerialTest;
        private System.Windows.Forms.Button ButtonThingspeakTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputThingspeakChannelId;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.CheckBox CheckBoxStartup;
        private System.Windows.Forms.GroupBox GroupGeneralSettings;
    }
}