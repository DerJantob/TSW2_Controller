using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
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
        public static string newestVersion = "";
        public FormSettings()
        {
            InitializeComponent();

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (version.Split('.')[3] == "0")
            {
                lbl_version.Text = "v" + FormMain.GetVersion(true);
            }
            else
            {
                lbl_version.Text = "Pre-release " + version.Split('.')[3] + " " + "v" + version.Split('.')[0] + "." + version.Split('.')[1] + "." + (Convert.ToInt32(version.Split('.')[2]) + 1);
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            try
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

                checkBox_deleteLogsAutomatically.Checked = Settings.Default.DeleteLogsAutomatically;

                if (Sprache.isGerman)
                {
                    deutschToolStripMenuItem.Checked = true;
                }
                else
                {
                    englischToolStripMenuItem.Checked = true;
                }

                if (newestVersion != "")
                {
                    sucheNachUpdatesToolStripMenuItem1.Text = Sprache.Translate("Installiere v" + newestVersion, "Install v" + newestVersion);
                }

                string[] files = Directory.GetFiles(Tcfg.configOrdnerPfad);
                comboBox_TrainConfig.Items.Add("_Standard");
                foreach (string file in files)
                {
                    comboBox_TrainConfig.Items.Add(Path.GetFileName(file).Replace(".csv", ""));
                }

                if (File.Exists(Tcfg.configOrdnerPfad + Settings.Default.selectedTrainConfig + ".csv"))
                {
                    comboBox_TrainConfig.SelectedItem = Settings.Default.selectedTrainConfig;
                }
                else if (Settings.Default.selectedTrainConfig == "_Standard")
                {
                    comboBox_TrainConfig.SelectedItem = Settings.Default.selectedTrainConfig;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorException(ex);
            }
        }

        #region Updater
        public async void CheckGitHubNewerVersion()
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
                    Log.Add("Update available", false, 1);
                    //The version on GitHub is more up to date than this local release.
                    if (newestVersion.Contains("dontAsk"))
                    {
                        newestVersion = newestVersion.Replace("dontAsk", "");
                        progressBar_updater.Show();
                        DownloadNewestVersion(latestGitHubVersion);
                    }
                    else if (MessageBox.Show("Version " + latestGitHubVersion + Sprache.Translate(" ist verfügbar! Möchtest du aktualisieren?", " is available! Do you want to update?"), "Update", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    Log.Add("No update available");
                    Sprache.ShowMessageBox("Du hast die neuste Version", "You have the latest version");
                }
            }
            catch (Exception ex)
            {
                Log.ErrorException(ex);
                if (Sprache.isGerman)
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
            Log.Add("Download \"" + @"https://github.com/DerJantob/TSW2_Controller/releases/download/" + version + "/TSW2_Controller_Setup.exe\"");

            sucheNachUpdatesToolStripMenuItem1.Text = Sprache.Translate("Installiere...", "Installing...");
            sucheNachUpdatesToolStripMenuItem1.Enabled = false;
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
                Log.ErrorException(ex);
            }
        }
        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (progressBar_updater.Value != e.ProgressPercentage)
            {
                Log.Add("Downloading... " + e.ProgressPercentage + "%");
            }
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
                sucheNachUpdatesToolStripMenuItem1.Text = Sprache.Translate("Download gescheitert", "Download failed");
                sucheNachUpdatesToolStripMenuItem1.Enabled = true;
            }
        }
        #endregion


        #region TrainConfig wechseln
        private void comboBox_TrainConfig_KeyUp(object sender, KeyEventArgs e)
        {
            if (comboBox_TrainConfig.Items.Contains(comboBox_TrainConfig.Text))
            {
                btn_trainconfigHinzufuegen.Enabled = false;
                changeConfig();
                if (comboBox_TrainConfig.Text == "_Standard")
                {
                    btn_trainconfigLoeschen.Enabled = false;
                    btn_export.Enabled = false;

                    btn_trainconfigHinzufuegen.Enabled = false;
                }
                else
                {
                    btn_trainconfigLoeschen.Enabled = true;
                    btn_export.Enabled = true;
                }
            }
            else if (comboBox_TrainConfig.Text == "")
            {
                btn_trainconfigLoeschen.Enabled = false;
                btn_export.Enabled = false;
                btn_trainconfigHinzufuegen.Enabled = false;
            }
            else
            {
                btn_trainconfigLoeschen.Enabled = false;
                btn_export.Enabled = false;
                btn_trainconfigHinzufuegen.Enabled = true;
            }
        }

        private void comboBox_TrainConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^?,:\\/:*?\""<>|]"))
            {
                e.Handled = true;
            }
        }

        private void comboBox_TrainConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_TrainConfig.Text == "_Standard")
            {
                btn_trainconfigLoeschen.Enabled = false;
                btn_export.Enabled = false;
                btn_trainconfigHinzufuegen.Enabled = false;
            }
            else
            {
                btn_trainconfigLoeschen.Enabled = true;
                btn_export.Enabled = true;
                btn_trainconfigHinzufuegen.Enabled = true;
            }
            btn_trainconfigHinzufuegen.Enabled = false;
            changeConfig();
        }

        private void btn_trainconfigHinzufuegen_Click(object sender, EventArgs e)
        {
            if (comboBox_TrainConfig.Text != "")
            {
                if (!comboBox_TrainConfig.Items.Contains(comboBox_TrainConfig.Text))
                {
                    //Hinzufügen
                    if (MessageBox.Show(Sprache.Translate("Einstellungen von ", "Transfer the data of ") + Settings.Default.selectedTrainConfig + Sprache.Translate(" übernehmen?", "?"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Copy(Tcfg.configpfad, Tcfg.configOrdnerPfad + comboBox_TrainConfig.Text + ".csv", true);
                    }
                    else
                    {
                        File.Create(Tcfg.configOrdnerPfad + comboBox_TrainConfig.Text + ".csv").Close();
                        File.WriteAllText(Tcfg.configOrdnerPfad + comboBox_TrainConfig.Text + ".csv", "Zug,Beschreibung,JoystickNummer,JoystickInput,Invertieren,InputTyp,InputUmrechnen,Tastenkombination,Aktion,Art,Schritte,Specials,Zeitfaktor,Länger drücken");
                    }
                    changeConfig();
                    comboBox_TrainConfig.Items.Add(comboBox_TrainConfig.Text);
                    comboBox_TrainConfig.SelectedItem = comboBox_TrainConfig.Text;
                }
            }
            else
            {
                MessageBox.Show(Sprache.Translate("Das Feld darf nicht leer sein", "The text field cannot be empty"));
            }
        }

        private void btn_trainconfigLoeschen_Click(object sender, EventArgs e)
        {
            if (comboBox_TrainConfig.Text != "_Standard")
            {
                if (File.Exists(Tcfg.configOrdnerPfad + comboBox_TrainConfig.Text + ".csv"))
                {
                    if (MessageBox.Show(Sprache.Translate("Möchtest du \"", "Do you want to remove \"") + comboBox_TrainConfig.Text + Sprache.Translate("\" löschen?", "\"?") + "\n" + Sprache.Translate("Alle Züge gehen dabei verloren!", "All trains will be deleted!"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Delete(Tcfg.configOrdnerPfad + comboBox_TrainConfig.Text + ".csv");
                        Settings.Default.selectedTrainConfig = "_Standard";
                        Settings.Default.Save();
                        comboBox_TrainConfig.Items.Remove(comboBox_TrainConfig.Text);
                        comboBox_TrainConfig.Text = "_Standard";
                    }
                }
            }
        }

        private void changeConfig()
        {
            try
            {
                if (comboBox_TrainConfig.Text == "_Standard")
                {
                    if (Settings.Default.selectedTrainConfig != "_Standard")
                    {
                        File.Copy(Tcfg.configpfad, Tcfg.configOrdnerPfad + Settings.Default.selectedTrainConfig + ".csv", true);
                    }
                    File.Copy(Tcfg.configstandardpfad, Tcfg.configpfad, true);
                    Settings.Default.selectedTrainConfig = "_Standard";
                }
                else
                {
                    File.Copy(Tcfg.configOrdnerPfad + comboBox_TrainConfig.Text + ".csv", Tcfg.configpfad, true);
                    Settings.Default.selectedTrainConfig = comboBox_TrainConfig.Text;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorException(ex);
                MessageBox.Show("Error with Trainconfig");
            }
            Settings.Default.Save();
        }
        #endregion

        private void btn_speichern_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.res = new Rectangle(0, 0, Convert.ToInt32(comboBox_resolution.Text.Split('x')[0]), Convert.ToInt32(comboBox_resolution.Text.Split('x')[1]));
            }
            catch (Exception ex)
            {
                Log.ErrorException(ex);
                MessageBox.Show(Sprache.Translate("Fehler bei der Auflösung", "Error with resolution!"));
            }

            try
            {
                Settings.Default.DeleteLogsAutomatically = checkBox_deleteLogsAutomatically.Checked;
            }
            catch (Exception ex)
            {
                Log.ErrorException(ex);
            }

            Settings.Default.showDebug = check_showDebug.Checked;
            Settings.Default.showScanResult = check_ShowScan.Checked;
            Settings.Default.Save();
            Close();
        }

        private void btn_steuerung_Click(object sender, EventArgs e)
        {
            Log.Add("Going to controls");
            FormSteuerung2 formSteuerung2 = new FormSteuerung2();
            formSteuerung2.Location = this.Location;
            formSteuerung2.ShowDialog();
            Log.Add("Leaving controls");

            if (Settings.Default.selectedTrainConfig == "_Standard")
            {
                if (!File.ReadLines(Tcfg.configpfad).SequenceEqual(File.ReadLines(Tcfg.configstandardpfad)))
                {
                    //Die Datei hat sich geändert
                    Log.Add("Config has changed, but standard selected");
                    string name = "yourConfig";
                    if (!File.Exists(Tcfg.configOrdnerPfad + name + ".csv"))
                    {
                        File.Copy(Tcfg.configpfad, Tcfg.configOrdnerPfad + name + ".csv");
                        Settings.Default.selectedTrainConfig = name;
                        Settings.Default.Save();
                        comboBox_TrainConfig.Items.Add(name);
                        comboBox_TrainConfig.SelectedItem = name;
                    }
                    else
                    {
                        int counter = 0;
                        while (File.Exists(Tcfg.configOrdnerPfad + name + counter + ".csv"))
                        { counter++; }

                        name = name + counter.ToString();
                        File.Copy(Tcfg.configpfad, Tcfg.configOrdnerPfad + name + ".csv");
                        Settings.Default.selectedTrainConfig = name;
                        Settings.Default.Save();
                        comboBox_TrainConfig.Items.Add(name);
                        comboBox_TrainConfig.SelectedItem = name;
                    }
                    Log.Add("Saved as " + name);
                }
            }
            else
            {
                File.Copy(Tcfg.configpfad, Tcfg.configOrdnerPfad + Settings.Default.selectedTrainConfig + ".csv", true);
            }
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

        private void txt_ConvertKeyToString_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Wenn man im "Aktion" Feld eine Taste drückt finde passenden Namen zur Taste
            //PreviewKeyDown um auch tab-Taste zu erlauben
            ((TextBox)sender).Text = Keyboard.ConvertKeyToString(e.KeyCode);
            btn_speichern.Select();
        }

        private void txt_SuppressKeyPress_KeyDown(object sender, KeyEventArgs e)
        {
            //Verhindert, dass die gedrückte Taste ins Textfeld geschrieben wird
            e.SuppressKeyPress = true;
        }

        private void wasIstNeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWasIstNeu formWasIstNeu = new FormWasIstNeu("0.0.0");
            formWasIstNeu.ShowDialog();
        }

        private void informationsdateiErstellenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string finishedFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TSW2Controller_HelpFile.zip");
            string startfolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TSW2_Controller";

            if (File.Exists(finishedFile)) { File.Delete(finishedFile); }
            ZipFile.CreateFromDirectory(startfolder, finishedFile, CompressionLevel.Fastest, true);
            Process.Start("explorer.exe", "/select, \"" + finishedFile + "\"");
            Sprache.ShowMessageBox("Datei wurde auf dem Desktop erstellt!", "File has been created on the desktop!");
            Close();
            System.Windows.Forms.Application.Exit();
        }

        private void sucheNachUpdatesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Log.Add("Check github Version...");
            if (newestVersion != "")
            {
                newestVersion += "dontAsk";
            }
            CheckGitHubNewerVersion();
        }

        private void englischToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!englischToolStripMenuItem.Checked)
            {
                englischToolStripMenuItem.Checked = true;
                deutschToolStripMenuItem.Checked = false;

                Settings.Default.Sprache = "en";
                ChangeIndicatorLanguage(Settings.Default.Sprache);
                Settings.Default.Save();
                System.Windows.Forms.Application.Restart();
            }
        }

        private void deutschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!deutschToolStripMenuItem.Checked)
            {
                deutschToolStripMenuItem.Checked = true;
                englischToolStripMenuItem.Checked = false;

                Settings.Default.Sprache = "de-DE";
                ChangeIndicatorLanguage(Settings.Default.Sprache);
                Settings.Default.Save();
                System.Windows.Forms.Application.Restart();
            }
        }

        private void zurConfigGehenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Tcfg.configpfad.Replace("Trainconfig.csv", ""));
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            string path = Tcfg.configOrdnerPfad + comboBox_TrainConfig.Text + ".csv";
            if (File.Exists(path))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "(*.csv)|*.csv";
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.AddExtension = true;
                saveFileDialog.FileName = comboBox_TrainConfig.Text;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    if (File.Exists(saveFileDialog.FileName) && saveFileDialog.OverwritePrompt == true)
                    {
                        MessageBox.Show("YAY");
                        File.Copy(path, saveFileDialog.FileName, true);
                    }
                    else
                    {
                        File.Copy(path, saveFileDialog.FileName, false);
                    }
                }
            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.csv)|*.csv";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool isOK = true;
                using (var reader = new StreamReader(openFileDialog.FileName))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        string[] values = line.Split(',');
                        if (values.Count() != Tcfg.arrayLength)
                        {
                            isOK = false;
                        }
                    }
                }
                if (isOK)
                {
                    if (File.Exists(Tcfg.configOrdnerPfad + openFileDialog.SafeFileName))
                    {
                        if (MessageBox.Show(Sprache.Translate("Überschreiben?", "Overwrite?"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            File.Copy(openFileDialog.FileName, Tcfg.configOrdnerPfad + openFileDialog.SafeFileName, true);
                        }
                        else
                        {
                            isOK = false;
                        }
                    }
                    else
                    {
                        File.Copy(openFileDialog.FileName, Tcfg.configOrdnerPfad + openFileDialog.SafeFileName, true);
                    }

                    if (isOK)
                    {
                        comboBox_TrainConfig.Items.Clear();
                        string[] files = Directory.GetFiles(Tcfg.configOrdnerPfad);
                        comboBox_TrainConfig.Items.Add("_Standard");
                        foreach (string file in files)
                        {
                            comboBox_TrainConfig.Items.Add(Path.GetFileName(file).Replace(".csv", ""));
                        }

                        if (File.Exists(Tcfg.configOrdnerPfad + openFileDialog.SafeFileName))
                        {
                            comboBox_TrainConfig.SelectedItem = openFileDialog.SafeFileName.Replace(".csv", "");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ERROR");
                }
            }
        }
    }
}
