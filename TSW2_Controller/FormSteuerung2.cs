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
        string selectedTrain = "";

        public FormSteuerung2()
        {
            InitializeComponent();

            FormMain formMain = new FormMain();
            trainConfig = formMain.trainConfig;

            comboBoxT0_Zugauswahl.Items.Add(Tcfg.nameForGlobal);
            comboBoxT0_Zugauswahl.Items.AddRange(formMain.trainNames.ToArray());
            comboBoxT0_Zugauswahl.SelectedItem = Tcfg.nameForGlobal;

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
        }
        #endregion

        #region Zugauswahl
        private void btnT0_edit_Click(object sender, EventArgs e)
        {
            selectedTrain = comboBoxT0_Zugauswahl.Text;
            listBoxT1_ControllerList.Items.Clear();
            foreach(string[] singleTrain in trainConfig)
            {
                if(singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.reglerName] != "" && !listBoxT1_ControllerList.Items.Equals(singleTrain[Tcfg.reglerName]))
                {
                    listBoxT1_ControllerList.Items.Add(singleTrain[Tcfg.reglerName]);
                }
            }
            selectT1();
        }
        #endregion

        #region Konfiguration
        private void ResetRegler()
        {

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
            ResetRegler();
            foreach (string[] singleTrain in trainConfig)
            {
                if (singleTrain[Tcfg.zug] == selectedTrain && singleTrain[Tcfg.reglerName] == listBoxT1_ControllerList.SelectedItem.ToString())
                {
                    txtR_JoyNr.Text = singleTrain[Tcfg.joystickNummer];
                    txtR_JoyAchse.Text = singleTrain[Tcfg.joystickInput];
                    txtR_AnzahlStufen.Text = singleTrain[Tcfg.schritte];
                    txtR_LongPress.Text = singleTrain[Tcfg.laengerDruecken];
                    txtR_Sonderfaelle.Text = singleTrain[Tcfg.specials];
                    txtR_Zeitfaktor.Text = singleTrain[Tcfg.zeitfaktor];
                }
            }
        }

        #region Regler
        private void btn_R_eigenes_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible)
            {
                dataGridView1.Hide();
            }
            else
            {
                dataGridView1.Show();
            }
        }
        #endregion

        #region Knöpfe

        #endregion

        #endregion
    }
}
