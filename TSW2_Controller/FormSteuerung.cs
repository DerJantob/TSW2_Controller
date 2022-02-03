using SlimDX.DirectInput;
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
            lblT1_Bedingung.Hide();
            txtT1_Bedingung.Hide();

            lblT2_haltezeit.Hide();
            txtT2_Haltezeit.Hide();

            listBoxT1_ShowJoystickStates.Hide();

            tabControl_Anzeige.Size = new Size(162, 170);

            //Verstecke die Auswahl der Tab-Buttons
            tabControl_Anzeige.Appearance = TabAppearance.FlatButtons;
            tabControl_Anzeige.ItemSize = new Size(0, 1);
            tabControl_Anzeige.SizeMode = TabSizeMode.Fixed;
        }

        private void tabControl_Anzeige_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((TabControl)sender).SelectedIndex)
            {
                case 0:
                    tabControl_Anzeige.Size = new Size(162, 170);
                    break;
                case 1:
                    tabControl_Anzeige.Size = new Size(365, 239);
                    break;
                case 2:
                    tabControl_Anzeige.Size = new Size(307, 256);
                    break;
            }
        }

        #region T0
        private void btnT0_ok_Click(object sender, EventArgs e)
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

        private void btnT0_Add_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region T1
        private void radioT1_normal_CheckedChanged(object sender, EventArgs e)
        {
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
            if (t1IsJoyButton) { btnT1_Erkennen.Enabled = false;listBoxT1_ShowJoystickStates.Show(); Timer_CheckForButtonPress.Start(); } else { btnT1_Erkennen.Enabled = true; listBoxT1_ShowJoystickStates.Hide(); Timer_CheckForButtonPress.Stop(); }
        }
        private void comboBoxT1_KnopfAuswahl_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtT1_Aktion.Text = "";
            txtT1_Bedingung.Text = "";
            txtT1_JoystickKnopf.Text = "";
            txtT1_JoystickNr.Text = "";
            txtT1_Tastenkombination.Text = "";
        }
        private void txtT1_Aktion_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            txtT1_Aktion.Text = Keyboard.ConvertKeyToString(e.KeyCode);
        }
        private void btnT1_Erstellen_Click(object sender, EventArgs e)
        {
            tabControl_Anzeige.SelectedIndex = 2;
        }

        private void comboBoxT1_KnopfAuswahl_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string[] singleTrain in trainConfig)
            {
                if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.beschreibung] == comboBoxT1_KnopfAuswahl.Text)
                {
                    if (singleTrain[Tcfg.inputTyp].Contains("[")) { t1IsJoyButton = true; radioT1_regler.Checked = true; btnT1_Erkennen.Enabled = false; listBoxT1_ShowJoystickStates.Show(); Timer_CheckForButtonPress.Start(); } else { t1IsJoyButton = false; listBoxT1_ShowJoystickStates.Hide(); radioT1_normal.Checked = true; btnT1_Erkennen.Enabled = true; Timer_CheckForButtonPress.Stop(); }

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

            File.WriteAllLines(Tcfg.pfad, line);
        }
        private void btnT1_Erkennen_Click(object sender, EventArgs e)
        {
            btnT1_Erkennen.Enabled = false;
            Timer_CheckForButtonPress.Start();
        }
        private void Timer_CheckForButtonPress_Tick(object sender, EventArgs e)
        {
            string result = getBtn();
            if (result != "" && !t1IsJoyButton)
            {
                txtT1_JoystickKnopf.Text = result.Remove(result.IndexOf('|'), result.Length - result.IndexOf('|'));
                txtT1_JoystickNr.Text = result.Remove(0, result.IndexOf('|') + 1);
                Timer_CheckForButtonPress.Stop();
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

            File.WriteAllLines(Tcfg.pfad, line);
        }
        private void btnT1_Back_Click(object sender, EventArgs e)
        {
            tabControl_Anzeige.SelectedIndex = 0;
        }

        #endregion

        #region T2
        private void txtT2_Taste_KeyDown(object sender, KeyEventArgs e)
        {
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
    }
}
