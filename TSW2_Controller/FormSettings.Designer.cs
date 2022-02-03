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
            this.txt_resWidth = new System.Windows.Forms.TextBox();
            this.txt_resHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.check_showDebug = new System.Windows.Forms.CheckBox();
            this.lbl_version = new System.Windows.Forms.Label();
            this.check_ShowScan = new System.Windows.Forms.CheckBox();
            this.btn_updates = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.btn_changelog = new System.Windows.Forms.Button();
            this.btn_speichern = new System.Windows.Forms.Button();
            this.btn_steuerung = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_schubLeistung.SuspendLayout();
            this.tab_kombihebel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_resWidth
            // 
            this.txt_resWidth.Location = new System.Drawing.Point(6, 25);
            this.txt_resWidth.Name = "txt_resWidth";
            this.txt_resWidth.Size = new System.Drawing.Size(45, 20);
            this.txt_resWidth.TabIndex = 0;
            this.txt_resWidth.Text = "1920";
            // 
            // txt_resHeight
            // 
            this.txt_resHeight.Location = new System.Drawing.Point(57, 25);
            this.txt_resHeight.Name = "txt_resHeight";
            this.txt_resHeight.Size = new System.Drawing.Size(45, 20);
            this.txt_resHeight.TabIndex = 1;
            this.txt_resHeight.Text = "1080";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Spiel-Auflösung:";
            // 
            // check_showDebug
            // 
            this.check_showDebug.AutoSize = true;
            this.check_showDebug.Location = new System.Drawing.Point(6, 56);
            this.check_showDebug.Name = "check_showDebug";
            this.check_showDebug.Size = new System.Drawing.Size(125, 17);
            this.check_showDebug.TabIndex = 4;
            this.check_showDebug.Text = "Debug Informationen";
            this.check_showDebug.UseVisualStyleBackColor = true;
            // 
            // lbl_version
            // 
            this.lbl_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point(3, 338);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(40, 13);
            this.lbl_version.TabIndex = 6;
            this.lbl_version.Text = "vX.X.X";
            // 
            // check_ShowScan
            // 
            this.check_ShowScan.AutoSize = true;
            this.check_ShowScan.Location = new System.Drawing.Point(6, 79);
            this.check_ShowScan.Name = "check_ShowScan";
            this.check_ShowScan.Size = new System.Drawing.Size(141, 17);
            this.check_ShowScan.TabIndex = 7;
            this.check_ShowScan.Text = "Scan-Ergebnis anzeigen";
            this.check_ShowScan.UseVisualStyleBackColor = true;
            // 
            // btn_updates
            // 
            this.btn_updates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_updates.Location = new System.Drawing.Point(6, 309);
            this.btn_updates.Name = "btn_updates";
            this.btn_updates.Size = new System.Drawing.Size(86, 23);
            this.btn_updates.TabIndex = 8;
            this.btn_updates.Text = "check updates";
            this.btn_updates.UseVisualStyleBackColor = true;
            this.btn_updates.Click += new System.EventHandler(this.btn_updates_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(6, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 150);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text Indikatoren";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_schubLeistung);
            this.tabControl1.Controls.Add(this.tab_kombihebel);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(157, 126);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_schubLeistung
            // 
            this.tab_schubLeistung.Controls.Add(this.label3);
            this.tab_schubLeistung.Controls.Add(this.comboBox_Bremse);
            this.tab_schubLeistung.Controls.Add(this.label2);
            this.tab_schubLeistung.Controls.Add(this.comboBox_Schub);
            this.tab_schubLeistung.Location = new System.Drawing.Point(4, 22);
            this.tab_schubLeistung.Name = "tab_schubLeistung";
            this.tab_schubLeistung.Padding = new System.Windows.Forms.Padding(3);
            this.tab_schubLeistung.Size = new System.Drawing.Size(149, 100);
            this.tab_schubLeistung.TabIndex = 0;
            this.tab_schubLeistung.Text = "Schub/Bremse";
            this.tab_schubLeistung.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bremse";
            // 
            // comboBox_Bremse
            // 
            this.comboBox_Bremse.FormattingEnabled = true;
            this.comboBox_Bremse.Location = new System.Drawing.Point(6, 63);
            this.comboBox_Bremse.Name = "comboBox_Bremse";
            this.comboBox_Bremse.Size = new System.Drawing.Size(131, 21);
            this.comboBox_Bremse.Sorted = true;
            this.comboBox_Bremse.TabIndex = 2;
            this.comboBox_Bremse.SelectedIndexChanged += new System.EventHandler(this.comboBox_Bremse_SelectedIndexChanged);
            this.comboBox_Bremse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Bremse_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Schub";
            // 
            // comboBox_Schub
            // 
            this.comboBox_Schub.FormattingEnabled = true;
            this.comboBox_Schub.Location = new System.Drawing.Point(6, 19);
            this.comboBox_Schub.Name = "comboBox_Schub";
            this.comboBox_Schub.Size = new System.Drawing.Size(131, 21);
            this.comboBox_Schub.Sorted = true;
            this.comboBox_Schub.TabIndex = 0;
            this.comboBox_Schub.SelectedIndexChanged += new System.EventHandler(this.comboBox_Schub_SelectedIndexChanged);
            this.comboBox_Schub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Schub_KeyPress);
            // 
            // tab_kombihebel
            // 
            this.tab_kombihebel.Controls.Add(this.label4);
            this.tab_kombihebel.Controls.Add(this.comboBox_kombiBremse);
            this.tab_kombihebel.Controls.Add(this.label5);
            this.tab_kombihebel.Controls.Add(this.comboBox_kombiSchub);
            this.tab_kombihebel.Location = new System.Drawing.Point(4, 22);
            this.tab_kombihebel.Name = "tab_kombihebel";
            this.tab_kombihebel.Padding = new System.Windows.Forms.Padding(3);
            this.tab_kombihebel.Size = new System.Drawing.Size(149, 100);
            this.tab_kombihebel.TabIndex = 1;
            this.tab_kombihebel.Text = "Kombihebel";
            this.tab_kombihebel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bremse";
            // 
            // comboBox_kombiBremse
            // 
            this.comboBox_kombiBremse.FormattingEnabled = true;
            this.comboBox_kombiBremse.Location = new System.Drawing.Point(6, 63);
            this.comboBox_kombiBremse.Name = "comboBox_kombiBremse";
            this.comboBox_kombiBremse.Size = new System.Drawing.Size(131, 21);
            this.comboBox_kombiBremse.Sorted = true;
            this.comboBox_kombiBremse.TabIndex = 6;
            this.comboBox_kombiBremse.SelectedIndexChanged += new System.EventHandler(this.comboBox_kombiBremse_SelectedIndexChanged);
            this.comboBox_kombiBremse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_kombiBremse_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Schub";
            // 
            // comboBox_kombiSchub
            // 
            this.comboBox_kombiSchub.FormattingEnabled = true;
            this.comboBox_kombiSchub.Location = new System.Drawing.Point(6, 19);
            this.comboBox_kombiSchub.Name = "comboBox_kombiSchub";
            this.comboBox_kombiSchub.Size = new System.Drawing.Size(131, 21);
            this.comboBox_kombiSchub.Sorted = true;
            this.comboBox_kombiSchub.TabIndex = 4;
            this.comboBox_kombiSchub.SelectedIndexChanged += new System.EventHandler(this.comboBox_kombiSchub_SelectedIndexChanged);
            this.comboBox_kombiSchub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_kombiSchub_KeyPress);
            // 
            // btn_changelog
            // 
            this.btn_changelog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_changelog.Location = new System.Drawing.Point(6, 280);
            this.btn_changelog.Name = "btn_changelog";
            this.btn_changelog.Size = new System.Drawing.Size(86, 23);
            this.btn_changelog.TabIndex = 12;
            this.btn_changelog.Text = "Was ist neu?";
            this.btn_changelog.UseVisualStyleBackColor = true;
            this.btn_changelog.Click += new System.EventHandler(this.btn_changelog_Click);
            // 
            // btn_speichern
            // 
            this.btn_speichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_speichern.Location = new System.Drawing.Point(170, 328);
            this.btn_speichern.Name = "btn_speichern";
            this.btn_speichern.Size = new System.Drawing.Size(75, 23);
            this.btn_speichern.TabIndex = 13;
            this.btn_speichern.Text = "speichern";
            this.btn_speichern.UseVisualStyleBackColor = true;
            this.btn_speichern.Click += new System.EventHandler(this.btn_speichern_Click);
            // 
            // btn_steuerung
            // 
            this.btn_steuerung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_steuerung.Location = new System.Drawing.Point(170, 9);
            this.btn_steuerung.Name = "btn_steuerung";
            this.btn_steuerung.Size = new System.Drawing.Size(75, 23);
            this.btn_steuerung.TabIndex = 14;
            this.btn_steuerung.Text = "Steuerung";
            this.btn_steuerung.UseVisualStyleBackColor = true;
            this.btn_steuerung.Click += new System.EventHandler(this.btn_steuerung_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(257, 360);
            this.Controls.Add(this.btn_steuerung);
            this.Controls.Add(this.btn_speichern);
            this.Controls.Add(this.btn_changelog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_updates);
            this.Controls.Add(this.check_ShowScan);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.check_showDebug);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_resHeight);
            this.Controls.Add(this.txt_resWidth);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Einstellungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tab_schubLeistung.ResumeLayout(false);
            this.tab_schubLeistung.PerformLayout();
            this.tab_kombihebel.ResumeLayout(false);
            this.tab_kombihebel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_resWidth;
        private System.Windows.Forms.TextBox txt_resHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox check_showDebug;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.CheckBox check_ShowScan;
        private System.Windows.Forms.Button btn_updates;
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
        private System.Windows.Forms.Button btn_changelog;
        private System.Windows.Forms.Button btn_speichern;
        private System.Windows.Forms.Button btn_steuerung;
    }
}