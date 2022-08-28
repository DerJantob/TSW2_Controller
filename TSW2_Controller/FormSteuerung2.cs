using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSW2_Controller
{
    public partial class FormSteuerung2 : Form
    {
        List<string[]> trainConfig = new List<string[]>();
        List<VirtualController> virtualControllerList = new List<VirtualController>();
        List<string[]> customController = new List<string[]>();
        string selectedTrain = "";
        string selectedRegler = "";

        public FormSteuerung2()
        {
            InitializeComponent();

            FormMain formMain = new FormMain();
            trainConfig = formMain.trainConfig;

            comboBoxT0_Zugauswahl.Items.Add(Tcfg.nameForGlobal);
            comboBoxT0_Zugauswahl.Items.AddRange(formMain.trainNames.ToArray());
            comboBoxT0_Zugauswahl.SelectedItem = Tcfg.nameForGlobal;

            lblB_Bedingung.Hide();
            txtB_Bedingung.Hide();
            lblR_KnopfNr.Text = Sprache.Translate("KnopfNr.", "Button no.");

            dataGridView1.Size = new Size(254, 205);

            //Verstecke die Auswahl der Tab-Buttons
            tabControl_main.Appearance = TabAppearance.FlatButtons;
            tabControl_main.ItemSize = new Size(0, 1);
            tabControl_main.SizeMode = TabSizeMode.Fixed;
            tabControl_main.Size = new Size(313, 104);
        }

        #region Allgemeines
        private void tabControl_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_main.SelectedIndex == 0)
            {
                tabControl_main.Size = new Size(313, 104);
            }
            else if (tabControl_main.SelectedIndex == 2)
            {
                tabControl_main.Size = new Size(313, 348);
            }
            else if (tabControl_main.SelectedIndex == 3)
            {
                tabControl_main.Size = new Size(474, 266);
            }
            else
            {
                tabControl_main.Size = new Size(647, 348);
            }
        }
        private void ReadControllersFile()
        {
            comboBoxT1_Controllers.Items.Clear();
            virtualControllerList.Clear();
            if (File.Exists(Tcfg.controllersConfigPfad))
            {
                using (var reader = new StreamReader(Tcfg.controllersConfigPfad))
                {
                    bool skipFirst = true;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        if (!skipFirst)
                        {
                            VirtualController vc = new VirtualController();
                            vc.InsertFileArray(values);
                            virtualControllerList.Add(vc);

                            comboBoxT1_Controllers.Items.Add(values[0]);
                        }
                        else
                        {
                            skipFirst = false;
                        }
                    }
                }
            }
        }

        private void txt_OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void timer_CheckJoysticks_Tick(object sender, EventArgs e)
        {
            int counter = 1;
            int topIndex = listBox_ShowJoystickStates.TopIndex;
            for (int i = 0; i < FormMain.MainSticks.Length; i++)
            {
                int[] joyInputs = new int[8];

                JoystickState state = new JoystickState();

                state = FormMain.MainSticks[i].GetCurrentState();

                joyInputs[0] = state.X;
                joyInputs[1] = state.Y;
                joyInputs[2] = state.Z;
                joyInputs[3] = state.PointOfViewControllers[0] + 1;
                joyInputs[4] = state.RotationX;
                joyInputs[5] = state.RotationY;
                joyInputs[6] = state.RotationZ;
                joyInputs[7] = state.Sliders[0];


                for (int o = 0; o < state.Buttons.Count(); o++)
                {
                    if (state.Buttons[o] == true)
                    {

                        if (counter <= listBox_ShowJoystickStates.Items.Count)
                        {
                            listBox_ShowJoystickStates.Items[counter - 1] = Sprache.Translate("Nr:", "No:") + i + " B" + o;
                        }
                        else
                        {
                            listBox_ShowJoystickStates.Items.Add(Sprache.Translate("Nr:", "No:") + i + " B" + o);
                        }
                        counter++;
                    }
                }
                for (int o = 0; o < joyInputs.Length; o++)
                {
                    if (joyInputs[o] != 0)
                    {
                        //Zeige den Joystick-Wert nur, wenn er != 0 ist
                        if (counter <= listBox_ShowJoystickStates.Items.Count)
                        {
                            listBox_ShowJoystickStates.Items[counter - 1] = Sprache.Translate("Nr:", "No:") + i + " " + FormMain.inputNames[o] + "  " + joyInputs[o];
                        }
                        else
                        {
                            listBox_ShowJoystickStates.Items.Add(Sprache.Translate("Nr:", "No:" + i + " " + FormMain.inputNames[o] + "  " + joyInputs[o]));
                        }
                        counter++;
                    }
                }

                string textOutput = "";
                try
                {
                    for (int o = 0; i < FormMain.inputNames.Count(); o++)
                    {
                        if (FormMain.inputNames[o] == txtR_JoyAchse.Text && i.ToString() == txtR_JoyNr.Text)
                        {
                            textOutput = joyInputs[o].ToString() + " ";
                            for (int j = 0; j < customController.Count; j++)
                            {
                                if (j + 1 > customController.Count - 1)
                                {
                                    joyInputs[o] = Convert.ToInt32(customController[j][1]);
                                    textOutput += "-> " + joyInputs[o].ToString() + " ";
                                    break;
                                }
                                else
                                {
                                    if (joyInputs[o] >= Convert.ToInt32(customController[j][0]) && joyInputs[o] < Convert.ToInt32(customController[j + 1][0]))
                                    {
                                        double steigung = (Convert.ToDouble(customController[j + 1][1]) - Convert.ToDouble(customController[j][1])) / (Convert.ToDouble(customController[j + 1][0]) - Convert.ToDouble(customController[j][0]));

                                        joyInputs[o] = Convert.ToInt32(Math.Round(((joyInputs[o] - Convert.ToDouble(customController[j + 1][0])) * steigung) + Convert.ToDouble(customController[j + 1][1]), 0));
                                        textOutput += "-> " + joyInputs[o].ToString() + " ";
                                        break;
                                    }
                                }
                            }

                            progressBar_Joystick.Value = joyInputs[o] + 100;
                        }


                        if (txtR_InputUmrechnen.Text.Length >= 3 && txtR_JoyAchse.Text == FormMain.inputNames[o])
                        {
                            try
                            {
                                string[] umrechnen = txtR_InputUmrechnen.Text.Split(' ');

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
                                            textOutput += "-> " + joyInputs[o] + " ";
                                            break;
                                        }
                                        else if (von >= joyInputs[o] && joyInputs[o] >= bis)
                                        {
                                            joyInputs[o] = entsprechendeNummer;
                                            textOutput += "-> " + joyInputs[o] + " ";
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
                                            textOutput += "-> " + joyInputs[o] + " ";
                                            break;
                                        }
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }

                        if (txtR_JoyAchse.Text == FormMain.inputNames[o])
                        {
                            if (radioR_Stufen.Checked)
                            {
                                try
                                {
                                    joyInputs[o] = Convert.ToInt32(Math.Round(joyInputs[o] * (Convert.ToDouble(txtR_AnzahlStufen.Text) / 100), 0));
                                    textOutput += "-> " + joyInputs[o];
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
                catch
                {

                }

                lblR_ReglerStand.Text = textOutput;
            }
            for (int o = listBox_ShowJoystickStates.Items.Count - counter; o >= 0; o--)
            {
                listBox_ShowJoystickStates.Items[listBox_ShowJoystickStates.Items.Count - o - 1] = "";
            }
            if (listBox_ShowJoystickStates.Items.Count > topIndex)
            {
                listBox_ShowJoystickStates.TopIndex = topIndex;
            }
        }
        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Zugauswahl
        private void btnT0_edit_Click(object sender, EventArgs e)
        {
            selectedTrain = comboBoxT0_Zugauswahl.Text;
            ResetKonfiguration();
            if (selectedTrain == Tcfg.nameForGlobal)
            {
                tabControl_ReglerKnopf.SelectedIndex = 1;
                //btnT1_Controller_Add.Enabled = false;
            }
            if (tabControl_ReglerKnopf.SelectedIndex == 1)
            {
                groupBoxT1_Regler.Hide();
            }
            else
            {
                groupBoxT1_Regler.Show();
            }
            tabControl_main.SelectedIndex = 1;
            panel_Regler.Enabled = false;
        }
        private void btnT0_Add_Click(object sender, EventArgs e)
        {
            ComboBox cb = comboBoxT0_Zugauswahl;
            cb.Text = cb.Text.Replace(",", "");
            if (!cb.Items.Contains(cb.Text))
            {
                cb.Items.Add(cb.Text);
                cb.SelectedItem = cb.Text;
                resetControllerBearbeiten(false);
                selectedTrain = comboBoxT0_Zugauswahl.Text;
                ResetKonfiguration();
                tabControl_main.SelectedIndex = 1;
                panel_Regler.Enabled = false;
            }
            else
            {
                resetControllerBearbeiten(false);
            }
            //panel_main.Enabled = true;
        }
        private void btnT0_Delete_Click(object sender, EventArgs e)
        {
            selectedTrain = comboBoxT0_Zugauswahl.Text;

            if (selectedTrain != "")
            {
                if (MessageBox.Show(Sprache.Translate("Möchtest du wirklich \"", "Do you really want to remove \"") + selectedTrain + Sprache.Translate("\" löschen?", "?"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
        private void btnT0_globalKeybinds_Click(object sender, EventArgs e)
        {
            selectedTrain = "";
            resetControllerBearbeiten();
            tabControl_main.SelectedIndex = 2;
        }
        #endregion

        #region Konfiguration
        private void ResetKonfiguration(bool clearLists = true)
        {
            ReadControllersFile();
            lblT1_TrainName.Text = selectedTrain;

            txtR_AnzahlStufen.Text = "";
            txtR_InputUmrechnen.Text = "";
            txtR_JoyAchse.Text = "";
            txtR_JoyNr.Text = "";
            txtR_LongPress.Text = "";
            txtR_Sonderfaelle.Text = "";
            txtR_Zeitfaktor.Text = "";

            txtB_Aktion.Text = "";
            txtB_Bedingung.Text = "";
            txtB_JoystickKnopf.Text = "";
            txtB_JoystickNr.Text = "";
            txtB_Tastenkombination.Text = "";

            comboBoxB_KnopfAuswahl.Text = "";

            if (clearLists)
            {
                listBoxT1_ControllerList.Items.Clear();
                comboBoxB_KnopfAuswahl.Items.Clear();
                foreach (string[] singleTrain in trainConfig)
                {
                    if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.reglerName] != "" && !listBoxT1_ControllerList.Items.Equals(singleTrain[Tcfg.reglerName]))
                    {
                        listBoxT1_ControllerList.Items.Add(singleTrain[Tcfg.reglerName]);
                    }
                }
                foreach (string[] singleTrain in trainConfig)
                {
                    if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.inputTyp].Contains("Button") && !comboBoxB_KnopfAuswahl.Items.Equals(singleTrain[Tcfg.beschreibung]))
                    {
                        comboBoxB_KnopfAuswahl.Items.Add(singleTrain[Tcfg.beschreibung]);
                    }
                }
            }
        }
        private void btnT1_Controller_Add_Click(object sender, EventArgs e)
        {
            bool bereitsVorhanden = false;
            foreach (string item in listBoxT1_ControllerList.Items)
            {
                if (comboBoxT1_Controllers.Text == item || comboBoxT1_Controllers.Text == "")
                {
                    bereitsVorhanden = true;
                    break;
                }
            }
            if (!bereitsVorhanden)
            {
                listBoxT1_ControllerList.Items.Add(comboBoxT1_Controllers.Text);
            }
        }

        private void listBoxT1_ControllerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetKonfiguration(false);
            if (listBoxT1_ControllerList.SelectedItem != null)
            {
                foreach (string[] singleTrain in trainConfig)
                {
                    if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.reglerName] == listBoxT1_ControllerList.SelectedItem.ToString())
                    {
                        txtR_JoyNr.Text = singleTrain[Tcfg.joystickNummer];
                        txtR_JoyAchse.Text = singleTrain[Tcfg.joystickInput];
                        txtR_AnzahlStufen.Text = singleTrain[Tcfg.schritte];
                        txtR_LongPress.Text = singleTrain[Tcfg.laengerDruecken].Replace("[", "").Replace("]", " ").TrimEnd(' ');
                        txtR_Sonderfaelle.Text = singleTrain[Tcfg.specials].Replace(" ", "_").Replace("[", "").Replace("]", " ").TrimEnd(' '); ;
                        txtR_Zeitfaktor.Text = singleTrain[Tcfg.zeitfaktor];
                        txtR_InputUmrechnen.Text = singleTrain[Tcfg.inputUmrechnen].Replace("[", "").Replace("]", " ").TrimEnd(' '); ;

                        if (singleTrain[Tcfg.art] == "Stufenlos")
                        {
                            radioR_Stufenlos.Checked = true;
                        }
                        else
                        {
                            radioR_Stufen.Checked = true;
                        }

                        if (singleTrain[Tcfg.reglerName].Split('|').Count() > 0)
                        {
                            dataGridView1.Rows.Clear();
                            string[] split = singleTrain[Tcfg.invertieren].Split('|');
                            for (int i = 0; i < split.Count() - 1; i += 2)
                            {
                                dataGridView1.Rows.Add(new string[] { split[i], split[i + 1] });
                            }
                            ReadDataGrid();
                        }
                    }
                }
                selectedRegler = listBoxT1_ControllerList.Text;

                radioR_Stufen.Enabled = true;
                foreach (VirtualController vc in virtualControllerList)
                {
                    if (selectedRegler == vc.name)
                    {
                        if (vc.isMasterController)
                        {
                            radioR_Stufen.Enabled = false;
                            radioR_Stufenlos.Checked = true;
                        }
                        break;
                    }
                }

                panel_Regler.Enabled = true;
                btnT1_Controller_Remove.Enabled = true;
            }
        }
        private void btnT1_back_Click(object sender, EventArgs e)
        {
            tabControl_main.SelectedIndex = 0;
        }

        private void tabControl_ReglerKnopf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedTrain == Tcfg.nameForGlobal)
            {
                tabControl_ReglerKnopf.SelectedIndex = 1;
            }
            if (tabControl_ReglerKnopf.SelectedIndex == 0)
            {
                groupBoxT1_Regler.Visible = true;
            }
            else
            {
                groupBoxT1_Regler.Visible = false;
            }
        }

        #region Regler
        private void btnR_Erkennen_Click(object sender, EventArgs e)
        {
            getNumberAndJoy();//First one may contain false information
            Thread.Sleep(30);
            string[] output = getNumberAndJoy();

            txtR_JoyNr.Text = output[0];
            txtR_JoyAchse.Text = output[1];


            string[] getNumberAndJoy()
            {
                bool wait = true;
                List<int[]> JoyStateCurrent = new List<int[]>();
                List<int[]> JoyStateStart = new List<int[]>();
                for (int i = 0; i < FormMain.MainSticks.Length; i++)
                {
                    int[] joyInputs = new int[8];

                    JoystickState state = new JoystickState();

                    state = FormMain.MainSticks[i].GetCurrentState();

                    joyInputs[0] = state.X;
                    joyInputs[1] = state.Y;
                    joyInputs[2] = state.Z;
                    joyInputs[3] = state.PointOfViewControllers[0] + 1;
                    joyInputs[4] = state.RotationX;
                    joyInputs[5] = state.RotationY;
                    joyInputs[6] = state.RotationZ;
                    joyInputs[7] = state.Sliders[0];

                    JoyStateStart.Add(joyInputs);
                }

                int counter = 0;
                while (wait)
                {
                    try
                    {

                        JoyStateCurrent.Clear();
                        for (int i = 0; i < FormMain.MainSticks.Length; i++)
                        {
                            int[] joyInputs = new int[8];

                            JoystickState state = new JoystickState();

                            state = FormMain.MainSticks[i].GetCurrentState();

                            joyInputs[0] = state.X;
                            joyInputs[1] = state.Y;
                            joyInputs[2] = state.Z;
                            joyInputs[3] = state.PointOfViewControllers[0] + 1;
                            joyInputs[4] = state.RotationX;
                            joyInputs[5] = state.RotationY;
                            joyInputs[6] = state.RotationZ;
                            joyInputs[7] = state.Sliders[0];

                            JoyStateCurrent.Add(joyInputs);
                        }
                        Thread.Sleep(10);
                        if (JoyStateStart.Count == JoyStateCurrent.Count)
                        {
                            for (int id = 0; id < JoyStateCurrent.Count(); id++)
                            {
                                for (int input = 0; input < JoyStateCurrent[id].Count(); input++)
                                {
                                    if (Math.Abs(JoyStateStart[id][input] - JoyStateCurrent[id][input]) > 30)
                                    {
                                        return new string[] { id.ToString(), FormMain.inputNames[input] };
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorException(ex);
                    }
                    counter++;
                    if (counter > 500)
                    {
                        wait = false;
                    }
                }
                return new string[] { "/", "/" };
            }
        }
        private void btn_R_eigenes_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible)
            {
                dataGridView1.Hide();
                ReadDataGrid();
            }
            else
            {
                dataGridView1.Show();
                dataGridView1.BringToFront();
            }
        }
        private void ReadDataGrid()
        {
            try
            {
                customController.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    dataGridView1.Rows[i].Cells[1].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                }
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    customController.Add(new string[] { dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString() });
                }
            }
            catch
            {

            }
        }
        private void radioR_CheckedChanged(object sender, EventArgs e)
        {
            if (radioR_Stufenlos.Checked)
            {
                txtR_AnzahlStufen.Visible = false;
                lblR_AnzahlStufen.Visible = false;
            }
            else
            {
                txtR_AnzahlStufen.Visible = true;
                lblR_AnzahlStufen.Visible = true;
            }
        }
        private void btnR_ControllerValues_Click(object sender, EventArgs e)
        {
            try
            {
                bool didSomething = false;
                int realJoyState = Convert.ToInt32(lblR_ReglerStand.Text.Remove(lblR_ReglerStand.Text.IndexOf(" "), lblR_ReglerStand.Text.Length - (lblR_ReglerStand.Text.IndexOf(" "))));
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString() != "100" && dataGridView1.Rows[i].Cells[1].Value.ToString() != "-100" && dataGridView1.Rows[i].Cells[1].Value.ToString() != "0")
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() == ((Button)sender).Text)
                        {
                            dataGridView1.Rows[i].Cells[0].Value = realJoyState;
                            didSomething = true;
                            break;
                        }
                    }
                }
                if (!didSomething)
                {
                    dataGridView1.Rows.Add(realJoyState, ((Button)sender).Text);
                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == realJoyState.ToString() && dataGridView1.Rows[i].Cells[1].Value.ToString() != ((Button)sender).Text)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }
                ReadDataGrid();
            }
            catch (Exception ex)
            {
                Log.ErrorException(ex);
            }
        }
        private void btnR_GetTimeFactor_Click(object sender, EventArgs e)
        {
            FormZeitfaktor2 formZeitfaktor2 = new FormZeitfaktor2(listBoxT1_ControllerList.SelectedItem.ToString(), radioR_Stufenlos.Checked);
            if (formZeitfaktor2.DialogResult != DialogResult.Cancel) { formZeitfaktor2.ShowDialog(); }
            txtR_Zeitfaktor.Text = formZeitfaktor2.resultString;
        }
        private void btnT1_Controller_Remove_Click(object sender, EventArgs e)
        {
            RemoveSelectedController();
        }
        private void listBoxT1_ControllerList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedController();
            }
        }
        private void RemoveSelectedController()
        {
            if (MessageBox.Show(Sprache.Translate("Möchtest du wirklich " + listBoxT1_ControllerList.SelectedItem.ToString() + " löschen?", "Do you really want to delete " + listBoxT1_ControllerList.SelectedItem.ToString() + "?"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < trainConfig.Count; i++)
                {
                    string[] singleTrain = trainConfig[i];
                    if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.reglerName] == listBoxT1_ControllerList.SelectedItem.ToString())
                    {
                        trainConfig.RemoveAt(i);
                    }
                }
                listBoxT1_ControllerList.Items.Remove(listBoxT1_ControllerList.SelectedItem);
                ReglerSpeichern(true);
                panel_Regler.Enabled = false;
                btnT1_Controller_Remove.Enabled = false;
            }
        }
        private void btnR_Speichern_Click(object sender, EventArgs e)
        {
            ReglerSpeichern();
        }
        private void ReglerSpeichern(bool justWriteFile = false)
        {
            if (!justWriteFile)
            {
                bool ok = true;
                #region Eingabeüberprüfung
                if (txtR_JoyAchse.Text == "" && txtR_JoyNr.Text == "" && txtR_AnzahlStufen.Text == "" && txtR_InputUmrechnen.Text == "" && txtR_Zeitfaktor.Text == "" && txtR_LongPress.Text == "" && txtR_Sonderfaelle.Text == "")
                {
                    ok = false;
                }
                else if (txtR_JoyAchse.Text.Contains(",") || txtR_JoyNr.Text.Contains(",") || txtR_AnzahlStufen.Text.Contains(",") || txtR_InputUmrechnen.Text.Contains(",") || txtR_Zeitfaktor.Text.Contains(",") || txtR_LongPress.Text.Contains(",") || txtR_Sonderfaelle.Text.Contains(","))
                {
                    ok = false;
                    Sprache.ShowMessageBox("Du darfst kein Komma benutzen! Das würde deine Config zerstören, also versuch es nicht zu umgehen :)", "You are not allowed to enter a comma! That would break your config, so don't try to work around it :)");
                }
                else
                {
                    if (!(radioR_Stufen.Checked || radioR_Stufenlos.Checked))
                    {
                        ok = false;
                        Sprache.ShowMessageBox("Wähle noch \"" + radioR_Stufenlos.Text + "\" oder \"" + radioR_Stufen.Text + "\" aus", "Please select \"" + radioR_Stufenlos.Text + "\" or \"" + radioR_Stufen.Text + "\"");
                    }
                    if (txtR_JoyNr.Text == "" || !txtR_JoyNr.Text.All(char.IsDigit))
                    {
                        ok = false;
                        Sprache.ShowMessageBox("Fehler bei Joystick Nr.", "Error with Joy no.");
                    }
                    if (txtR_JoyAchse.Text == "" || !FormMain.inputNames.Any(txtR_JoyAchse.Text.Equals))
                    {
                        ok = false;
                        Sprache.ShowMessageBox("Fehler bei Joy-Achse", "Error with Joy-Axis");
                    }
                    if (radioR_Stufen.Checked && (!txtR_AnzahlStufen.Text.All(char.IsDigit) || txtR_AnzahlStufen.Text == ""))
                    {
                        ok = false;
                        Sprache.ShowMessageBox("Fehler bei Anzahl der Stufen", "Error with Number of notches");
                    }
                    if (txtR_InputUmrechnen.Text != "" && (txtR_InputUmrechnen.Text.Any(char.IsLetter) || txtR_InputUmrechnen.Text.Split(' ').Count() + 1 != txtR_InputUmrechnen.Text.Split('=').Count()))
                    {
                        //txtT3_JoyUmrechnen.Text != "" weil es leer sein darf
                        ok = false;
                        Sprache.ShowMessageBox("Fehler bei Joy umrechnen", "Error with Reassign joy states");
                    }
                    if (txtR_Sonderfaelle.Text != "" && (txtR_Sonderfaelle.Text.Split(' ').Count() + 1 != txtR_Sonderfaelle.Text.Split('=').Count()))
                    {
                        //txtT3_Sonderfaelle.Text != "" weil es leer sein darf
                        ok = false;
                        Sprache.ShowMessageBox("Fehler bei Sonderfälle umrechnen", "Error with Convert special cases");
                    }
                    if (txtR_Zeitfaktor.Text == "" || txtR_Zeitfaktor.Text.Any(char.IsLetter))
                    {
                        ok = false;
                        Sprache.ShowMessageBox("Fehler bei Zeitfaktor", "Error with Time factor");
                    }
                    if (txtR_LongPress.Text != "" && (txtR_LongPress.Text.Split(' ').Count() + 1 != txtR_LongPress.Text.Split(':').Count() && !txtR_LongPress.Text.Contains("|")))
                    {
                        //txtT3_Zeitfaktor.Text != "" weil es leer sein darf
                        ok = false;
                        Sprache.ShowMessageBox("Fehler bei Länger drücken", "Error with Long press");
                    }
                }
                #endregion

                if (ok)
                {
                    bool bereitsVorhanden = false;
                    for (int i = 0; i < trainConfig.Count; i++)
                    {
                        string[] singleTrain = trainConfig[i];
                        if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.reglerName] == selectedRegler)
                        {
                            bereitsVorhanden = true;

                            singleTrain[Tcfg.zug] = selectedTrain;
                            singleTrain[Tcfg.joystickNummer] = txtR_JoyNr.Text;
                            singleTrain[Tcfg.joystickInput] = txtR_JoyAchse.Text;
                            singleTrain[Tcfg.schritte] = txtR_AnzahlStufen.Text;
                            singleTrain[Tcfg.zeitfaktor] = txtR_Zeitfaktor.Text;
                            if (txtR_InputUmrechnen.Text.Length >= 3) { singleTrain[Tcfg.inputUmrechnen] = "[" + txtR_InputUmrechnen.Text.Replace(" ", "][") + "]"; } else { singleTrain[Tcfg.inputUmrechnen] = ""; }
                            if (txtR_Sonderfaelle.Text.Length >= 3) { singleTrain[Tcfg.specials] = "[" + txtR_Sonderfaelle.Text.Replace(" ", "][").Replace("_", " ") + "]"; } else { singleTrain[Tcfg.specials] = ""; }
                            if (txtR_LongPress.Text.Length >= 3) { singleTrain[Tcfg.laengerDruecken] = "[" + txtR_LongPress.Text.Replace(" ", "][") + "]"; } else { singleTrain[Tcfg.laengerDruecken] = ""; }
                            if (radioR_Stufen.Checked) { singleTrain[Tcfg.art] = "Stufen"; } else { singleTrain[Tcfg.art] = "Stufenlos"; }

                            string dataGridString = "";
                            if (dataGridView1.Rows.Count > 1)
                            {
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        if (cell.Value != null)
                                        {
                                            dataGridString += cell.Value.ToString() + "|";
                                        }
                                    }
                                }
                                dataGridString = dataGridString.Remove(dataGridString.Length - 1, 1);
                            }
                            singleTrain[Tcfg.invertieren] = dataGridString;
                            trainConfig[i] = singleTrain;
                        }
                    }
                    if (!bereitsVorhanden)
                    {
                        string[] singleTrain = new string[Tcfg.arrayLength];
                        singleTrain[Tcfg.zug] = selectedTrain;
                        singleTrain[Tcfg.reglerName] = selectedRegler;
                        singleTrain[Tcfg.joystickNummer] = txtR_JoyNr.Text;
                        singleTrain[Tcfg.joystickInput] = txtR_JoyAchse.Text;
                        singleTrain[Tcfg.schritte] = txtR_AnzahlStufen.Text;
                        singleTrain[Tcfg.zeitfaktor] = txtR_Zeitfaktor.Text;
                        if (txtR_InputUmrechnen.Text.Length >= 3) { singleTrain[Tcfg.inputUmrechnen] = "[" + txtR_InputUmrechnen.Text.Replace(" ", "][") + "]"; } else { singleTrain[Tcfg.inputUmrechnen] = ""; }
                        if (txtR_Sonderfaelle.Text.Length >= 3) { singleTrain[Tcfg.specials] = "[" + txtR_Sonderfaelle.Text.Replace(" ", "][").Replace("_", " ") + "]"; } else { singleTrain[Tcfg.specials] = ""; }
                        if (txtR_LongPress.Text.Length >= 3) { singleTrain[Tcfg.laengerDruecken] = "[" + txtR_LongPress.Text.Replace(" ", "][") + "]"; } else { singleTrain[Tcfg.laengerDruecken] = ""; }
                        if (radioR_Stufen.Checked) { singleTrain[Tcfg.art] = "Stufen"; } else { singleTrain[Tcfg.art] = "Stufenlos"; }

                        string dataGridString = "";
                        if (dataGridView1.Rows.Count > 1)
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                    {
                                        dataGridString += cell.Value.ToString() + "|";
                                    }
                                }
                            }
                            dataGridString = dataGridString.Remove(dataGridString.Length - 1, 1);
                        }
                        singleTrain[Tcfg.invertieren] = dataGridString;
                        trainConfig.Add(singleTrain);
                    }
                }
            }

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
        private void btnT1_editController_Click(object sender, EventArgs e)
        {
            resetControllerBearbeiten();
            tabControl_main.SelectedIndex = 2;
            if (listBoxT1_ControllerList.SelectedItem != null)
            {
                if (comboBoxT2_Reglerauswahl.Items.Contains(listBoxT1_ControllerList.SelectedItem))
                {
                    comboBoxT2_Reglerauswahl.SelectedItem = listBoxT1_ControllerList.SelectedItem;
                }
            }
        }
        #endregion

        #region Knöpfe
        private void btnB_Erkennen_Click(object sender, EventArgs e)
        {
            string[] output = new string[] { "", "" };

            if (radioB_normal.Checked)
            {
                output = getNumberAndButton();
            }
            else
            {
                output = getNumberAndJoy();
            }

            txtB_JoystickNr.Text = output[0];
            txtB_JoystickKnopf.Text = output[1];


            string[] getNumberAndButton()
            {
                bool wait = true;
                int counter = 0;
                while (wait)
                {
                    try
                    {
                        for (int i = 0; i < FormMain.MainSticks.Length; i++)
                        {
                            int[] joyInputs = new int[8];

                            JoystickState state = new JoystickState();

                            state = FormMain.MainSticks[i].GetCurrentState();

                            bool[] Buttons = state.Buttons;
                            for (int j = 0; j < Buttons.Length; j++)
                            {
                                if (Buttons[j] == true)
                                {
                                    return new string[] { i.ToString(), "B" + j };
                                }
                            }

                        }
                        Thread.Sleep(10);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorException(ex);
                    }
                    counter++;
                    if (counter > 200)
                    {
                        wait = false;
                    }
                }
                return new string[] { "/", "/" };
            }
            string[] getNumberAndJoy()
            {
                bool wait = true;
                List<int[]> JoyStateCurrent = new List<int[]>();
                List<int[]> JoyStateStart = new List<int[]>();
                for (int i = 0; i < FormMain.MainSticks.Length; i++)
                {
                    int[] joyInputs = new int[8];

                    JoystickState state = new JoystickState();

                    state = FormMain.MainSticks[i].GetCurrentState();

                    joyInputs[0] = state.X;
                    joyInputs[1] = state.Y;
                    joyInputs[2] = state.Z;
                    joyInputs[3] = state.PointOfViewControllers[0] + 1;
                    joyInputs[4] = state.RotationX;
                    joyInputs[5] = state.RotationY;
                    joyInputs[6] = state.RotationZ;
                    joyInputs[7] = state.Sliders[0];

                    JoyStateStart.Add(joyInputs);
                }

                int counter = 0;
                while (wait)
                {
                    try
                    {

                        JoyStateCurrent.Clear();
                        for (int i = 0; i < FormMain.MainSticks.Length; i++)
                        {
                            int[] joyInputs = new int[8];

                            JoystickState state = new JoystickState();

                            state = FormMain.MainSticks[i].GetCurrentState();

                            joyInputs[0] = state.X;
                            joyInputs[1] = state.Y;
                            joyInputs[2] = state.Z;
                            joyInputs[3] = state.PointOfViewControllers[0] + 1;
                            joyInputs[4] = state.RotationX;
                            joyInputs[5] = state.RotationY;
                            joyInputs[6] = state.RotationZ;
                            joyInputs[7] = state.Sliders[0];

                            JoyStateCurrent.Add(joyInputs);
                        }
                        Thread.Sleep(10);
                        if (JoyStateStart.Count == JoyStateCurrent.Count)
                        {
                            for (int id = 0; id < JoyStateCurrent.Count(); id++)
                            {
                                for (int input = 0; input < JoyStateCurrent[id].Count(); input++)
                                {
                                    if (Math.Abs(JoyStateStart[id][input] - JoyStateCurrent[id][input]) > 30)
                                    {
                                        return new string[] { id.ToString(), FormMain.inputNames[input] };
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorException(ex);
                    }
                    counter++;
                    if (counter > 200)
                    {
                        wait = false;
                    }
                }
                return new string[] { "/", "/" };
            }
        }
        private void comboBoxB_KnopfAuswahl_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string[] singleTrain in trainConfig)
            {
                if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.beschreibung] == comboBoxB_KnopfAuswahl.Text)
                {
                    txtB_JoystickNr.Text = singleTrain[Tcfg.joystickNummer];
                    txtB_JoystickKnopf.Text = singleTrain[Tcfg.joystickInput];
                    txtB_Aktion.Text = singleTrain[Tcfg.aktion];
                    txtB_Tastenkombination.Text = singleTrain[Tcfg.tastenKombination];
                    txtB_Bedingung.Text = singleTrain[Tcfg.inputTyp].Replace("Button", "").Replace("[", "").Replace("]", " ").TrimEnd(' ');

                    if (singleTrain[Tcfg.inputTyp].Contains("["))
                    {
                        radioB_regler.Checked = true;
                        radioB_normal.Checked = false;
                    }
                    else
                    {
                        radioB_regler.Checked = false;
                        radioB_normal.Checked = true;
                    }
                }
            }
        }
        private void radioB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioB_normal.Checked)
            {
                lblB_Bedingung.Hide();
                txtB_Bedingung.Hide();
                lblR_KnopfNr.Text = Sprache.Translate("KnopfNr.", "Button no.");
            }
            else
            {
                lblB_Bedingung.Show();
                txtB_Bedingung.Show();
                lblR_KnopfNr.Text = Sprache.Translate("JoyName", "Joyname");
            }
        }
        private void btnB_entfernen_Click(object sender, EventArgs e)
        {
            if (comboBoxB_KnopfAuswahl.SelectedItem != null)
            {
                for (int i = 0; i < trainConfig.Count; i++)
                {
                    string[] singleTrain = trainConfig[i];
                    if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.beschreibung] == comboBoxB_KnopfAuswahl.SelectedItem.ToString())
                    {
                        trainConfig.RemoveAt(i);
                        comboBoxB_KnopfAuswahl.Items.Remove(comboBoxB_KnopfAuswahl.SelectedItem);
                        break;
                    }
                }
                Buttons_Speichern(true);
                ResetKonfiguration();
            }
        }
        private void btnB_Speichern_Click(object sender, EventArgs e)
        {
            Buttons_Speichern();
            comboBoxB_KnopfAuswahl.Items.Add(comboBoxB_KnopfAuswahl.Text);
        }
        private void Buttons_Speichern(bool justWriteFile = false)
        {
            if (!justWriteFile)
            {
                bool ok = true;
                #region Eingabeüberprüfung
                if (comboBoxB_KnopfAuswahl.Text.Contains(",") || txtB_Aktion.Text.Contains(",") || txtB_Bedingung.Text.Contains(",") || txtB_JoystickKnopf.Text.Contains(",") || txtB_Tastenkombination.Text.Contains(","))
                {
                    ok = false;
                    Sprache.ShowMessageBox("Du darfst kein Komma benutzen! Das würde deine Config zerstören, also versuch es nicht zu umgehen :)", "You are not allowed to enter a comma! That would break your config, so don't try to work around it :)");
                }
                else
                {
                    if (comboBoxB_KnopfAuswahl.Text == "")
                    {
                        ok = false;
                        Sprache.ShowMessageBox("Kein Name eingegeben", "No name entered");
                    }
                    if (txtB_JoystickNr.Text == "" || !txtB_JoystickNr.Text.All(char.IsDigit))
                    {
                        ok = false;
                        Sprache.ShowMessageBox("Fehler bei Joystick Nr.", "Error with Joy no.");
                    }
                    if (txtB_JoystickKnopf.Text == "" || (!FormMain.inputNames.Any(txtB_JoystickKnopf.Text.Equals) && radioB_regler.Checked))
                    {
                        ok = false;
                        if (radioB_normal.Checked)
                        {
                            Sprache.ShowMessageBox("Fehler bei Knopf Nr.", "Error with Button-no.");
                        }
                        else
                        {
                            Sprache.ShowMessageBox("Fehler bei JoyName", "Error with Joyname");
                        }
                    }
                    if (txtB_Bedingung.Text != "" && (!(txtB_Bedingung.Text.Contains("<") || txtB_Bedingung.Text.Contains(">") || txtB_Bedingung.Text.Contains("=")) || txtB_Bedingung.Text.Any(char.IsLetter)))
                    {
                        //txtB_Bedingung.Text != "" weil es leer sein darf
                        ok = false;
                        Sprache.ShowMessageBox("Fehler bei Bedingung", "Error with Condition");
                    }
                    if (txtB_Aktion.Text == "" && txtB_Tastenkombination.Text == "")
                    {
                        ok = false;
                        Sprache.ShowMessageBox("Keine Aktion oder Tastenkombination", "No action or keyboard shortcut");
                    }
                    if (txtB_Tastenkombination.Text != "" && !(txtB_Tastenkombination.Text.Split('_').Count() == 3 || txtB_Tastenkombination.Text.Split('_').Count() % 3 == 0))
                    {
                        ok = false;
                        Sprache.ShowMessageBox("Fehler bei Tastenkombination", "Error with keyboard shortcut");
                    }
                }
                #endregion

                if (ok)
                {
                    bool bereitsVorhanden = false;
                    for (int i = 0; i < trainConfig.Count; i++)
                    {
                        string[] singleTrain = trainConfig[i];
                        if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.beschreibung] == comboBoxB_KnopfAuswahl.Text)
                        {
                            bereitsVorhanden = true;

                            singleTrain[Tcfg.joystickNummer] = txtB_JoystickNr.Text;
                            if (radioB_normal.Checked) { singleTrain[Tcfg.inputTyp] = "Button"; } else { singleTrain[Tcfg.inputTyp] = "Button[" + txtB_Bedingung.Text.Replace(" ", "][") + "]"; }
                            if (radioB_normal.Checked) { singleTrain[Tcfg.joystickInput] = txtB_JoystickKnopf.Text; } else { singleTrain[Tcfg.joystickInput] = txtB_JoystickKnopf.Text; }
                            singleTrain[Tcfg.aktion] = txtB_Aktion.Text;
                            singleTrain[Tcfg.tastenKombination] = txtB_Tastenkombination.Text;
                            trainConfig[i] = singleTrain;
                        }
                    }

                    if (!bereitsVorhanden)
                    {
                        string[] singleTrain = new string[trainConfig[0].Count()];
                        singleTrain[Tcfg.zug] = selectedTrain;
                        singleTrain[Tcfg.beschreibung] = comboBoxB_KnopfAuswahl.Text.ToString();
                        singleTrain[Tcfg.joystickNummer] = txtB_JoystickNr.Text;
                        if (radioB_normal.Checked) { singleTrain[Tcfg.inputTyp] = "Button"; } else { singleTrain[Tcfg.inputTyp] = "Button[" + txtB_Bedingung.Text.Replace(" ", "][") + "]"; }
                        if (radioB_normal.Checked) { singleTrain[Tcfg.joystickInput] = "B" + txtB_JoystickKnopf.Text; } else { singleTrain[Tcfg.joystickInput] = txtB_JoystickKnopf.Text; }
                        singleTrain[Tcfg.aktion] = txtB_Aktion.Text;
                        singleTrain[Tcfg.tastenKombination] = txtB_Tastenkombination.Text;
                        trainConfig.Add(singleTrain);
                    }
                }
            }
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
        private void btnB_Editor_Click(object sender, EventArgs e)
        {
            resetTastenkombination();

            if (txtB_Tastenkombination.Text != "" && (txtB_Tastenkombination.Text.Split('_').Count() == 3 || txtB_Tastenkombination.Text.Split('_').Count() % 3 == 0))
            {
                string[] splitted = txtB_Tastenkombination.Text.Split('_');

                for (int i = 0; i < splitted.Count(); i += 3)
                {
                    tastenkombiliste.Add(splitted[i] + "_" + splitted[i + 1] + "_" + splitted[i + 2]);


                    splitted[i + 1] = splitted[i + 1].Replace("[", "").Replace("]", "");
                    splitted[i + 2] = splitted[i + 2].Replace("[", "").Replace("]", "");

                    if (splitted[i + 1].Contains("press")) { listBoxT3_Output.Items.Add(Sprache.Translate(splitted[i] + " kurz drücken, danach " + splitted[i + 2] + "ms warten", splitted[i] + " short press, then wait " + splitted[i + 2] + "ms")); }
                    if (splitted[i + 1].Contains("hold")) { listBoxT3_Output.Items.Add(Sprache.Translate(splitted[i] + " für " + splitted[i + 1].Replace("hold", "") + "ms halten, danach " + splitted[i + 2] + "ms warten", "hold " + splitted[i] + " for " + splitted[i + 1].Replace("hold", "") + "ms, then wait " + splitted[i + 2] + "ms")); }
                    if (splitted[i + 1].Contains("down")) { listBoxT3_Output.Items.Add(Sprache.Translate(splitted[i] + " gedrückt halten, danach " + splitted[i + 2] + "ms warten", "hold down " + splitted[i] + ", then wait " + splitted[i + 2] + "ms")); }
                    if (splitted[i + 1].Contains("up")) { listBoxT3_Output.Items.Add(Sprache.Translate(splitted[i] + " loslassen, danach " + splitted[i + 2] + "ms warten", "release " + splitted[i] + ", then wait " + splitted[i + 2] + "ms")); }
                }
            }

            tabControl_main.SelectedIndex = 3;
        }
        #region Tastenkombination
        List<string> tastenkombiliste = new List<string>();
        private void resetTastenkombination()
        {
            listBoxT3_Output.Items.Clear();
            txtT3_Haltezeit.Text = "0";
            txtT3_Taste.Text = "";
            txtT3_Wartezeit.Text = "10";
            radioT3_einmalDruecken.Checked = true;
            lblT3_haltezeit.Hide();
            txtT3_Haltezeit.Hide();

            tastenkombiliste.Clear();
        }
        private void btnT3_Hinzufügen_Click(object sender, EventArgs e)
        {
            int insertIndex = listBoxT3_Output.SelectedIndex + 1;
            if (insertIndex == 0)
            {
                insertIndex = listBoxT3_Output.Items.Count;
            }


            if (txtT3_Taste.Text != "")
            {
                if (txtT3_Wartezeit.Text == "") { txtT3_Wartezeit.Text = "0"; }
                if (txtT3_Haltezeit.Text == "") { txtT3_Haltezeit.Text = "0"; }

                if (radioT3_einmalDruecken.Checked)
                {
                    tastenkombiliste.Insert(insertIndex, txtT3_Taste.Text + "_[press]_[" + txtT3_Wartezeit.Text + "]");
                    listBoxT3_Output.Items.Insert(insertIndex, Sprache.Translate(txtT3_Taste.Text + " kurz drücken, danach " + txtT3_Wartezeit.Text + "ms warten", txtT3_Taste.Text + " short press, then wait " + txtT3_Wartezeit.Text + "ms"));
                }
                else if (radioT3_Halten.Checked)
                {
                    tastenkombiliste.Insert(insertIndex, txtT3_Taste.Text + "_[hold" + txtT3_Haltezeit.Text + "]_[" + txtT3_Wartezeit.Text + "]");
                    listBoxT3_Output.Items.Insert(insertIndex, Sprache.Translate(txtT3_Taste.Text + " für " + txtT3_Haltezeit.Text + "ms halten, danach " + txtT3_Wartezeit.Text + "ms warten", "hold " + txtT3_Taste.Text + " for " + txtT3_Haltezeit.Text + "ms, then wait " + txtT3_Wartezeit.Text + "ms"));
                }
                else if (radioT3_Druecken.Checked)
                {
                    tastenkombiliste.Insert(insertIndex, txtT3_Taste.Text + "_[down]_[" + txtT3_Wartezeit.Text + "]");
                    listBoxT3_Output.Items.Insert(insertIndex, Sprache.Translate(txtT3_Taste.Text + " gedrückt halten, danach " + txtT3_Wartezeit.Text + "ms warten", "press " + txtT3_Taste.Text + " down, then wait " + txtT3_Wartezeit.Text + "ms"));
                }
                else if (radioT3_Loslassen.Checked)
                {
                    tastenkombiliste.Insert(insertIndex, txtT3_Taste.Text + "_[up]_[" + txtT3_Wartezeit.Text + "]");
                    listBoxT3_Output.Items.Insert(insertIndex, Sprache.Translate(txtT3_Taste.Text + " loslassen, danach " + txtT3_Wartezeit.Text + "ms warten", "release " + txtT3_Taste.Text + ", then wait " + txtT3_Wartezeit.Text + "ms"));
                }
                listBoxT3_Output.SelectedIndex = insertIndex;
                radioT3_einmalDruecken.Checked = true;
            }
            else
            {
                Sprache.ShowMessageBox("Keine Taste", "No key");
            }
        }
        private void btnT3_Fertig_Click(object sender, EventArgs e)
        {
            string combined = "";
            if (tastenkombiliste.Count != 0)
            {
                foreach (string single in tastenkombiliste)
                {
                    combined += single + "_";
                }
                combined = combined.Remove(combined.Length - 1, 1);
            }
            txtB_Tastenkombination.Text = combined;
            tabControl_main.SelectedIndex = 1;
        }
        private void listBoxT3_Output_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    int index = listBoxT3_Output.SelectedIndex;
                    tastenkombiliste.RemoveAt(index);
                    listBoxT3_Output.Items.RemoveAt(index);
                    if (listBoxT3_Output.Items.Count > 0)
                    {
                        listBoxT3_Output.SelectedIndex = index - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorException(ex);
                MessageBox.Show("ERROR");
            }
        }
        private void radio_Changed(object sender, EventArgs e)
        {
            if (radioT3_Halten.Checked)
            {
                lblT3_haltezeit.Show();
                txtT3_Haltezeit.Show();
            }
            else
            {
                lblT3_haltezeit.Hide();
                txtT3_Haltezeit.Hide();
            }
        }
        #endregion
        #endregion

        #endregion

        #region Regler bearbeiten
        private void resetControllerBearbeiten(bool fullReset = true)
        {

            txtT2_increase.Text = "";
            txtT2_decrease.Text = "";
            comboBoxT2_mainIndicator.Text = "";
            comboBoxT2_brakearea.Text = "";
            comboBoxT2_throttlearea.Text = "";
            comboBoxT2_mainIndicator.Items.Clear();
            comboBoxT2_brakearea.Items.Clear();
            comboBoxT2_throttlearea.Items.Clear();
            checkboxT2_Kombihebel.Checked = false;

            if (fullReset)
            {
                virtualControllerList.Clear();
                comboBoxT2_Reglerauswahl.Text = "";
                comboBoxT2_Reglerauswahl.Items.Clear();
                if (File.Exists(Tcfg.controllersConfigPfad))
                {
                    using (var reader = new StreamReader(Tcfg.controllersConfigPfad))
                    {
                        bool skipFirst = true;
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            string[] values = line.Split(',');
                            if (!skipFirst)
                            {
                                VirtualController vc = new VirtualController();
                                vc.InsertFileArray(values);

                                virtualControllerList.Add(vc);
                                comboBoxT2_Reglerauswahl.Items.Add(values[0]);
                            }
                            else
                            {
                                skipFirst = false;
                            }
                        }
                    }
                }
            }
        }
        private void comboBoxT2_Reglerauswahl_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetControllerBearbeiten(false);
            string selection = comboBoxT2_Reglerauswahl.SelectedItem.ToString();

            foreach (VirtualController singleController in virtualControllerList)
            {
                if (selection == singleController.name)
                {
                    txtT2_increase.Text = singleController.increaseKey;
                    txtT2_decrease.Text = singleController.decreaseKey;

                    comboBoxT2_mainIndicator.Items.AddRange(singleController.mainIndicators);
                    comboBoxT2_throttlearea.Items.AddRange(singleController.textindicators_throttlearea);
                    comboBoxT2_brakearea.Items.AddRange(singleController.textindicators_brakearea);
                    checkboxT2_Kombihebel.Checked = singleController.isMasterController;
                }
            }
            panel_main.Enabled = true;
        }
        private void comboBoxT2_Reglerauswahl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
            panel_main.Enabled = false;
        }
        private void btnT2_add_Click(object sender, EventArgs e)
        {
            ComboBox cb = comboBoxT2_Reglerauswahl;
            if (!cb.Items.Contains(cb.Text))
            {
                cb.Items.Add(cb.Text);
                panel_main.Enabled = true;
            }
            resetControllerBearbeiten(false);
        }
        private void btnT2_remove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Sprache.Translate("Möchtest du wirklich den Regler " + comboBoxT2_Reglerauswahl.Text + " löschen?", "Do you really want to remove " + comboBoxT2_Reglerauswahl.Text + "?"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ComboBox cb = comboBoxT2_Reglerauswahl;
                if (cb.Items.Contains(cb.Text))
                {
                    for (int i = 0; i < virtualControllerList.Count; i++)
                    {
                        if (virtualControllerList[i].name == cb.Text)
                        {
                            virtualControllerList.RemoveAt(i);
                        }
                    }
                    cb.Items.Remove(cb.Text);

                    //Schreibe Datei
                    string[] line = new string[virtualControllerList.Count + 1];
                    line[0] = VirtualController.firstLine;
                    for (int i = 1; i < virtualControllerList.Count + 1; i++)
                    {
                        VirtualController vc = virtualControllerList[i - 1];

                        string combined = vc.combineToString();

                        line[i] = combined;
                    }

                    File.WriteAllLines(Tcfg.controllersConfigPfad, line);

                    ComboBox cb2 = comboBoxT2_Reglerauswahl;
                    if (!cb2.Items.Contains(cb2.Text))
                    {
                        cb2.Items.Add(cb2.Text);
                    }
                    resetControllerBearbeiten();
                }
                panel_main.Enabled = false;
            }
        }
        private void txt_Aktion_KeyDown(object sender, KeyEventArgs e)
        {
            //Verhindert, dass die gedrückte Taste ins Textfeld geschrieben wird
            e.SuppressKeyPress = true;
        }
        private void txt_Aktion_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Wenn man im "Aktion" Feld eine Taste drückt finde passenden Namen zur Taste
            //PreviewKeyDown um auch tab-Taste zu erlauben
            ((TextBox)sender).Text = Keyboard.ConvertKeyToString(e.KeyCode);
            if (((TextBox)sender).Name != "txtT3_Taste")
            {
                SelectNextControl((Control)sender, true, false, true, true);
            }
        }
        private void txt_Aktion_MouseDown(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }
        private void comboBoxT2_Indicators_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (e.KeyChar == (char)Keys.Enter)
            {
                //add
                if (!cb.Items.Contains(cb.Text) && cb.Text != "")
                {
                    cb.Items.Add(cb.Text);
                    cb.Text = "";
                }
            }
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }
        private void comboBoxT2_Indicators_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (MessageBox.Show(Sprache.Translate("Willst du " + cb.Text + " ENTFERNEN?", "Do you want to REMOVE " + cb.Text + "?"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cb.Items.Remove(cb.Text);
            }
        }
        private void checkboxT2_Kombihebel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxT2_Kombihebel.Checked)
            {
                groupBox_kombihebel.Enabled = true;
            }
            else
            {
                groupBox_kombihebel.Enabled = false;
            }
        }
        private void btnT2_Save_Click(object sender, EventArgs e)
        {
            void checkCombobox(ComboBox comboBox)
            {
                if (comboBox.SelectedItem == null && comboBox.Text != "")
                {
                    comboBox.Items.Add(comboBox.Text);
                }
            }

            checkCombobox(comboBoxT2_mainIndicator);
            checkCombobox(comboBoxT2_throttlearea);
            checkCombobox(comboBoxT2_brakearea);

            if (txtT2_increase.Text != "" && txtT2_decrease.Text != "")
            {
                VirtualController vc = new VirtualController();
                vc.name = comboBoxT2_Reglerauswahl.Text;
                vc.increaseKey = txtT2_increase.Text;
                vc.decreaseKey = txtT2_decrease.Text;
                vc.isMasterController = checkboxT2_Kombihebel.Checked;
                vc.mainIndicators = comboBoxT2_mainIndicator.Items.Cast<Object>().Select(item => item.ToString()).ToArray();
                if (vc.isMasterController)
                {
                    vc.textindicators_throttlearea = comboBoxT2_throttlearea.Items.Cast<Object>().Select(item => item.ToString()).ToArray();
                    vc.textindicators_brakearea = comboBoxT2_brakearea.Items.Cast<Object>().Select(item => item.ToString()).ToArray();
                }
                else
                {
                    vc.textindicators_throttlearea = new string[0];
                    vc.textindicators_brakearea = new string[0];
                }

                bool aleardyExists = false;
                for (int i = 0; i < virtualControllerList.Count; i++)
                {
                    if (virtualControllerList[i].name == comboBoxT2_Reglerauswahl.Text)
                    {
                        aleardyExists = true;
                        virtualControllerList[i] = vc;

                        break;
                    }
                }
                if (!aleardyExists)
                {
                    virtualControllerList.Add(vc);
                }
            }

            //Schreibe Datei
            string[] line = new string[virtualControllerList.Count + 1];
            line[0] = VirtualController.firstLine;
            for (int i = 1; i < virtualControllerList.Count + 1; i++)
            {
                VirtualController vc = virtualControllerList[i - 1];

                string combined = vc.combineToString();

                line[i] = combined;
            }

            File.WriteAllLines(Tcfg.controllersConfigPfad, line);

            ComboBox cb = comboBoxT2_Reglerauswahl;
            if (!cb.Items.Contains(cb.Text))
            {
                cb.Items.Add(cb.Text);
            }
            resetControllerBearbeiten();

            ReadControllersFile();

            if (selectedTrain != "")
            {
                tabControl_main.SelectedIndex = 1;
            }
            else
            {
                tabControl_main.SelectedIndex = 0;
            }
        }
        private void btnT2_back_Click(object sender, EventArgs e)
        {
            if (selectedTrain != "")
            {
                resetControllerBearbeiten(true);
                tabControl_main.SelectedIndex = 1;
            }
            else
            {
                tabControl_main.SelectedIndex = 0;
            }
        }
        private void btnT2_defaultSettings_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Sprache.Translate("Möchtest du wirklich alle Regler auf die Standardeinstellungen zurücksetzen? (Ohne speichern wirksam)", "Do you really want to reset all controllers to default settings?"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Sprache.isGerman)
                {
                    File.Copy(Tcfg.controllersstandardpfad_DE, Tcfg.controllersConfigPfad, true);
                    Log.Add("Copy :" + Tcfg.controllersstandardpfad_DE + " to " + Tcfg.controllersConfigPfad);
                }
                else
                {
                    File.Copy(Tcfg.controllersstandardpfad_EN, Tcfg.controllersConfigPfad, true);
                    Log.Add("Copy :" + Tcfg.controllersstandardpfad_EN + " to " + Tcfg.controllersConfigPfad);
                }
                resetControllerBearbeiten();
            }
        }
        #endregion
    }
}
