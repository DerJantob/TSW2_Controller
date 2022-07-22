using SharpDX.DirectInput;
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
using TSW2_Controller.Properties;

namespace TSW2_Controller
{
    public partial class FormSteuerung : Form
    {
        string selectedTrain = "";
        List<string[]> trainConfig = new List<string[]>();
        DirectInput input = new DirectInput();
        bool t1IsJoyButton = false;

        public FormSteuerung()
        {
            InitializeComponent();

            FormMain formMain = new FormMain();
            trainConfig = formMain.trainConfig;

            comboBoxT0_Zugauswahl.Items.Add(Tcfg.nameForGlobal);
            comboBoxT0_Zugauswahl.Items.AddRange(formMain.trainNames.ToArray());
            comboBoxT0_Zugauswahl.SelectedItem = Tcfg.nameForGlobal;

            lblT1_KnopfNr.Text = Sprache.Translate("KnopfNr.", "Button no.");
            lblT3_AnzahlStufen.Hide();
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
            T1Reset(true);
            if (comboBoxT0_Zugauswahl.Text != "" && comboBoxT0_Zugauswahl.Text != Sprache.Zugauswahl())
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
            T3Reset(true);
            if (comboBoxT0_Zugauswahl.Text != "" && comboBoxT0_Zugauswahl.Text != Sprache.Zugauswahl())
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

            if (!exestiertBereits && comboBoxT0_Zugauswahl.Text != "")
            {
                comboBoxT0_Zugauswahl.Items.Add(comboBoxT0_Zugauswahl.Text);
            }
        }
        private void btnT0_Delete_Click(object sender, EventArgs e)
        {
            selectedTrain = comboBoxT0_Zugauswahl.Text;

            if (selectedTrain != "")
            {
                if (MessageBox.Show(Sprache.Translate("Möchtest du wirklich \"","Do you really want to remove \"") + selectedTrain + Sprache.Translate("\" löschen?","?"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (selectedTrain != Tcfg.nameForGlobal)
                    {
                        comboBoxT0_Zugauswahl.Items.Remove(selectedTrain);
                    }

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

                    MessageBox.Show(counter + Sprache.Translate(" Einträge gelöscht!", " entries deleted!"));
                }
            }
        }
        #endregion

        #region T1
        private void T1Reset(bool full)
        {
            if (full)
            {
                comboBoxT1_KnopfAuswahl.Items.Clear();
            }
            comboBoxT1_KnopfAuswahl.Text = "";
            txtT1_Aktion.Text = "";
            txtT1_Bedingung.Text = "";
            txtT1_JoystickKnopf.Text = "";
            txtT1_JoystickNr.Text = "";
            txtT1_Tastenkombination.Text = "";
        }
        private void radioT1_normal_CheckedChanged(object sender, EventArgs e)
        {
            //Auswahl zwischen "normaler Knopf" und "Regler als Knopf"
            if (radioT1_normal.Checked)
            {
                t1IsJoyButton = false;
                lblT1_KnopfNr.Text = Sprache.Translate("KnopfNr.","Button no.");
                lblT1_Bedingung.Hide();
                txtT1_Bedingung.Hide();
            }
            else
            {
                t1IsJoyButton = true;
                lblT1_KnopfNr.Text = Sprache.Translate("JoyName","Joyname");
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
            //erstmal ausgeschaltet

            ////Wenn man eigenen Knopf erstellt dann Leere alle Felder
            //txtT1_Aktion.Text = "";
            //txtT1_Bedingung.Text = "";
            //txtT1_JoystickKnopf.Text = "";
            //txtT1_JoystickNr.Text = "";
            //txtT1_Tastenkombination.Text = "";
        }
        private void txtT1_Aktion_KeyDown(object sender, KeyEventArgs e)
        {
            //Verhindert, dass die gedrückte Taste ins Textfeld geschrieben wird
            e.SuppressKeyPress = true;
        }
        private void txtT1_Aktion_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Wenn man im "Aktion" Feld eine Taste drückt finde passenden Namen zur Taste
            //PreviewKeyDown um auch tab-Taste zu erlauben
            txtT1_Aktion.Text = Keyboard.ConvertKeyToString(e.KeyCode);
            SelectNextControl((Control)sender, true, false, true, true);
        }
        private void txtT1_Aktion_MouseDown(object sender, MouseEventArgs e)
        {
            txtT1_Aktion.Text = "";
        }
        private void btnT1_Editor_Click(object sender, EventArgs e)
        {
            //Erstelle eine Tastenkombination
            if (txtT1_Tastenkombination.Text != "" && (txtT1_Tastenkombination.Text.Split('_').Count() == 3 || txtT1_Tastenkombination.Text.Split('_').Count() % 3 == 0))
            {
                string[] splitted = txtT1_Tastenkombination.Text.Split('_');

                listBoxT2_Output.Items.Clear();

                for (int i = 0; i < splitted.Count(); i += 3)
                {
                    listBoxT2_Output.Items.Add(splitted[i] + "_" + splitted[i + 1] + "_" + splitted[i + 2] );
                }
            }

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
            bool ok = true;
            #region Eingabeüberprüfung
            if (comboBoxT1_KnopfAuswahl.Text == "")
            {
                ok = false;
                Sprache.ShowMessageBox("Kein Name eingegeben", "No name entered");
            }
            if (txtT1_JoystickNr.Text == "" || !txtT1_JoystickNr.Text.All(char.IsDigit))
            {
                ok = false;
                Sprache.ShowMessageBox("Fehler bei Joystick Nr.", "Error with Joy no.");
            }
            if (txtT1_JoystickKnopf.Text == "" || (!txtT1_JoystickKnopf.Text.All(char.IsDigit) && radioT1_normal.Checked) || (!FormMain.inputNames.Any(txtT1_JoystickKnopf.Text.Equals) && radioT1_regler.Checked))
            {
                ok = false;
                if (radioT1_normal.Checked)
                {
                    Sprache.ShowMessageBox("Fehler bei Knopf Nr.", "Error with Button-no.");
                }
                else
                {
                    Sprache.ShowMessageBox("Fehler bei JoyName", "Error with Joyname");
                }
            }
            if (txtT1_Bedingung.Text != "" && (!(txtT1_Bedingung.Text.Contains("<") || txtT1_Bedingung.Text.Contains(">") || txtT1_Bedingung.Text.Contains("=")) || txtT1_Bedingung.Text.Any(char.IsLetter)))
            {
                //txtT1_Bedingung.Text != "" weil es leer sein darf
                ok = false;
                Sprache.ShowMessageBox("Fehler bei Bedingung", "Error with Condition");
            }
            if (txtT1_Aktion.Text == "" && txtT1_Tastenkombination.Text == "")
            {
                ok = false;
                Sprache.ShowMessageBox("Keine Aktion oder Tastenkombination", "No action or keyboard shortcut");
            }
            if (txtT1_Tastenkombination.Text != "" && !(txtT1_Tastenkombination.Text.Split('_').Count() == 3 || txtT1_Tastenkombination.Text.Split('_').Count() % 3 == 0))
            {
                ok = false;
                Sprache.ShowMessageBox("Fehler bei Tastenkombination", "Error with keyboard shortcut");
            }
            #endregion


            if (ok)
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
                        MessageBox.Show(Sprache.Translate("Ersetzt","Relpaced"));
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
                    MessageBox.Show(Sprache.Translate("Hinzugefügt","Added"));
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
        }
        private void btnT1_Erkennen_Click(object sender, EventArgs e)
        {
            //Erkenne die gedrückte Taste
            btnT1_Erkennen.Enabled = false;
            T1Timer_CheckForButtonPress.Start();
        }
        private void T1Timer_CheckForButtonPress_Tick(object sender, EventArgs e)
        {
            int topIndex = listBoxT1_ShowJoystickStates.TopIndex;
            string result = getBtn();
            if (listBoxT1_ShowJoystickStates.Items.Count > topIndex)
            {
                listBoxT1_ShowJoystickStates.TopIndex = topIndex;
            }

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
            int counter = 1;
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
                joyInputs[3] = state.PointOfViewControllers[0] + 1;
                joyInputs[4] = state.RotationX;
                joyInputs[5] = state.RotationY;
                joyInputs[6] = state.RotationZ;
                joyInputs[7] = state.Sliders[0];


                //Alle Knopf states bekommen
                buttons = state.Buttons;


                for (int o = 0; o < buttons.Length; o++)
                {
                    if (buttons[o])
                    {
                        //Zeige den gedrückten Button
                        if (counter <= listBoxT1_ShowJoystickStates.Items.Count)
                        {
                            listBoxT1_ShowJoystickStates.Items[counter - 1] = Sprache.Translate("Nr:","No:") + i + " " + "B" + o;
                        }
                        else
                        {
                            listBoxT1_ShowJoystickStates.Items.Add(Sprache.Translate("Nr:", "No:") + i + " " + "B" + o);
                        }
                        counter++;
                    }
                }
                for (int o = 0; o < joyInputs.Length; o++)
                {
                    if (joyInputs[o] != 0)
                    {
                        //Zeige den Joystick-Wert nur, wenn er != 0 ist
                        if (counter <= listBoxT1_ShowJoystickStates.Items.Count)
                        {
                            listBoxT1_ShowJoystickStates.Items[counter - 1] = Sprache.Translate("Nr:", "No:") + i + " " + FormMain.inputNames[o] + "  " + joyInputs[o];
                        }
                        else
                        {
                            listBoxT1_ShowJoystickStates.Items.Add(Sprache.Translate("Nr:", "No:") + i + " " + FormMain.inputNames[o] + "  " + joyInputs[o]);
                        }
                        counter++;
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
            for (int o = listBoxT1_ShowJoystickStates.Items.Count - counter; o >= 0; o--)
            {
                listBoxT1_ShowJoystickStates.Items[listBoxT1_ShowJoystickStates.Items.Count - o - 1] = "";
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
                    T1Reset(false);
                    Sprache.ShowMessageBox("Entfernt", "Removed");
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
            int insertIndex = listBoxT2_Output.SelectedIndex + 1;
            if (insertIndex == 0)
            {
                insertIndex = listBoxT2_Output.Items.Count;
            }


            if (txtT2_Taste.Text != "")
            {
                if (txtT2_Wartezeit.Text == "") { txtT2_Wartezeit.Text = "0"; }
                if (txtT2_Haltezeit.Text == "") { txtT2_Haltezeit.Text = "0"; }

                if (radioT2_einmalDruecken.Checked)
                {
                    listBoxT2_Output.Items.Insert(insertIndex, txtT2_Taste.Text + "_[press]_[" + txtT2_Wartezeit.Text + "]");
                }
                else if (radioT2_Halten.Checked)
                {
                    listBoxT2_Output.Items.Insert(insertIndex, txtT2_Taste.Text + "_[hold" + txtT2_Haltezeit.Text + "]_[" + txtT2_Wartezeit.Text + "]");
                }
                else if (radioT2_Druecken.Checked)
                {
                    listBoxT2_Output.Items.Insert(insertIndex, txtT2_Taste.Text + "_[down]_[" + txtT2_Wartezeit.Text + "]");
                }
                else if (radioT2_Loslassen.Checked)
                {
                    listBoxT2_Output.Items.Insert(insertIndex, txtT2_Taste.Text + "_[up]_[" + txtT2_Wartezeit.Text + "]");
                }
                listBoxT2_Output.SelectedIndex = insertIndex;
            }
            else
            {
                Sprache.ShowMessageBox("Keine Taste", "No key");
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
            catch (Exception ex)
            {
                Log.ErrorException(ex);
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
                    Log.ErrorException(ex);
                    MessageBox.Show(ex.ToString());
                }
            }
            tabControl_Anzeige.SelectedIndex = 1;
        }
        #endregion

        #region T3
        private void T3Reset(bool full)
        {
            txtT3_JoyNr.Text = "";
            txtT3_JoyAchse.Text = "";
            txtT3_JoyUmrechnen.Text = "";
            txtT3_AnzahlStufen.Text = "";
            txtT3_Sonderfaelle.Text = "";
            txtT3_Zeitfaktor.Text = "";
            txtT3_LongPress.Text = "";

            checkT3_andererJoyModus.Checked = false;
            checkT3_Invertiert.Checked = false;
            if (full)
            {
                radioT3_Schub.Checked = false;
                radioT3_Bremse.Checked = false;
                radioT3_Kombihebel.Checked = false;
                radioT3_Stufenlos.Checked = false;
                radioT3_Stufen.Checked = false;
            }
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
                        if (singleTrain[Tcfg.art] == "Stufen") { radioT3_Stufen.Checked = true; } else if (singleTrain[Tcfg.art] == "Stufenlos") { radioT3_Stufenlos.Checked = true; }
                        if (singleTrain[Tcfg.invertieren] == "1") { checkT3_Invertiert.Checked = true; } else { checkT3_Invertiert.Checked = false; }
                        if (singleTrain[Tcfg.inputTyp] == "1") { checkT3_andererJoyModus.Checked = true; } else { checkT3_andererJoyModus.Checked = false; }

                        foundData = true;

                        break;
                    }
                }
            }
            if (!foundData)
            {
                T3Reset(false);
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
            T3Reset(false);
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
            bool ok = true;
            #region Eingabeüberprüfung
            if (txtT3_JoyAchse.Text == "" && txtT3_JoyNr.Text == "" && txtT3_AnzahlStufen.Text == "" && txtT3_JoyUmrechnen.Text == "" && txtT3_Zeitfaktor.Text == "" && txtT3_LongPress.Text == "" && txtT3_Sonderfaelle.Text == "")
            {
                ok = false;
            }
            else
            {
                if (!(radioT3_Stufen.Checked || radioT3_Stufenlos.Checked))
                {
                    ok = false;
                    Sprache.ShowMessageBox("Wähle noch \"" + radioT3_Stufenlos.Text + "\" oder \"" + radioT3_Stufen.Text + "\" aus", "Please select \"" + radioT3_Stufenlos.Text + "\" or \"" + radioT3_Stufen.Text + "\"");
                }
                if (txtT3_JoyNr.Text == "" || !txtT3_JoyNr.Text.All(char.IsDigit))
                {
                    ok = false;
                    Sprache.ShowMessageBox("Fehler bei Joystick Nr.", "Error with Joy no.");
                }
                if (txtT3_JoyAchse.Text == "" || !FormMain.inputNames.Any(txtT3_JoyAchse.Text.Equals))
                {
                    ok = false;
                    Sprache.ShowMessageBox("Fehler bei Joy-Achse", "Error with Joy-Axis");
                }
                if (radioT3_Stufen.Checked && (!txtT3_AnzahlStufen.Text.All(char.IsDigit) || txtT3_AnzahlStufen.Text == ""))
                {
                    ok = false;
                    Sprache.ShowMessageBox("Fehler bei Anzahl der Stufen", "Error with Number of notches");
                }
                if (txtT3_JoyUmrechnen.Text != "" && (txtT3_JoyUmrechnen.Text.Any(char.IsLetter) || txtT3_JoyUmrechnen.Text.Split(' ').Count() + 1 != txtT3_JoyUmrechnen.Text.Split('=').Count()))
                {
                    //txtT3_JoyUmrechnen.Text != "" weil es leer sein darf
                    ok = false;
                    Sprache.ShowMessageBox("Fehler bei Joy umrechnen", "Error with Reassign joy states");
                }
                if (txtT3_Sonderfaelle.Text != "" && (txtT3_Sonderfaelle.Text.Split(' ').Count() + 1 != txtT3_Sonderfaelle.Text.Split('=').Count()))
                {
                    //txtT3_Sonderfaelle.Text != "" weil es leer sein darf
                    ok = false;
                    Sprache.ShowMessageBox("Fehler bei Sonderfälle umrechnen", "Error with Convert special cases");
                }
                if (txtT3_Zeitfaktor.Text == "" || txtT3_Zeitfaktor.Text.Any(char.IsLetter))
                {
                    ok = false;
                    Sprache.ShowMessageBox("Fehler bei Zeitfakrot", "Error with Time factor");
                }
                if (txtT3_LongPress.Text != "" && (txtT3_LongPress.Text.Split(' ').Count() + 1 != txtT3_LongPress.Text.Split(':').Count()))
                {
                    //txtT3_Zeitfaktor.Text != "" weil es leer sein darf
                    ok = false;
                    Sprache.ShowMessageBox("Fehler bei Länger drücken", "Error with Long press");
                }
            }
            #endregion


            if (radioT3_Stufen.Checked || radioT3_Stufenlos.Checked)
            {
                bool ersetzt = false;
                for (int i = 0; i < trainConfig.Count; i++)
                {
                    string[] singleTrain = trainConfig[i];
                    if (singleTrain[Tcfg.zug] == selectedTrain && ((singleTrain[Tcfg.tastenKombination] == "Schub" && radioT3_Schub.Checked) || (singleTrain[Tcfg.tastenKombination] == "Bremse" && radioT3_Bremse.Checked) || (singleTrain[Tcfg.tastenKombination] == "Kombihebel" && radioT3_Kombihebel.Checked)))
                    {
                        if (txtT3_JoyAchse.Text == "" && txtT3_JoyNr.Text == "" && txtT3_AnzahlStufen.Text == "" && txtT3_JoyUmrechnen.Text == "" && txtT3_Zeitfaktor.Text == "" && txtT3_LongPress.Text == "" && txtT3_Sonderfaelle.Text == "")
                        {
                            trainConfig.RemoveAt(i);
                            Sprache.ShowMessageBox("Gelöscht!", "Deleted!");
                        }
                        else if (ok)
                        {
                            singleTrain[Tcfg.zug] = selectedTrain;
                            singleTrain[Tcfg.joystickNummer] = txtT3_JoyNr.Text;
                            singleTrain[Tcfg.joystickInput] = txtT3_JoyAchse.Text;
                            singleTrain[Tcfg.schritte] = txtT3_AnzahlStufen.Text;
                            singleTrain[Tcfg.zeitfaktor] = txtT3_Zeitfaktor.Text;
                            if (txtT3_JoyUmrechnen.Text.Length >= 3) { singleTrain[Tcfg.inputUmrechnen] = "[" + txtT3_JoyUmrechnen.Text.Replace(" ", "][") + "]"; } else { singleTrain[Tcfg.inputUmrechnen] = ""; }
                            if (txtT3_Sonderfaelle.Text.Length >= 3) { singleTrain[Tcfg.specials] = "[" + txtT3_Sonderfaelle.Text.Replace(" ", "][").Replace("_", " ") + "]"; } else { singleTrain[Tcfg.specials] = ""; }
                            if (txtT3_LongPress.Text.Length >= 3) { singleTrain[Tcfg.laengerDruecken] = "[" + txtT3_LongPress.Text.Replace(" ", "][") + "]"; } else { singleTrain[Tcfg.laengerDruecken] = ""; }
                            if (radioT3_Stufen.Checked) { singleTrain[Tcfg.art] = "Stufen"; } else { singleTrain[Tcfg.art] = "Stufenlos"; }
                            if (checkT3_Invertiert.Checked) { singleTrain[Tcfg.invertieren] = "1"; } else { singleTrain[Tcfg.invertieren] = "0"; }
                            if (checkT3_andererJoyModus.Checked) { singleTrain[Tcfg.inputTyp] = "1"; } else { singleTrain[Tcfg.inputTyp] = "0"; }

                            trainConfig[i] = singleTrain;

                            MessageBox.Show(Sprache.Translate("Ersetzt","Replaced"));
                        }
                        ersetzt = true;
                    }
                }
                if (!ersetzt && ok)
                {
                    string[] singleTrain = new string[trainConfig[0].Length];
                    singleTrain[Tcfg.zug] = selectedTrain;
                    singleTrain[Tcfg.joystickNummer] = txtT3_JoyNr.Text;
                    singleTrain[Tcfg.joystickInput] = txtT3_JoyAchse.Text;
                    singleTrain[Tcfg.schritte] = txtT3_AnzahlStufen.Text;
                    singleTrain[Tcfg.zeitfaktor] = txtT3_Zeitfaktor.Text;
                    if (txtT3_JoyUmrechnen.Text.Length >= 3) { singleTrain[Tcfg.inputUmrechnen] = "[" + txtT3_JoyUmrechnen.Text.Replace(" ", "][") + "]"; }
                    if (txtT3_Sonderfaelle.Text.Length >= 3) { singleTrain[Tcfg.specials] = "[" + txtT3_Sonderfaelle.Text.Replace(" ", "][").Replace("_", " ") + "]"; }
                    if (txtT3_LongPress.Text.Length >= 3) { singleTrain[Tcfg.laengerDruecken] = "[" + txtT3_LongPress.Text.Replace(" ", "][") + "]"; }
                    if (radioT3_Stufen.Checked) { singleTrain[Tcfg.art] = "Stufen"; } else { singleTrain[Tcfg.art] = "Stufenlos"; }
                    if (checkT3_Invertiert.Checked) { singleTrain[Tcfg.invertieren] = "1"; } else { singleTrain[Tcfg.invertieren] = "0"; }
                    if (checkT3_andererJoyModus.Checked) { singleTrain[Tcfg.inputTyp] = "1"; } else { singleTrain[Tcfg.inputTyp] = "0"; }

                    if (radioT3_Schub.Checked) { singleTrain[Tcfg.tastenKombination] = "Schub"; } else if (radioT3_Bremse.Checked) { singleTrain[Tcfg.tastenKombination] = "Bremse"; } else { singleTrain[Tcfg.tastenKombination] = "Kombihebel"; }

                    trainConfig.Add(singleTrain);

                    MessageBox.Show(Sprache.Translate("Erstellt","Added"));
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
                if (Sprache.isGerman)
                {
                    MessageBox.Show("Wähle noch \"" + radioT3_Stufenlos.Text + "\" oder \"" + radioT3_Stufen.Text + "\" aus");
                }
                else
                {
                    MessageBox.Show("Please select \"" + radioT3_Stufenlos.Text + "\" or \"" + radioT3_Stufen.Text + "\"");
                }
            }
        }
        private void T3Timer_GetJoyStates_Tick(object sender, EventArgs e)
        {
            //Anzeigeliste leeren
            int counter = 1;
            int topIndex = listBoxT3_ShowJoystickStates.TopIndex;
            for (int i = 0; i < FormMain.MainSticks.Length; i++)
            {
                int[] joyInputs = new int[8];

                JoystickState state = new JoystickState();

                //Bekomme alle Infos über den mit id ausgewählten Stick
                state = FormMain.MainSticks[i].GetCurrentState();

                joyInputs[0] = state.X;
                joyInputs[1] = state.Y;
                joyInputs[2] = state.Z;
                joyInputs[3] = state.PointOfViewControllers[0] + 1;
                joyInputs[4] = state.RotationX;
                joyInputs[5] = state.RotationY;
                joyInputs[6] = state.RotationZ;
                joyInputs[7] = state.Sliders[0];


                for (int o = 0; o < joyInputs.Length; o++)
                {
                    try
                    {
                        if (txtT3_JoyAchse.Text == FormMain.inputNames[o] && Convert.ToInt32(txtT3_JoyNr.Text) == i)
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
                    }
                    catch
                    {

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
                        if (counter <= listBoxT3_ShowJoystickStates.Items.Count)
                        {
                            listBoxT3_ShowJoystickStates.Items[counter - 1] = Sprache.Translate("Nr:","No:") + i + " " + FormMain.inputNames[o] + "  " + joyInputs[o];
                        }
                        else
                        {
                            listBoxT3_ShowJoystickStates.Items.Add(Sprache.Translate("Nr:", "No:" + i + " " + FormMain.inputNames[o] + "  " + joyInputs[o]));
                        }
                        counter++;
                    }
                }
            }
            for (int o = listBoxT3_ShowJoystickStates.Items.Count - counter; o >= 0; o--)
            {
                listBoxT3_ShowJoystickStates.Items[listBoxT3_ShowJoystickStates.Items.Count - o - 1] = "";
            }
            if (listBoxT3_ShowJoystickStates.Items.Count > topIndex)
            {
                listBoxT3_ShowJoystickStates.TopIndex = topIndex;
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
