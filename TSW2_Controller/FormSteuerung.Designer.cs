namespace TSW2_Controller
{
    partial class FormSteuerung
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
            this.components = new System.ComponentModel.Container();
            this.tabControl_Anzeige = new System.Windows.Forms.TabControl();
            this.tabPage_Zugauswahl = new System.Windows.Forms.TabPage();
            this.btnT0_Add = new System.Windows.Forms.Button();
            this.btnT0_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxT0_Zugauswahl = new System.Windows.Forms.ComboBox();
            this.tabPage_Button = new System.Windows.Forms.TabPage();
            this.btnT1_Erstellen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtT1_Tastenkombination = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtT1_Aktion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnT1_Hinzufuegen_ersetzen = new System.Windows.Forms.Button();
            this.comboBoxT1_KnopfAuswahl = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtT1_JoystickNr = new System.Windows.Forms.TextBox();
            this.btnT1_Erkennen = new System.Windows.Forms.Button();
            this.lblT1_KnopfNr = new System.Windows.Forms.Label();
            this.txtT1_JoystickKnopf = new System.Windows.Forms.TextBox();
            this.radioT1_regler = new System.Windows.Forms.RadioButton();
            this.radioT1_normal = new System.Windows.Forms.RadioButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnT2_Fertig = new System.Windows.Forms.Button();
            this.btnT2_Hinzufügen = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtT2_Wartezeit = new System.Windows.Forms.TextBox();
            this.lblT2_haltezeit = new System.Windows.Forms.Label();
            this.txtT2_Haltezeit = new System.Windows.Forms.TextBox();
            this.radioT2_Loslassen = new System.Windows.Forms.RadioButton();
            this.radioT2_Druecken = new System.Windows.Forms.RadioButton();
            this.radioT2_Halten = new System.Windows.Forms.RadioButton();
            this.radioT2_einmalDruecken = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtT2_Taste = new System.Windows.Forms.TextBox();
            this.listBoxT2_Output = new System.Windows.Forms.ListBox();
            this.Timer_CheckForButtonPress = new System.Windows.Forms.Timer(this.components);
            this.lblT1_Bedingung = new System.Windows.Forms.Label();
            this.txtT1_Bedingung = new System.Windows.Forms.TextBox();
            this.listBoxT1_ShowJoystickStates = new System.Windows.Forms.ListBox();
            this.btnT1_entfernen = new System.Windows.Forms.Button();
            this.btnT1_Back = new System.Windows.Forms.Button();
            this.tabControl_Anzeige.SuspendLayout();
            this.tabPage_Zugauswahl.SuspendLayout();
            this.tabPage_Button.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Anzeige
            // 
            this.tabControl_Anzeige.Controls.Add(this.tabPage_Zugauswahl);
            this.tabControl_Anzeige.Controls.Add(this.tabPage_Button);
            this.tabControl_Anzeige.Controls.Add(this.tabPage1);
            this.tabControl_Anzeige.Location = new System.Drawing.Point(12, 12);
            this.tabControl_Anzeige.Name = "tabControl_Anzeige";
            this.tabControl_Anzeige.SelectedIndex = 0;
            this.tabControl_Anzeige.Size = new System.Drawing.Size(362, 261);
            this.tabControl_Anzeige.TabIndex = 0;
            this.tabControl_Anzeige.SelectedIndexChanged += new System.EventHandler(this.tabControl_Anzeige_SelectedIndexChanged);
            // 
            // tabPage_Zugauswahl
            // 
            this.tabPage_Zugauswahl.Controls.Add(this.btnT0_Add);
            this.tabPage_Zugauswahl.Controls.Add(this.btnT0_ok);
            this.tabPage_Zugauswahl.Controls.Add(this.label1);
            this.tabPage_Zugauswahl.Controls.Add(this.comboBoxT0_Zugauswahl);
            this.tabPage_Zugauswahl.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Zugauswahl.Name = "tabPage_Zugauswahl";
            this.tabPage_Zugauswahl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Zugauswahl.Size = new System.Drawing.Size(357, 213);
            this.tabPage_Zugauswahl.TabIndex = 0;
            this.tabPage_Zugauswahl.Text = "Zugauswahl";
            this.tabPage_Zugauswahl.UseVisualStyleBackColor = true;
            // 
            // btnT0_Add
            // 
            this.btnT0_Add.Location = new System.Drawing.Point(9, 113);
            this.btnT0_Add.Name = "btnT0_Add";
            this.btnT0_Add.Size = new System.Drawing.Size(75, 23);
            this.btnT0_Add.TabIndex = 4;
            this.btnT0_Add.Text = "Hinzufügen";
            this.btnT0_Add.UseVisualStyleBackColor = true;
            this.btnT0_Add.Click += new System.EventHandler(this.btnT0_Add_Click);
            // 
            // btnT0_ok
            // 
            this.btnT0_ok.Location = new System.Drawing.Point(9, 46);
            this.btnT0_ok.Name = "btnT0_ok";
            this.btnT0_ok.Size = new System.Drawing.Size(75, 23);
            this.btnT0_ok.TabIndex = 3;
            this.btnT0_ok.Text = "OK";
            this.btnT0_ok.UseVisualStyleBackColor = true;
            this.btnT0_ok.Click += new System.EventHandler(this.btnT0_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zug Auswählen";
            // 
            // comboBoxT0_Zugauswahl
            // 
            this.comboBoxT0_Zugauswahl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxT0_Zugauswahl.FormattingEnabled = true;
            this.comboBoxT0_Zugauswahl.Location = new System.Drawing.Point(9, 19);
            this.comboBoxT0_Zugauswahl.Name = "comboBoxT0_Zugauswahl";
            this.comboBoxT0_Zugauswahl.Size = new System.Drawing.Size(131, 21);
            this.comboBoxT0_Zugauswahl.Sorted = true;
            this.comboBoxT0_Zugauswahl.TabIndex = 1;
            // 
            // tabPage_Button
            // 
            this.tabPage_Button.Controls.Add(this.btnT1_Back);
            this.tabPage_Button.Controls.Add(this.btnT1_entfernen);
            this.tabPage_Button.Controls.Add(this.listBoxT1_ShowJoystickStates);
            this.tabPage_Button.Controls.Add(this.lblT1_Bedingung);
            this.tabPage_Button.Controls.Add(this.txtT1_Bedingung);
            this.tabPage_Button.Controls.Add(this.btnT1_Erstellen);
            this.tabPage_Button.Controls.Add(this.label6);
            this.tabPage_Button.Controls.Add(this.txtT1_Tastenkombination);
            this.tabPage_Button.Controls.Add(this.label5);
            this.tabPage_Button.Controls.Add(this.txtT1_Aktion);
            this.tabPage_Button.Controls.Add(this.label4);
            this.tabPage_Button.Controls.Add(this.btnT1_Hinzufuegen_ersetzen);
            this.tabPage_Button.Controls.Add(this.comboBoxT1_KnopfAuswahl);
            this.tabPage_Button.Controls.Add(this.label3);
            this.tabPage_Button.Controls.Add(this.txtT1_JoystickNr);
            this.tabPage_Button.Controls.Add(this.btnT1_Erkennen);
            this.tabPage_Button.Controls.Add(this.lblT1_KnopfNr);
            this.tabPage_Button.Controls.Add(this.txtT1_JoystickKnopf);
            this.tabPage_Button.Controls.Add(this.radioT1_regler);
            this.tabPage_Button.Controls.Add(this.radioT1_normal);
            this.tabPage_Button.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Button.Name = "tabPage_Button";
            this.tabPage_Button.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Button.Size = new System.Drawing.Size(354, 235);
            this.tabPage_Button.TabIndex = 1;
            this.tabPage_Button.Text = "Button";
            this.tabPage_Button.UseVisualStyleBackColor = true;
            // 
            // btnT1_Erstellen
            // 
            this.btnT1_Erstellen.Location = new System.Drawing.Point(247, 149);
            this.btnT1_Erstellen.Name = "btnT1_Erstellen";
            this.btnT1_Erstellen.Size = new System.Drawing.Size(100, 23);
            this.btnT1_Erstellen.TabIndex = 15;
            this.btnT1_Erstellen.Text = "Erstellen";
            this.btnT1_Erstellen.UseVisualStyleBackColor = true;
            this.btnT1_Erstellen.Click += new System.EventHandler(this.btnT1_Erstellen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tastenkombination";
            // 
            // txtT1_Tastenkombination
            // 
            this.txtT1_Tastenkombination.Location = new System.Drawing.Point(247, 123);
            this.txtT1_Tastenkombination.Name = "txtT1_Tastenkombination";
            this.txtT1_Tastenkombination.Size = new System.Drawing.Size(100, 20);
            this.txtT1_Tastenkombination.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Aktion";
            // 
            // txtT1_Aktion
            // 
            this.txtT1_Aktion.Location = new System.Drawing.Point(197, 123);
            this.txtT1_Aktion.Name = "txtT1_Aktion";
            this.txtT1_Aktion.Size = new System.Drawing.Size(44, 20);
            this.txtT1_Aktion.TabIndex = 11;
            this.txtT1_Aktion.Text = "bildab";
            this.txtT1_Aktion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtT1_Aktion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtT1_Aktion_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Name";
            // 
            // btnT1_Hinzufuegen_ersetzen
            // 
            this.btnT1_Hinzufuegen_ersetzen.Location = new System.Drawing.Point(224, 187);
            this.btnT1_Hinzufuegen_ersetzen.Name = "btnT1_Hinzufuegen_ersetzen";
            this.btnT1_Hinzufuegen_ersetzen.Size = new System.Drawing.Size(123, 21);
            this.btnT1_Hinzufuegen_ersetzen.TabIndex = 9;
            this.btnT1_Hinzufuegen_ersetzen.Text = "Hinzufügen / Ersetzen";
            this.btnT1_Hinzufuegen_ersetzen.UseVisualStyleBackColor = true;
            this.btnT1_Hinzufuegen_ersetzen.Click += new System.EventHandler(this.btnT1_Hinzufuegen_ersetzen_Click);
            // 
            // comboBoxT1_KnopfAuswahl
            // 
            this.comboBoxT1_KnopfAuswahl.FormattingEnabled = true;
            this.comboBoxT1_KnopfAuswahl.Location = new System.Drawing.Point(6, 19);
            this.comboBoxT1_KnopfAuswahl.Name = "comboBoxT1_KnopfAuswahl";
            this.comboBoxT1_KnopfAuswahl.Size = new System.Drawing.Size(121, 21);
            this.comboBoxT1_KnopfAuswahl.TabIndex = 8;
            this.comboBoxT1_KnopfAuswahl.SelectedIndexChanged += new System.EventHandler(this.comboBoxT1_KnopfAuswahl_SelectedIndexChanged);
            this.comboBoxT1_KnopfAuswahl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxT1_KnopfAuswahl_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Joysticknr.";
            // 
            // txtT1_JoystickNr
            // 
            this.txtT1_JoystickNr.Location = new System.Drawing.Point(6, 123);
            this.txtT1_JoystickNr.Name = "txtT1_JoystickNr";
            this.txtT1_JoystickNr.Size = new System.Drawing.Size(57, 20);
            this.txtT1_JoystickNr.TabIndex = 6;
            this.txtT1_JoystickNr.Text = "0";
            this.txtT1_JoystickNr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnT1_Erkennen
            // 
            this.btnT1_Erkennen.Location = new System.Drawing.Point(6, 149);
            this.btnT1_Erkennen.Name = "btnT1_Erkennen";
            this.btnT1_Erkennen.Size = new System.Drawing.Size(107, 23);
            this.btnT1_Erkennen.TabIndex = 5;
            this.btnT1_Erkennen.Text = "Erkennen";
            this.btnT1_Erkennen.UseVisualStyleBackColor = true;
            this.btnT1_Erkennen.Click += new System.EventHandler(this.btnT1_Erkennen_Click);
            // 
            // lblT1_KnopfNr
            // 
            this.lblT1_KnopfNr.AutoSize = true;
            this.lblT1_KnopfNr.Location = new System.Drawing.Point(66, 107);
            this.lblT1_KnopfNr.Name = "lblT1_KnopfNr";
            this.lblT1_KnopfNr.Size = new System.Drawing.Size(47, 13);
            this.lblT1_KnopfNr.TabIndex = 4;
            this.lblT1_KnopfNr.Text = "Knopfnr.";
            // 
            // txtT1_JoystickKnopf
            // 
            this.txtT1_JoystickKnopf.Location = new System.Drawing.Point(69, 123);
            this.txtT1_JoystickKnopf.Name = "txtT1_JoystickKnopf";
            this.txtT1_JoystickKnopf.Size = new System.Drawing.Size(44, 20);
            this.txtT1_JoystickKnopf.TabIndex = 3;
            this.txtT1_JoystickKnopf.Text = "11";
            this.txtT1_JoystickKnopf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioT1_regler
            // 
            this.radioT1_regler.AutoSize = true;
            this.radioT1_regler.Location = new System.Drawing.Point(6, 69);
            this.radioT1_regler.Name = "radioT1_regler";
            this.radioT1_regler.Size = new System.Drawing.Size(103, 17);
            this.radioT1_regler.TabIndex = 2;
            this.radioT1_regler.Text = "Regler als Knopf";
            this.radioT1_regler.UseVisualStyleBackColor = true;
            // 
            // radioT1_normal
            // 
            this.radioT1_normal.AutoSize = true;
            this.radioT1_normal.Checked = true;
            this.radioT1_normal.Location = new System.Drawing.Point(6, 46);
            this.radioT1_normal.Name = "radioT1_normal";
            this.radioT1_normal.Size = new System.Drawing.Size(96, 17);
            this.radioT1_normal.TabIndex = 1;
            this.radioT1_normal.TabStop = true;
            this.radioT1_normal.Text = "normaler Knopf";
            this.radioT1_normal.UseVisualStyleBackColor = true;
            this.radioT1_normal.CheckedChanged += new System.EventHandler(this.radioT1_normal_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnT2_Fertig);
            this.tabPage1.Controls.Add(this.btnT2_Hinzufügen);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtT2_Wartezeit);
            this.tabPage1.Controls.Add(this.lblT2_haltezeit);
            this.tabPage1.Controls.Add(this.txtT2_Haltezeit);
            this.tabPage1.Controls.Add(this.radioT2_Loslassen);
            this.tabPage1.Controls.Add(this.radioT2_Druecken);
            this.tabPage1.Controls.Add(this.radioT2_Halten);
            this.tabPage1.Controls.Add(this.radioT2_einmalDruecken);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtT2_Taste);
            this.tabPage1.Controls.Add(this.listBoxT2_Output);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(354, 235);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Tastenkombi Erstellen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnT2_Fertig
            // 
            this.btnT2_Fertig.Location = new System.Drawing.Point(247, 200);
            this.btnT2_Fertig.Name = "btnT2_Fertig";
            this.btnT2_Fertig.Size = new System.Drawing.Size(45, 23);
            this.btnT2_Fertig.TabIndex = 12;
            this.btnT2_Fertig.Text = "Fertig";
            this.btnT2_Fertig.UseVisualStyleBackColor = true;
            this.btnT2_Fertig.Click += new System.EventHandler(this.btnT2_Fertig_Click);
            // 
            // btnT2_Hinzufügen
            // 
            this.btnT2_Hinzufügen.Location = new System.Drawing.Point(129, 200);
            this.btnT2_Hinzufügen.Name = "btnT2_Hinzufügen";
            this.btnT2_Hinzufügen.Size = new System.Drawing.Size(75, 23);
            this.btnT2_Hinzufügen.TabIndex = 11;
            this.btnT2_Hinzufügen.Text = "Hinzufügen";
            this.btnT2_Hinzufügen.UseVisualStyleBackColor = true;
            this.btnT2_Hinzufügen.Click += new System.EventHandler(this.btnT2_Hinzufügen_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(129, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Wartezeit [ms]";
            // 
            // txtT2_Wartezeit
            // 
            this.txtT2_Wartezeit.Location = new System.Drawing.Point(129, 174);
            this.txtT2_Wartezeit.Name = "txtT2_Wartezeit";
            this.txtT2_Wartezeit.Size = new System.Drawing.Size(92, 20);
            this.txtT2_Wartezeit.TabIndex = 9;
            this.txtT2_Wartezeit.Text = "0";
            this.txtT2_Wartezeit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtT2_Haltezeit_KeyPress);
            // 
            // lblT2_haltezeit
            // 
            this.lblT2_haltezeit.AutoSize = true;
            this.lblT2_haltezeit.Location = new System.Drawing.Point(129, 112);
            this.lblT2_haltezeit.Name = "lblT2_haltezeit";
            this.lblT2_haltezeit.Size = new System.Drawing.Size(92, 13);
            this.lblT2_haltezeit.TabIndex = 8;
            this.lblT2_haltezeit.Text = "Dauer Halten [ms]";
            // 
            // txtT2_Haltezeit
            // 
            this.txtT2_Haltezeit.Location = new System.Drawing.Point(129, 128);
            this.txtT2_Haltezeit.Name = "txtT2_Haltezeit";
            this.txtT2_Haltezeit.Size = new System.Drawing.Size(92, 20);
            this.txtT2_Haltezeit.TabIndex = 7;
            this.txtT2_Haltezeit.Text = "0";
            this.txtT2_Haltezeit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtT2_Haltezeit_KeyPress);
            // 
            // radioT2_Loslassen
            // 
            this.radioT2_Loslassen.AutoSize = true;
            this.radioT2_Loslassen.Location = new System.Drawing.Point(220, 79);
            this.radioT2_Loslassen.Name = "radioT2_Loslassen";
            this.radioT2_Loslassen.Size = new System.Drawing.Size(72, 17);
            this.radioT2_Loslassen.TabIndex = 6;
            this.radioT2_Loslassen.Text = "Loslassen";
            this.radioT2_Loslassen.UseVisualStyleBackColor = true;
            this.radioT2_Loslassen.CheckedChanged += new System.EventHandler(this.radio_Changed);
            // 
            // radioT2_Druecken
            // 
            this.radioT2_Druecken.AutoSize = true;
            this.radioT2_Druecken.Location = new System.Drawing.Point(220, 56);
            this.radioT2_Druecken.Name = "radioT2_Druecken";
            this.radioT2_Druecken.Size = new System.Drawing.Size(66, 17);
            this.radioT2_Druecken.TabIndex = 5;
            this.radioT2_Druecken.Text = "Drücken";
            this.radioT2_Druecken.UseVisualStyleBackColor = true;
            this.radioT2_Druecken.CheckedChanged += new System.EventHandler(this.radio_Changed);
            // 
            // radioT2_Halten
            // 
            this.radioT2_Halten.AutoSize = true;
            this.radioT2_Halten.Location = new System.Drawing.Point(129, 79);
            this.radioT2_Halten.Name = "radioT2_Halten";
            this.radioT2_Halten.Size = new System.Drawing.Size(56, 17);
            this.radioT2_Halten.TabIndex = 4;
            this.radioT2_Halten.Text = "Halten";
            this.radioT2_Halten.UseVisualStyleBackColor = true;
            this.radioT2_Halten.CheckedChanged += new System.EventHandler(this.radio_Changed);
            // 
            // radioT2_einmalDruecken
            // 
            this.radioT2_einmalDruecken.AutoSize = true;
            this.radioT2_einmalDruecken.Checked = true;
            this.radioT2_einmalDruecken.Location = new System.Drawing.Point(129, 56);
            this.radioT2_einmalDruecken.Name = "radioT2_einmalDruecken";
            this.radioT2_einmalDruecken.Size = new System.Drawing.Size(80, 17);
            this.radioT2_einmalDruecken.TabIndex = 3;
            this.radioT2_einmalDruecken.TabStop = true;
            this.radioT2_einmalDruecken.Text = "1x Drücken";
            this.radioT2_einmalDruecken.UseVisualStyleBackColor = true;
            this.radioT2_einmalDruecken.CheckedChanged += new System.EventHandler(this.radio_Changed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(129, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Taste";
            // 
            // txtT2_Taste
            // 
            this.txtT2_Taste.Location = new System.Drawing.Point(129, 30);
            this.txtT2_Taste.Name = "txtT2_Taste";
            this.txtT2_Taste.Size = new System.Drawing.Size(75, 20);
            this.txtT2_Taste.TabIndex = 1;
            this.txtT2_Taste.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtT2_Taste_KeyDown);
            // 
            // listBoxT2_Output
            // 
            this.listBoxT2_Output.FormattingEnabled = true;
            this.listBoxT2_Output.Location = new System.Drawing.Point(3, 3);
            this.listBoxT2_Output.Name = "listBoxT2_Output";
            this.listBoxT2_Output.Size = new System.Drawing.Size(120, 225);
            this.listBoxT2_Output.TabIndex = 0;
            this.listBoxT2_Output.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxT2_Output_KeyDown);
            // 
            // Timer_CheckForButtonPress
            // 
            this.Timer_CheckForButtonPress.Interval = 10;
            this.Timer_CheckForButtonPress.Tick += new System.EventHandler(this.Timer_CheckForButtonPress_Tick);
            // 
            // lblT1_Bedingung
            // 
            this.lblT1_Bedingung.AutoSize = true;
            this.lblT1_Bedingung.Location = new System.Drawing.Point(126, 107);
            this.lblT1_Bedingung.Name = "lblT1_Bedingung";
            this.lblT1_Bedingung.Size = new System.Drawing.Size(58, 13);
            this.lblT1_Bedingung.TabIndex = 17;
            this.lblT1_Bedingung.Text = "Bedingung";
            // 
            // txtT1_Bedingung
            // 
            this.txtT1_Bedingung.Location = new System.Drawing.Point(119, 123);
            this.txtT1_Bedingung.Name = "txtT1_Bedingung";
            this.txtT1_Bedingung.Size = new System.Drawing.Size(72, 20);
            this.txtT1_Bedingung.TabIndex = 16;
            this.txtT1_Bedingung.Text = "11";
            this.txtT1_Bedingung.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBoxT1_ShowJoystickStates
            // 
            this.listBoxT1_ShowJoystickStates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxT1_ShowJoystickStates.FormattingEnabled = true;
            this.listBoxT1_ShowJoystickStates.Location = new System.Drawing.Point(227, 3);
            this.listBoxT1_ShowJoystickStates.Name = "listBoxT1_ShowJoystickStates";
            this.listBoxT1_ShowJoystickStates.Size = new System.Drawing.Size(120, 91);
            this.listBoxT1_ShowJoystickStates.TabIndex = 18;
            // 
            // btnT1_entfernen
            // 
            this.btnT1_entfernen.Location = new System.Drawing.Point(129, 19);
            this.btnT1_entfernen.Name = "btnT1_entfernen";
            this.btnT1_entfernen.Size = new System.Drawing.Size(62, 21);
            this.btnT1_entfernen.TabIndex = 19;
            this.btnT1_entfernen.Text = "Entfernen";
            this.btnT1_entfernen.UseVisualStyleBackColor = true;
            this.btnT1_entfernen.Click += new System.EventHandler(this.btnT1_entfernen_Click);
            // 
            // btnT1_Back
            // 
            this.btnT1_Back.Location = new System.Drawing.Point(6, 184);
            this.btnT1_Back.Name = "btnT1_Back";
            this.btnT1_Back.Size = new System.Drawing.Size(35, 23);
            this.btnT1_Back.TabIndex = 20;
            this.btnT1_Back.Text = "<<--";
            this.btnT1_Back.UseVisualStyleBackColor = true;
            this.btnT1_Back.Click += new System.EventHandler(this.btnT1_Back_Click);
            // 
            // FormSteuerung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl_Anzeige);
            this.Name = "FormSteuerung";
            this.Text = "FormSteuerung";
            this.tabControl_Anzeige.ResumeLayout(false);
            this.tabPage_Zugauswahl.ResumeLayout(false);
            this.tabPage_Zugauswahl.PerformLayout();
            this.tabPage_Button.ResumeLayout(false);
            this.tabPage_Button.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Anzeige;
        private System.Windows.Forms.TabPage tabPage_Zugauswahl;
        private System.Windows.Forms.TabPage tabPage_Button;
        private System.Windows.Forms.ComboBox comboBoxT0_Zugauswahl;
        private System.Windows.Forms.Button btnT0_Add;
        private System.Windows.Forms.Button btnT0_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxT1_KnopfAuswahl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtT1_JoystickNr;
        private System.Windows.Forms.Button btnT1_Erkennen;
        private System.Windows.Forms.Label lblT1_KnopfNr;
        private System.Windows.Forms.TextBox txtT1_JoystickKnopf;
        private System.Windows.Forms.RadioButton radioT1_regler;
        private System.Windows.Forms.RadioButton radioT1_normal;
        private System.Windows.Forms.Button btnT1_Hinzufuegen_ersetzen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtT1_Aktion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtT1_Tastenkombination;
        private System.Windows.Forms.Button btnT1_Erstellen;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtT2_Taste;
        private System.Windows.Forms.ListBox listBoxT2_Output;
        private System.Windows.Forms.RadioButton radioT2_Loslassen;
        private System.Windows.Forms.RadioButton radioT2_Druecken;
        private System.Windows.Forms.RadioButton radioT2_Halten;
        private System.Windows.Forms.RadioButton radioT2_einmalDruecken;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtT2_Wartezeit;
        private System.Windows.Forms.Label lblT2_haltezeit;
        private System.Windows.Forms.TextBox txtT2_Haltezeit;
        private System.Windows.Forms.Button btnT2_Hinzufügen;
        private System.Windows.Forms.Button btnT2_Fertig;
        private System.Windows.Forms.Timer Timer_CheckForButtonPress;
        private System.Windows.Forms.Label lblT1_Bedingung;
        private System.Windows.Forms.TextBox txtT1_Bedingung;
        private System.Windows.Forms.ListBox listBoxT1_ShowJoystickStates;
        private System.Windows.Forms.Button btnT1_entfernen;
        private System.Windows.Forms.Button btnT1_Back;
    }
}