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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_textindikator_StandardLaden = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_schubLeistung = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Bremse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Schub = new System.Windows.Forms.ComboBox();
            this.tab_kombihebel = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_kombiBremse = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_kombiSchub = new System.Windows.Forms.ComboBox();
            this.btn_speichern = new System.Windows.Forms.Button();
            this.btn_steuerung = new System.Windows.Forms.Button();
            this.comboBox_resolution = new System.Windows.Forms.ComboBox();
            this.progressBar_updater = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_decreaseBrake = new System.Windows.Forms.TextBox();
            this.txt_increaseBrake = new System.Windows.Forms.TextBox();
            this.txt_decreaseThrottle = new System.Windows.Forms.TextBox();
            this.txt_increaseThrottle = new System.Windows.Forms.TextBox();
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
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_schubLeistung.SuspendLayout();
            this.tab_kombihebel.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.btn_textindikator_StandardLaden);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btn_textindikator_StandardLaden
            // 
            resources.ApplyResources(this.btn_textindikator_StandardLaden, "btn_textindikator_StandardLaden");
            this.btn_textindikator_StandardLaden.Name = "btn_textindikator_StandardLaden";
            this.btn_textindikator_StandardLaden.UseVisualStyleBackColor = true;
            this.btn_textindikator_StandardLaden.Click += new System.EventHandler(this.btn_textindikator_StandardLaden_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tab_schubLeistung);
            this.tabControl1.Controls.Add(this.tab_kombihebel);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tab_schubLeistung
            // 
            resources.ApplyResources(this.tab_schubLeistung, "tab_schubLeistung");
            this.tab_schubLeistung.Controls.Add(this.label3);
            this.tab_schubLeistung.Controls.Add(this.comboBox_Bremse);
            this.tab_schubLeistung.Controls.Add(this.label2);
            this.tab_schubLeistung.Controls.Add(this.comboBox_Schub);
            this.tab_schubLeistung.Name = "tab_schubLeistung";
            this.tab_schubLeistung.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // comboBox_Bremse
            // 
            resources.ApplyResources(this.comboBox_Bremse, "comboBox_Bremse");
            this.comboBox_Bremse.FormattingEnabled = true;
            this.comboBox_Bremse.Name = "comboBox_Bremse";
            this.comboBox_Bremse.Sorted = true;
            this.comboBox_Bremse.SelectedIndexChanged += new System.EventHandler(this.comboBox_Bremse_SelectedIndexChanged);
            this.comboBox_Bremse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Bremse_KeyPress);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // comboBox_Schub
            // 
            resources.ApplyResources(this.comboBox_Schub, "comboBox_Schub");
            this.comboBox_Schub.FormattingEnabled = true;
            this.comboBox_Schub.Name = "comboBox_Schub";
            this.comboBox_Schub.Sorted = true;
            this.comboBox_Schub.SelectedIndexChanged += new System.EventHandler(this.comboBox_Schub_SelectedIndexChanged);
            this.comboBox_Schub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Schub_KeyPress);
            // 
            // tab_kombihebel
            // 
            resources.ApplyResources(this.tab_kombihebel, "tab_kombihebel");
            this.tab_kombihebel.Controls.Add(this.label4);
            this.tab_kombihebel.Controls.Add(this.comboBox_kombiBremse);
            this.tab_kombihebel.Controls.Add(this.label5);
            this.tab_kombihebel.Controls.Add(this.comboBox_kombiSchub);
            this.tab_kombihebel.Name = "tab_kombihebel";
            this.tab_kombihebel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // comboBox_kombiBremse
            // 
            resources.ApplyResources(this.comboBox_kombiBremse, "comboBox_kombiBremse");
            this.comboBox_kombiBremse.FormattingEnabled = true;
            this.comboBox_kombiBremse.Name = "comboBox_kombiBremse";
            this.comboBox_kombiBremse.Sorted = true;
            this.comboBox_kombiBremse.SelectedIndexChanged += new System.EventHandler(this.comboBox_kombiBremse_SelectedIndexChanged);
            this.comboBox_kombiBremse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_kombiBremse_KeyPress);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // comboBox_kombiSchub
            // 
            resources.ApplyResources(this.comboBox_kombiSchub, "comboBox_kombiSchub");
            this.comboBox_kombiSchub.FormattingEnabled = true;
            this.comboBox_kombiSchub.Name = "comboBox_kombiSchub";
            this.comboBox_kombiSchub.Sorted = true;
            this.comboBox_kombiSchub.SelectedIndexChanged += new System.EventHandler(this.comboBox_kombiSchub_SelectedIndexChanged);
            this.comboBox_kombiSchub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_kombiSchub_KeyPress);
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
            resources.ApplyResources(this.comboBox_resolution, "comboBox_resolution");
            this.comboBox_resolution.FormattingEnabled = true;
            this.comboBox_resolution.Items.AddRange(new object[] {
            resources.GetString("comboBox_resolution.Items"),
            resources.GetString("comboBox_resolution.Items1"),
            resources.GetString("comboBox_resolution.Items2")});
            this.comboBox_resolution.Name = "comboBox_resolution";
            // 
            // progressBar_updater
            // 
            resources.ApplyResources(this.progressBar_updater, "progressBar_updater");
            this.progressBar_updater.Name = "progressBar_updater";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_decreaseBrake);
            this.groupBox2.Controls.Add(this.txt_increaseBrake);
            this.groupBox2.Controls.Add(this.txt_decreaseThrottle);
            this.groupBox2.Controls.Add(this.txt_increaseThrottle);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txt_decreaseBrake
            // 
            resources.ApplyResources(this.txt_decreaseBrake, "txt_decreaseBrake");
            this.txt_decreaseBrake.Name = "txt_decreaseBrake";
            this.txt_decreaseBrake.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SuppressKeyPress_KeyDown);
            this.txt_decreaseBrake.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txt_ConvertKeyToString_PreviewKeyDown);
            // 
            // txt_increaseBrake
            // 
            resources.ApplyResources(this.txt_increaseBrake, "txt_increaseBrake");
            this.txt_increaseBrake.Name = "txt_increaseBrake";
            this.txt_increaseBrake.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SuppressKeyPress_KeyDown);
            this.txt_increaseBrake.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txt_ConvertKeyToString_PreviewKeyDown);
            // 
            // txt_decreaseThrottle
            // 
            resources.ApplyResources(this.txt_decreaseThrottle, "txt_decreaseThrottle");
            this.txt_decreaseThrottle.Name = "txt_decreaseThrottle";
            this.txt_decreaseThrottle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SuppressKeyPress_KeyDown);
            this.txt_decreaseThrottle.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txt_ConvertKeyToString_PreviewKeyDown);
            // 
            // txt_increaseThrottle
            // 
            resources.ApplyResources(this.txt_increaseThrottle, "txt_increaseThrottle");
            this.txt_increaseThrottle.Name = "txt_increaseThrottle";
            this.txt_increaseThrottle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SuppressKeyPress_KeyDown);
            this.txt_increaseThrottle.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txt_ConvertKeyToString_PreviewKeyDown);
            // 
            // comboBox_TrainConfig
            // 
            resources.ApplyResources(this.comboBox_TrainConfig, "comboBox_TrainConfig");
            this.comboBox_TrainConfig.FormattingEnabled = true;
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
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.comboBox_TrainConfig);
            this.groupBox3.Controls.Add(this.btn_trainconfigHinzufuegen);
            this.groupBox3.Controls.Add(this.btn_trainconfigLoeschen);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wasIstNeuToolStripMenuItem,
            this.sucheNachUpdatesToolStripMenuItem,
            this.spracheToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // wasIstNeuToolStripMenuItem
            // 
            resources.ApplyResources(this.wasIstNeuToolStripMenuItem, "wasIstNeuToolStripMenuItem");
            this.wasIstNeuToolStripMenuItem.Name = "wasIstNeuToolStripMenuItem";
            this.wasIstNeuToolStripMenuItem.Click += new System.EventHandler(this.wasIstNeuToolStripMenuItem_Click);
            // 
            // sucheNachUpdatesToolStripMenuItem
            // 
            resources.ApplyResources(this.sucheNachUpdatesToolStripMenuItem, "sucheNachUpdatesToolStripMenuItem");
            this.sucheNachUpdatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sucheNachUpdatesToolStripMenuItem1});
            this.sucheNachUpdatesToolStripMenuItem.Name = "sucheNachUpdatesToolStripMenuItem";
            // 
            // sucheNachUpdatesToolStripMenuItem1
            // 
            resources.ApplyResources(this.sucheNachUpdatesToolStripMenuItem1, "sucheNachUpdatesToolStripMenuItem1");
            this.sucheNachUpdatesToolStripMenuItem1.Name = "sucheNachUpdatesToolStripMenuItem1";
            this.sucheNachUpdatesToolStripMenuItem1.Click += new System.EventHandler(this.sucheNachUpdatesToolStripMenuItem1_Click);
            // 
            // spracheToolStripMenuItem
            // 
            resources.ApplyResources(this.spracheToolStripMenuItem, "spracheToolStripMenuItem");
            this.spracheToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deutschToolStripMenuItem,
            this.englischToolStripMenuItem});
            this.spracheToolStripMenuItem.Name = "spracheToolStripMenuItem";
            // 
            // deutschToolStripMenuItem
            // 
            resources.ApplyResources(this.deutschToolStripMenuItem, "deutschToolStripMenuItem");
            this.deutschToolStripMenuItem.Name = "deutschToolStripMenuItem";
            this.deutschToolStripMenuItem.Click += new System.EventHandler(this.deutschToolStripMenuItem_Click);
            // 
            // englischToolStripMenuItem
            // 
            resources.ApplyResources(this.englischToolStripMenuItem, "englischToolStripMenuItem");
            this.englischToolStripMenuItem.Name = "englischToolStripMenuItem";
            this.englischToolStripMenuItem.Click += new System.EventHandler(this.englischToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            resources.ApplyResources(this.hilfeToolStripMenuItem, "hilfeToolStripMenuItem");
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationsdateiErstellenToolStripMenuItem,
            this.zurConfigGehenToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            // 
            // informationsdateiErstellenToolStripMenuItem
            // 
            resources.ApplyResources(this.informationsdateiErstellenToolStripMenuItem, "informationsdateiErstellenToolStripMenuItem");
            this.informationsdateiErstellenToolStripMenuItem.Name = "informationsdateiErstellenToolStripMenuItem";
            this.informationsdateiErstellenToolStripMenuItem.Click += new System.EventHandler(this.informationsdateiErstellenToolStripMenuItem_Click);
            // 
            // zurConfigGehenToolStripMenuItem
            // 
            resources.ApplyResources(this.zurConfigGehenToolStripMenuItem, "zurConfigGehenToolStripMenuItem");
            this.zurConfigGehenToolStripMenuItem.Name = "zurConfigGehenToolStripMenuItem";
            this.zurConfigGehenToolStripMenuItem.Click += new System.EventHandler(this.zurConfigGehenToolStripMenuItem_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // comboBox_DeleteLogsAfterXDays
            // 
            resources.ApplyResources(this.comboBox_DeleteLogsAfterXDays, "comboBox_DeleteLogsAfterXDays");
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
            this.comboBox_DeleteLogsAfterXDays.Name = "comboBox_DeleteLogsAfterXDays";
            // 
            // FormSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox_DeleteLogsAfterXDays);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progressBar_updater);
            this.Controls.Add(this.comboBox_resolution);
            this.Controls.Add(this.btn_steuerung);
            this.Controls.Add(this.btn_speichern);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.check_ShowScan);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.check_showDebug);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tab_schubLeistung.ResumeLayout(false);
            this.tab_schubLeistung.PerformLayout();
            this.tab_kombihebel.ResumeLayout(false);
            this.tab_kombihebel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_schubLeistung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Schub;
        private System.Windows.Forms.TabPage tab_kombihebel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Bremse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_kombiBremse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_kombiSchub;
        private System.Windows.Forms.Button btn_speichern;
        private System.Windows.Forms.Button btn_steuerung;
        private System.Windows.Forms.ComboBox comboBox_resolution;
        private System.Windows.Forms.ProgressBar progressBar_updater;
        private System.Windows.Forms.Button btn_textindikator_StandardLaden;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_decreaseBrake;
        private System.Windows.Forms.TextBox txt_increaseBrake;
        private System.Windows.Forms.TextBox txt_decreaseThrottle;
        private System.Windows.Forms.TextBox txt_increaseThrottle;
        private System.Windows.Forms.ComboBox comboBox_TrainConfig;
        private System.Windows.Forms.Button btn_trainconfigHinzufuegen;
        private System.Windows.Forms.Button btn_trainconfigLoeschen;
        private System.Windows.Forms.Label label6;
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