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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            check_showDebug.Checked = Properties.Settings.Default.showDebug;
            txt_resHeight.Text = Properties.Settings.Default.res.Height.ToString();
            txt_resWidth.Text = Properties.Settings.Default.res.Width.ToString();
        }

        private void check_showDebug_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.showDebug = check_showDebug.Checked;
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

            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
            Keyboard.HoldKey((byte)Keys.A,1000);
        }
    }
}
