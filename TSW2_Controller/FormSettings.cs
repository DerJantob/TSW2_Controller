using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSW2_Controller
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            lbl_version.Text = "v" + this.ProductVersion.Remove(ProductVersion.Length - 2, 2);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            check_showDebug.Checked = Properties.Settings.Default.showDebug;
            check_ShowScan.Checked = Properties.Settings.Default.showScanResult;

            txt_resHeight.Text = Properties.Settings.Default.res.Height.ToString();
            txt_resWidth.Text = Properties.Settings.Default.res.Width.ToString();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Properties.Settings.Default.res = new Rectangle(0, 0, Convert.ToInt32(txt_resWidth.Text), Convert.ToInt32(txt_resHeight.Text));
            }
            catch
            {
                MessageBox.Show("Fehler bei Auflösung!");
            }

            Properties.Settings.Default.showDebug = check_showDebug.Checked;
            Properties.Settings.Default.showScanResult = check_ShowScan.Checked;
            Properties.Settings.Default.Save();
        }




        private void btn_Zeitumrechnungshilfe_Click(object sender, EventArgs e)
        {
            FormZeitumrechnung formZeitumrechnung = new FormZeitumrechnung();
            formZeitumrechnung.Location = this.Location;
            formZeitumrechnung.ShowDialog();
        }
    }
}
