namespace TSW2_Controller
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lst_inputs = new System.Windows.Forms.ListBox();
            this.check_active = new System.Windows.Forms.CheckBox();
            this.btn_reloadConfig = new System.Windows.Forms.Button();
            this.comboBox_Zugauswahl = new System.Windows.Forms.ComboBox();
            this.timer_CheckSticks = new System.Windows.Forms.Timer(this.components);
            this.comboBox_JoystickNumber = new System.Windows.Forms.ComboBox();
            this.bgw_Throttle = new System.ComponentModel.BackgroundWorker();
            this.bgw_readScreen = new System.ComponentModel.BackgroundWorker();
            this.lbl_schub = new System.Windows.Forms.Label();
            this.bgw_Brake = new System.ComponentModel.BackgroundWorker();
            this.lbl_bremse = new System.Windows.Forms.Label();
            this.listBox_debugInfo = new System.Windows.Forms.ListBox();
            this.lbl_resolution = new System.Windows.Forms.Label();
            this.btn_einstellungen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lst_inputs
            // 
            this.lst_inputs.FormattingEnabled = true;
            this.lst_inputs.Location = new System.Drawing.Point(15, 86);
            this.lst_inputs.Name = "lst_inputs";
            this.lst_inputs.Size = new System.Drawing.Size(120, 95);
            this.lst_inputs.TabIndex = 9;
            // 
            // check_active
            // 
            this.check_active.AutoSize = true;
            this.check_active.Location = new System.Drawing.Point(15, 15);
            this.check_active.Name = "check_active";
            this.check_active.Size = new System.Drawing.Size(50, 17);
            this.check_active.TabIndex = 10;
            this.check_active.Text = "Aktiv";
            this.check_active.UseVisualStyleBackColor = true;
            // 
            // btn_reloadConfig
            // 
            this.btn_reloadConfig.Location = new System.Drawing.Point(15, 57);
            this.btn_reloadConfig.Name = "btn_reloadConfig";
            this.btn_reloadConfig.Size = new System.Drawing.Size(120, 23);
            this.btn_reloadConfig.TabIndex = 12;
            this.btn_reloadConfig.Text = "Reload config";
            this.btn_reloadConfig.UseVisualStyleBackColor = true;
            this.btn_reloadConfig.Click += new System.EventHandler(this.btn_reloadConfig_Click);
            // 
            // comboBox_Zugauswahl
            // 
            this.comboBox_Zugauswahl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Zugauswahl.FormattingEnabled = true;
            this.comboBox_Zugauswahl.Location = new System.Drawing.Point(71, 13);
            this.comboBox_Zugauswahl.Name = "comboBox_Zugauswahl";
            this.comboBox_Zugauswahl.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Zugauswahl.TabIndex = 13;
            this.comboBox_Zugauswahl.SelectedIndexChanged += new System.EventHandler(this.comboBox_Zugauswahl_SelectedIndexChanged);
            // 
            // timer_CheckSticks
            // 
            this.timer_CheckSticks.Interval = 10;
            this.timer_CheckSticks.Tick += new System.EventHandler(this.timer_CheckSticks_Tick);
            // 
            // comboBox_JoystickNumber
            // 
            this.comboBox_JoystickNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_JoystickNumber.FormattingEnabled = true;
            this.comboBox_JoystickNumber.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox_JoystickNumber.Location = new System.Drawing.Point(85, 187);
            this.comboBox_JoystickNumber.Name = "comboBox_JoystickNumber";
            this.comboBox_JoystickNumber.Size = new System.Drawing.Size(50, 21);
            this.comboBox_JoystickNumber.TabIndex = 14;
            // 
            // bgw_Throttle
            // 
            this.bgw_Throttle.WorkerReportsProgress = true;
            this.bgw_Throttle.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Throttle_DoWork);
            // 
            // bgw_readScreen
            // 
            this.bgw_readScreen.WorkerReportsProgress = true;
            this.bgw_readScreen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_readScreen_DoWork);
            this.bgw_readScreen.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_readScreen_ProgressChanged);
            this.bgw_readScreen.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_readScreen_RunWorkerCompleted);
            // 
            // lbl_schub
            // 
            this.lbl_schub.AutoSize = true;
            this.lbl_schub.Location = new System.Drawing.Point(189, 428);
            this.lbl_schub.Name = "lbl_schub";
            this.lbl_schub.Size = new System.Drawing.Size(110, 13);
            this.lbl_schub.TabIndex = 16;
            this.lbl_schub.Text = "Schub ist X und soll X";
            // 
            // bgw_Brake
            // 
            this.bgw_Brake.WorkerReportsProgress = true;
            this.bgw_Brake.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Brake_DoWork);
            // 
            // lbl_bremse
            // 
            this.lbl_bremse.AutoSize = true;
            this.lbl_bremse.Location = new System.Drawing.Point(189, 441);
            this.lbl_bremse.Name = "lbl_bremse";
            this.lbl_bremse.Size = new System.Drawing.Size(114, 13);
            this.lbl_bremse.TabIndex = 17;
            this.lbl_bremse.Text = "Bremse ist X und soll X";
            // 
            // listBox_debugInfo
            // 
            this.listBox_debugInfo.FormattingEnabled = true;
            this.listBox_debugInfo.Location = new System.Drawing.Point(149, 57);
            this.listBox_debugInfo.Name = "listBox_debugInfo";
            this.listBox_debugInfo.Size = new System.Drawing.Size(195, 368);
            this.listBox_debugInfo.TabIndex = 18;
            // 
            // lbl_resolution
            // 
            this.lbl_resolution.AutoSize = true;
            this.lbl_resolution.Location = new System.Drawing.Point(272, 37);
            this.lbl_resolution.Name = "lbl_resolution";
            this.lbl_resolution.Size = new System.Drawing.Size(60, 13);
            this.lbl_resolution.TabIndex = 21;
            this.lbl_resolution.Text = "2560x1440";
            // 
            // btn_einstellungen
            // 
            this.btn_einstellungen.Location = new System.Drawing.Point(262, 13);
            this.btn_einstellungen.Name = "btn_einstellungen";
            this.btn_einstellungen.Size = new System.Drawing.Size(82, 21);
            this.btn_einstellungen.TabIndex = 22;
            this.btn_einstellungen.Text = "Einstellungen";
            this.btn_einstellungen.UseVisualStyleBackColor = true;
            this.btn_einstellungen.Click += new System.EventHandler(this.btn_einstellungen_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(365, 492);
            this.Controls.Add(this.btn_einstellungen);
            this.Controls.Add(this.lbl_resolution);
            this.Controls.Add(this.listBox_debugInfo);
            this.Controls.Add(this.lbl_bremse);
            this.Controls.Add(this.lbl_schub);
            this.Controls.Add(this.comboBox_JoystickNumber);
            this.Controls.Add(this.comboBox_Zugauswahl);
            this.Controls.Add(this.btn_reloadConfig);
            this.Controls.Add(this.check_active);
            this.Controls.Add(this.lst_inputs);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "TSW2_Controller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lst_inputs;
        private System.Windows.Forms.CheckBox check_active;
        private System.Windows.Forms.Button btn_reloadConfig;
        private System.Windows.Forms.ComboBox comboBox_Zugauswahl;
        private System.Windows.Forms.Timer timer_CheckSticks;
        private System.Windows.Forms.ComboBox comboBox_JoystickNumber;
        private System.ComponentModel.BackgroundWorker bgw_Throttle;
        private System.ComponentModel.BackgroundWorker bgw_readScreen;
        private System.Windows.Forms.Label lbl_schub;
        private System.ComponentModel.BackgroundWorker bgw_Brake;
        private System.Windows.Forms.Label lbl_bremse;
        private System.Windows.Forms.ListBox listBox_debugInfo;
        private System.Windows.Forms.Label lbl_resolution;
        private System.Windows.Forms.Button btn_einstellungen;
    }
}

