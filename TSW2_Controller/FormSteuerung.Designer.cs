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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSteuerung));
            this.tabControl_Anzeige = new System.Windows.Forms.TabControl();
            this.tabPage_Zugauswahl = new System.Windows.Forms.TabPage();
            this.btnT0_Delete = new System.Windows.Forms.Button();
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
            resources.ApplyResources(this.tabControl_Anzeige, "tabControl_Anzeige");
            this.tabControl_Anzeige.Name = "tabControl_Anzeige";
            this.tabControl_Anzeige.SelectedIndex = 0;
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
            resources.ApplyResources(this.tabPage_Zugauswahl, "tabPage_Zugauswahl");
            this.tabPage_Zugauswahl.Name = "tabPage_Zugauswahl";
            this.tabPage_Zugauswahl.UseVisualStyleBackColor = true;
            // 
            // btnT0_Delete
            // 
            resources.ApplyResources(this.btnT0_Delete, "btnT0_Delete");
            this.btnT0_Delete.Name = "btnT0_Delete";
            this.btnT0_Delete.UseVisualStyleBackColor = true;
            this.btnT0_Delete.Click += new System.EventHandler(this.btnT0_Delete_Click);
            // 
            // btnT0_editRegler
            // 
            resources.ApplyResources(this.btnT0_editRegler, "btnT0_editRegler");
            this.btnT0_editRegler.Name = "btnT0_editRegler";
            this.btnT0_editRegler.UseVisualStyleBackColor = true;
            this.btnT0_editRegler.Click += new System.EventHandler(this.btnT0_editRegler_Click);
            // 
            // btnT0_Add
            // 
            resources.ApplyResources(this.btnT0_Add, "btnT0_Add");
            this.btnT0_Add.Name = "btnT0_Add";
            this.btnT0_Add.UseVisualStyleBackColor = true;
            this.btnT0_Add.Click += new System.EventHandler(this.btnT0_Add_Click);
            // 
            // btnT0_editButtons
            // 
            resources.ApplyResources(this.btnT0_editButtons, "btnT0_editButtons");
            this.btnT0_editButtons.Name = "btnT0_editButtons";
            this.btnT0_editButtons.UseVisualStyleBackColor = true;
            this.btnT0_editButtons.Click += new System.EventHandler(this.btnT0_editButtons_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBoxT0_Zugauswahl
            // 
            this.comboBoxT0_Zugauswahl.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxT0_Zugauswahl, "comboBoxT0_Zugauswahl");
            this.comboBoxT0_Zugauswahl.Name = "comboBoxT0_Zugauswahl";
            this.comboBoxT0_Zugauswahl.Sorted = true;
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
            resources.ApplyResources(this.tabPage_Button, "tabPage_Button");
            this.tabPage_Button.Name = "tabPage_Button";
            this.tabPage_Button.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // btnT1_Back
            // 
            resources.ApplyResources(this.btnT1_Back, "btnT1_Back");
            this.btnT1_Back.Name = "btnT1_Back";
            this.btnT1_Back.UseVisualStyleBackColor = true;
            this.btnT1_Back.Click += new System.EventHandler(this.btnT1_Back_Click);
            // 
            // btnT1_entfernen
            // 
            resources.ApplyResources(this.btnT1_entfernen, "btnT1_entfernen");
            this.btnT1_entfernen.Name = "btnT1_entfernen";
            this.btnT1_entfernen.UseVisualStyleBackColor = true;
            this.btnT1_entfernen.Click += new System.EventHandler(this.btnT1_entfernen_Click);
            // 
            // listBoxT1_ShowJoystickStates
            // 
            this.listBoxT1_ShowJoystickStates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxT1_ShowJoystickStates.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxT1_ShowJoystickStates, "listBoxT1_ShowJoystickStates");
            this.listBoxT1_ShowJoystickStates.Name = "listBoxT1_ShowJoystickStates";
            // 
            // lblT1_Bedingung
            // 
            resources.ApplyResources(this.lblT1_Bedingung, "lblT1_Bedingung");
            this.lblT1_Bedingung.Name = "lblT1_Bedingung";
            // 
            // txtT1_Bedingung
            // 
            resources.ApplyResources(this.txtT1_Bedingung, "txtT1_Bedingung");
            this.txtT1_Bedingung.Name = "txtT1_Bedingung";
            // 
            // btnT1_Editor
            // 
            resources.ApplyResources(this.btnT1_Editor, "btnT1_Editor");
            this.btnT1_Editor.Name = "btnT1_Editor";
            this.btnT1_Editor.UseVisualStyleBackColor = true;
            this.btnT1_Editor.Click += new System.EventHandler(this.btnT1_Editor_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtT1_Tastenkombination
            // 
            resources.ApplyResources(this.txtT1_Tastenkombination, "txtT1_Tastenkombination");
            this.txtT1_Tastenkombination.Name = "txtT1_Tastenkombination";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtT1_Aktion
            // 
            resources.ApplyResources(this.txtT1_Aktion, "txtT1_Aktion");
            this.txtT1_Aktion.Name = "txtT1_Aktion";
            this.txtT1_Aktion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtT1_Aktion_KeyDown);
            this.txtT1_Aktion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtT1_Aktion_MouseDown);
            this.txtT1_Aktion.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtT1_Aktion_PreviewKeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btnT1_Hinzufuegen_ersetzen
            // 
            resources.ApplyResources(this.btnT1_Hinzufuegen_ersetzen, "btnT1_Hinzufuegen_ersetzen");
            this.btnT1_Hinzufuegen_ersetzen.Name = "btnT1_Hinzufuegen_ersetzen";
            this.btnT1_Hinzufuegen_ersetzen.UseVisualStyleBackColor = true;
            this.btnT1_Hinzufuegen_ersetzen.Click += new System.EventHandler(this.btnT1_Hinzufuegen_ersetzen_Click);
            // 
            // comboBoxT1_KnopfAuswahl
            // 
            this.comboBoxT1_KnopfAuswahl.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxT1_KnopfAuswahl, "comboBoxT1_KnopfAuswahl");
            this.comboBoxT1_KnopfAuswahl.Name = "comboBoxT1_KnopfAuswahl";
            this.comboBoxT1_KnopfAuswahl.SelectedIndexChanged += new System.EventHandler(this.comboBoxT1_KnopfAuswahl_SelectedIndexChanged);
            this.comboBoxT1_KnopfAuswahl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxT1_KnopfAuswahl_KeyPress);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtT1_JoystickNr
            // 
            resources.ApplyResources(this.txtT1_JoystickNr, "txtT1_JoystickNr");
            this.txtT1_JoystickNr.Name = "txtT1_JoystickNr";
            // 
            // btnT1_Erkennen
            // 
            resources.ApplyResources(this.btnT1_Erkennen, "btnT1_Erkennen");
            this.btnT1_Erkennen.Name = "btnT1_Erkennen";
            this.btnT1_Erkennen.UseVisualStyleBackColor = true;
            this.btnT1_Erkennen.Click += new System.EventHandler(this.btnT1_Erkennen_Click);
            // 
            // lblT1_KnopfNr
            // 
            resources.ApplyResources(this.lblT1_KnopfNr, "lblT1_KnopfNr");
            this.lblT1_KnopfNr.Name = "lblT1_KnopfNr";
            // 
            // txtT1_JoystickKnopf
            // 
            resources.ApplyResources(this.txtT1_JoystickKnopf, "txtT1_JoystickKnopf");
            this.txtT1_JoystickKnopf.Name = "txtT1_JoystickKnopf";
            // 
            // radioT1_regler
            // 
            resources.ApplyResources(this.radioT1_regler, "radioT1_regler");
            this.radioT1_regler.Name = "radioT1_regler";
            this.radioT1_regler.TabStop = true;
            this.radioT1_regler.UseVisualStyleBackColor = true;
            // 
            // radioT1_normal
            // 
            resources.ApplyResources(this.radioT1_normal, "radioT1_normal");
            this.radioT1_normal.Checked = true;
            this.radioT1_normal.Name = "radioT1_normal";
            this.radioT1_normal.TabStop = true;
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
            resources.ApplyResources(this.tabPage_Tastenkombi_Erstellen, "tabPage_Tastenkombi_Erstellen");
            this.tabPage_Tastenkombi_Erstellen.Name = "tabPage_Tastenkombi_Erstellen";
            this.tabPage_Tastenkombi_Erstellen.UseVisualStyleBackColor = true;
            // 
            // btnT2_Fertig
            // 
            resources.ApplyResources(this.btnT2_Fertig, "btnT2_Fertig");
            this.btnT2_Fertig.Name = "btnT2_Fertig";
            this.btnT2_Fertig.UseVisualStyleBackColor = true;
            this.btnT2_Fertig.Click += new System.EventHandler(this.btnT2_Fertig_Click);
            // 
            // btnT2_Hinzufügen
            // 
            resources.ApplyResources(this.btnT2_Hinzufügen, "btnT2_Hinzufügen");
            this.btnT2_Hinzufügen.Name = "btnT2_Hinzufügen";
            this.btnT2_Hinzufügen.UseVisualStyleBackColor = true;
            this.btnT2_Hinzufügen.Click += new System.EventHandler(this.btnT2_Hinzufügen_Click);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtT2_Wartezeit
            // 
            resources.ApplyResources(this.txtT2_Wartezeit, "txtT2_Wartezeit");
            this.txtT2_Wartezeit.Name = "txtT2_Wartezeit";
            this.txtT2_Wartezeit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtT2_Haltezeit_KeyPress);
            // 
            // lblT2_haltezeit
            // 
            resources.ApplyResources(this.lblT2_haltezeit, "lblT2_haltezeit");
            this.lblT2_haltezeit.Name = "lblT2_haltezeit";
            // 
            // txtT2_Haltezeit
            // 
            resources.ApplyResources(this.txtT2_Haltezeit, "txtT2_Haltezeit");
            this.txtT2_Haltezeit.Name = "txtT2_Haltezeit";
            this.txtT2_Haltezeit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtT2_Haltezeit_KeyPress);
            // 
            // radioT2_Loslassen
            // 
            resources.ApplyResources(this.radioT2_Loslassen, "radioT2_Loslassen");
            this.radioT2_Loslassen.Name = "radioT2_Loslassen";
            this.radioT2_Loslassen.TabStop = true;
            this.radioT2_Loslassen.UseVisualStyleBackColor = true;
            this.radioT2_Loslassen.CheckedChanged += new System.EventHandler(this.radio_Changed);
            // 
            // radioT2_Druecken
            // 
            resources.ApplyResources(this.radioT2_Druecken, "radioT2_Druecken");
            this.radioT2_Druecken.Name = "radioT2_Druecken";
            this.radioT2_Druecken.TabStop = true;
            this.radioT2_Druecken.UseVisualStyleBackColor = true;
            this.radioT2_Druecken.CheckedChanged += new System.EventHandler(this.radio_Changed);
            // 
            // radioT2_Halten
            // 
            resources.ApplyResources(this.radioT2_Halten, "radioT2_Halten");
            this.radioT2_Halten.Name = "radioT2_Halten";
            this.radioT2_Halten.TabStop = true;
            this.radioT2_Halten.UseVisualStyleBackColor = true;
            this.radioT2_Halten.CheckedChanged += new System.EventHandler(this.radio_Changed);
            // 
            // radioT2_einmalDruecken
            // 
            resources.ApplyResources(this.radioT2_einmalDruecken, "radioT2_einmalDruecken");
            this.radioT2_einmalDruecken.Checked = true;
            this.radioT2_einmalDruecken.Name = "radioT2_einmalDruecken";
            this.radioT2_einmalDruecken.TabStop = true;
            this.radioT2_einmalDruecken.UseVisualStyleBackColor = true;
            this.radioT2_einmalDruecken.CheckedChanged += new System.EventHandler(this.radio_Changed);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtT2_Taste
            // 
            resources.ApplyResources(this.txtT2_Taste, "txtT2_Taste");
            this.txtT2_Taste.Name = "txtT2_Taste";
            this.txtT2_Taste.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtT2_Taste_KeyDown);
            // 
            // listBoxT2_Output
            // 
            this.listBoxT2_Output.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxT2_Output, "listBoxT2_Output");
            this.listBoxT2_Output.Name = "listBoxT2_Output";
            this.listBoxT2_Output.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxT2_Output_KeyDown);
            // 
            // tabPage_Regler
            // 
            this.tabPage_Regler.Controls.Add(this.btnT3_ZeitfaktorFinden);
            this.tabPage_Regler.Controls.Add(this.button1);
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
            resources.ApplyResources(this.tabPage_Regler, "tabPage_Regler");
            this.tabPage_Regler.Name = "tabPage_Regler";
            this.tabPage_Regler.UseVisualStyleBackColor = true;
            // 
            // btnT3_ZeitfaktorFinden
            // 
            resources.ApplyResources(this.btnT3_ZeitfaktorFinden, "btnT3_ZeitfaktorFinden");
            this.btnT3_ZeitfaktorFinden.Name = "btnT3_ZeitfaktorFinden";
            this.btnT3_ZeitfaktorFinden.UseVisualStyleBackColor = true;
            this.btnT3_ZeitfaktorFinden.Click += new System.EventHandler(this.btnT3_ZeitfaktorFinden_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnT1_Back_Click);
            // 
            // listBoxT3_ShowJoystickStates
            // 
            this.listBoxT3_ShowJoystickStates.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxT3_ShowJoystickStates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxT3_ShowJoystickStates.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxT3_ShowJoystickStates, "listBoxT3_ShowJoystickStates");
            this.listBoxT3_ShowJoystickStates.Name = "listBoxT3_ShowJoystickStates";
            // 
            // btnT3_leeren
            // 
            resources.ApplyResources(this.btnT3_leeren, "btnT3_leeren");
            this.btnT3_leeren.Name = "btnT3_leeren";
            this.btnT3_leeren.UseVisualStyleBackColor = true;
            this.btnT3_leeren.Click += new System.EventHandler(this.btnT3_leeren_Click);
            // 
            // btnT3_Speichern
            // 
            resources.ApplyResources(this.btnT3_Speichern, "btnT3_Speichern");
            this.btnT3_Speichern.Name = "btnT3_Speichern";
            this.btnT3_Speichern.UseVisualStyleBackColor = true;
            this.btnT3_Speichern.Click += new System.EventHandler(this.btnT3_Speichern_Click);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // txtT3_LongPress
            // 
            resources.ApplyResources(this.txtT3_LongPress, "txtT3_LongPress");
            this.txtT3_LongPress.Name = "txtT3_LongPress";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // txtT3_Zeitfaktor
            // 
            resources.ApplyResources(this.txtT3_Zeitfaktor, "txtT3_Zeitfaktor");
            this.txtT3_Zeitfaktor.Name = "txtT3_Zeitfaktor";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // txtT3_Sonderfaelle
            // 
            resources.ApplyResources(this.txtT3_Sonderfaelle, "txtT3_Sonderfaelle");
            this.txtT3_Sonderfaelle.Name = "txtT3_Sonderfaelle";
            // 
            // txtT3_JoyUmrechnen
            // 
            resources.ApplyResources(this.txtT3_JoyUmrechnen, "txtT3_JoyUmrechnen");
            this.txtT3_JoyUmrechnen.Name = "txtT3_JoyUmrechnen";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // txtT3_AnzahlStufen
            // 
            resources.ApplyResources(this.txtT3_AnzahlStufen, "txtT3_AnzahlStufen");
            this.txtT3_AnzahlStufen.Name = "txtT3_AnzahlStufen";
            // 
            // lblT3_AnzahlStufen
            // 
            resources.ApplyResources(this.lblT3_AnzahlStufen, "lblT3_AnzahlStufen");
            this.lblT3_AnzahlStufen.Name = "lblT3_AnzahlStufen";
            // 
            // txtT3_JoyNr
            // 
            resources.ApplyResources(this.txtT3_JoyNr, "txtT3_JoyNr");
            this.txtT3_JoyNr.Name = "txtT3_JoyNr";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // checkT3_andererJoyModus
            // 
            resources.ApplyResources(this.checkT3_andererJoyModus, "checkT3_andererJoyModus");
            this.checkT3_andererJoyModus.Name = "checkT3_andererJoyModus";
            this.checkT3_andererJoyModus.UseVisualStyleBackColor = true;
            // 
            // checkT3_Invertiert
            // 
            resources.ApplyResources(this.checkT3_Invertiert, "checkT3_Invertiert");
            this.checkT3_Invertiert.Name = "checkT3_Invertiert";
            this.checkT3_Invertiert.UseVisualStyleBackColor = true;
            // 
            // txtT3_JoyAchse
            // 
            resources.ApplyResources(this.txtT3_JoyAchse, "txtT3_JoyAchse");
            this.txtT3_JoyAchse.Name = "txtT3_JoyAchse";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panelT3_StufenStufenlos
            // 
            this.panelT3_StufenStufenlos.Controls.Add(this.radioT3_Stufenlos);
            this.panelT3_StufenStufenlos.Controls.Add(this.radioT3_Stufen);
            resources.ApplyResources(this.panelT3_StufenStufenlos, "panelT3_StufenStufenlos");
            this.panelT3_StufenStufenlos.Name = "panelT3_StufenStufenlos";
            // 
            // radioT3_Stufenlos
            // 
            resources.ApplyResources(this.radioT3_Stufenlos, "radioT3_Stufenlos");
            this.radioT3_Stufenlos.Name = "radioT3_Stufenlos";
            this.radioT3_Stufenlos.UseVisualStyleBackColor = true;
            this.radioT3_Stufenlos.CheckedChanged += new System.EventHandler(this.radioT3_StufenStufenlos_CheckedChanged);
            // 
            // radioT3_Stufen
            // 
            resources.ApplyResources(this.radioT3_Stufen, "radioT3_Stufen");
            this.radioT3_Stufen.Name = "radioT3_Stufen";
            this.radioT3_Stufen.UseVisualStyleBackColor = true;
            this.radioT3_Stufen.CheckedChanged += new System.EventHandler(this.radioT3_StufenStufenlos_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioT3_Schub);
            this.panel1.Controls.Add(this.radioT3_Kombihebel);
            this.panel1.Controls.Add(this.radioT3_Bremse);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // radioT3_Schub
            // 
            resources.ApplyResources(this.radioT3_Schub, "radioT3_Schub");
            this.radioT3_Schub.Name = "radioT3_Schub";
            this.radioT3_Schub.UseVisualStyleBackColor = true;
            this.radioT3_Schub.CheckedChanged += new System.EventHandler(this.radioT3_SchubBremseKombihebel_CheckedChanged);
            // 
            // radioT3_Kombihebel
            // 
            resources.ApplyResources(this.radioT3_Kombihebel, "radioT3_Kombihebel");
            this.radioT3_Kombihebel.Name = "radioT3_Kombihebel";
            this.radioT3_Kombihebel.UseVisualStyleBackColor = true;
            this.radioT3_Kombihebel.CheckedChanged += new System.EventHandler(this.radioT3_SchubBremseKombihebel_CheckedChanged);
            // 
            // radioT3_Bremse
            // 
            resources.ApplyResources(this.radioT3_Bremse, "radioT3_Bremse");
            this.radioT3_Bremse.Name = "radioT3_Bremse";
            this.radioT3_Bremse.UseVisualStyleBackColor = true;
            this.radioT3_Bremse.CheckedChanged += new System.EventHandler(this.radioT3_SchubBremseKombihebel_CheckedChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
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
            // FormSteuerung
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl_Anzeige);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSteuerung";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnT3_ZeitfaktorFinden;
        private System.Windows.Forms.Button btnT0_Delete;
    }
}