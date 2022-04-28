namespace TSW2_Controller
{
    partial class FormSteuerung2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSteuerung2));
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnT0_Delete = new System.Windows.Forms.Button();
            this.btnT0_Add = new System.Windows.Forms.Button();
            this.btnT0_edit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxT0_Zugauswahl = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxT1_Regler = new System.Windows.Forms.GroupBox();
            this.listBoxT1_ControllerList = new System.Windows.Forms.ListBox();
            this.comboBoxT1_Controllers = new System.Windows.Forms.ComboBox();
            this.btnT1_Controller_Add = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox_ShowJoystickStates = new System.Windows.Forms.ListBox();
            this.tabControl_ReglerKnopf = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtR_InputUmrechnen = new System.Windows.Forms.TextBox();
            this.lblR_ReglerStand = new System.Windows.Forms.Label();
            this.btnR_Speichern = new System.Windows.Forms.Button();
            this.btn_R_eigenes = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Joystick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtR_LongPress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtR_JoyAchse = new System.Windows.Forms.TextBox();
            this.txtR_Zeitfaktor = new System.Windows.Forms.TextBox();
            this.txtR_JoyNr = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblR_AnzahlStufen = new System.Windows.Forms.Label();
            this.txtR_Sonderfaelle = new System.Windows.Forms.TextBox();
            this.txtR_AnzahlStufen = new System.Windows.Forms.TextBox();
            this.btnR_Erkennen = new System.Windows.Forms.Button();
            this.progressBar_Joystick = new System.Windows.Forms.ProgressBar();
            this.radioR_Stufenlos = new System.Windows.Forms.RadioButton();
            this.btnR_m100 = new System.Windows.Forms.Button();
            this.radioR_Stufen = new System.Windows.Forms.RadioButton();
            this.btnR_0 = new System.Windows.Forms.Button();
            this.btnR_100 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnB_Speichern = new System.Windows.Forms.Button();
            this.btnB_entfernen = new System.Windows.Forms.Button();
            this.lblB_Bedingung = new System.Windows.Forms.Label();
            this.txtB_Bedingung = new System.Windows.Forms.TextBox();
            this.btnB_Editor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtB_Tastenkombination = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtB_Aktion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxB_KnopfAuswahl = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtB_JoystickNr = new System.Windows.Forms.TextBox();
            this.btnB_Erkennen = new System.Windows.Forms.Button();
            this.lblR_KnopfNr = new System.Windows.Forms.Label();
            this.txtB_JoystickKnopf = new System.Windows.Forms.TextBox();
            this.radioB_regler = new System.Windows.Forms.RadioButton();
            this.radioB_normal = new System.Windows.Forms.RadioButton();
            this.lblT1_TrainName = new System.Windows.Forms.Label();
            this.timer_CheckJoysticks = new System.Windows.Forms.Timer(this.components);
            this.tabControl_main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxT1_Regler.SuspendLayout();
            this.tabControl_ReglerKnopf.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage1);
            this.tabControl_main.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl_main, "tabControl_main");
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnT0_Delete);
            this.tabPage1.Controls.Add(this.btnT0_Add);
            this.tabPage1.Controls.Add(this.btnT0_edit);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.comboBoxT0_Zugauswahl);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnT0_Delete
            // 
            resources.ApplyResources(this.btnT0_Delete, "btnT0_Delete");
            this.btnT0_Delete.Name = "btnT0_Delete";
            this.btnT0_Delete.UseVisualStyleBackColor = true;
            this.btnT0_Delete.Click += new System.EventHandler(this.btnT0_Delete_Click);
            // 
            // btnT0_Add
            // 
            resources.ApplyResources(this.btnT0_Add, "btnT0_Add");
            this.btnT0_Add.Name = "btnT0_Add";
            this.btnT0_Add.UseVisualStyleBackColor = true;
            // 
            // btnT0_edit
            // 
            resources.ApplyResources(this.btnT0_edit, "btnT0_edit");
            this.btnT0_edit.Name = "btnT0_edit";
            this.btnT0_edit.UseVisualStyleBackColor = true;
            this.btnT0_edit.Click += new System.EventHandler(this.btnT0_edit_Click);
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
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxT1_Regler);
            this.tabPage2.Controls.Add(this.listBox_ShowJoystickStates);
            this.tabPage2.Controls.Add(this.tabControl_ReglerKnopf);
            this.tabPage2.Controls.Add(this.lblT1_TrainName);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxT1_Regler
            // 
            this.groupBoxT1_Regler.Controls.Add(this.listBoxT1_ControllerList);
            this.groupBoxT1_Regler.Controls.Add(this.comboBoxT1_Controllers);
            this.groupBoxT1_Regler.Controls.Add(this.btnT1_Controller_Add);
            this.groupBoxT1_Regler.Controls.Add(this.button2);
            resources.ApplyResources(this.groupBoxT1_Regler, "groupBoxT1_Regler");
            this.groupBoxT1_Regler.Name = "groupBoxT1_Regler";
            this.groupBoxT1_Regler.TabStop = false;
            // 
            // listBoxT1_ControllerList
            // 
            this.listBoxT1_ControllerList.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxT1_ControllerList, "listBoxT1_ControllerList");
            this.listBoxT1_ControllerList.Name = "listBoxT1_ControllerList";
            this.listBoxT1_ControllerList.SelectedIndexChanged += new System.EventHandler(this.listBoxT1_ControllerList_SelectedIndexChanged);
            this.listBoxT1_ControllerList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxT1_ControllerList_KeyDown);
            // 
            // comboBoxT1_Controllers
            // 
            this.comboBoxT1_Controllers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxT1_Controllers.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxT1_Controllers, "comboBoxT1_Controllers");
            this.comboBoxT1_Controllers.Name = "comboBoxT1_Controllers";
            // 
            // btnT1_Controller_Add
            // 
            resources.ApplyResources(this.btnT1_Controller_Add, "btnT1_Controller_Add");
            this.btnT1_Controller_Add.Name = "btnT1_Controller_Add";
            this.btnT1_Controller_Add.UseVisualStyleBackColor = true;
            this.btnT1_Controller_Add.Click += new System.EventHandler(this.btnT1_Controller_Add_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listBox_ShowJoystickStates
            // 
            this.listBox_ShowJoystickStates.FormattingEnabled = true;
            resources.ApplyResources(this.listBox_ShowJoystickStates, "listBox_ShowJoystickStates");
            this.listBox_ShowJoystickStates.Name = "listBox_ShowJoystickStates";
            // 
            // tabControl_ReglerKnopf
            // 
            this.tabControl_ReglerKnopf.Controls.Add(this.tabPage4);
            this.tabControl_ReglerKnopf.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabControl_ReglerKnopf, "tabControl_ReglerKnopf");
            this.tabControl_ReglerKnopf.Name = "tabControl_ReglerKnopf";
            this.tabControl_ReglerKnopf.SelectedIndex = 0;
            this.tabControl_ReglerKnopf.SelectedIndexChanged += new System.EventHandler(this.tabControl_ReglerKnopf_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.txtR_InputUmrechnen);
            this.tabPage4.Controls.Add(this.lblR_ReglerStand);
            this.tabPage4.Controls.Add(this.btnR_Speichern);
            this.tabPage4.Controls.Add(this.btn_R_eigenes);
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.txtR_LongPress);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.txtR_JoyAchse);
            this.tabPage4.Controls.Add(this.txtR_Zeitfaktor);
            this.tabPage4.Controls.Add(this.txtR_JoyNr);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.lblR_AnzahlStufen);
            this.tabPage4.Controls.Add(this.txtR_Sonderfaelle);
            this.tabPage4.Controls.Add(this.txtR_AnzahlStufen);
            this.tabPage4.Controls.Add(this.btnR_Erkennen);
            this.tabPage4.Controls.Add(this.progressBar_Joystick);
            this.tabPage4.Controls.Add(this.radioR_Stufenlos);
            this.tabPage4.Controls.Add(this.btnR_m100);
            this.tabPage4.Controls.Add(this.radioR_Stufen);
            this.tabPage4.Controls.Add(this.btnR_0);
            this.tabPage4.Controls.Add(this.btnR_100);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtR_InputUmrechnen
            // 
            resources.ApplyResources(this.txtR_InputUmrechnen, "txtR_InputUmrechnen");
            this.txtR_InputUmrechnen.Name = "txtR_InputUmrechnen";
            // 
            // lblR_ReglerStand
            // 
            resources.ApplyResources(this.lblR_ReglerStand, "lblR_ReglerStand");
            this.lblR_ReglerStand.Name = "lblR_ReglerStand";
            // 
            // btnR_Speichern
            // 
            resources.ApplyResources(this.btnR_Speichern, "btnR_Speichern");
            this.btnR_Speichern.Name = "btnR_Speichern";
            this.btnR_Speichern.UseVisualStyleBackColor = true;
            this.btnR_Speichern.Click += new System.EventHandler(this.btnR_Speichern_Click);
            // 
            // btn_R_eigenes
            // 
            resources.ApplyResources(this.btn_R_eigenes, "btn_R_eigenes");
            this.btn_R_eigenes.Name = "btn_R_eigenes";
            this.btn_R_eigenes.UseVisualStyleBackColor = true;
            this.btn_R_eigenes.Click += new System.EventHandler(this.btn_R_eigenes_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Joystick,
            this.Output});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            // 
            // Joystick
            // 
            this.Joystick.Name = "Joystick";
            // 
            // Output
            // 
            this.Output.Name = "Output";
            this.Output.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtR_LongPress
            // 
            resources.ApplyResources(this.txtR_LongPress, "txtR_LongPress");
            this.txtR_LongPress.Name = "txtR_LongPress";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // txtR_JoyAchse
            // 
            resources.ApplyResources(this.txtR_JoyAchse, "txtR_JoyAchse");
            this.txtR_JoyAchse.Name = "txtR_JoyAchse";
            // 
            // txtR_Zeitfaktor
            // 
            resources.ApplyResources(this.txtR_Zeitfaktor, "txtR_Zeitfaktor");
            this.txtR_Zeitfaktor.Name = "txtR_Zeitfaktor";
            // 
            // txtR_JoyNr
            // 
            resources.ApplyResources(this.txtR_JoyNr, "txtR_JoyNr");
            this.txtR_JoyNr.Name = "txtR_JoyNr";
            this.txtR_JoyNr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_OnlyNumbers_KeyPress);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // lblR_AnzahlStufen
            // 
            resources.ApplyResources(this.lblR_AnzahlStufen, "lblR_AnzahlStufen");
            this.lblR_AnzahlStufen.Name = "lblR_AnzahlStufen";
            // 
            // txtR_Sonderfaelle
            // 
            resources.ApplyResources(this.txtR_Sonderfaelle, "txtR_Sonderfaelle");
            this.txtR_Sonderfaelle.Name = "txtR_Sonderfaelle";
            // 
            // txtR_AnzahlStufen
            // 
            resources.ApplyResources(this.txtR_AnzahlStufen, "txtR_AnzahlStufen");
            this.txtR_AnzahlStufen.Name = "txtR_AnzahlStufen";
            // 
            // btnR_Erkennen
            // 
            resources.ApplyResources(this.btnR_Erkennen, "btnR_Erkennen");
            this.btnR_Erkennen.Name = "btnR_Erkennen";
            this.btnR_Erkennen.UseVisualStyleBackColor = true;
            this.btnR_Erkennen.Click += new System.EventHandler(this.btnR_Erkennen_Click);
            // 
            // progressBar_Joystick
            // 
            this.progressBar_Joystick.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar_Joystick.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.progressBar_Joystick, "progressBar_Joystick");
            this.progressBar_Joystick.Maximum = 200;
            this.progressBar_Joystick.Name = "progressBar_Joystick";
            this.progressBar_Joystick.Value = 50;
            // 
            // radioR_Stufenlos
            // 
            resources.ApplyResources(this.radioR_Stufenlos, "radioR_Stufenlos");
            this.radioR_Stufenlos.Name = "radioR_Stufenlos";
            this.radioR_Stufenlos.UseVisualStyleBackColor = true;
            this.radioR_Stufenlos.CheckedChanged += new System.EventHandler(this.radioR_CheckedChanged);
            // 
            // btnR_m100
            // 
            resources.ApplyResources(this.btnR_m100, "btnR_m100");
            this.btnR_m100.Name = "btnR_m100";
            this.btnR_m100.UseVisualStyleBackColor = true;
            this.btnR_m100.Click += new System.EventHandler(this.btnR_ControllerValues_Click);
            // 
            // radioR_Stufen
            // 
            resources.ApplyResources(this.radioR_Stufen, "radioR_Stufen");
            this.radioR_Stufen.Checked = true;
            this.radioR_Stufen.Name = "radioR_Stufen";
            this.radioR_Stufen.TabStop = true;
            this.radioR_Stufen.UseVisualStyleBackColor = true;
            this.radioR_Stufen.CheckedChanged += new System.EventHandler(this.radioR_CheckedChanged);
            // 
            // btnR_0
            // 
            resources.ApplyResources(this.btnR_0, "btnR_0");
            this.btnR_0.Name = "btnR_0";
            this.btnR_0.UseVisualStyleBackColor = true;
            this.btnR_0.Click += new System.EventHandler(this.btnR_ControllerValues_Click);
            // 
            // btnR_100
            // 
            resources.ApplyResources(this.btnR_100, "btnR_100");
            this.btnR_100.Name = "btnR_100";
            this.btnR_100.UseVisualStyleBackColor = true;
            this.btnR_100.Click += new System.EventHandler(this.btnR_ControllerValues_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnB_Speichern);
            this.tabPage3.Controls.Add(this.btnB_entfernen);
            this.tabPage3.Controls.Add(this.lblB_Bedingung);
            this.tabPage3.Controls.Add(this.txtB_Bedingung);
            this.tabPage3.Controls.Add(this.btnB_Editor);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtB_Tastenkombination);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.txtB_Aktion);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.comboBoxB_KnopfAuswahl);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.txtB_JoystickNr);
            this.tabPage3.Controls.Add(this.btnB_Erkennen);
            this.tabPage3.Controls.Add(this.lblR_KnopfNr);
            this.tabPage3.Controls.Add(this.txtB_JoystickKnopf);
            this.tabPage3.Controls.Add(this.radioB_regler);
            this.tabPage3.Controls.Add(this.radioB_normal);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnB_Speichern
            // 
            resources.ApplyResources(this.btnB_Speichern, "btnB_Speichern");
            this.btnB_Speichern.Name = "btnB_Speichern";
            this.btnB_Speichern.UseVisualStyleBackColor = true;
            this.btnB_Speichern.Click += new System.EventHandler(this.btnB_Speichern_Click);
            // 
            // btnB_entfernen
            // 
            resources.ApplyResources(this.btnB_entfernen, "btnB_entfernen");
            this.btnB_entfernen.Name = "btnB_entfernen";
            this.btnB_entfernen.UseVisualStyleBackColor = true;
            this.btnB_entfernen.Click += new System.EventHandler(this.btnB_entfernen_Click);
            // 
            // lblB_Bedingung
            // 
            resources.ApplyResources(this.lblB_Bedingung, "lblB_Bedingung");
            this.lblB_Bedingung.Name = "lblB_Bedingung";
            // 
            // txtB_Bedingung
            // 
            resources.ApplyResources(this.txtB_Bedingung, "txtB_Bedingung");
            this.txtB_Bedingung.Name = "txtB_Bedingung";
            // 
            // btnB_Editor
            // 
            resources.ApplyResources(this.btnB_Editor, "btnB_Editor");
            this.btnB_Editor.Name = "btnB_Editor";
            this.btnB_Editor.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtB_Tastenkombination
            // 
            resources.ApplyResources(this.txtB_Tastenkombination, "txtB_Tastenkombination");
            this.txtB_Tastenkombination.Name = "txtB_Tastenkombination";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtB_Aktion
            // 
            resources.ApplyResources(this.txtB_Aktion, "txtB_Aktion");
            this.txtB_Aktion.Name = "txtB_Aktion";
            this.txtB_Aktion.Click += new System.EventHandler(this.txtB_Aktion_Click);
            this.txtB_Aktion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtB_Aktion_KeyDown);
            this.txtB_Aktion.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtB_Aktion_PreviewKeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // comboBoxB_KnopfAuswahl
            // 
            this.comboBoxB_KnopfAuswahl.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxB_KnopfAuswahl, "comboBoxB_KnopfAuswahl");
            this.comboBoxB_KnopfAuswahl.Name = "comboBoxB_KnopfAuswahl";
            this.comboBoxB_KnopfAuswahl.SelectedIndexChanged += new System.EventHandler(this.comboBoxB_KnopfAuswahl_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtB_JoystickNr
            // 
            resources.ApplyResources(this.txtB_JoystickNr, "txtB_JoystickNr");
            this.txtB_JoystickNr.Name = "txtB_JoystickNr";
            this.txtB_JoystickNr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_OnlyNumbers_KeyPress);
            // 
            // btnB_Erkennen
            // 
            resources.ApplyResources(this.btnB_Erkennen, "btnB_Erkennen");
            this.btnB_Erkennen.Name = "btnB_Erkennen";
            this.btnB_Erkennen.UseVisualStyleBackColor = true;
            this.btnB_Erkennen.Click += new System.EventHandler(this.btnB_Erkennen_Click);
            // 
            // lblR_KnopfNr
            // 
            resources.ApplyResources(this.lblR_KnopfNr, "lblR_KnopfNr");
            this.lblR_KnopfNr.Name = "lblR_KnopfNr";
            // 
            // txtB_JoystickKnopf
            // 
            resources.ApplyResources(this.txtB_JoystickKnopf, "txtB_JoystickKnopf");
            this.txtB_JoystickKnopf.Name = "txtB_JoystickKnopf";
            // 
            // radioB_regler
            // 
            resources.ApplyResources(this.radioB_regler, "radioB_regler");
            this.radioB_regler.Name = "radioB_regler";
            this.radioB_regler.UseVisualStyleBackColor = true;
            this.radioB_regler.CheckedChanged += new System.EventHandler(this.radioB_CheckedChanged);
            // 
            // radioB_normal
            // 
            resources.ApplyResources(this.radioB_normal, "radioB_normal");
            this.radioB_normal.Checked = true;
            this.radioB_normal.Name = "radioB_normal";
            this.radioB_normal.TabStop = true;
            this.radioB_normal.UseVisualStyleBackColor = true;
            this.radioB_normal.CheckedChanged += new System.EventHandler(this.radioB_CheckedChanged);
            // 
            // lblT1_TrainName
            // 
            resources.ApplyResources(this.lblT1_TrainName, "lblT1_TrainName");
            this.lblT1_TrainName.Name = "lblT1_TrainName";
            // 
            // timer_CheckJoysticks
            // 
            this.timer_CheckJoysticks.Enabled = true;
            this.timer_CheckJoysticks.Tick += new System.EventHandler(this.timer_CheckJoysticks_Tick);
            // 
            // FormSteuerung2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl_main);
            this.MaximizeBox = false;
            this.Name = "FormSteuerung2";
            this.tabControl_main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBoxT1_Regler.ResumeLayout(false);
            this.tabControl_ReglerKnopf.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnT0_Delete;
        private System.Windows.Forms.Button btnT0_Add;
        private System.Windows.Forms.Button btnT0_edit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxT0_Zugauswahl;
        private System.Windows.Forms.ComboBox comboBoxT1_Controllers;
        private System.Windows.Forms.ListBox listBoxT1_ControllerList;
        private System.Windows.Forms.Button btnT1_Controller_Add;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblT1_TrainName;
        private System.Windows.Forms.Button btnR_100;
        private System.Windows.Forms.Button btnR_0;
        private System.Windows.Forms.Button btnR_m100;
        private System.Windows.Forms.ProgressBar progressBar_Joystick;
        private System.Windows.Forms.Button btnR_Erkennen;
        private System.Windows.Forms.TextBox txtR_AnzahlStufen;
        private System.Windows.Forms.Label lblR_AnzahlStufen;
        private System.Windows.Forms.TextBox txtR_JoyNr;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtR_JoyAchse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioR_Stufenlos;
        private System.Windows.Forms.RadioButton radioR_Stufen;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtR_LongPress;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtR_Zeitfaktor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtR_Sonderfaelle;
        private System.Windows.Forms.TabControl tabControl_ReglerKnopf;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listBox_ShowJoystickStates;
        private System.Windows.Forms.Button btnB_entfernen;
        private System.Windows.Forms.Label lblB_Bedingung;
        private System.Windows.Forms.TextBox txtB_Bedingung;
        private System.Windows.Forms.Button btnB_Editor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtB_Tastenkombination;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtB_Aktion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxB_KnopfAuswahl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtB_JoystickNr;
        private System.Windows.Forms.Button btnB_Erkennen;
        private System.Windows.Forms.Label lblR_KnopfNr;
        private System.Windows.Forms.TextBox txtB_JoystickKnopf;
        private System.Windows.Forms.RadioButton radioB_regler;
        private System.Windows.Forms.RadioButton radioB_normal;
        private System.Windows.Forms.Button btn_R_eigenes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Joystick;
        private System.Windows.Forms.DataGridViewTextBoxColumn Output;
        private System.Windows.Forms.Button btnR_Speichern;
        private System.Windows.Forms.GroupBox groupBoxT1_Regler;
        private System.Windows.Forms.Timer timer_CheckJoysticks;
        private System.Windows.Forms.Label lblR_ReglerStand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtR_InputUmrechnen;
        private System.Windows.Forms.Button btnB_Speichern;
    }
}