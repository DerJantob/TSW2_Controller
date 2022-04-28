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

namespace TSW2_Controller
{
    public partial class FormSteuerung2 : Form
    {
        List<string[]> trainConfig = new List<string[]>();
        List<string[]> customController = new List<string[]>();
        string selectedTrain = "";

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


            ReadControllersFile();

            dataGridView1.Size = new Size(254, 205);
        }

        #region Allgemeines

        private void ReadControllersFile()
        {
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

        private void selectT1()
        {
            lblT1_TrainName.Text = selectedTrain;
            tabControl_main.SelectedIndex = 1;

            foreach (string[] singleTrain in trainConfig)
            {
                if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.inputTyp].Contains("Button") && !comboBoxB_KnopfAuswahl.Items.Equals(singleTrain[Tcfg.beschreibung]))
                {
                    comboBoxB_KnopfAuswahl.Items.Add(singleTrain[Tcfg.beschreibung]);
                }
            }
        }
        private void timer_CheckJoysticks_Tick(object sender, EventArgs e)
        {
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
                                    textOutput += "-> "+joyInputs[o].ToString()+" ";
                                    break;
                                }
                                else
                                {
                                    if (joyInputs[o] >= Convert.ToInt32(customController[j][0]) && joyInputs[o] < Convert.ToInt32(customController[j + 1][0]))
                                    {
                                        double steigung = (Convert.ToDouble(customController[j + 1][1]) - Convert.ToDouble(customController[j][1])) / (Convert.ToDouble(customController[j + 1][0]) - Convert.ToDouble(customController[j][0]));

                                        joyInputs[o] = Convert.ToInt32(Math.Round(((joyInputs[o] - Convert.ToDouble(customController[j + 1][0])) * steigung) + Convert.ToDouble(customController[j + 1][1]), 0));
                                        textOutput += "-> " + joyInputs[o].ToString()+" ";
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
                                            textOutput += "-> " + joyInputs[o]+ " ";
                                            break;
                                        }
                                        else if (von >= joyInputs[o] && joyInputs[o] >= bis)
                                        {
                                            joyInputs[o] = entsprechendeNummer;
                                            textOutput += "-> " + joyInputs[o]+" ";
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
                                            textOutput += "-> " + joyInputs[o]+" ";
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
        }
        #endregion

        #region Zugauswahl
        private void btnT0_edit_Click(object sender, EventArgs e)
        {
            selectedTrain = comboBoxT0_Zugauswahl.Text;
            listBoxT1_ControllerList.Items.Clear();
            foreach (string[] singleTrain in trainConfig)
            {
                if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.reglerName] != "" && !listBoxT1_ControllerList.Items.Equals(singleTrain[Tcfg.reglerName]))
                {
                    listBoxT1_ControllerList.Items.Add(singleTrain[Tcfg.reglerName]);
                }
            }
            selectT1();
        }
        #endregion

        #region Konfiguration
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
                }
            }
        }

        #region Regler
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
        private void btnR_Speichern_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Knöpfe
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
        private void btnB_Speichern_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #endregion

        private void tabControl_ReglerKnopf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_ReglerKnopf.SelectedIndex == 0)
            {
                groupBoxT1_Regler.Visible = true;
            }
            else
            {
                groupBoxT1_Regler.Visible = false;
            }
        }
    }
}
