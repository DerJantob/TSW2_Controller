﻿using SlimDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSW2_Controller
{
    public partial class FormSteuerung : Form
    {
        string selectedTrain = "";
        List<string[]> trainConfig = new List<string[]>();
        DirectInput input = new DirectInput();
        Joystick mainStick;
        bool t1IsJoyButton = false;

        public FormSteuerung()
        {
            InitializeComponent();

            FormMain formMain = new FormMain();
            trainConfig = formMain.trainConfig;

            comboBoxT0_Zugauswahl.Items.Add(Tcfg.nameForGlobal);
            comboBoxT0_Zugauswahl.Items.AddRange(formMain.trainNames.ToArray());
            comboBoxT0_Zugauswahl.Items.Remove("_Zugauswahl");
            comboBoxT0_Zugauswahl.SelectedItem = Tcfg.nameForGlobal;

            lblT1_KnopfNr.Text = "KnopfNr.";
            lblT3_AnzahlStufen.Text = "";
            lblT1_Bedingung.Hide();
            txtT1_Bedingung.Hide();

            lblT2_haltezeit.Hide();
            txtT2_Haltezeit.Hide();
            txtT3_AnzahlStufen.Hide();

            listBoxT1_ShowJoystickStates.Hide();

            tabControl_Anzeige.Size = new Size(316, 133);

            //Verstecke die Auswahl der Tab-Buttons
            tabControl_Anzeige.Appearance = TabAppearance.FlatButtons;
            tabControl_Anzeige.ItemSize = new Size(0, 1);
            tabControl_Anzeige.SizeMode = TabSizeMode.Fixed;
        }

        private void tabControl_Anzeige_SelectedIndexChanged(object sender, EventArgs e)
        {
            T3Timer_GetJoyStates.Stop();
            switch (((TabControl)sender).SelectedIndex)
            {
                case 0:
                    tabControl_Anzeige.Size = new Size(316, 133);
                    break;
                case 1:
                    tabControl_Anzeige.Size = new Size(366, 273);
                    break;
                case 2:
                    tabControl_Anzeige.Size = new Size(307, 256);
                    break;
                case 3:
                    tabControl_Anzeige.Size = new Size(565, 270);
                    T3Timer_GetJoyStates.Start();
                    break;
            }
        }

        #region T0
        private void comboBoxT0_Zugauswahl_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxT0_Zugauswahl.Text == Tcfg.nameForGlobal)
            {
                btnT0_editRegler.Enabled = false;
            }
            else
            {
                btnT0_editRegler.Enabled = true;
            }
        }
        private void btnT0_editButtons_Click(object sender, EventArgs e)
        {
            if (comboBoxT0_Zugauswahl.Text != "" && comboBoxT0_Zugauswahl.Text != "_Zugauswahl")
            {
                selectedTrain = comboBoxT0_Zugauswahl.Text;
                comboBoxT1_KnopfAuswahl.Items.Clear();
                foreach (string[] cfg in trainConfig)
                {
                    if ((cfg[Tcfg.zug] == selectedTrain && cfg[Tcfg.inputTyp] == "Button") || (cfg[Tcfg.zug] == selectedTrain && cfg[Tcfg.inputTyp].Contains("[")))
                    {
                        comboBoxT1_KnopfAuswahl.Items.Add(cfg[Tcfg.beschreibung]);
                    }
                }
                tabControl_Anzeige.SelectedIndex = 1;
            }
        }
        private void btnT0_editRegler_Click(object sender, EventArgs e)
        {
            if (comboBoxT0_Zugauswahl.Text != "" && comboBoxT0_Zugauswahl.Text != "_Zugauswahl")
            {
                selectedTrain = comboBoxT0_Zugauswahl.Text;
                tabControl_Anzeige.SelectedIndex = 3;
            }
        }
        private void btnT0_Add_Click(object sender, EventArgs e)
        {
            bool exestiertBereits = false;
            foreach (string s in comboBoxT0_Zugauswahl.Items)
            {
                if (s == comboBoxT0_Zugauswahl.Text)
                {
                    exestiertBereits = true;
                }
            }

            if (!exestiertBereits)
            {
                comboBoxT0_Zugauswahl.Items.Add(comboBoxT0_Zugauswahl.Text);
            }
        }
        private void btnT0_Delete_Click(object sender, EventArgs e)
        {
            selectedTrain = comboBoxT0_Zugauswahl.Text;
            comboBoxT0_Zugauswahl.Items.Remove(selectedTrain);

            if (MessageBox.Show("Willst du wirklich \"" + selectedTrain + "\" löschen?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int counter = 0;
                for (int i = 0; i < trainConfig.Count; i++)
                {
                    if (trainConfig[i][Tcfg.zug] == selectedTrain)
                    {
                        trainConfig.RemoveAt(i);
                        i--;
                        counter++;
                    }
                }

                //Schreibe Datei
                string[] line = new string[trainConfig.Count];
                for (int i = 0; i < trainConfig.Count; i++)
                {
                    string combined = "";
                    foreach (string s in trainConfig[i])
                    {
                        combined += s + ",";
                    }
                    combined = combined.Remove(combined.Length - 1);
                    line[i] = combined;
                }
                File.WriteAllLines(Tcfg.configpfad, line);

                MessageBox.Show(counter + " Einträge gelöscht!");
            }
        }
        #endregion

        #region T1
        private void radioT1_normal_CheckedChanged(object sender, EventArgs e)
        {
            //Auswahl zwischen "normaler Knopf" und "Regler als Knopf"
            if (radioT1_normal.Checked)
            {
                t1IsJoyButton = false;
                lblT1_KnopfNr.Text = "KnopfNr.";
                lblT1_Bedingung.Hide();
                txtT1_Bedingung.Hide();
            }
            else
            {
                t1IsJoyButton = true;
                lblT1_KnopfNr.Text = "JoyName";
                lblT1_Bedingung.Show();
                txtT1_Bedingung.Show();
            }

            if (t1IsJoyButton)
            {
                btnT1_Erkennen.Enabled = false;
                listBoxT1_ShowJoystickStates.Show();
                T1Timer_CheckForButtonPress.Start();
            }
            else
            {
                btnT1_Erkennen.Enabled = true;
                listBoxT1_ShowJoystickStates.Hide();
                T1Timer_CheckForButtonPress.Stop();
            }
        }
        private void comboBoxT1_KnopfAuswahl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Wenn man eigenen Knopf erstellt dann Leere alle Felder
            txtT1_Aktion.Text = "";
            txtT1_Bedingung.Text = "";
            txtT1_JoystickKnopf.Text = "";
            txtT1_JoystickNr.Text = "";
            txtT1_Tastenkombination.Text = "";
        }
        private void txtT1_Aktion_KeyDown(object sender, KeyEventArgs e)
        {
            //Wenn man im "Aktion" Feld eine Taste drückt finde passenden Namen zur Taste
            e.SuppressKeyPress = true;
            txtT1_Aktion.Text = Keyboard.ConvertKeyToString(e.KeyCode);
        }
        private void btnT1_Editor_Click(object sender, EventArgs e)
        {
            //Erstelle eine Tastenkombination
            tabControl_Anzeige.SelectedIndex = 2;
        }
        private void comboBoxT1_KnopfAuswahl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Wenn ich die Auswahl vom Knopfnamen ändere
            foreach (string[] singleTrain in trainConfig)
            {
                if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.beschreibung] == comboBoxT1_KnopfAuswahl.Text)
                {
                    if (singleTrain[Tcfg.inputTyp].Contains("["))
                    {
                        //Ist ein Joy als Knopf
                        t1IsJoyButton = true;
                        radioT1_regler.Checked = true;
                        btnT1_Erkennen.Enabled = false;
                        listBoxT1_ShowJoystickStates.Show();
                        T1Timer_CheckForButtonPress.Start();
                    }
                    else
                    {
                        //Ist ein normaler Knopf
                        t1IsJoyButton = false;
                        listBoxT1_ShowJoystickStates.Hide();
                        radioT1_normal.Checked = true;
                        btnT1_Erkennen.Enabled = true;
                        T1Timer_CheckForButtonPress.Stop();
                    }

                    //Alle Informationen einfügen
                    txtT1_JoystickNr.Text = singleTrain[Tcfg.joystickNummer];
                    txtT1_JoystickKnopf.Text = singleTrain[Tcfg.joystickInput].Replace("B", "");
                    txtT1_Aktion.Text = singleTrain[Tcfg.aktion];
                    txtT1_Tastenkombination.Text = singleTrain[Tcfg.tastenKombination];
                    if (t1IsJoyButton)
                    {
                        txtT1_Bedingung.Text = singleTrain[Tcfg.inputTyp].Replace("Button", "").Replace("[", "").Replace("]", " ").TrimEnd(' ');
                    }
                    else
                    {
                        txtT1_Bedingung.Text = "";
                    }
                }
            }
        }
        private void btnT1_Hinzufuegen_ersetzen_Click(object sender, EventArgs e)
        {
            bool ersetzt = false;
            for (int i = 0; i < trainConfig.Count; i++)
            {
                string[] singleTrain = trainConfig[i];
                if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.beschreibung] == comboBoxT1_KnopfAuswahl.Text)
                {
                    singleTrain[Tcfg.joystickNummer] = txtT1_JoystickNr.Text;
                    if (!t1IsJoyButton) { singleTrain[Tcfg.inputTyp] = "Button"; } else { singleTrain[Tcfg.inputTyp] = "Button[" + txtT1_Bedingung.Text.Replace(" ", "][") + "]"; }
                    if (!t1IsJoyButton) { singleTrain[Tcfg.joystickInput] = "B" + txtT1_JoystickKnopf.Text; } else { singleTrain[Tcfg.joystickInput] = txtT1_JoystickKnopf.Text; }
                    singleTrain[Tcfg.aktion] = txtT1_Aktion.Text;
                    singleTrain[Tcfg.tastenKombination] = txtT1_Tastenkombination.Text;
                    trainConfig[i] = singleTrain;
                    ersetzt = true;
                    MessageBox.Show("Ersetzt!");
                }
            }
            if (!ersetzt)
            {
                string[] singleTrain = new string[trainConfig[0].Length];

                singleTrain[Tcfg.zug] = selectedTrain;
                singleTrain[Tcfg.beschreibung] = comboBoxT1_KnopfAuswahl.Text;
                singleTrain[Tcfg.joystickNummer] = txtT1_JoystickNr.Text;
                if (!t1IsJoyButton) { singleTrain[Tcfg.inputTyp] = "Button"; } else { singleTrain[Tcfg.inputTyp] = "Button[" + txtT1_Bedingung.Text.Replace(" ", "][") + "]"; }
                if (!t1IsJoyButton) { singleTrain[Tcfg.joystickInput] = "B" + txtT1_JoystickKnopf.Text; } else { singleTrain[Tcfg.joystickInput] = txtT1_JoystickKnopf.Text; }
                singleTrain[Tcfg.aktion] = txtT1_Aktion.Text;
                singleTrain[Tcfg.tastenKombination] = txtT1_Tastenkombination.Text;
                trainConfig.Add(singleTrain);
                comboBoxT1_KnopfAuswahl.Items.Add(comboBoxT1_KnopfAuswahl.Text);
                MessageBox.Show("Hinzugefügt!");
            }

            //Schreibe Datei
            string[] line = new string[trainConfig.Count];
            for (int i = 0; i < trainConfig.Count; i++)
            {
                string combined = "";
                foreach (string s in trainConfig[i])
                {
                    combined += s + ",";
                }
                combined = combined.Remove(combined.Length - 1);
                line[i] = combined;
            }

            File.WriteAllLines(Tcfg.configpfad, line);
        }
        private void btnT1_Erkennen_Click(object sender, EventArgs e)
        {
            //Erkenne die gedrückte Taste
            btnT1_Erkennen.Enabled = false;
            T1Timer_CheckForButtonPress.Start();
        }
        private void T1Timer_CheckForButtonPress_Tick(object sender, EventArgs e)
        {
            string result = getBtn();
            if (result != "" && !t1IsJoyButton)
            {
                txtT1_JoystickKnopf.Text = result.Remove(result.IndexOf('|'), result.Length - result.IndexOf('|'));
                txtT1_JoystickNr.Text = result.Remove(0, result.IndexOf('|') + 1);
                T1Timer_CheckForButtonPress.Stop();
                btnT1_Erkennen.Enabled = true;
            }
        }
        private string getBtn()
        {
            //Anzeigeliste leeren
            listBoxT1_ShowJoystickStates.Items.Clear();
            for (int i = 0; i < FormMain.MainSticks.Length; i++)
            {
                bool[] buttons;
                int[] joyInputs = new int[8];

                JoystickState state = new JoystickState();

                //Bekomme alle Infos über den mit id ausgewählten Stick
                state = FormMain.MainSticks[i].GetCurrentState();

                joyInputs[0] = state.X;
                joyInputs[1] = state.Y;
                joyInputs[2] = state.Z;
                joyInputs[3] = state.GetPointOfViewControllers()[0] + 1;
                joyInputs[4] = state.RotationX;
                joyInputs[5] = state.RotationY;
                joyInputs[6] = state.RotationZ;
                joyInputs[7] = state.GetSliders()[0];


                //Alle Knopf states bekommen
                buttons = state.GetButtons();


                for (int o = 0; o < buttons.Length; o++)
                {
                    if (buttons[o])
                    {
                        //Zeige den gedrückten Button
                        listBoxT1_ShowJoystickStates.Items.Add("B" + o);
                    }
                }
                for (int o = 0; o < joyInputs.Length; o++)
                {
                    if (joyInputs[o] != 0)
                    {
                        //Zeige den Joystick-Wert nur, wenn er != 0 ist
                        listBoxT1_ShowJoystickStates.Items.Add("Nr:" + i + " " + FormMain.inputNames[o] + "  " + joyInputs[o]);
                    }
                }

                for (int o = 0; o < buttons.Length; o++)
                {
                    if (buttons[o] == true)
                    {
                        return o + "|" + i; //Button|JoystickID
                    }
                }
            }
            return "";
        }
        private void btnT1_entfernen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < trainConfig.Count; i++)
            {
                string[] singleTrain = trainConfig[i];
                if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.beschreibung] == comboBoxT1_KnopfAuswahl.Text)
                {
                    trainConfig.RemoveAt(i);
                    comboBoxT1_KnopfAuswahl.Items.Remove(comboBoxT1_KnopfAuswahl.Text);
                    comboBoxT1_KnopfAuswahl.Text = "";
                }
            }

            //Write file
            string[] line = new string[trainConfig.Count];
            for (int i = 0; i < trainConfig.Count; i++)
            {
                string combined = "";
                foreach (string s in trainConfig[i])
                {
                    combined += s + ",";
                }
                combined = combined.Remove(combined.Length - 1);
                line[i] = combined;
            }

            File.WriteAllLines(Tcfg.configpfad, line);
        }
        private void btnT1_Back_Click(object sender, EventArgs e)
        {
            tabControl_Anzeige.SelectedIndex = 0;
        }

        #endregion

        #region T2
        private void txtT2_Taste_KeyDown(object sender, KeyEventArgs e)
        {
            //Erkennung der Taste
            e.SuppressKeyPress = true;
            txtT2_Taste.Text = Keyboard.ConvertKeyToString(e.KeyCode);
        }
        private void radio_Changed(object sender, EventArgs e)
        {
            if (radioT2_Halten.Checked)
            {
                lblT2_haltezeit.Show();
                txtT2_Haltezeit.Show();
            }
            else
            {
                lblT2_haltezeit.Hide();
                txtT2_Haltezeit.Hide();
            }
        }
        private void btnT2_Hinzufügen_Click(object sender, EventArgs e)
        {
            if (txtT2_Wartezeit.Text == "") { txtT2_Wartezeit.Text = "0"; }
            if (txtT2_Haltezeit.Text == "") { txtT2_Haltezeit.Text = "0"; }

            if (radioT2_einmalDruecken.Checked)
            {
                listBoxT2_Output.Items.Add(txtT2_Taste.Text + "_[press]_[" + txtT2_Wartezeit.Text + "]");
            }
            else if (radioT2_Halten.Checked)
            {
                listBoxT2_Output.Items.Add(txtT2_Taste.Text + "_[hold " + lblT2_haltezeit.Text + "]_[" + txtT2_Wartezeit.Text + "]");
            }
            else if (radioT2_Druecken.Checked)
            {
                listBoxT2_Output.Items.Add(txtT2_Taste.Text + "_[down]_[" + txtT2_Wartezeit.Text + "]");
            }
            else if (radioT2_Loslassen.Checked)
            {
                listBoxT2_Output.Items.Add(txtT2_Taste.Text + "_[up]_[" + txtT2_Wartezeit.Text + "]");
            }
        }
        private void txtT2_Haltezeit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Erlaube in Wartezeit und Haltezeit nur Ziffern
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void listBoxT2_Output_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    listBoxT2_Output.Items.RemoveAt(listBoxT2_Output.SelectedIndex);
                }
            }
            catch
            {
            }
        }
        private void btnT2_Fertig_Click(object sender, EventArgs e)
        {
            if (listBoxT2_Output.Items.Count > 0)
            {
                try
                {
                    string output = "";
                    foreach (string item in listBoxT2_Output.Items)
                    {
                        output += item;
                        output += "_";
                    }
                    output = output.Remove(output.Length - 1); //Entferne "_" ganz am Ende
                    txtT1_Tastenkombination.Text = output;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            tabControl_Anzeige.SelectedIndex = 1;
        }
        #endregion

        #region T3
        private void T3Reset()
        {
            txtT3_JoyNr.Text = "";
            txtT3_JoyAchse.Text = "";
            txtT3_JoyUmrechnen.Text = "";
            txtT3_AnzahlStufen.Text = "";
            txtT3_Sonderfaelle.Text = "";
            txtT3_Zeitfaktor.Text = "";
            txtT3_LongPress.Text = "";
            txtT3_Beschreibung.Text = "";

            checkT3_andererJoyModus.Checked = false;
            checkT3_Invertiert.Checked = false;
        }
        private void radioT3_SchubBremseKombihebel_CheckedChanged(object sender, EventArgs e)
        {
            panelT3_StufenStufenlos.Enabled = true;
            bool foundData = false;

            foreach (string[] singleTrain in trainConfig)
            {
                if (singleTrain[Tcfg.zug] == selectedTrain)
                {
                    if ((singleTrain[Tcfg.tastenKombination] == "Schub" && radioT3_Schub.Checked) || (singleTrain[Tcfg.tastenKombination] == "Bremse" && radioT3_Bremse.Checked) || (singleTrain[Tcfg.tastenKombination] == "Kombihebel" && radioT3_Kombihebel.Checked))
                    {
                        txtT3_JoyNr.Text = singleTrain[Tcfg.joystickNummer];
                        txtT3_JoyAchse.Text = singleTrain[Tcfg.joystickInput];
                        txtT3_JoyUmrechnen.Text = singleTrain[Tcfg.inputUmrechnen].Replace("[", "").Replace("]", " ").TrimEnd(' ');
                        txtT3_AnzahlStufen.Text = singleTrain[Tcfg.schritte];
                        txtT3_Sonderfaelle.Text = singleTrain[Tcfg.specials].Replace(" ", "_").Replace("[", "").Replace("]", " ").TrimEnd(' ');
                        txtT3_Zeitfaktor.Text = singleTrain[Tcfg.zeitfaktor];
                        txtT3_LongPress.Text = singleTrain[Tcfg.laengerDruecken].Replace("[", "").Replace("]", " ").TrimEnd(' ');
                        txtT3_Beschreibung.Text = singleTrain[Tcfg.beschreibung];
                        if (singleTrain[Tcfg.art] == "Stufen") { radioT3_Stufen.Checked = true; } else if (singleTrain[Tcfg.art] == "Stufenlos") { radioT3_Stufenlos.Checked = true; }
                        if (singleTrain[Tcfg.invert] == "1") { checkT3_Invertiert.Checked = true; } else { checkT3_Invertiert.Checked = false; }
                        if (singleTrain[Tcfg.inputTyp] == "1") { checkT3_andererJoyModus.Checked = true; } else { checkT3_andererJoyModus.Checked = false; }

                        foundData = true;

                        break;
                    }
                }
            }
            if (!foundData)
            {
                T3Reset();
                radioT3_Stufen.Checked = false;
                radioT3_Stufenlos.Checked = false;
            }

            if (radioT3_Kombihebel.Checked)
            {
                radioT3_Stufenlos.Checked = true;
                radioT3_Stufen.Enabled = false;
            }
            else
            {
                radioT3_Stufen.Enabled = true;
            }
        }
        private void btnT3_leeren_Click(object sender, EventArgs e)
        {
            T3Reset();
        }
        private void radioT3_StufenStufenlos_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioT3_Stufen.Checked)
            {
                txtT3_AnzahlStufen.Text = "";
                txtT3_AnzahlStufen.Hide();
                lblT3_AnzahlStufen.Hide();
            }
            else
            {
                txtT3_AnzahlStufen.Show();
                lblT3_AnzahlStufen.Show();
            }
        }
        private void btnT3_Speichern_Click(object sender, EventArgs e)
        {
            if (radioT3_Stufen.Checked || radioT3_Stufenlos.Checked)
            {
                bool ersetzt = false;
                for (int i = 0; i < trainConfig.Count; i++)
                {
                    string[] singleTrain = trainConfig[i];
                    if (singleTrain[Tcfg.zug] == selectedTrain && ((singleTrain[Tcfg.tastenKombination] == "Schub" && radioT3_Schub.Checked) || (singleTrain[Tcfg.tastenKombination] == "Bremse" && radioT3_Bremse.Checked) || (singleTrain[Tcfg.tastenKombination] == "Kombihebel" && radioT3_Kombihebel.Checked)))
                    {
                        if (txtT3_JoyAchse.Text == "")
                        {
                            trainConfig.RemoveAt(i);
                        }
                        else
                        {
                            singleTrain[Tcfg.zug] = selectedTrain;
                            singleTrain[Tcfg.joystickNummer] = txtT3_JoyNr.Text;
                            singleTrain[Tcfg.joystickInput] = txtT3_JoyAchse.Text;
                            singleTrain[Tcfg.schritte] = txtT3_AnzahlStufen.Text;
                            singleTrain[Tcfg.zeitfaktor] = txtT3_Zeitfaktor.Text;
                            singleTrain[Tcfg.beschreibung] = txtT3_Beschreibung.Text;
                            if (txtT3_JoyUmrechnen.Text.Length >= 3) { singleTrain[Tcfg.inputUmrechnen] = "[" + txtT3_JoyUmrechnen.Text.Replace(" ", "][") + "]"; } else { singleTrain[Tcfg.inputUmrechnen] = ""; }
                            if (txtT3_Sonderfaelle.Text.Length >= 3) { singleTrain[Tcfg.specials] = "[" + txtT3_Sonderfaelle.Text.Replace(" ", "][").Replace("_", " ") + "]"; } else { singleTrain[Tcfg.specials] = ""; }
                            if (txtT3_LongPress.Text.Length >= 3) { singleTrain[Tcfg.laengerDruecken] = "[" + txtT3_LongPress.Text.Replace(" ", "][") + "]"; } else { singleTrain[Tcfg.laengerDruecken] = ""; }
                            if (radioT3_Stufen.Checked) { singleTrain[Tcfg.art] = "Stufen"; } else { singleTrain[Tcfg.art] = "Stufenlos"; }
                            if (checkT3_Invertiert.Checked) { singleTrain[Tcfg.invert] = "1"; } else { singleTrain[Tcfg.invert] = "0"; }
                            if (checkT3_andererJoyModus.Checked) { singleTrain[Tcfg.inputTyp] = "1"; } else { singleTrain[Tcfg.inputTyp] = "0"; }

                            trainConfig[i] = singleTrain;
                        }
                        ersetzt = true;
                        MessageBox.Show("Ersetzt!");
                    }
                }
                if (!ersetzt)
                {
                    string[] singleTrain = new string[trainConfig[0].Length];
                    singleTrain[Tcfg.zug] = selectedTrain;
                    singleTrain[Tcfg.joystickNummer] = txtT3_JoyNr.Text;
                    singleTrain[Tcfg.joystickInput] = txtT3_JoyAchse.Text;
                    singleTrain[Tcfg.schritte] = txtT3_AnzahlStufen.Text;
                    singleTrain[Tcfg.zeitfaktor] = txtT3_Zeitfaktor.Text;
                    singleTrain[Tcfg.beschreibung] = txtT3_Beschreibung.Text;
                    if (txtT3_JoyUmrechnen.Text.Length >= 3) { singleTrain[Tcfg.inputUmrechnen] = "[" + txtT3_JoyUmrechnen.Text.Replace(" ", "][") + "]"; }
                    if (txtT3_Sonderfaelle.Text.Length >= 3) { singleTrain[Tcfg.specials] = "[" + txtT3_Sonderfaelle.Text.Replace(" ", "][").Replace("_", " ") + "]"; }
                    if (txtT3_LongPress.Text.Length >= 3) { singleTrain[Tcfg.laengerDruecken] = "[" + txtT3_LongPress.Text.Replace(" ", "][") + "]"; }
                    if (radioT3_Stufen.Checked) { singleTrain[Tcfg.art] = "Stufen"; } else { singleTrain[Tcfg.art] = "Stufenlos"; }
                    if (checkT3_Invertiert.Checked) { singleTrain[Tcfg.invert] = "1"; } else { singleTrain[Tcfg.invert] = "0"; }
                    if (checkT3_andererJoyModus.Checked) { singleTrain[Tcfg.inputTyp] = "1"; } else { singleTrain[Tcfg.inputTyp] = "0"; }

                    if (radioT3_Schub.Checked) { singleTrain[Tcfg.tastenKombination] = "Schub"; } else if (radioT3_Bremse.Checked) { singleTrain[Tcfg.tastenKombination] = "Bremse"; } else { singleTrain[Tcfg.tastenKombination] = "Kombihebel"; }

                    trainConfig.Add(singleTrain);

                    MessageBox.Show("Erstellt!");
                }
                //Schreibe Datei
                string[] line = new string[trainConfig.Count];
                for (int i = 0; i < trainConfig.Count; i++)
                {
                    string combined = "";
                    foreach (string s in trainConfig[i])
                    {
                        combined += s + ",";
                    }
                    combined = combined.Remove(combined.Length - 1);
                    line[i] = combined;
                }

                File.WriteAllLines(Tcfg.configpfad, line);
            }
            else
            {
                MessageBox.Show("Wähle noch \"Stufenlos\" oder \"Stufen\" aus");
            }
        }
        private void T3Timer_GetJoyStates_Tick(object sender, EventArgs e)
        {
            //Anzeigeliste leeren
            listBoxT3_ShowJoystickStates.Items.Clear();
            for (int i = 0; i < FormMain.MainSticks.Length; i++)
            {
                int[] joyInputs = new int[8];

                JoystickState state = new JoystickState();

                //Bekomme alle Infos über den mit id ausgewählten Stick
                state = FormMain.MainSticks[i].GetCurrentState();

                joyInputs[0] = state.X;
                joyInputs[1] = state.Y;
                joyInputs[2] = state.Z;
                joyInputs[3] = state.GetPointOfViewControllers()[0] + 1;
                joyInputs[4] = state.RotationX;
                joyInputs[5] = state.RotationY;
                joyInputs[6] = state.RotationZ;
                joyInputs[7] = state.GetSliders()[0];


                for (int o = 0; o < joyInputs.Length; o++)
                {
                    if (txtT3_JoyAchse.Text == FormMain.inputNames[o])
                    {
                        if (checkT3_Invertiert.Checked)
                        {
                            //Soll Invertiert werden
                            joyInputs[o] = joyInputs[o] * (-1);
                        }
                        if (checkT3_andererJoyModus.Checked)
                        {
                            //Soll von (0<>100) in (-100<>0<>100) geändert werden
                            joyInputs[o] = (joyInputs[o] / (-2)) + 50;
                        }
                    }

                    //Bestimmt Inputwerte sollen in andere Umgerechnet werden
                    if (txtT3_JoyUmrechnen.Text.Length >= 3 && txtT3_JoyAchse.Text == FormMain.inputNames[o])
                    {
                        try
                        {
                            string[] umrechnen = txtT3_JoyUmrechnen.Text.Split(' ');

                            foreach (string single_umrechnen in umrechnen)
                            {
                                if (single_umrechnen.Contains("|"))
                                {
                                    int von = Convert.ToInt32(single_umrechnen.Remove(single_umrechnen.IndexOf("|"), single_umrechnen.Length - single_umrechnen.IndexOf("|")));

                                    string temp_bis = single_umrechnen.Remove(0, single_umrechnen.IndexOf("|") + 1);
                                    int index = temp_bis.IndexOf("=");
                                    int bis = Convert.ToInt32(temp_bis.Remove(index, temp_bis.Length - index));
                                    int entsprechendeNummer = Convert.ToInt32(single_umrechnen.Remove(0, single_umrechnen.IndexOf("=") + 1));

                                    if (von <= joyInputs[o] && joyInputs[o] <= bis)
                                    {
                                        joyInputs[o] = entsprechendeNummer;
                                        break;
                                    }
                                    else if (von >= joyInputs[o] && joyInputs[o] >= bis)
                                    {
                                        joyInputs[o] = entsprechendeNummer;
                                        break;
                                    }
                                }
                                else
                                {
                                    int index = single_umrechnen.IndexOf("=");
                                    int gesuchteNummer = Convert.ToInt32(single_umrechnen.Remove(index, single_umrechnen.Length - index));
                                    int entsprechendeNummer = Convert.ToInt32(single_umrechnen.Remove(0, index + 1));

                                    if (joyInputs[o] == gesuchteNummer)
                                    {
                                        joyInputs[o] = entsprechendeNummer;
                                        break;
                                    }
                                }
                            }
                        }
                        catch
                        {

                        }
                    }

                    if (joyInputs[o] != 0)
                    {
                        //Zeige den Joystick-Wert nur, wenn er != 0 ist
                        listBoxT3_ShowJoystickStates.Items.Add("Nr:" + i + " " + FormMain.inputNames[o] + "  " + joyInputs[o]);
                    }
                }
            }
        }
        private void btnT3_ZeitfaktorFinden_Click(object sender, EventArgs e)
        {
            FormZeitfaktor formZeitfaktor = new FormZeitfaktor();
            formZeitfaktor.ShowDialog();
        }
        #endregion
    }
}