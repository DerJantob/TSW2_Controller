using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSW2_Controller.Properties;

namespace TSW2_Controller
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            lbl_version.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString().Remove(Assembly.GetExecutingAssembly().GetName().Version.ToString().Length - 2, 2);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            check_showDebug.Checked = Settings.Default.showDebug;
            check_ShowScan.Checked = Settings.Default.showScanResult;

            txt_resHeight.Text = Settings.Default.res.Height.ToString();
            txt_resWidth.Text = Settings.Default.res.Width.ToString();

            comboBox_Schub.Items.Clear();
            comboBox_Bremse.Items.Clear();
            comboBox_kombiSchub.Items.Clear();
            comboBox_kombiBremse.Items.Clear();

            comboBox_Schub.Items.AddRange(Settings.Default.SchubIndexe.Cast<string>().ToArray());
            comboBox_Bremse.Items.AddRange(Settings.Default.BremsIndexe.Cast<string>().ToArray());
            comboBox_kombiSchub.Items.AddRange(Settings.Default.Kombihebel_SchubIndexe.Cast<string>().ToArray());
            comboBox_kombiBremse.Items.AddRange(Settings.Default.Kombihebel_BremsIndexe.Cast<string>().ToArray());
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Settings.Default.res = new Rectangle(0, 0, Convert.ToInt32(txt_resWidth.Text), Convert.ToInt32(txt_resHeight.Text));
            }
            catch
            {
                MessageBox.Show("Fehler bei Auflösung!");
            }

            try
            {
                Settings.Default.SchubIndexe.Clear();
                Settings.Default.SchubIndexe.AddRange(comboBox_Schub.Items.Cast<Object>().Select(item => item.ToString()).ToArray());

                Settings.Default.BremsIndexe.Clear();
                Settings.Default.BremsIndexe.AddRange(comboBox_Bremse.Items.Cast<Object>().Select(item => item.ToString()).ToArray());

                Settings.Default.Kombihebel_SchubIndexe.Clear();
                Settings.Default.Kombihebel_SchubIndexe.AddRange(comboBox_kombiSchub.Items.Cast<Object>().Select(item => item.ToString()).ToArray());

                Settings.Default.Kombihebel_BremsIndexe.Clear();
                Settings.Default.Kombihebel_BremsIndexe.AddRange(comboBox_kombiBremse.Items.Cast<Object>().Select(item => item.ToString()).ToArray());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fehler beim Textindex!");
                MessageBox.Show(ex.ToString());
            }

            Settings.Default.showDebug = check_showDebug.Checked;
            Settings.Default.showScanResult = check_ShowScan.Checked;
            Settings.Default.Save();
        }




        private void btn_Zeitumrechnungshilfe_Click(object sender, EventArgs e)
        {
            FormZeitumrechnung formZeitumrechnung = new FormZeitumrechnung();
            formZeitumrechnung.Location = this.Location;
            formZeitumrechnung.ShowDialog();
        }

        private void btn_updates_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/DerJantob/TSW2_Controller");
        }


        #region Textindex

        private void comboBox_Schub_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                comboBox_Schub.Items.Add(comboBox_Schub.Text);
                comboBox_Schub.Text = "";
            }
        }

        private void comboBox_Bremse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                comboBox_Bremse.Items.Add(comboBox_Bremse.Text);
                comboBox_Bremse.Text = "";
            }
        }

        private void comboBox_kombiSchub_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                comboBox_kombiSchub.Items.Add(comboBox_kombiSchub.Text);
                comboBox_kombiSchub.Text = "";
            }
        }

        private void comboBox_kombiBremse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                comboBox_kombiBremse.Items.Add(comboBox_kombiBremse.Text);
                comboBox_kombiBremse.Text = "";
            }
        }



        private void comboBox_Schub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show("Möchtest du \"" + comboBox_Schub.SelectedItem + "\" entfernen?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                comboBox_Schub.Items.RemoveAt(comboBox_Schub.SelectedIndex);
            }
        }

        private void comboBox_Bremse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show("Möchtest du \"" + comboBox_Bremse.SelectedItem + "\" entfernen?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                comboBox_Bremse.Items.RemoveAt(comboBox_Bremse.SelectedIndex);
            }
        }

        private void comboBox_kombiSchub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show("Möchtest du \"" + comboBox_kombiSchub.SelectedItem + "\" entfernen?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                comboBox_kombiSchub.Items.RemoveAt(comboBox_kombiSchub.SelectedIndex);
            }
        }

        private void comboBox_kombiBremse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show("Möchtest du \"" + comboBox_kombiBremse.SelectedItem + "\" entfernen?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                comboBox_kombiBremse.Items.RemoveAt(comboBox_kombiBremse.SelectedIndex);
            }
        }
        #endregion

        private void btn_changelog_Click(object sender, EventArgs e)
        {
            FormWasIstNeu formWasIstNeu = new FormWasIstNeu("0.0.0");
            formWasIstNeu.ShowDialog();
        }

        private void btn_speichern_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_steuerung_Click(object sender, EventArgs e)
        {
            FormSteuerung formSteuerung = new FormSteuerung();
            formSteuerung.Location = this.Location;
            formSteuerung.ShowDialog();
        }
    }
}
