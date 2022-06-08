namespace TSW2_Controller
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.check_showDebug = new System.Windows.Forms.CheckBox();
            this.lbl_version = new System.Windows.Forms.Label();
            this.check_ShowScan = new System.Windows.Forms.CheckBox();
            this.btn_speichern = new System.Windows.Forms.Button();
            this.btn_steuerung = new System.Windows.Forms.Button();
            this.comboBox_resolution = new System.Windows.Forms.ComboBox();
            this.progressBar_updater = new System.Windows.Forms.ProgressBar();
            this.comboBox_TrainConfig = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_trainconfigHinzufuegen = new System.Windows.Forms.Button();
            this.btn_trainconfigLoeschen = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.wasIstNeuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucheNachUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucheNachUpdatesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.spracheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deutschToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englischToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationsdateiErstellenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zurConfigGehenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_DeleteLogsAfterXDays = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // check_showDebug
            // 
            resources.ApplyResources(this.check_showDebug, "check_showDebug");
            this.check_showDebug.Name = "check_showDebug";
            this.check_showDebug.UseVisualStyleBackColor = true;
            // 
            // lbl_version
            // 
            resources.ApplyResources(this.lbl_version, "lbl_version");
            this.lbl_version.Name = "lbl_version";
            // 
            // check_ShowScan
            // 
            resources.ApplyResources(this.check_ShowScan, "check_ShowScan");
            this.check_ShowScan.Name = "check_ShowScan";
            this.check_ShowScan.UseVisualStyleBackColor = true;
            // 
            // btn_speichern
            // 
            resources.ApplyResources(this.btn_speichern, "btn_speichern");
            this.btn_speichern.Name = "btn_speichern";
            this.btn_speichern.UseVisualStyleBackColor = true;
            this.btn_speichern.Click += new System.EventHandler(this.btn_speichern_Click);
            // 
            // btn_steuerung
            // 
            resources.ApplyResources(this.btn_steuerung, "btn_steuerung");
            this.btn_steuerung.Name = "btn_steuerung";
            this.btn_steuerung.UseVisualStyleBackColor = true;
            this.btn_steuerung.Click += new System.EventHandler(this.btn_steuerung_Click);
            // 
            // comboBox_resolution
            // 
            this.comboBox_resolution.FormattingEnabled = true;
            this.comboBox_resolution.Items.AddRange(new object[] {
            resources.GetString("comboBox_resolution.Items"),
            resources.GetString("comboBox_resolution.Items1"),
            resources.GetString("comboBox_resolution.Items2")});
            resources.ApplyResources(this.comboBox_resolution, "comboBox_resolution");
            this.comboBox_resolution.Name = "comboBox_resolution";
            // 
            // progressBar_updater
            // 
            resources.ApplyResources(this.progressBar_updater, "progressBar_updater");
            this.progressBar_updater.Name = "progressBar_updater";
            // 
            // comboBox_TrainConfig
            // 
            this.comboBox_TrainConfig.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_TrainConfig, "comboBox_TrainConfig");
            this.comboBox_TrainConfig.Name = "comboBox_TrainConfig";
            this.comboBox_TrainConfig.SelectedIndexChanged += new System.EventHandler(this.comboBox_TrainConfig_SelectedIndexChanged);
            this.comboBox_TrainConfig.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox_TrainConfig_KeyUp);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // btn_trainconfigHinzufuegen
            // 
            resources.ApplyResources(this.btn_trainconfigHinzufuegen, "btn_trainconfigHinzufuegen");
            this.btn_trainconfigHinzufuegen.Name = "btn_trainconfigHinzufuegen";
            this.btn_trainconfigHinzufuegen.UseVisualStyleBackColor = true;
            this.btn_trainconfigHinzufuegen.Click += new System.EventHandler(this.btn_trainconfigHinzufuegen_Click);
            // 
            // btn_trainconfigLoeschen
            // 
            resources.ApplyResources(this.btn_trainconfigLoeschen, "btn_trainconfigLoeschen");
            this.btn_trainconfigLoeschen.Name = "btn_trainconfigLoeschen";
            this.btn_trainconfigLoeschen.UseVisualStyleBackColor = true;
            this.btn_trainconfigLoeschen.Click += new System.EventHandler(this.btn_trainconfigLoeschen_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_TrainConfig);
            this.groupBox3.Controls.Add(this.btn_trainconfigHinzufuegen);
            this.groupBox3.Controls.Add(this.btn_trainconfigLoeschen);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wasIstNeuToolStripMenuItem,
            this.sucheNachUpdatesToolStripMenuItem,
            this.spracheToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // wasIstNeuToolStripMenuItem
            // 
            this.wasIstNeuToolStripMenuItem.Name = "wasIstNeuToolStripMenuItem";
            resources.ApplyResources(this.wasIstNeuToolStripMenuItem, "wasIstNeuToolStripMenuItem");
            this.wasIstNeuToolStripMenuItem.Click += new System.EventHandler(this.wasIstNeuToolStripMenuItem_Click);
            // 
            // sucheNachUpdatesToolStripMenuItem
            // 
            this.sucheNachUpdatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sucheNachUpdatesToolStripMenuItem1});
            this.sucheNachUpdatesToolStripMenuItem.Name = "sucheNachUpdatesToolStripMenuItem";
            resources.ApplyResources(this.sucheNachUpdatesToolStripMenuItem, "sucheNachUpdatesToolStripMenuItem");
            // 
            // sucheNachUpdatesToolStripMenuItem1
            // 
            this.sucheNachUpdatesToolStripMenuItem1.Name = "sucheNachUpdatesToolStripMenuItem1";
            resources.ApplyResources(this.sucheNachUpdatesToolStripMenuItem1, "sucheNachUpdatesToolStripMenuItem1");
            this.sucheNachUpdatesToolStripMenuItem1.Click += new System.EventHandler(this.sucheNachUpdatesToolStripMenuItem1_Click);
            // 
            // spracheToolStripMenuItem
            // 
            this.spracheToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deutschToolStripMenuItem,
            this.englischToolStripMenuItem});
            this.spracheToolStripMenuItem.Name = "spracheToolStripMenuItem";
            resources.ApplyResources(this.spracheToolStripMenuItem, "spracheToolStripMenuItem");
            // 
            // deutschToolStripMenuItem
            // 
            this.deutschToolStripMenuItem.Name = "deutschToolStripMenuItem";
            resources.ApplyResources(this.deutschToolStripMenuItem, "deutschToolStripMenuItem");
            this.deutschToolStripMenuItem.Click += new System.EventHandler(this.deutschToolStripMenuItem_Click);
            // 
            // englischToolStripMenuItem
            // 
            this.englischToolStripMenuItem.Name = "englischToolStripMenuItem";
            resources.ApplyResources(this.englischToolStripMenuItem, "englischToolStripMenuItem");
            this.englischToolStripMenuItem.Click += new System.EventHandler(this.englischToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationsdateiErstellenToolStripMenuItem,
            this.zurConfigGehenToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            resources.ApplyResources(this.hilfeToolStripMenuItem, "hilfeToolStripMenuItem");
            // 
            // informationsdateiErstellenToolStripMenuItem
            // 
            this.informationsdateiErstellenToolStripMenuItem.Name = "informationsdateiErstellenToolStripMenuItem";
            resources.ApplyResources(this.informationsdateiErstellenToolStripMenuItem, "informationsdateiErstellenToolStripMenuItem");
            this.informationsdateiErstellenToolStripMenuItem.Click += new System.EventHandler(this.informationsdateiErstellenToolStripMenuItem_Click);
            // 
            // zurConfigGehenToolStripMenuItem
            // 
            this.zurConfigGehenToolStripMenuItem.Name = "zurConfigGehenToolStripMenuItem";
            resources.ApplyResources(this.zurConfigGehenToolStripMenuItem, "zurConfigGehenToolStripMenuItem");
            this.zurConfigGehenToolStripMenuItem.Click += new System.EventHandler(this.zurConfigGehenToolStripMenuItem_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // comboBox_DeleteLogsAfterXDays
            // 
            this.comboBox_DeleteLogsAfterXDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DeleteLogsAfterXDays.FormattingEnabled = true;
            this.comboBox_DeleteLogsAfterXDays.Items.AddRange(new object[] {
            resources.GetString("comboBox_DeleteLogsAfterXDays.Items"),
            resources.GetString("comboBox_DeleteLogsAfterXDays.Items1"),
            resources.GetString("comboBox_DeleteLogsAfterXDays.Items2"),
            resources.GetString("comboBox_DeleteLogsAfterXDays.Items3"),
            resources.GetString("comboBox_DeleteLogsAfterXDays.Items4"),
            resources.GetString("comboBox_DeleteLogsAfterXDays.Items5"),
            resources.GetString("comboBox_DeleteLogsAfterXDays.Items6"),
            resources.GetString("comboBox_DeleteLogsAfterXDays.Items7"),
            resources.GetString("comboBox_DeleteLogsAfterXDays.Items8")});
            resources.ApplyResources(this.comboBox_DeleteLogsAfterXDays, "comboBox_DeleteLogsAfterXDays");
            this.comboBox_DeleteLogsAfterXDays.Name = "comboBox_DeleteLogsAfterXDays";
            // 
            // FormSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox_DeleteLogsAfterXDays);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.progressBar_updater);
            this.Controls.Add(this.comboBox_resolution);
            this.Controls.Add(this.btn_steuerung);
            this.Controls.Add(this.btn_speichern);
            this.Controls.Add(this.check_ShowScan);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.check_showDebug);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox check_showDebug;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.CheckBox check_ShowScan;
        private System.Windows.Forms.Button btn_speichern;
        private System.Windows.Forms.Button btn_steuerung;
        private System.Windows.Forms.ComboBox comboBox_resolution;
        private System.Windows.Forms.ProgressBar progressBar_updater;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_TrainConfig;
        private System.Windows.Forms.Button btn_trainconfigHinzufuegen;
        private System.Windows.Forms.Button btn_trainconfigLoeschen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wasIstNeuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationsdateiErstellenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sucheNachUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sucheNachUpdatesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem spracheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englischToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deutschToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zurConfigGehenToolStripMenuItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_DeleteLogsAfterXDays;
    }
}