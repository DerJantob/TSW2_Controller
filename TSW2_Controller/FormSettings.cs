using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (version.EndsWith("0"))
            {
                lbl_version.Text = "v" + version.Remove(version.Length - 2, 2);
            }
            else
            {
                lbl_version.Text = "Pre-release " + version.Split('.')[3] +" "+ "v" + version.Split('.')[0] + "." + version.Split('.')[1] + "." + (Convert.ToInt32(version.Split('.')[2]) + 1);
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            check_showDebug.Checked = Settings.Default.showDebug;
            check_ShowScan.Checked = Settings.Default.showScanResult;


            string resName = Settings.Default.res.Width.ToString() + "x" + Settings.Default.res.Height.ToString();
            if (!comboBox_resolution.Items.Contains(resName))
            {
                comboBox_resolution.Items.Add(resName);
            }
            if (comboBox_resolution.Items.Contains(resName))
            {
                comboBox_resolution.SelectedItem = resName;
            }


            comboBox_Schub.Items.Clear();
            comboBox_Bremse.Items.Clear();
            comboBox_kombiSchub.Items.Clear();
            comboBox_kombiBremse.Items.Clear();

            comboBox_Schub.Items.AddRange(Settings.Default.SchubIndexe.Cast<string>().ToArray());
            comboBox_Bremse.Items.AddRange(Settings.Default.BremsIndexe.Cast<string>().ToArray());
            comboBox_kombiSchub.Items.AddRange(Settings.Default.Kombihebel_SchubIndexe.Cast<string>().ToArray());
            comboBox_kombiBremse.Items.AddRange(Settings.Default.Kombihebel_BremsIndexe.Cast<string>().ToArray());
        }

        #region Updater
        private void btn_updates_Click(object sender, EventArgs e)
        {
            CheckGitHubNewerVersion();
        }

        private async void CheckGitHubNewerVersion()
        {
            try
            {
                GitHubClient client = new GitHubClient(new ProductHeaderValue("DerJantob"));
                IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("DerJantob", "TSW2_Controller");

                //Setup the versions
                Version latestGitHubVersion = new Version(releases[0].TagName);
                Version localVersion = new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString().Remove(Assembly.GetExecutingAssembly().GetName().Version.ToString().Length - 2, 2)); //Replace this with your local version. 
                                                                                                                                                                                                     //Only tested with numeric values.
                int versionComparison = localVersion.CompareTo(latestGitHubVersion);
                if (versionComparison < 0)
                {
                    //The version on GitHub is more up to date than this local release.
                    if (MessageBox.Show("Version " + latestGitHubVersion + Sprache.ist_verfuegbar_Moechtest_du_aktualisieren, "Update", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        progressBar_updater.Show();
                        DownloadNewestVersion(latestGitHubVersion);
                    }
                    else
                    {
                        System.Diagnostics.Process.Start("https://github.com/DerJantob/TSW2_Controller");
                    }
                }
                else
                {
                    //This local Version and the Version on GitHub are equal
                    MessageBox.Show(Sprache.Du_hast_die_neueste_Version);
                }
            }
            catch
            {
                if (Sprache.SprachenName == "Deutsch")
                {
                    MessageBox.Show("Es konnte keine Verbindung zu \"github.com/DerJantob/TSW2_Controller\" hergestellt werden.\n\nDas kann eventuell daran liegen dass das Anfragelimit überschritten wurde. Das wird nach einer Stunde zurückgesetzt.");
                }
                else
                {
                    MessageBox.Show("Could not reach \"github.com/DerJantob/TSW2_Controller\"\n\nThis may be due to the fact that the request limit has been exceeded. This is reset after one hour.");
                }
            }
        }
        private void DownloadNewestVersion(Version version)
        {
            Uri uri = new Uri(@"https://github.com/DerJantob/TSW2_Controller/releases/download/" + version + @"/TSW2_Controller_Setup.exe");
            var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp/TSW2_Controller_Setup.exe");

            try
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                WebClient wc = new WebClient();
                wc.DownloadFileAsync(uri, filename);
                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar_updater.Value = e.ProgressPercentage;
        }
        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp/TSW2_Controller_Setup.exe"));
                Close();
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                MessageBox.Show("Unable to download exe", "Download failed!");
                progressBar_updater.Hide();
            }
        }
        #endregion

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
            if (MessageBox.Show(Sprache.Moechtest_du + comboBox_Schub.SelectedItem + Sprache.entfernen, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                comboBox_Schub.Items.RemoveAt(comboBox_Schub.SelectedIndex);
            }
        }

        private void comboBox_Bremse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show(Sprache.Moechtest_du + comboBox_Bremse.SelectedItem + Sprache.entfernen, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                comboBox_Bremse.Items.RemoveAt(comboBox_Bremse.SelectedIndex);
            }
        }

        private void comboBox_kombiSchub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show(Sprache.Moechtest_du + comboBox_kombiSchub.SelectedItem + Sprache.entfernen, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                comboBox_kombiSchub.Items.RemoveAt(comboBox_kombiSchub.SelectedIndex);
            }
        }

        private void comboBox_kombiBremse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show(Sprache.Moechtest_du + comboBox_kombiBremse.SelectedItem + Sprache.entfernen, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                comboBox_kombiBremse.Items.RemoveAt(comboBox_kombiBremse.SelectedIndex);
            }
        }
        #endregion

        private void btn_Zeitumrechnungshilfe_Click(object sender, EventArgs e)
        {
            FormZeitfaktor formZeitumrechnung = new FormZeitfaktor();
            formZeitumrechnung.Location = this.Location;
            formZeitumrechnung.ShowDialog();
        }

        private void btn_changelog_Click(object sender, EventArgs e)
        {
            FormWasIstNeu formWasIstNeu = new FormWasIstNeu("0.0.0");
            formWasIstNeu.ShowDialog();
        }

        private void btn_speichern_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.res = new Rectangle(0, 0, Convert.ToInt32(comboBox_resolution.Text.Split('x')[0]), Convert.ToInt32(comboBox_resolution.Text.Split('x')[1]));
            }
            catch
            {
                MessageBox.Show(Sprache.Fehler_bei_Aufloesung);
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
            catch (Exception ex)
            {
                MessageBox.Show(Sprache.Fehler_beim_Textindikator);
                MessageBox.Show(ex.ToString());
            }

            Settings.Default.showDebug = check_showDebug.Checked;
            Settings.Default.showScanResult = check_ShowScan.Checked;
            Settings.Default.Save();
            Close();
        }

        private void btn_steuerung_Click(object sender, EventArgs e)
        {
            FormSteuerung formSteuerung = new FormSteuerung();
            formSteuerung.Location = this.Location;
            formSteuerung.ShowDialog();
        }

        private void btn_Sprache_Click(object sender, EventArgs e)
        {
            if (Settings.Default.Sprache == "de-DE")
            {
                Settings.Default.Sprache = "en";
            }
            else
            {
                Settings.Default.Sprache = "de-DE";
            }

            ChangeIndicatorLanguage(Settings.Default.Sprache);

            Settings.Default.Save();
            System.Windows.Forms.Application.Restart();
        }

        private void ChangeIndicatorLanguage(string Sprache)
        {
            if (Sprache == "de-DE")
            {
                Settings.Default.SchubIndexe_EN = Settings.Default.SchubIndexe;
                Settings.Default.BremsIndexe_EN = Settings.Default.BremsIndexe;
                Settings.Default.Kombihebel_SchubIndexe_EN = Settings.Default.Kombihebel_SchubIndexe;
                Settings.Default.Kombihebel_BremsIndexe_EN = Settings.Default.Kombihebel_BremsIndexe;

                Settings.Default.SchubIndexe = Settings.Default.SchubIndexe_DE;
                Settings.Default.BremsIndexe = Settings.Default.BremsIndexe_DE;
                Settings.Default.Kombihebel_SchubIndexe = Settings.Default.Kombihebel_SchubIndexe_DE;
                Settings.Default.Kombihebel_BremsIndexe = Settings.Default.Kombihebel_BremsIndexe_DE;
            }
            else
            {
                Settings.Default.SchubIndexe_DE = Settings.Default.SchubIndexe;
                Settings.Default.BremsIndexe_DE = Settings.Default.BremsIndexe;
                Settings.Default.Kombihebel_SchubIndexe_DE = Settings.Default.Kombihebel_SchubIndexe;
                Settings.Default.Kombihebel_BremsIndexe_DE = Settings.Default.Kombihebel_BremsIndexe;

                Settings.Default.SchubIndexe = Settings.Default.SchubIndexe_EN;
                Settings.Default.BremsIndexe = Settings.Default.BremsIndexe_EN;
                Settings.Default.Kombihebel_SchubIndexe = Settings.Default.Kombihebel_SchubIndexe_EN;
                Settings.Default.Kombihebel_BremsIndexe = Settings.Default.Kombihebel_BremsIndexe_EN;
            }
        }

        private void btn_textindikator_StandardLaden_Click(object sender, EventArgs e)
        {
            comboBox_Schub.Items.Clear();
            comboBox_Bremse.Items.Clear();
            comboBox_kombiSchub.Items.Clear();
            comboBox_kombiBremse.Items.Clear();

            if (Sprache.SprachenName == "Deutsch")
            {
                comboBox_Schub.Items.AddRange(Settings.Default.SchubIndexe_DE.Cast<string>().ToArray());
                comboBox_Bremse.Items.AddRange(Settings.Default.BremsIndexe_DE.Cast<string>().ToArray());
                comboBox_kombiSchub.Items.AddRange(Settings.Default.Kombihebel_SchubIndexe_DE.Cast<string>().ToArray());
                comboBox_kombiBremse.Items.AddRange(Settings.Default.Kombihebel_BremsIndexe_DE.Cast<string>().ToArray());
                MessageBox.Show("Textindikatoren wurden zurückgesetzt!");
            }
            else
            {
                comboBox_Schub.Items.AddRange(Settings.Default.SchubIndexe_EN.Cast<string>().ToArray());
                comboBox_Bremse.Items.AddRange(Settings.Default.BremsIndexe_EN.Cast<string>().ToArray());
                comboBox_kombiSchub.Items.AddRange(Settings.Default.Kombihebel_SchubIndexe_EN.Cast<string>().ToArray());
                comboBox_kombiBremse.Items.AddRange(Settings.Default.Kombihebel_BremsIndexe_EN.Cast<string>().ToArray());
                MessageBox.Show("Text indicators have been reset!");
            }
        }
    }
}
