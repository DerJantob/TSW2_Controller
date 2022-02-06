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
            this.btnT0_editRegler = new System.Windows.Forms.Button();
            this.btnT0_Add = new System.Windows.Forms.Button();
            this.btnT0_editButtons = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxT0_Zugauswahl = new System.Windows.Forms.ComboBox();
            this.tabPage_Button = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.btnT1_Back = new System.Windows.Forms.Button();
            this.btnT1_entfernen = new System.Windows.Forms.Button();
            this.listBoxT1_ShowJoystickStates = new System.Windows.Forms.ListBox();
            this.lblT1_Bedingung = new System.Windows.Forms.Label();
            this.txtT1_Bedingung = new System.Windows.Forms.TextBox();
            this.btnT1_Editor = new System.Windows.Forms.Button();
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
            this.tabPage_Tastenkombi_Erstellen = new System.Windows.Forms.TabPage();
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
            this.tabPage_Regler = new System.Windows.Forms.TabPage();
            this.btnT3_ZeitfaktorFinden = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtT3_Beschreibung = new System.Windows.Forms.TextBox();
            this.listBoxT3_ShowJoystickStates = new System.Windows.Forms.ListBox();
            this.btnT3_leeren = new System.Windows.Forms.Button();
            this.btnT3_Speichern = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtT3_LongPress = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtT3_Zeitfaktor = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtT3_Sonderfaelle = new System.Windows.Forms.TextBox();
            this.txtT3_JoyUmrechnen = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtT3_AnzahlStufen = new System.Windows.Forms.TextBox();
            this.lblT3_AnzahlStufen = new System.Windows.Forms.Label();
            this.txtT3_JoyNr = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkT3_andererJoyModus = new System.Windows.Forms.CheckBox();
            this.checkT3_Invertiert = new System.Windows.Forms.CheckBox();
            this.txtT3_JoyAchse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelT3_StufenStufenlos = new System.Windows.Forms.Panel();
            this.radioT3_Stufenlos = new System.Windows.Forms.RadioButton();
            this.radioT3_Stufen = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioT3_Schub = new System.Windows.Forms.RadioButton();
            this.radioT3_Kombihebel = new System.Windows.Forms.RadioButton();
            this.radioT3_Bremse = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.T1Timer_CheckForButtonPress = new System.Windows.Forms.Timer(this.components);
            this.T3Timer_GetJoyStates = new System.Windows.Forms.Timer(this.components);
            this.btnT0_Delete = new System.Windows.Forms.Button();
            this.tabControl_Anzeige.SuspendLayout();
            this.tabPage_Zugauswahl.SuspendLayout();
            this.tabPage_Button.SuspendLayout();
            this.tabPage_Tastenkombi_Erstellen.SuspendLayout();
            this.tabPage_Regler.SuspendLayout();
            this.panelT3_StufenStufenlos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Anzeige
            // 
            this.tabControl_Anzeige.Controls.Add(this.tabPage_Zugauswahl);
            this.tabControl_Anzeige.Controls.Add(this.tabPage_Button);
            this.tabControl_Anzeige.Controls.Add(this.tabPage_Tastenkombi_Erstellen);
            this.tabControl_Anzeige.Controls.Add(this.tabPage_Regler);
            this.tabControl_Anzeige.Location = new System.Drawing.Point(12, 12);
            this.tabControl_Anzeige.Name = "tabControl_Anzeige";
            this.tabControl_Anzeige.SelectedIndex = 0;
            this.tabControl_Anzeige.Size = new System.Drawing.Size(316, 133);
            this.tabControl_Anzeige.TabIndex = 0;
            this.tabControl_Anzeige.SelectedIndexChanged += new System.EventHandler(this.tabControl_Anzeige_SelectedIndexChanged);
            // 
            // tabPage_Zugauswahl
            // 
            this.tabPage_Zugauswahl.Controls.Add(this.btnT0_Delete);
            this.tabPage_Zugauswahl.Controls.Add(this.btnT0_editRegler);
            this.tabPage_Zugauswahl.Controls.Add(this.btnT0_Add);
            this.tabPage_Zugauswahl.Controls.Add(this.btnT0_editButtons);
            this.tabPage_Zugauswahl.Controls.Add(this.label1);
            this.tabPage_Zugauswahl.Controls.Add(this.comboBoxT0_Zugauswahl);
            this.tabPage_Zugauswahl.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Zugauswahl.Name = "tabPage_Zugauswahl";
            this.tabPage_Zugauswahl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Zugauswahl.Size = new System.Drawing.Size(308, 107);
            this.tabPage_Zugauswahl.TabIndex = 0;
            this.tabPage_Zugauswahl.Text = "Zugauswahl";
            this.tabPage_Zugauswahl.UseVisualStyleBackColor = true;
            // 
            // btnT0_editRegler
            // 
            this.btnT0_editRegler.Location = new System.Drawing.Point(9, 75);
            this.btnT0_editRegler.Name = "btnT0_editRegler";
            this.btnT0_editRegler.Size = new System.Drawing.Size(106, 23);
            this.btnT0_editRegler.TabIndex = 5;
            this.btnT0_editRegler.Text = "Regler bearbeiten";
            this.btnT0_editRegler.UseVisualStyleBackColor = true;
            this.btnT0_editRegler.Click += new System.EventHandler(this.btnT0_editRegler_Click);
            // 
            // btnT0_Add
            // 
            this.btnT0_Add.Location = new System.Drawing.Point(146, 19);
            this.btnT0_Add.Name = "btnT0_Add";
            this.btnT0_Add.Size = new System.Drawing.Size(75, 23);
            this.btnT0_Add.TabIndex = 4;
            this.btnT0_Add.Text = "Hinzufügen";
            this.btnT0_Add.UseVisualStyleBackColor = true;
            this.btnT0_Add.Click += new System.EventHandler(this.btnT0_Add_Click);
            // 
            // btnT0_editButtons
            // 
            this.btnT0_editButtons.Location = new System.Drawing.Point(9, 46);
            this.btnT0_editButtons.Name = "btnT0_editButtons";
            this.btnT0_editButtons.Size = new System.Drawing.Size(106, 23);
            this.btnT0_editButtons.TabIndex = 3;
            this.btnT0_editButtons.Text = "Knöpfe bearbeiten";
            this.btnT0_editButtons.UseVisualStyleBackColor = true;
            this.btnT0_editButtons.Click += new System.EventHandler(this.btnT0_editButtons_Click);
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
            this.comboBoxT0_Zugauswahl.FormattingEnabled = true;
            this.comboBoxT0_Zugauswahl.Location = new System.Drawing.Point(9, 19);
            this.comboBoxT0_Zugauswahl.Name = "comboBoxT0_Zugauswahl";
            this.comboBoxT0_Zugauswahl.Size = new System.Drawing.Size(131, 21);
            this.comboBoxT0_Zugauswahl.Sorted = true;
            this.comboBoxT0_Zugauswahl.TabIndex = 1;
            this.comboBoxT0_Zugauswahl.TextChanged += new System.EventHandler(this.comboBoxT0_Zugauswahl_TextChanged);
            // 
            // tabPage_Button
            // 
            this.tabPage_Button.Controls.Add(this.label8);
            this.tabPage_Button.Controls.Add(this.btnT1_Back);
            this.tabPage_Button.Controls.Add(this.btnT1_entfernen);
            this.tabPage_Button.Controls.Add(this.listBoxT1_ShowJoystickStates);
            this.tabPage_Button.Controls.Add(this.lblT1_Bedingung);
            this.tabPage_Button.Controls.Add(this.txtT1_Bedingung);
            this.tabPage_Button.Controls.Add(this.btnT1_Editor);
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
            this.tabPage_Button.Size = new System.Drawing.Size(565, 270);
            this.tabPage_Button.TabIndex = 1;
            this.tabPage_Button.Text = "Button";
            this.tabPage_Button.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Knopf Editor";
            // 
            // btnT1_Back
            // 
            this.btnT1_Back.Location = new System.Drawing.Point(6, 215);
            this.btnT1_Back.Name = "btnT1_Back";
            this.btnT1_Back.Size = new System.Drawing.Size(35, 23);
            this.btnT1_Back.TabIndex = 20;
            this.btnT1_Back.Text = "<<--";
            this.btnT1_Back.UseVisualStyleBackColor = true;
            this.btnT1_Back.Click += new System.EventHandler(this.btnT1_Back_Click);
            // 
            // btnT1_entfernen
            // 
            this.btnT1_entfernen.Location = new System.Drawing.Point(129, 50);
            this.btnT1_entfernen.Name = "btnT1_entfernen";
            this.btnT1_entfernen.Size = new System.Drawing.Size(62, 21);
            this.btnT1_entfernen.TabIndex = 19;
            this.btnT1_entfernen.Text = "Entfernen";
            this.btnT1_entfernen.UseVisualStyleBackColor = true;
            this.btnT1_entfernen.Click += new System.EventHandler(this.btnT1_entfernen_Click);
            // 
            // listBoxT1_ShowJoystickStates
            // 
            this.listBoxT1_ShowJoystickStates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxT1_ShowJoystickStates.FormattingEnabled = true;
            this.listBoxT1_ShowJoystickStates.Location = new System.Drawing.Point(227, 34);
            this.listBoxT1_ShowJoystickStates.Name = "listBoxT1_ShowJoystickStates";
            this.listBoxT1_ShowJoystickStates.Size = new System.Drawing.Size(120, 91);
            this.listBoxT1_ShowJoystickStates.TabIndex = 18;
            // 
            // lblT1_Bedingung
            // 
            this.lblT1_Bedingung.AutoSize = true;
            this.lblT1_Bedingung.Location = new System.Drawing.Point(104, 138);
            this.lblT1_Bedingung.Name = "lblT1_Bedingung";
            this.lblT1_Bedingung.Size = new System.Drawing.Size(58, 13);
            this.lblT1_Bedingung.TabIndex = 17;
            this.lblT1_Bedingung.Text = "Bedingung";
            // 
            // txtT1_Bedingung
            // 
            this.txtT1_Bedingung.Location = new System.Drawing.Point(97, 154);
            this.txtT1_Bedingung.Name = "txtT1_Bedingung";
            this.txtT1_Bedingung.Size = new System.Drawing.Size(72, 20);
            this.txtT1_Bedingung.TabIndex = 16;
            this.txtT1_Bedingung.Text = "11";
            this.txtT1_Bedingung.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnT1_Editor
            // 
            this.btnT1_Editor.Location = new System.Drawing.Point(247, 180);
            this.btnT1_Editor.Name = "btnT1_Editor";
            this.btnT1_Editor.Size = new System.Drawing.Size(100, 23);
            this.btnT1_Editor.TabIndex = 15;
            this.btnT1_Editor.Text = "Editor";
            this.btnT1_Editor.UseVisualStyleBackColor = true;
            this.btnT1_Editor.Click += new System.EventHandler(this.btnT1_Editor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tastenkombination";
            // 
            // txtT1_Tastenkombination
            // 
            this.txtT1_Tastenkombination.Location = new System.Drawing.Point(247, 154);
            this.txtT1_Tastenkombination.Name = "txtT1_Tastenkombination";
            this.txtT1_Tastenkombination.Size = new System.Drawing.Size(100, 20);
            this.txtT1_Tastenkombination.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Aktion";
            // 
            // txtT1_Aktion
            // 
            this.txtT1_Aktion.Location = new System.Drawing.Point(197, 154);
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
            this.label4.Location = new System.Drawing.Point(6, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Name";
            // 
            // btnT1_Hinzufuegen_ersetzen
            // 
            this.btnT1_Hinzufuegen_ersetzen.Location = new System.Drawing.Point(224, 218);
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
            this.comboBoxT1_KnopfAuswahl.Location = new System.Drawing.Point(6, 50);
            this.comboBoxT1_KnopfAuswahl.Name = "comboBoxT1_KnopfAuswahl";
            this.comboBoxT1_KnopfAuswahl.Size = new System.Drawing.Size(121, 21);
            this.comboBoxT1_KnopfAuswahl.TabIndex = 8;
            this.comboBoxT1_KnopfAuswahl.SelectedIndexChanged += new System.EventHandler(this.comboBoxT1_KnopfAuswahl_SelectedIndexChanged);
            this.comboBoxT1_KnopfAuswahl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxT1_KnopfAuswahl_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Joy-Nr";
            // 
            // txtT1_JoystickNr
            // 
            this.txtT1_JoystickNr.Location = new System.Drawing.Point(6, 154);
            this.txtT1_JoystickNr.Name = "txtT1_JoystickNr";
            this.txtT1_JoystickNr.Size = new System.Drawing.Size(35, 20);
            this.txtT1_JoystickNr.TabIndex = 6;
            this.txtT1_JoystickNr.Text = "0";
            this.txtT1_JoystickNr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnT1_Erkennen
            // 
            this.btnT1_Erkennen.Location = new System.Drawing.Point(6, 180);
            this.btnT1_Erkennen.Name = "btnT1_Erkennen";
            this.btnT1_Erkennen.Size = new System.Drawing.Size(85, 23);
            this.btnT1_Erkennen.TabIndex = 5;
            this.btnT1_Erkennen.Text = "Erkennen";
            this.btnT1_Erkennen.UseVisualStyleBackColor = true;
            this.btnT1_Erkennen.Click += new System.EventHandler(this.btnT1_Erkennen_Click);
            // 
            // lblT1_KnopfNr
            // 
            this.lblT1_KnopfNr.AutoSize = true;
            this.lblT1_KnopfNr.Location = new System.Drawing.Point(44, 138);
            this.lblT1_KnopfNr.Name = "lblT1_KnopfNr";
            this.lblT1_KnopfNr.Size = new System.Drawing.Size(47, 13);
            this.lblT1_KnopfNr.TabIndex = 4;
            this.lblT1_KnopfNr.Text = "Knopfnr.";
            // 
            // txtT1_JoystickKnopf
            // 
            this.txtT1_JoystickKnopf.Location = new System.Drawing.Point(47, 154);
            this.txtT1_JoystickKnopf.Name = "txtT1_JoystickKnopf";
            this.txtT1_JoystickKnopf.Size = new System.Drawing.Size(44, 20);
            this.txtT1_JoystickKnopf.TabIndex = 3;
            this.txtT1_JoystickKnopf.Text = "11";
            this.txtT1_JoystickKnopf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioT1_regler
            // 
            this.radioT1_regler.AutoSize = true;
            this.radioT1_regler.Location = new System.Drawing.Point(6, 100);
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
            this.radioT1_normal.Location = new System.Drawing.Point(6, 77);
            this.radioT1_normal.Name = "radioT1_normal";
            this.radioT1_normal.Size = new System.Drawing.Size(96, 17);
            this.radioT1_normal.TabIndex = 1;
            this.radioT1_normal.TabStop = true;
            this.radioT1_normal.Text = "normaler Knopf";
            this.radioT1_normal.UseVisualStyleBackColor = true;
            this.radioT1_normal.CheckedChanged += new System.EventHandler(this.radioT1_normal_CheckedChanged);
            // 
            // tabPage_Tastenkombi_Erstellen
            // 
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.btnT2_Fertig);
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.btnT2_Hinzufügen);
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.label9);
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.txtT2_Wartezeit);
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.lblT2_haltezeit);
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.txtT2_Haltezeit);
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.radioT2_Loslassen);
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.radioT2_Druecken);
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.radioT2_Halten);
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.radioT2_einmalDruecken);
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.label7);
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.txtT2_Taste);
            this.tabPage_Tastenkombi_Erstellen.Controls.Add(this.listBoxT2_Output);
            this.tabPage_Tastenkombi_Erstellen.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Tastenkombi_Erstellen.Name = "tabPage_Tastenkombi_Erstellen";
            this.tabPage_Tastenkombi_Erstellen.Size = new System.Drawing.Size(565, 270);
            this.tabPage_Tastenkombi_Erstellen.TabIndex = 2;
            this.tabPage_Tastenkombi_Erstellen.Text = "Tastenkombi Erstellen";
            this.tabPage_Tastenkombi_Erstellen.UseVisualStyleBackColor = true;
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
            // tabPage_Regler
            // 
            this.tabPage_Regler.Controls.Add(this.btnT3_ZeitfaktorFinden);
            this.tabPage_Regler.Controls.Add(this.button1);
            this.tabPage_Regler.Controls.Add(this.label17);
            this.tabPage_Regler.Controls.Add(this.txtT3_Beschreibung);
            this.tabPage_Regler.Controls.Add(this.listBoxT3_ShowJoystickStates);
            this.tabPage_Regler.Controls.Add(this.btnT3_leeren);
            this.tabPage_Regler.Controls.Add(this.btnT3_Speichern);
            this.tabPage_Regler.Controls.Add(this.label16);
            this.tabPage_Regler.Controls.Add(this.txtT3_LongPress);
            this.tabPage_Regler.Controls.Add(this.label15);
            this.tabPage_Regler.Controls.Add(this.txtT3_Zeitfaktor);
            this.tabPage_Regler.Controls.Add(this.label14);
            this.tabPage_Regler.Controls.Add(this.txtT3_Sonderfaelle);
            this.tabPage_Regler.Controls.Add(this.txtT3_JoyUmrechnen);
            this.tabPage_Regler.Controls.Add(this.label13);
            this.tabPage_Regler.Controls.Add(this.txtT3_AnzahlStufen);
            this.tabPage_Regler.Controls.Add(this.lblT3_AnzahlStufen);
            this.tabPage_Regler.Controls.Add(this.txtT3_JoyNr);
            this.tabPage_Regler.Controls.Add(this.label11);
            this.tabPage_Regler.Controls.Add(this.checkT3_andererJoyModus);
            this.tabPage_Regler.Controls.Add(this.checkT3_Invertiert);
            this.tabPage_Regler.Controls.Add(this.txtT3_JoyAchse);
            this.tabPage_Regler.Controls.Add(this.label2);
            this.tabPage_Regler.Controls.Add(this.panelT3_StufenStufenlos);
            this.tabPage_Regler.Controls.Add(this.panel1);
            this.tabPage_Regler.Controls.Add(this.label10);
            this.tabPage_Regler.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Regler.Name = "tabPage_Regler";
            this.tabPage_Regler.Size = new System.Drawing.Size(565, 270);
            this.tabPage_Regler.TabIndex = 3;
            this.tabPage_Regler.Text = "Regler";
            this.tabPage_Regler.UseVisualStyleBackColor = true;
            // 
            // btnT3_ZeitfaktorFinden
            // 
            this.btnT3_ZeitfaktorFinden.Location = new System.Drawing.Point(418, 89);
            this.btnT3_ZeitfaktorFinden.Name = "btnT3_ZeitfaktorFinden";
            this.btnT3_ZeitfaktorFinden.Size = new System.Drawing.Size(137, 23);
            this.btnT3_ZeitfaktorFinden.TabIndex = 49;
            this.btnT3_ZeitfaktorFinden.Text = "Zeitfaktor finden";
            this.btnT3_ZeitfaktorFinden.UseVisualStyleBackColor = true;
            this.btnT3_ZeitfaktorFinden.Click += new System.EventHandler(this.btnT3_ZeitfaktorFinden_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "<<--";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnT1_Back_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(385, 224);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 13);
            this.label17.TabIndex = 47;
            this.label17.Text = "Beschreibung";
            // 
            // txtT3_Beschreibung
            // 
            this.txtT3_Beschreibung.Location = new System.Drawing.Point(374, 239);
            this.txtT3_Beschreibung.Name = "txtT3_Beschreibung";
            this.txtT3_Beschreibung.Size = new System.Drawing.Size(100, 20);
            this.txtT3_Beschreibung.TabIndex = 46;
            // 
            // listBoxT3_ShowJoystickStates
            // 
            this.listBoxT3_ShowJoystickStates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxT3_ShowJoystickStates.FormattingEnabled = true;
            this.listBoxT3_ShowJoystickStates.Location = new System.Drawing.Point(435, 5);
            this.listBoxT3_ShowJoystickStates.Name = "listBoxT3_ShowJoystickStates";
            this.listBoxT3_ShowJoystickStates.Size = new System.Drawing.Size(120, 91);
            this.listBoxT3_ShowJoystickStates.TabIndex = 45;
            // 
            // btnT3_leeren
            // 
            this.btnT3_leeren.Location = new System.Drawing.Point(236, 41);
            this.btnT3_leeren.Name = "btnT3_leeren";
            this.btnT3_leeren.Size = new System.Drawing.Size(51, 23);
            this.btnT3_leeren.TabIndex = 44;
            this.btnT3_leeren.Text = "Leeren";
            this.btnT3_leeren.UseVisualStyleBackColor = true;
            this.btnT3_leeren.Click += new System.EventHandler(this.btnT3_leeren_Click);
            // 
            // btnT3_Speichern
            // 
            this.btnT3_Speichern.Location = new System.Drawing.Point(480, 237);
            this.btnT3_Speichern.Name = "btnT3_Speichern";
            this.btnT3_Speichern.Size = new System.Drawing.Size(75, 23);
            this.btnT3_Speichern.TabIndex = 43;
            this.btnT3_Speichern.Text = "Speichern";
            this.btnT3_Speichern.UseVisualStyleBackColor = true;
            this.btnT3_Speichern.Click += new System.EventHandler(this.btnT3_Speichern_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(473, 115);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "Länger drücken";
            // 
            // txtT3_LongPress
            // 
            this.txtT3_LongPress.Location = new System.Drawing.Point(473, 131);
            this.txtT3_LongPress.Name = "txtT3_LongPress";
            this.txtT3_LongPress.Size = new System.Drawing.Size(82, 20);
            this.txtT3_LongPress.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(415, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Zeitfaktor";
            // 
            // txtT3_Zeitfaktor
            // 
            this.txtT3_Zeitfaktor.Location = new System.Drawing.Point(415, 131);
            this.txtT3_Zeitfaktor.Name = "txtT3_Zeitfaktor";
            this.txtT3_Zeitfaktor.Size = new System.Drawing.Size(52, 20);
            this.txtT3_Zeitfaktor.TabIndex = 39;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(255, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Sonderfälle umrechnen";
            // 
            // txtT3_Sonderfaelle
            // 
            this.txtT3_Sonderfaelle.Location = new System.Drawing.Point(211, 178);
            this.txtT3_Sonderfaelle.Name = "txtT3_Sonderfaelle";
            this.txtT3_Sonderfaelle.Size = new System.Drawing.Size(198, 20);
            this.txtT3_Sonderfaelle.TabIndex = 37;
            // 
            // txtT3_JoyUmrechnen
            // 
            this.txtT3_JoyUmrechnen.Location = new System.Drawing.Point(211, 131);
            this.txtT3_JoyUmrechnen.Name = "txtT3_JoyUmrechnen";
            this.txtT3_JoyUmrechnen.Size = new System.Drawing.Size(198, 20);
            this.txtT3_JoyUmrechnen.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(274, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Joy umrechnen";
            // 
            // txtT3_AnzahlStufen
            // 
            this.txtT3_AnzahlStufen.Location = new System.Drawing.Point(117, 131);
            this.txtT3_AnzahlStufen.Name = "txtT3_AnzahlStufen";
            this.txtT3_AnzahlStufen.Size = new System.Drawing.Size(88, 20);
            this.txtT3_AnzahlStufen.TabIndex = 34;
            // 
            // lblT3_AnzahlStufen
            // 
            this.lblT3_AnzahlStufen.AutoSize = true;
            this.lblT3_AnzahlStufen.Location = new System.Drawing.Point(114, 115);
            this.lblT3_AnzahlStufen.Name = "lblT3_AnzahlStufen";
            this.lblT3_AnzahlStufen.Size = new System.Drawing.Size(91, 13);
            this.lblT3_AnzahlStufen.TabIndex = 33;
            this.lblT3_AnzahlStufen.Text = "Anzahl der Stufen";
            // 
            // txtT3_JoyNr
            // 
            this.txtT3_JoyNr.Location = new System.Drawing.Point(9, 131);
            this.txtT3_JoyNr.Name = "txtT3_JoyNr";
            this.txtT3_JoyNr.Size = new System.Drawing.Size(37, 20);
            this.txtT3_JoyNr.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Joy-Nr";
            // 
            // checkT3_andererJoyModus
            // 
            this.checkT3_andererJoyModus.AutoSize = true;
            this.checkT3_andererJoyModus.Location = new System.Drawing.Point(52, 181);
            this.checkT3_andererJoyModus.Name = "checkT3_andererJoyModus";
            this.checkT3_andererJoyModus.Size = new System.Drawing.Size(117, 17);
            this.checkT3_andererJoyModus.TabIndex = 30;
            this.checkT3_andererJoyModus.Text = "Anderer Joy-Modus";
            this.checkT3_andererJoyModus.UseVisualStyleBackColor = true;
            // 
            // checkT3_Invertiert
            // 
            this.checkT3_Invertiert.AutoSize = true;
            this.checkT3_Invertiert.Location = new System.Drawing.Point(53, 158);
            this.checkT3_Invertiert.Name = "checkT3_Invertiert";
            this.checkT3_Invertiert.Size = new System.Drawing.Size(67, 17);
            this.checkT3_Invertiert.TabIndex = 29;
            this.checkT3_Invertiert.Text = "Invertiert";
            this.checkT3_Invertiert.UseVisualStyleBackColor = true;
            // 
            // txtT3_JoyAchse
            // 
            this.txtT3_JoyAchse.Location = new System.Drawing.Point(52, 131);
            this.txtT3_JoyAchse.Name = "txtT3_JoyAchse";
            this.txtT3_JoyAchse.Size = new System.Drawing.Size(56, 20);
            this.txtT3_JoyAchse.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Joy-Achse";
            // 
            // panelT3_StufenStufenlos
            // 
            this.panelT3_StufenStufenlos.Controls.Add(this.radioT3_Stufenlos);
            this.panelT3_StufenStufenlos.Controls.Add(this.radioT3_Stufen);
            this.panelT3_StufenStufenlos.Enabled = false;
            this.panelT3_StufenStufenlos.Location = new System.Drawing.Point(6, 70);
            this.panelT3_StufenStufenlos.Name = "panelT3_StufenStufenlos";
            this.panelT3_StufenStufenlos.Size = new System.Drawing.Size(136, 26);
            this.panelT3_StufenStufenlos.TabIndex = 26;
            // 
            // radioT3_Stufenlos
            // 
            this.radioT3_Stufenlos.AutoSize = true;
            this.radioT3_Stufenlos.Location = new System.Drawing.Point(3, 3);
            this.radioT3_Stufenlos.Name = "radioT3_Stufenlos";
            this.radioT3_Stufenlos.Size = new System.Drawing.Size(69, 17);
            this.radioT3_Stufenlos.TabIndex = 1;
            this.radioT3_Stufenlos.Text = "Stufenlos";
            this.radioT3_Stufenlos.UseVisualStyleBackColor = true;
            this.radioT3_Stufenlos.CheckedChanged += new System.EventHandler(this.radioT3_StufenStufenlos_CheckedChanged);
            // 
            // radioT3_Stufen
            // 
            this.radioT3_Stufen.AutoSize = true;
            this.radioT3_Stufen.Location = new System.Drawing.Point(78, 3);
            this.radioT3_Stufen.Name = "radioT3_Stufen";
            this.radioT3_Stufen.Size = new System.Drawing.Size(56, 17);
            this.radioT3_Stufen.TabIndex = 23;
            this.radioT3_Stufen.Text = "Stufen";
            this.radioT3_Stufen.UseVisualStyleBackColor = true;
            this.radioT3_Stufen.CheckedChanged += new System.EventHandler(this.radioT3_StufenStufenlos_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioT3_Schub);
            this.panel1.Controls.Add(this.radioT3_Kombihebel);
            this.panel1.Controls.Add(this.radioT3_Bremse);
            this.panel1.Location = new System.Drawing.Point(6, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 26);
            this.panel1.TabIndex = 25;
            // 
            // radioT3_Schub
            // 
            this.radioT3_Schub.AutoSize = true;
            this.radioT3_Schub.Location = new System.Drawing.Point(3, 3);
            this.radioT3_Schub.Name = "radioT3_Schub";
            this.radioT3_Schub.Size = new System.Drawing.Size(56, 17);
            this.radioT3_Schub.TabIndex = 1;
            this.radioT3_Schub.Text = "Schub";
            this.radioT3_Schub.UseVisualStyleBackColor = true;
            this.radioT3_Schub.CheckedChanged += new System.EventHandler(this.radioT3_SchubBremseKombihebel_CheckedChanged);
            // 
            // radioT3_Kombihebel
            // 
            this.radioT3_Kombihebel.AutoSize = true;
            this.radioT3_Kombihebel.Location = new System.Drawing.Point(131, 3);
            this.radioT3_Kombihebel.Name = "radioT3_Kombihebel";
            this.radioT3_Kombihebel.Size = new System.Drawing.Size(80, 17);
            this.radioT3_Kombihebel.TabIndex = 24;
            this.radioT3_Kombihebel.Text = "Kombihebel";
            this.radioT3_Kombihebel.UseVisualStyleBackColor = true;
            this.radioT3_Kombihebel.CheckedChanged += new System.EventHandler(this.radioT3_SchubBremseKombihebel_CheckedChanged);
            // 
            // radioT3_Bremse
            // 
            this.radioT3_Bremse.AutoSize = true;
            this.radioT3_Bremse.Location = new System.Drawing.Point(65, 3);
            this.radioT3_Bremse.Name = "radioT3_Bremse";
            this.radioT3_Bremse.Size = new System.Drawing.Size(60, 17);
            this.radioT3_Bremse.TabIndex = 23;
            this.radioT3_Bremse.Text = "Bremse";
            this.radioT3_Bremse.UseVisualStyleBackColor = true;
            this.radioT3_Bremse.CheckedChanged += new System.EventHandler(this.radioT3_SchubBremseKombihebel_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Regler Editor";
            // 
            // T1Timer_CheckForButtonPress
            // 
            this.T1Timer_CheckForButtonPress.Tick += new System.EventHandler(this.T1Timer_CheckForButtonPress_Tick);
            // 
            // T3Timer_GetJoyStates
            // 
            this.T3Timer_GetJoyStates.Enabled = true;
            this.T3Timer_GetJoyStates.Tick += new System.EventHandler(this.T3Timer_GetJoyStates_Tick);
            // 
            // btnT0_Delete
            // 
            this.btnT0_Delete.Location = new System.Drawing.Point(227, 19);
            this.btnT0_Delete.Name = "btnT0_Delete";
            this.btnT0_Delete.Size = new System.Drawing.Size(75, 23);
            this.btnT0_Delete.TabIndex = 6;
            this.btnT0_Delete.Text = "Löschen";
            this.btnT0_Delete.UseVisualStyleBackColor = true;
            this.btnT0_Delete.Click += new System.EventHandler(this.btnT0_Delete_Click);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormSteuerung";
            this.tabControl_Anzeige.ResumeLayout(false);
            this.tabPage_Zugauswahl.ResumeLayout(false);
            this.tabPage_Zugauswahl.PerformLayout();
            this.tabPage_Button.ResumeLayout(false);
            this.tabPage_Button.PerformLayout();
            this.tabPage_Tastenkombi_Erstellen.ResumeLayout(false);
            this.tabPage_Tastenkombi_Erstellen.PerformLayout();
            this.tabPage_Regler.ResumeLayout(false);
            this.tabPage_Regler.PerformLayout();
            this.panelT3_StufenStufenlos.ResumeLayout(false);
            this.panelT3_StufenStufenlos.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Anzeige;
        private System.Windows.Forms.TabPage tabPage_Zugauswahl;
        private System.Windows.Forms.TabPage tabPage_Button;
        private System.Windows.Forms.ComboBox comboBoxT0_Zugauswahl;
        private System.Windows.Forms.Button btnT0_Add;
        private System.Windows.Forms.Button btnT0_editButtons;
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
        private System.Windows.Forms.Button btnT1_Editor;
        private System.Windows.Forms.TabPage tabPage_Tastenkombi_Erstellen;
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
        private System.Windows.Forms.Timer T1Timer_CheckForButtonPress;
        private System.Windows.Forms.Label lblT1_Bedingung;
        private System.Windows.Forms.TextBox txtT1_Bedingung;
        private System.Windows.Forms.ListBox listBoxT1_ShowJoystickStates;
        private System.Windows.Forms.Button btnT1_entfernen;
        private System.Windows.Forms.Button btnT1_Back;
        private System.Windows.Forms.TabPage tabPage_Regler;
        private System.Windows.Forms.Button btnT0_editRegler;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioT3_Schub;
        private System.Windows.Forms.RadioButton radioT3_Kombihebel;
        private System.Windows.Forms.RadioButton radioT3_Bremse;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtT3_JoyAchse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelT3_StufenStufenlos;
        private System.Windows.Forms.RadioButton radioT3_Stufenlos;
        private System.Windows.Forms.RadioButton radioT3_Stufen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtT3_JoyNr;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkT3_andererJoyModus;
        private System.Windows.Forms.CheckBox checkT3_Invertiert;
        private System.Windows.Forms.TextBox txtT3_AnzahlStufen;
        private System.Windows.Forms.Label lblT3_AnzahlStufen;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtT3_LongPress;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtT3_Zeitfaktor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtT3_Sonderfaelle;
        private System.Windows.Forms.TextBox txtT3_JoyUmrechnen;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnT3_Speichern;
        private System.Windows.Forms.Button btnT3_leeren;
        private System.Windows.Forms.ListBox listBoxT3_ShowJoystickStates;
        private System.Windows.Forms.Timer T3Timer_GetJoyStates;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtT3_Beschreibung;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnT3_ZeitfaktorFinden;
        private System.Windows.Forms.Button btnT0_Delete;
    }
}