namespace TSW2_Controller
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lst_inputs = new System.Windows.Forms.ListBox();
            this.check_active = new System.Windows.Forms.CheckBox();
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
            this.pictureBox_Screenshot_original = new System.Windows.Forms.PictureBox();
            this.pictureBox_Screenshot_alternativ = new System.Windows.Forms.PictureBox();
            this.check_deactivateGlobal = new System.Windows.Forms.CheckBox();
            this.lbl_originalResult = new System.Windows.Forms.Label();
            this.lbl_alternativeResult = new System.Windows.Forms.Label();
            this.groupBox_ScanErgebnisse = new System.Windows.Forms.GroupBox();
            this.lbl_requests = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_updateAvailable = new System.Windows.Forms.Label();
            this.btn_checkJoysticks = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Screenshot_original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Screenshot_alternativ)).BeginInit();
            this.groupBox_ScanErgebnisse.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst_inputs
            // 
            resources.ApplyResources(this.lst_inputs, "lst_inputs");
            this.lst_inputs.FormattingEnabled = true;
            this.lst_inputs.Name = "lst_inputs";
            // 
            // check_active
            // 
            resources.ApplyResources(this.check_active, "check_active");
            this.check_active.BackColor = System.Drawing.Color.Red;
            this.check_active.Name = "check_active";
            this.check_active.UseVisualStyleBackColor = false;
            this.check_active.CheckedChanged += new System.EventHandler(this.check_active_CheckedChanged);
            // 
            // comboBox_Zugauswahl
            // 
            resources.ApplyResources(this.comboBox_Zugauswahl, "comboBox_Zugauswahl");
            this.comboBox_Zugauswahl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Zugauswahl.FormattingEnabled = true;
            this.comboBox_Zugauswahl.Name = "comboBox_Zugauswahl";
            this.comboBox_Zugauswahl.Sorted = true;
            this.comboBox_Zugauswahl.SelectedIndexChanged += new System.EventHandler(this.comboBox_Zugauswahl_SelectedIndexChanged);
            // 
            // timer_CheckSticks
            // 
            this.timer_CheckSticks.Interval = 10;
            this.timer_CheckSticks.Tick += new System.EventHandler(this.timer_CheckSticks_Tick);
            // 
            // comboBox_JoystickNumber
            // 
            resources.ApplyResources(this.comboBox_JoystickNumber, "comboBox_JoystickNumber");
            this.comboBox_JoystickNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_JoystickNumber.FormattingEnabled = true;
            this.comboBox_JoystickNumber.Name = "comboBox_JoystickNumber";
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
            resources.ApplyResources(this.lbl_schub, "lbl_schub");
            this.lbl_schub.Name = "lbl_schub";
            // 
            // bgw_Brake
            // 
            this.bgw_Brake.WorkerReportsProgress = true;
            this.bgw_Brake.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Brake_DoWork);
            // 
            // lbl_bremse
            // 
            resources.ApplyResources(this.lbl_bremse, "lbl_bremse");
            this.lbl_bremse.Name = "lbl_bremse";
            // 
            // listBox_debugInfo
            // 
            resources.ApplyResources(this.listBox_debugInfo, "listBox_debugInfo");
            this.listBox_debugInfo.FormattingEnabled = true;
            this.listBox_debugInfo.Name = "listBox_debugInfo";
            // 
            // lbl_resolution
            // 
            resources.ApplyResources(this.lbl_resolution, "lbl_resolution");
            this.lbl_resolution.Name = "lbl_resolution";
            // 
            // btn_einstellungen
            // 
            resources.ApplyResources(this.btn_einstellungen, "btn_einstellungen");
            this.btn_einstellungen.Name = "btn_einstellungen";
            this.btn_einstellungen.UseVisualStyleBackColor = true;
            this.btn_einstellungen.Click += new System.EventHandler(this.btn_einstellungen_Click);
            // 
            // pictureBox_Screenshot_original
            // 
            resources.ApplyResources(this.pictureBox_Screenshot_original, "pictureBox_Screenshot_original");
            this.pictureBox_Screenshot_original.Name = "pictureBox_Screenshot_original";
            this.pictureBox_Screenshot_original.TabStop = false;
            // 
            // pictureBox_Screenshot_alternativ
            // 
            resources.ApplyResources(this.pictureBox_Screenshot_alternativ, "pictureBox_Screenshot_alternativ");
            this.pictureBox_Screenshot_alternativ.Name = "pictureBox_Screenshot_alternativ";
            this.pictureBox_Screenshot_alternativ.TabStop = false;
            // 
            // check_deactivateGlobal
            // 
            resources.ApplyResources(this.check_deactivateGlobal, "check_deactivateGlobal");
            this.check_deactivateGlobal.Name = "check_deactivateGlobal";
            this.check_deactivateGlobal.UseVisualStyleBackColor = true;
            this.check_deactivateGlobal.CheckedChanged += new System.EventHandler(this.check_deactivateGlobal_CheckedChanged);
            // 
            // lbl_originalResult
            // 
            resources.ApplyResources(this.lbl_originalResult, "lbl_originalResult");
            this.lbl_originalResult.Name = "lbl_originalResult";
            // 
            // lbl_alternativeResult
            // 
            resources.ApplyResources(this.lbl_alternativeResult, "lbl_alternativeResult");
            this.lbl_alternativeResult.Name = "lbl_alternativeResult";
            // 
            // groupBox_ScanErgebnisse
            // 
            resources.ApplyResources(this.groupBox_ScanErgebnisse, "groupBox_ScanErgebnisse");
            this.groupBox_ScanErgebnisse.Controls.Add(this.lbl_alternativeResult);
            this.groupBox_ScanErgebnisse.Controls.Add(this.lbl_originalResult);
            this.groupBox_ScanErgebnisse.Name = "groupBox_ScanErgebnisse";
            this.groupBox_ScanErgebnisse.TabStop = false;
            // 
            // lbl_requests
            // 
            resources.ApplyResources(this.lbl_requests, "lbl_requests");
            this.lbl_requests.Name = "lbl_requests";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbl_updateAvailable
            // 
            resources.ApplyResources(this.lbl_updateAvailable, "lbl_updateAvailable");
            this.lbl_updateAvailable.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_updateAvailable.Name = "lbl_updateAvailable";
            this.lbl_updateAvailable.Click += new System.EventHandler(this.lbl_updateAvailable_Click);
            // 
            // btn_checkJoysticks
            // 
            resources.ApplyResources(this.btn_checkJoysticks, "btn_checkJoysticks");
            this.btn_checkJoysticks.Name = "btn_checkJoysticks";
            this.btn_checkJoysticks.UseVisualStyleBackColor = true;
            this.btn_checkJoysticks.Click += new System.EventHandler(this.btn_checkJoysticks_Click);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_checkJoysticks);
            this.Controls.Add(this.lbl_updateAvailable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_requests);
            this.Controls.Add(this.groupBox_ScanErgebnisse);
            this.Controls.Add(this.check_deactivateGlobal);
            this.Controls.Add(this.pictureBox_Screenshot_alternativ);
            this.Controls.Add(this.pictureBox_Screenshot_original);
            this.Controls.Add(this.btn_einstellungen);
            this.Controls.Add(this.lbl_resolution);
            this.Controls.Add(this.listBox_debugInfo);
            this.Controls.Add(this.lbl_bremse);
            this.Controls.Add(this.lbl_schub);
            this.Controls.Add(this.comboBox_JoystickNumber);
            this.Controls.Add(this.comboBox_Zugauswahl);
            this.Controls.Add(this.check_active);
            this.Controls.Add(this.lst_inputs);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Screenshot_original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Screenshot_alternativ)).EndInit();
            this.groupBox_ScanErgebnisse.ResumeLayout(false);
            this.groupBox_ScanErgebnisse.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lst_inputs;
        private System.Windows.Forms.CheckBox check_active;
        private System.Windows.Forms.ComboBox comboBox_Zugauswahl;
        private System.Windows.Forms.Timer timer_CheckSticks;
        private System.Windows.Forms.ComboBox comboBox_JoystickNumber;
        private System.ComponentModel.BackgroundWorker bgw_Throttle;
        private System.ComponentModel.BackgroundWorker bgw_readScreen;
        private System.Windows.Forms.Label lbl_schub;
        private System.ComponentModel.BackgroundWorker bgw_Brake;
        private System.Windows.Forms.Label lbl_bremse;
        private System.Windows.Forms.Label lbl_resolution;
        private System.Windows.Forms.Button btn_einstellungen;
        private System.Windows.Forms.PictureBox pictureBox_Screenshot_original;
        private System.Windows.Forms.PictureBox pictureBox_Screenshot_alternativ;
        private System.Windows.Forms.CheckBox check_deactivateGlobal;
        private System.Windows.Forms.Label lbl_originalResult;
        private System.Windows.Forms.Label lbl_alternativeResult;
        private System.Windows.Forms.GroupBox groupBox_ScanErgebnisse;
        private System.Windows.Forms.Label lbl_requests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_updateAvailable;
        private System.Windows.Forms.ListBox listBox_debugInfo;
        private System.Windows.Forms.Button btn_checkJoysticks;
    }
}

