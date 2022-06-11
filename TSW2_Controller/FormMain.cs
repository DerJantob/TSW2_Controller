﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using SharpDX.DirectInput;
using System.IO;
using TSW2_Controller.Properties;
using System.Reflection;
using System.Net;
using Octokit;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace TSW2_Controller
{
    public partial class FormMain : Form
    {
        DirectInput input = new DirectInput();
        public static Joystick[] MainSticks;

        public Rectangle res = Screen.PrimaryScreen.Bounds;

        public List<string[]> trainConfig = new List<string[]>();
        List<VirtualController> vControllerList = new List<VirtualController>();

        List<string[]> activeTrain = new List<string[]>();
        List<VirtualController> activeVControllers = new List<VirtualController>();

        public List<string> trainNames = new List<string>();

        List<object[]> joystickStates = new List<object[]>(); // id, joyInputs, inputNames, buttons

        static TesseractEngine TCengine = new TesseractEngine(@"./tessdata", "deu", EngineMode.Default);

        bool[] currentlyPressedButtons = new bool[128];
        bool[] previouslyPressedButtons = new bool[128];

        public static string[] inputNames = { "JoyX", "JoyY", "JoyZ", "pov", "RotX", "RotY", "RotZ", "Sldr" };

        bool globalIsDeactivated = false;




        //Soll später weg
        //string[] defaultDE_schubIndexe = { "Fahrschalter", "Geschwindigkeitswähler", "Leistungsregler", "Fahrstufenschalter", "Leistungshebel", "Kombihebel", "Leistung/Bremse" };
        //string[] defaultDE_bremsIndexe = { "Führerbremsventil", "Zugbremse", "Fahrerbremsventil" };
        //string[] defaultDE_kombihebel_schubIndexe = { "Leistung" };
        //string[] defaultDE_kombihebel_bremsIndexe = { "Bremsleistung", "Bremse" };
        //
        //string[] defaultEN_schubIndexe = { "Throttle", "Master Controller" };
        //string[] defaultEN_bremsIndexe = { "Train Brake" };
        //string[] defaultEN_kombihebel_schubIndexe = { "Power" };
        //string[] defaultEN_kombihebel_bremsIndexe = { "Brake" };
        //
        //string[] throttleConfig; //{Aktiver Indikator,Art,Schritte,Specials,Zeit,längerDrücken,Beschreibung}
        //string[] brakeConfig; //{Aktiver Indikator,Art,Schritte,Specials,Zeit,LängerDrücken,Beschreibung}

        //List<string> schubIndexe = new List<string>();
        //List<string> bremsIndexe = new List<string>();
        //List<string> kombihebel_schubIndexe = new List<string>();
        //List<string> kombihebel_bremsIndexe = new List<string>();
        //soll später weg


        public FormMain()
        {
            checkVersion();
            checkLanguageSetting();

            Log.Add("Init components");
            InitializeComponent();

            #region Dateistruktur überprüfen
            if (!File.Exists(Tcfg.configpfad))
            {
                if (!Directory.Exists(Tcfg.configpfad.Replace(@"\Trainconfig.csv", "")))
                {
                    Directory.CreateDirectory(Tcfg.configpfad.Replace(@"\Trainconfig.csv", ""));
                    Log.Add("Create Dir:" + Tcfg.configpfad.Replace(@"\Trainconfig.csv", ""));
                }
                if (File.Exists(Tcfg.configstandardpfad))
                {
                    File.Copy(Tcfg.configstandardpfad, Tcfg.configpfad, false);
                    Log.Add("No TrainConfig.csv");
                    Log.Add("Copy :" + Tcfg.configstandardpfad + " to " + Tcfg.configpfad);
                }
            }
            if (!File.Exists(Tcfg.controllersConfigPfad))
            {
                File.Create(Tcfg.controllersConfigPfad);
                Log.Add("Create File:" + Tcfg.controllersConfigPfad);
            }
            if (!Directory.Exists(Tcfg.configOrdnerPfad))
            {
                Directory.CreateDirectory(Tcfg.configOrdnerPfad);
                Log.Add("Create Dir:" + Tcfg.configOrdnerPfad);
            }
            if (Settings.Default.selectedTrainConfig == "_Standard")
            {
                File.Copy(Tcfg.configstandardpfad, Tcfg.configpfad, true);
                Log.Add("Copy:" + Tcfg.configstandardpfad + " to " + Tcfg.configpfad);
            }
            else
            {
                if (File.Exists(Tcfg.configOrdnerPfad + Settings.Default.selectedTrainConfig + ".csv"))
                {
                    File.Copy(Tcfg.configOrdnerPfad + Settings.Default.selectedTrainConfig + ".csv", Tcfg.configpfad, true);
                    Log.Add("Copy:" + Tcfg.configOrdnerPfad + Settings.Default.selectedTrainConfig + ".csv" + " to " + Tcfg.configpfad);
                }
                else
                {
                    File.Copy(Tcfg.configpfad, Tcfg.configOrdnerPfad + Settings.Default.selectedTrainConfig + ".csv", true);
                    Log.Add("Copy:" + Tcfg.configpfad + " to " + Tcfg.configOrdnerPfad + Settings.Default.selectedTrainConfig + ".csv");
                }
            }
            #endregion

            lbl_originalResult.Text = "";
            lbl_alternativeResult.Text = "";
            lbl_updateAvailable.Text = "";
            groupBox_ScanErgebnisse.Hide();

            CheckGitHubNewerVersion();

            Keyboard.initKeylist();

            loadSettings();

            MainSticks = getSticks();

            ReadVControllers();
            ReadTrainConfig();

            timer_CheckSticks.Start();
        }

        #region UI
        #region Haupttimer
        private void timer_CheckSticks_Tick(object sender, EventArgs e)
        {
            Main();
        }
        #endregion
        #region Zugauswahl
        private void comboBox_Zugauswahl_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_active.Checked = false;
            Log.Add(comboBox_Zugauswahl.Text + " selected");

            if (Settings.Default.deactivatedGlobals.Count > 0)
            {
                if (Settings.Default.deactivatedGlobals.Contains(comboBox_Zugauswahl.Text))
                {
                    check_deactivateGlobal.CheckedChanged -= check_deactivateGlobal_CheckedChanged;
                    check_deactivateGlobal.Checked = true;
                    check_deactivateGlobal.CheckedChanged += check_deactivateGlobal_CheckedChanged;

                    globalIsDeactivated = true;
                    Log.Add("_global is deactivated", false, 1);
                }
                else
                {
                    check_deactivateGlobal.CheckedChanged -= check_deactivateGlobal_CheckedChanged;
                    check_deactivateGlobal.Checked = false;
                    check_deactivateGlobal.CheckedChanged += check_deactivateGlobal_CheckedChanged;

                    globalIsDeactivated = false;
                }
            }

            getActiveTrain();
            getActiveVControllers();
        }
        #endregion
        #region Checkbox Aktiv
        private void check_active_CheckedChanged(object sender, EventArgs e)
        {
            if (check_active.Checked)
            {
                check_active.BackColor = Color.Lime;
                Log.Add("----------------------------------------------------------------------------------------------------");
                Log.Add("----------------------------------------------------------------------------------------------------");
                Log.Add("Active = true");
                Log.Add("Active Train:"); foreach (string[] train in activeTrain) { Log.Add(string.Join(",", train), false, 1); }
                Log.Add("");
                Log.Add("Textindicators:");
                Log.Add("   Throttle/Brake:");
                Log.Add("       Throttle/MasterController:" + string.Join(",", Settings.Default.SchubIndexe.Cast<string>().ToArray()));
                Log.Add("       Brake:" + string.Join(",", Settings.Default.BremsIndexe.Cast<string>().ToArray()));
                Log.Add("   MasterController:");
                Log.Add("       Throttle area:" + string.Join(",", Settings.Default.Kombihebel_SchubIndexe.Cast<string>().ToArray()));
                Log.Add("       Braking area:" + string.Join(",", Settings.Default.Kombihebel_BremsIndexe.Cast<string>().ToArray()));
                Log.Add("");
                Log.Add("KeyLayout:" + string.Join(",", Settings.Default.Tastenbelegung.Cast<string>().ToArray()));
                Log.Add("version:" + "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString().Remove(Assembly.GetExecutingAssembly().GetName().Version.ToString().Length - 2, 2));
                Log.Add("Resolution:" + Settings.Default.res.Width + "x" + Settings.Default.res.Height);
                Log.Add("Language:" + Settings.Default.Sprache);
                Log.Add("WindowsLanguage:" + InputLanguage.CurrentInputLanguage.Culture.Name);
                Log.Add("KeyboardLayout:" + InputLanguage.CurrentInputLanguage.LayoutName);
                Log.Add("");

                foreach (VirtualController vc in activeVControllers)
                {
                    vc.currentSimValue = vc.currentJoystickValue;
                    vc.getText = 0;
                }
            }
            else
            {
                check_active.BackColor = Color.Red;
                Log.Add("Active = false");
                Log.Add("----------------------------------------------------------------------------------------------------");
                Log.Add("----------------------------------------------------------------------------------------------------");
            }
        }
        #endregion
        #region Deaktiviere Global
        private void check_deactivateGlobal_CheckedChanged(object sender, EventArgs e)
        {
            if (check_deactivateGlobal.Checked)
            {
                Log.Add("Add " + comboBox_Zugauswahl.Text + " to deactivatedGlobals list");
                Settings.Default.deactivatedGlobals.Add(comboBox_Zugauswahl.Text);
                Settings.Default.Save();

                globalIsDeactivated = true;
            }
            else
            {
                Log.Add("Remove " + comboBox_Zugauswahl.Text + " from deactivatedGlobals list");
                Settings.Default.deactivatedGlobals.Remove(comboBox_Zugauswahl.Text);
                Settings.Default.Save();

                globalIsDeactivated = false;
            }
            getActiveTrain();
        }
        #endregion
        #region Einstellungen
        private void btn_einstellungen_Click(object sender, EventArgs e)
        {
            Log.Add("Going to settings:");
            check_active.Checked = false;
            FormSettings formSettings = new FormSettings();
            formSettings.Location = this.Location;
            formSettings.ShowDialog();
            Log.Add("Leaving settings");

            loadSettings();

            ReadTrainConfig();
            ReadVControllers();
        }
        #endregion
        #region Joysticks überprüfen
        private void btn_checkJoysticks_Click(object sender, EventArgs e)
        {
            Joystick[] sticks = getSticks();

            if (sticks.Count() != MainSticks.Count())
            {
                MainSticks = sticks;
            }
        }
        #endregion
        #region CheckGitHubVersion
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
                Log.Add("Get Releases from GitHub:");
                foreach (Release rel in releases) { Log.Add("->" + rel.TagName, false, 1); }
                Log.Add("->Your Version:" + localVersion.ToString(), false, 1);

                int versionComparison = localVersion.CompareTo(latestGitHubVersion);
                if (versionComparison < 0)
                {
                    //The version on GitHub is more up to date than this local release.
                    Log.Add("Update available", false, 1);
                    lbl_updateAvailable.Text = "Version " + latestGitHubVersion + "\n" + Sprache.Translate("ist verfügbar", "is available");
                    FormSettings.newestVersion = latestGitHubVersion.ToString();
                }
                else
                {
                    Log.Add("->No update available", false, 1);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorException(ex);
            }
        }
        #endregion
        #region lbl Update verfügbar
        private void lbl_updateAvailable_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.Location = this.Location;
            formSettings.CheckGitHubNewerVersion();
            formSettings.ShowDialog();
        }
        #endregion
        #region FormClose
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion
        #endregion

        #region Allgemeine Funktionen
        public bool ContainsWord(string stringToCheck, string word)
        {
            if (word != null)
            {
                string[] split_stringTC = stringToCheck.Split(' ');
                int countOfWordsGiven = word.Count(x => x == ' ') + 1;

                if (stringToCheck != "")
                {
                    for (int i = 0; i < split_stringTC.Length - countOfWordsGiven + 1; i++)
                    {
                        string str = "";
                        for (int o = 0; o < countOfWordsGiven; o++)
                        {
                            str += split_stringTC[o + i] + " ";
                        }
                        str = str.Trim();

                        if (str.ToLower() == word.ToLower())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static double GetDamerauLevenshteinDistanceInPercent(string string_to_check, string string_to_check_from, int maxLengthDiff, bool checkCase = false)
        {
            try
            {
                if (checkCase == false) { string_to_check = string_to_check.ToLower(); string_to_check_from = string_to_check_from.ToLower(); }

                if (string.IsNullOrEmpty(string_to_check) || Math.Abs(string_to_check.Length - string_to_check_from.Length) > maxLengthDiff)
                {
                    return 0;
                    //throw new ArgumentNullException(t, "String Cannot Be Null Or Empty");
                }

                if (string.IsNullOrEmpty(string_to_check_from))
                {
                    return 0;
                    //throw new ArgumentNullException(t, "String Cannot Be Null Or Empty");
                }

                int n = string_to_check.Length; // length of s
                int m = string_to_check_from.Length; // length of t

                if (n == 0)
                {
                    return m;
                }

                if (m == 0)
                {
                    return n;
                }

                int[] p = new int[n + 1]; //'previous' cost array, horizontally
                int[] d = new int[n + 1]; // cost array, horizontally

                // indexes into strings s and t
                int i; // iterates through s
                int j; // iterates through t

                for (i = 0; i <= n; i++)
                {
                    p[i] = i;
                }

                for (j = 1; j <= m; j++)
                {
                    char tJ = string_to_check_from[j - 1]; // jth character of t
                    d[0] = j;

                    for (i = 1; i <= n; i++)
                    {
                        int cost = string_to_check[i - 1] == tJ ? 0 : 1; // cost
                                                                         // minimum of cell to the left+1, to the top+1, diagonally left and up +cost                
                        d[i] = Math.Min(Math.Min(d[i - 1] + 1, p[i] + 1), p[i - 1] + cost);
                    }

                    // copy current distance counts to 'previous row' distance counts
                    int[] dPlaceholder = p; //placeholder to assist in swapping p and d
                    p = d;
                    d = dPlaceholder;
                }

                // our last action in the above loop was to switch d and p, so p now 
                // actually has the most recent cost counts
                //return p[n];

                return Convert.ToDouble(m - p[n]) / Convert.ToDouble(m);
            }
            catch (Exception ex)
            {
                Log.ErrorException(ex);
                return 0;
            }
        }

        public static void checkLanguageSetting()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Sprache);
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Sprache);
        }

        public Bitmap Screenshot(bool normal)
        {
            //Breite und Höhe des ScanFensters
            int width = ConvertWidth(513);
            int height = ConvertHeight(30);
            //Startposition vom oberen Fenster
            int x1 = ConvertWidth(1920);
            int y1 = ConvertHeight(458);
            //Angepasste Höhe fürs untere Fenster
            int y2 = ConvertHeight(530);


            Bitmap bmpScreenshot = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmpScreenshot);

            if (normal)
            {
                //oberes Fenster
                g.CopyFromScreen(x1, y1, 0, 0, new Size(width, height));
            }
            else
            {
                //unteres Fenster
                g.CopyFromScreen(x1, y2, 0, 0, new Size(width, height));
            }

            for (int y = 0; (y <= (bmpScreenshot.Height - 1)); y++)
            {
                for (int x = 0; (x <= (bmpScreenshot.Width - 1)); x++)
                {
                    Color inv = bmpScreenshot.GetPixel(x, y);

                    //Farbanpassung um möglichst nur die Schrift zu erkennen
                    if (inv.R + inv.G + inv.G < 500)
                    {
                        inv = Color.FromArgb(0, 0, 0, 0);
                    }

                    //invertier das Bild
                    inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    bmpScreenshot.SetPixel(x, y, inv);
                }
            }

            if (Settings.Default.showScanResult) { if (normal) { bgw_readScreen.ReportProgress(0, new object[] { bmpScreenshot, new Bitmap(1, 1), null, null, -1, -1 }); } else { bgw_readScreen.ReportProgress(0, new object[] { new Bitmap(1, 1), bmpScreenshot, null, null, -1, -1 }); } Thread.Sleep(50); }//Thread.Sleep(50) prevents crash with picturebox
            return bmpScreenshot;
        }
        private int ConvertHeight(int height)
        {
            return Convert.ToInt32(Math.Round((Convert.ToDouble(height) / 1440.0) * Convert.ToDouble(res.Height), 0));
        }
        private int ConvertWidth(int width)
        {
            return Convert.ToInt32(Math.Round((Convert.ToDouble(width) / 2560.0) * Convert.ToDouble(res.Width), 0));
        }

        public static string GetText(Bitmap imgsource)
        {
            var ocrtext = string.Empty;
            //engine.SetVariable("load_system_dawg", true);
            //engine.SetVariable("language_model_penalty_non_dict_word", 1);
            //engine.SetVariable("language_model_penalty_non_freq_dict_word", 1);
            using (var img = PixConverter.ToPix(imgsource))
            {
                using (var page = TCengine.Process(img))
                {
                    ocrtext = page.GetText();
                }
            }
            ocrtext = ocrtext.Replace(",", ".").Replace("\n", "");
            return ocrtext;
        }

        public static string GetVersion(bool removeLastDigit)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (removeLastDigit)
            {
                return version.Split('.')[0] + "." + version.Split('.')[1] + "." + version.Split('.')[2];
            }
            else
            {
                return version;
            }
        }
        #endregion

        #region Versions überprüfung
        public void checkVersion()
        {
            Log.Add("Check version of settings...");
            try
            {
                if (Settings.Default.UpdateErforderlich)
                {
                    object prevVersion = Settings.Default.GetPreviousVersion("Version");
                    if (prevVersion != null)
                    {
                        //Update
                        Log.Add("Updating Settings, prevVersion=" + prevVersion.ToString());

                        Settings.Default.Upgrade();
                        checkLanguageSetting();

                        FormWasIstNeu formWasIstNeu = new FormWasIstNeu(prevVersion.ToString());
                        formWasIstNeu.ShowDialog();

                        #region Update besonderheiten
                        if (new Version(prevVersion.ToString()).CompareTo(new Version("1.0.0")) < 0)
                        {
                            Log.Add("1.0.0", false, 1);
                            //Neue Einstellung muss mit Daten gefüllt werden 321321
                            //Settings.Default.SchubIndexe_EN.AddRange(defaultEN_schubIndexe);
                            //Settings.Default.BremsIndexe_EN.AddRange(defaultEN_bremsIndexe);
                            //Settings.Default.Kombihebel_SchubIndexe_EN.AddRange(defaultEN_kombihebel_schubIndexe);
                            //Settings.Default.Kombihebel_BremsIndexe_EN.AddRange(defaultEN_kombihebel_bremsIndexe);

                            //Settings.Default.SchubIndexe_DE.AddRange(defaultDE_schubIndexe);
                            //Settings.Default.BremsIndexe_DE.AddRange(defaultDE_bremsIndexe);
                            //Settings.Default.Kombihebel_SchubIndexe_DE.AddRange(defaultDE_kombihebel_schubIndexe);
                            //Settings.Default.Kombihebel_BremsIndexe_DE.AddRange(defaultDE_kombihebel_bremsIndexe);

                            Settings.Default.Save();
                        }
                        if (new Version(prevVersion.ToString()).CompareTo(new Version("1.1.0")) < 0)
                        {
                            Log.Add("1.1.0", false, 1);
                            if (File.Exists(Tcfg.configpfad))
                            {
                                //Backup
                                File.Copy(Tcfg.configpfad, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\backupTrainConfig.csv", true);
                                Sprache.ShowMessageBox("Backup has been created on the Desktop", "Ein Backup wurde auf dem Desktop erstellt");

                                //Neue Tastenbenennung
                                string[] file = File.ReadAllLines(Tcfg.configpfad);
                                for (int i = 0; i < file.Count(); i++)
                                {
                                    //Veränderungen
                                    string convertKey(string key)
                                    {
                                        switch (key)
                                        {
                                            case "einfg":
                                                return "insert";
                                            case "pos1":
                                                return "home";
                                            case "bildauf":
                                                return "pageUp";
                                            case "entf":
                                                return "del";
                                            case "ende":
                                                return "end";
                                            case "bildab":
                                                return "pageDown";
                                            case "hoch":
                                                return "up";
                                            case "runter":
                                                return "down";
                                            case "rechts":
                                                return "right";
                                            case "links":
                                                return "left";
                                            case "strg":
                                                return "ctrl";
                                            case "lstrg":
                                                return "lctrl";
                                            case "rstrg":
                                                return "rctrl";
                                            case "ü":
                                                return "oem1";
                                            case "#":
                                                return "oem2";
                                            case "ö":
                                                return "oem3";
                                            case "ß":
                                                return "oem4";
                                            case "^":
                                                return "oem5";
                                            case "´":
                                                return "oem6";
                                            case "ä":
                                                return "oem7";
                                            case "komma":
                                                return "comma";
                                            case "zurück":
                                                return "back";
                                            case "enter":
                                                return "return";
                                            case "drucken":
                                                return "print";
                                            case "rollen":
                                                return "scroll";
                                            default:
                                                return key;
                                        }
                                    }

                                    string[] single = file[i].Split(',');

                                    //Aktion
                                    single[8] = convertKey(single[8]);

                                    //Tastenkombination
                                    string[] tc = single[7].Split('_');
                                    if (tc.Count() >= 3)
                                    {
                                        for (int o = 0; o < tc.Count(); o += 3)
                                        {
                                            tc[o] = convertKey(tc[o]);
                                        }
                                        single[7] = String.Join("_", tc);
                                    }
                                    //Einstellungen
                                    Settings.Default.Tastenbelegung[0] = convertKey(Settings.Default.Tastenbelegung[0]);
                                    Settings.Default.Tastenbelegung[1] = convertKey(Settings.Default.Tastenbelegung[1]);
                                    Settings.Default.Tastenbelegung[2] = convertKey(Settings.Default.Tastenbelegung[2]);
                                    Settings.Default.Tastenbelegung[3] = convertKey(Settings.Default.Tastenbelegung[3]);

                                    file[i] = String.Join(",", single);
                                }

                                File.WriteAllLines(Tcfg.configpfad, file);
                            }


                            bool areEqual = File.ReadLines(Tcfg.configpfad).SequenceEqual(File.ReadLines(Tcfg.configstandardpfad));
                            if (!areEqual)
                            {
                                Directory.CreateDirectory(Tcfg.configOrdnerPfad);
                                File.Copy(Tcfg.configpfad, Tcfg.configOrdnerPfad + "yourConfig.csv", true);
                                Settings.Default.selectedTrainConfig = "yourConfig";
                            }


                            Settings.Default.Save();
                        }
                        #endregion

                    }
                    else
                    {
                        //Neuinstallation 321321
                        //CultureInfo ci = CultureInfo.InstalledUICulture;
                        //if (ci.Name == "de-DE")
                        //{
                        //    //Sprache von Windows
                        //    Settings.Default.Sprache = "de-DE";
                        //    Settings.Default.Save();
                        //}

                        //Settings.Default.SchubIndexe_EN.AddRange(defaultEN_schubIndexe);
                        //Settings.Default.BremsIndexe_EN.AddRange(defaultEN_bremsIndexe);
                        //Settings.Default.Kombihebel_SchubIndexe_EN.AddRange(defaultEN_kombihebel_schubIndexe);
                        //Settings.Default.Kombihebel_BremsIndexe_EN.AddRange(defaultEN_kombihebel_bremsIndexe);

                        //Settings.Default.SchubIndexe_DE.AddRange(defaultDE_schubIndexe);
                        //Settings.Default.BremsIndexe_DE.AddRange(defaultDE_bremsIndexe);
                        //Settings.Default.Kombihebel_SchubIndexe_DE.AddRange(defaultDE_kombihebel_schubIndexe);
                        //Settings.Default.Kombihebel_BremsIndexe_DE.AddRange(defaultDE_kombihebel_bremsIndexe);

                        //if (Sprache.isGerman())
                        //{
                        //    Settings.Default.SchubIndexe.AddRange(defaultDE_schubIndexe); Settings.Default.Save();
                        //    Settings.Default.BremsIndexe.AddRange(defaultDE_bremsIndexe); Settings.Default.Save();
                        //    Settings.Default.Kombihebel_SchubIndexe.AddRange(defaultDE_kombihebel_schubIndexe); Settings.Default.Save();
                        //    Settings.Default.Kombihebel_BremsIndexe.AddRange(defaultDE_kombihebel_bremsIndexe); Settings.Default.Save();
                        //}
                        //else
                        //{
                        //    Settings.Default.SchubIndexe.AddRange(defaultEN_schubIndexe); Settings.Default.Save();
                        //    Settings.Default.BremsIndexe.AddRange(defaultEN_bremsIndexe); Settings.Default.Save();
                        //    Settings.Default.Kombihebel_SchubIndexe.AddRange(defaultEN_kombihebel_schubIndexe); Settings.Default.Save();
                        //    Settings.Default.Kombihebel_BremsIndexe.AddRange(defaultEN_kombihebel_bremsIndexe); Settings.Default.Save();
                        //}
                    }

                    Settings.Default.UpdateErforderlich = false;
                    Settings.Default.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString().Remove(Assembly.GetExecutingAssembly().GetName().Version.ToString().Length - 2, 2);

                    Settings.Default.Save();
                }
                else
                {
                    Log.Add("Settings are up to date", false, 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log.ErrorException(ex);
            }
        }
        #endregion

        #region Einstellungen laden
        public void loadSettings()
        {
            Log.Add("Load Settings...");
            try
            {
                #region Auflösung
                Log.Add("load res", false, 1);
                if (Settings.Default.res.IsEmpty)
                {
                    Settings.Default.res = res;
                    Settings.Default.Save();
                }
                else
                {
                    res = Settings.Default.res;
                    lbl_resolution.Text = res.Width.ToString() + "x" + res.Height.ToString();
                }

                #endregion

                #region Zeige Debug-Infos
                Log.Add("load debug info", false, 1);
                if (Settings.Default.showDebug)
                {
                    listBox_debugInfo.Show();
                    lbl_requests.Show();
                }
                else
                {
                    listBox_debugInfo.Hide();
                    lbl_requests.Hide();
                }
                #endregion

                #region Zeige Scan Ergebnis
                Log.Add("load scan results", false, 1);
                if (Settings.Default.showScanResult)
                {
                    pictureBox_Screenshot_original.Show();
                    pictureBox_Screenshot_alternativ.Show();
                }
                else
                {
                    pictureBox_Screenshot_original.Hide();
                    pictureBox_Screenshot_alternativ.Hide();
                }
                #endregion

                #region Tastenbelegung
                Log.Add("load key bindings", false, 1);
                try
                {
                    Keyboard.increaseThrottle = Keyboard.ConvertStringToKey(Settings.Default.Tastenbelegung[0]);
                    Keyboard.decreaseThrottle = Keyboard.ConvertStringToKey(Settings.Default.Tastenbelegung[1]);
                    Keyboard.increaseBrake = Keyboard.ConvertStringToKey(Settings.Default.Tastenbelegung[2]);
                    Keyboard.decreaseBrake = Keyboard.ConvertStringToKey(Settings.Default.Tastenbelegung[3]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Log.ErrorException(ex);
                }
                #endregion
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); Log.ErrorException(ex); Close(); }
        }
        #endregion

        #region Trainconfig und VControllers
        public void ReadTrainConfig()
        {
            Log.Add("Read TrainConfig");
            if (File.Exists(Tcfg.configpfad))
            {
                trainConfig.Clear();
                using (var reader = new StreamReader(Tcfg.configpfad))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        trainConfig.Add(values);
                    }
                }
            }
            ReadTrainNamesFromTrainconfig();
        }

        public void ReadVControllers()
        {
            Log.Add("Read Controllers");
            if (File.Exists(Tcfg.controllersConfigPfad))
            {
                vControllerList.Clear();
                using (var reader = new StreamReader(Tcfg.controllersConfigPfad))
                {
                    int counter = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        string[] values = line.Split(',');
                        if (counter > 0)
                        {
                            //Skip first line
                            VirtualController vc = new VirtualController();
                            vc.InsertFileArray(values);
                            vControllerList.Add(vc);
                        }
                        counter++;
                    }
                }
            }
        }

        public void ReadTrainNamesFromTrainconfig()
        {
            trainNames.Clear();
            comboBox_Zugauswahl.Items.Clear();
            comboBox_Zugauswahl.Items.Add(Sprache.Translate("_Zugauswahl", "_Select train"));
            comboBox_Zugauswahl.SelectedItem = Sprache.Translate("_Zugauswahl", "_Select train");

            foreach (string[] str in trainConfig)
            {
                bool alreadyExists = false;
                foreach (string tN in trainNames)
                {
                    if (str[0] == tN)
                    {
                        alreadyExists = true;
                    }
                }

                if (!alreadyExists && str[0] != "Zug" && str[0] != Tcfg.nameForGlobal)
                {
                    trainNames.Add(str[0]);
                }
            }
            comboBox_Zugauswahl.Items.AddRange(trainNames.ToArray());
        }
        public void getActiveTrain()
        {
            //Reset Infos
            activeTrain.Clear();

            //Was wurde ausgewählt
            string selection = comboBox_Zugauswahl.Text;

            foreach (string[] str in trainConfig)
            {
                if (str[Tcfg.zug] == selection || (str[Tcfg.zug] == Tcfg.nameForGlobal && !globalIsDeactivated))
                {
                    //Alle Infos zum Ausgewählten Zug speichern
                    activeTrain.Add(str);
                }
            }

            foreach (string[] str in activeTrain)
            {
                //if (str[Tcfg.tastenKombination].Contains("Schub"))
                //{
                //    //Infos über den Schubhebel
                //    throttleConfig[0] = "empty";
                //    throttleConfig[1] = str[Tcfg.art];
                //    throttleConfig[2] = str[Tcfg.schritte];
                //    throttleConfig[3] = str[Tcfg.specials];
                //    throttleConfig[4] = str[Tcfg.zeitfaktor];
                //    throttleConfig[5] = str[Tcfg.laengerDruecken];
                //    throttleConfig[6] = "Schub";
                //}
                //else if (str[Tcfg.tastenKombination].Contains("Kombihebel"))
                //{
                //    //Infos über den Kombihebel
                //    isKombihebel = true;
                //    throttleConfig[0] = "empty";
                //    throttleConfig[1] = str[Tcfg.art];
                //    throttleConfig[2] = str[Tcfg.schritte];
                //    throttleConfig[3] = str[Tcfg.specials];
                //    throttleConfig[4] = str[Tcfg.zeitfaktor];
                //    throttleConfig[5] = str[Tcfg.laengerDruecken];
                //    throttleConfig[6] = "Kombihebel";
                //}

                //if (str[Tcfg.tastenKombination].Contains("Bremse"))
                //{
                //    //Infos über die Bremse
                //    brakeConfig[0] = "empty";
                //    brakeConfig[1] = str[Tcfg.art];
                //    brakeConfig[2] = str[Tcfg.schritte];
                //    brakeConfig[3] = str[Tcfg.specials];
                //    brakeConfig[4] = str[Tcfg.zeitfaktor];
                //    brakeConfig[5] = str[Tcfg.laengerDruecken];
                //    brakeConfig[6] = "Bremse";
                //}
            }

        }
        public void getActiveVControllers()
        {
            activeVControllers.Clear();

            string selection = comboBox_Zugauswahl.Text;

            foreach (string[] singleTrain in trainConfig)
            {
                if (singleTrain[Tcfg.zug] == selection)
                {
                    string selected_vControllername = singleTrain[Tcfg.reglerName];
                    if (selected_vControllername != "")
                    {
                        foreach (VirtualController vc in vControllerList)
                        {
                            if (vc.name == selected_vControllername)
                            {
                                if (singleTrain[Tcfg.zeitfaktor].Contains("|"))
                                {
                                    vc.timefactor = new int[] { Convert.ToInt32(singleTrain[Tcfg.zeitfaktor].Split('|')[0]), Convert.ToInt32(singleTrain[Tcfg.zeitfaktor].Split('|')[1]) };
                                }
                                else
                                {
                                    vc.timefactor = new int[] { Convert.ToInt32(singleTrain[Tcfg.zeitfaktor]), Convert.ToInt32(singleTrain[Tcfg.zeitfaktor]) };
                                }

                                if (singleTrain[Tcfg.schritte] != "")
                                {
                                    vc.stufen = Convert.ToInt32(singleTrain[Tcfg.schritte]);
                                }
                                if (singleTrain[Tcfg.art] == "Stufenlos")
                                {
                                    vc.istStufenlos = true;
                                }
                                else
                                {
                                    vc.istStufenlos = false;
                                }

                                if (singleTrain[Tcfg.specials].Contains("=") && singleTrain[Tcfg.specials] != "")
                                {
                                    string[] specialCases = singleTrain[Tcfg.specials].Remove(singleTrain[Tcfg.specials].Length - 1, 1).Replace("[", "").Split(']');
                                    foreach (string specialCase in specialCases)
                                    {
                                        int index = specialCase.IndexOf("=");
                                        string word = specialCase.Remove(index, specialCase.Length - index);
                                        int entsprechendeNummer = Convert.ToInt32(specialCase.Remove(0, index + 1));
                                        vc.specialCases.Add(new string[] { word, entsprechendeNummer.ToString() });
                                    }
                                }

                                if (singleTrain[Tcfg.laengerDruecken].Contains(":") && singleTrain[Tcfg.laengerDruecken] != "")
                                {
                                    string[] longPressArray = singleTrain[Tcfg.laengerDruecken].Remove(singleTrain[Tcfg.laengerDruecken].Length - 1, 1).Replace("[", "").Split(']');
                                    foreach (string singleLongPress in longPressArray)
                                    {
                                        int index_Gerade = singleLongPress.IndexOf("|");
                                        int index_doppelpnkt = singleLongPress.IndexOf(":");

                                        int untere_grenze = Convert.ToInt32(singleLongPress.Remove(index_Gerade, singleLongPress.Length - index_Gerade));
                                        int obere_grenze = Convert.ToInt32(singleLongPress.Remove(0, index_Gerade + 1).Remove(singleLongPress.Remove(0, index_Gerade + 1).IndexOf(":"), singleLongPress.Remove(0, index_Gerade + 1).Length - singleLongPress.Remove(0, index_Gerade + 1).IndexOf(":")));
                                        int dauer = Convert.ToInt32(singleLongPress.Remove(0, singleLongPress.IndexOf(":") + 1));
                                        vc.longPress.Add(new int[] { untere_grenze, obere_grenze, dauer });
                                    }
                                }



                                activeVControllers.Add(vc);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Joystick und Buttons
        public Joystick[] getSticks()
        {
            Log.Add("Search for joysticks:");
            //strg+c strg+v
            List<Joystick> sticks = new List<Joystick>();
            foreach (DeviceInstance device in input.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly))
            {
                Joystick stick = new Joystick(input, device.InstanceGuid);
                stick.Acquire();

                foreach (DeviceObjectInstance deviceObject in stick.GetObjects(DeviceObjectTypeFlags.Axis))
                {
                    stick.GetObjectPropertiesById(deviceObject.ObjectId).Range = new InputRange(-100, 100);
                }
                sticks.Add(stick);
            }

            if (comboBox_JoystickNumber.Items.Count != sticks.Count)
            {
                comboBox_JoystickNumber.Items.Clear();
                for (int i = 0; i < sticks.Count; i++)
                {
                    comboBox_JoystickNumber.Items.Add(i);
                }
                if (sticks.Count > 0) { comboBox_JoystickNumber.SelectedIndex = comboBox_JoystickNumber.Items.Count - 1; }
            }

            Log.Add(sticks.Count + " joysticks found", false, 1);
            return sticks.ToArray();

        }

        void stickHandle(Joystick stick, int id)
        {
            try
            {
                bool[] buttons;
                int[] joyInputs = new int[8];

                JoystickState state = new JoystickState();

                //Bekomme alle Infos über den mit id ausgewählten Stick
                state = stick.GetCurrentState();

                joyInputs[0] = state.X;
                joyInputs[1] = state.Y;
                joyInputs[2] = state.Z;
                joyInputs[3] = state.PointOfViewControllers[0] + 1;
                joyInputs[4] = state.RotationX;
                joyInputs[5] = state.RotationY;
                joyInputs[6] = state.RotationZ;
                joyInputs[7] = state.Sliders[0];


                for (int i = 0; i < inputNames.Length; i++)
                {
                    foreach (string[] strActiveTrain in activeTrain)
                    {
                        //In der Trainconfig kommt ein bekannter Achsen-Name vor
                        if (strActiveTrain[Tcfg.joystickInput] == inputNames[i] && Convert.ToInt32(strActiveTrain[Tcfg.joystickNummer]) == id && strActiveTrain[Tcfg.reglerName] != "")
                        {
                            List<string[]> customController = new List<string[]>();
                            string[] split = strActiveTrain[Tcfg.invertieren].Split('|');
                            for (int j = 0; j < split.Count() - 1; j += 2)
                            {
                                customController.Add(new string[] { split[j], split[j + 1] });
                            }

                            for (int j = 0; j < customController.Count; j++)
                            {
                                if (j + 1 > customController.Count - 1)
                                {
                                    joyInputs[i] = Convert.ToInt32(customController[j][1]);
                                    break;
                                }
                                else
                                {
                                    if (joyInputs[i] >= Convert.ToInt32(customController[j][0]) && joyInputs[i] < Convert.ToInt32(customController[j + 1][0]))
                                    {
                                        double steigung = (Convert.ToDouble(customController[j + 1][1]) - Convert.ToDouble(customController[j][1])) / (Convert.ToDouble(customController[j + 1][0]) - Convert.ToDouble(customController[j][0]));

                                        joyInputs[i] = Convert.ToInt32(Math.Round(((joyInputs[i] - Convert.ToDouble(customController[j + 1][0])) * steigung) + Convert.ToDouble(customController[j + 1][1]), 0));
                                        break;
                                    }
                                }
                            }


                            //Bestimmt Inputwerte sollen in andere Umgerechnet werden
                            if (strActiveTrain[Tcfg.inputUmrechnen].Length > 5)
                            {
                                string[] umrechnen = strActiveTrain[Tcfg.inputUmrechnen].Remove(strActiveTrain[Tcfg.inputUmrechnen].Length - 1).Replace("[", "").Split(']');

                                foreach (string single_umrechnen in umrechnen)
                                {
                                    if (single_umrechnen.Contains("|"))
                                    {
                                        int von = Convert.ToInt32(single_umrechnen.Remove(single_umrechnen.IndexOf("|"), single_umrechnen.Length - single_umrechnen.IndexOf("|")));

                                        string temp_bis = single_umrechnen.Remove(0, single_umrechnen.IndexOf("|") + 1);
                                        int index = temp_bis.IndexOf("=");
                                        int bis = Convert.ToInt32(temp_bis.Remove(index, temp_bis.Length - index));
                                        int entsprechendeNummer = Convert.ToInt32(single_umrechnen.Remove(0, single_umrechnen.IndexOf("=") + 1));

                                        if (von <= joyInputs[i] && joyInputs[i] <= bis)
                                        {
                                            joyInputs[i] = entsprechendeNummer;
                                            break;
                                        }
                                        else if (von >= joyInputs[i] && joyInputs[i] >= bis)
                                        {
                                            joyInputs[i] = entsprechendeNummer;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        int index = single_umrechnen.IndexOf("=");
                                        int gesuchteNummer = Convert.ToInt32(single_umrechnen.Remove(index, single_umrechnen.Length - index));
                                        int entsprechendeNummer = Convert.ToInt32(single_umrechnen.Remove(0, index + 1));

                                        if (joyInputs[i] == gesuchteNummer)
                                        {
                                            joyInputs[i] = entsprechendeNummer;
                                            break;
                                        }
                                    }
                                }
                            }

                            for (int j = 0; j < activeVControllers.Count; j++)
                            {
                                if (strActiveTrain[Tcfg.reglerName] == activeVControllers[j].name)
                                {
                                    activeVControllers[j].currentJoystickValue = joyInputs[i];
                                }
                            }

                        }
                    }
                }

                //Alle Knopf states bekommen
                buttons = state.Buttons;

                //Alle wichtigen Infos über den Joystick in Liste speichern
                joystickStates.Add(new object[] { id, joyInputs, inputNames, buttons });
            }
            catch (Exception ex)
            {
                Log.ErrorException(ex);
                MainSticks = getSticks();
                Sprache.ShowMessageBox(stick.Information.InstanceName + " nicht mehr angeschlossen!", stick.Information.InstanceName + " not connected anymore!");
            }
        }

        public int GetJoystickStateByName(string id, string input)
        {
            foreach (object[] obyJstk in joystickStates)
            {
                if ((int)obyJstk[0] == Convert.ToInt32(id))
                {
                    for (int i = 0; i < ((string[])obyJstk[2]).Length; i++)
                    {
                        if (((string[])obyJstk[2])[i] == input)
                        {
                            return ((int[])obyJstk[1])[i];
                        }
                    }
                }
            }
            return 0;
        }

        public void HandleButtons()
        {
            for (int i = 0; i < activeTrain.Count; i++)
            {
                //Wenn es ein Normaler Knopf vom Joystick ist
                if (activeTrain[i][Tcfg.inputTyp] == "Button")
                {
                    int buttonNumber = Convert.ToInt32(activeTrain[i][Tcfg.joystickInput].Replace("B", ""));
                    if (Convert.ToInt32(activeTrain[i][Tcfg.joystickNummer]) <= MainSticks.Count())
                    {
                        currentlyPressedButtons[i] = ((bool[])((object[])joystickStates[Convert.ToInt32(activeTrain[i][Tcfg.joystickNummer])])[3])[buttonNumber];
                    }
                }
                else if (activeTrain[i][Tcfg.inputTyp].Contains("Button"))
                {
                    //Wenn ein Analoger Input zum Knopf werden soll
                    for (int o = 0; o < inputNames.Count(); o++)
                    {
                        if (activeTrain[i][Tcfg.joystickInput] == inputNames[o])
                        {
                            int joyButtonValue = GetJoystickStateByName(activeTrain[i][Tcfg.joystickNummer], inputNames[o]);
                            string[] convert = activeTrain[i][Tcfg.inputTyp].Replace("Button", "").Replace("[", "").Split(']');


                            currentlyPressedButtons[i] = false;
                            foreach (string single_convert in convert)
                            {
                                if (single_convert.Contains("="))
                                {
                                    if (joyButtonValue == Convert.ToInt32(single_convert.Remove(0, 1)))
                                    {
                                        currentlyPressedButtons[i] = true;
                                        break;
                                    }
                                    else
                                    {
                                        currentlyPressedButtons[i] = false;
                                    }
                                }
                                else if (single_convert.Contains(">"))
                                {
                                    if (joyButtonValue > Convert.ToInt32(single_convert.Remove(0, 1)))
                                    {
                                        currentlyPressedButtons[i] = true;
                                    }
                                    else
                                    {
                                        currentlyPressedButtons[i] = false;
                                        break;
                                    }
                                }
                                else if (single_convert.Contains("<"))
                                {
                                    if (joyButtonValue < Convert.ToInt32(single_convert.Remove(0, 1)))
                                    {
                                        currentlyPressedButtons[i] = true;
                                    }
                                    else
                                    {
                                        currentlyPressedButtons[i] = false;
                                        break;
                                    }
                                }

                            }
                        }
                    }
                }
            }


            for (int i = 0; i < currentlyPressedButtons.Count(); i++)
            {
                if (currentlyPressedButtons[i] != previouslyPressedButtons[i])
                {
                    if (currentlyPressedButtons[i] == true)
                    {
                        //on Press
                        Log.Add("\"" + activeTrain[i][Tcfg.beschreibung] + "\" is getting pressed", true);
                        if (activeTrain[i][Tcfg.tastenKombination] != "") { Keyboard.ProcessAktion(activeTrain[i][Tcfg.tastenKombination]); }
                        if (activeTrain[i][Tcfg.aktion] != "") { Keyboard.KeyDown(Keyboard.ConvertStringToKey(activeTrain[i][Tcfg.aktion])); }
                    }
                    else
                    {
                        //on release
                        Log.Add("\"" + activeTrain[i][Tcfg.beschreibung] + "\" is getting released", true);
                        if (activeTrain[i][Tcfg.aktion] != "") { Keyboard.KeyUp(Keyboard.ConvertStringToKey(activeTrain[i][Tcfg.aktion])); }
                    }
                    previouslyPressedButtons[i] = currentlyPressedButtons[i];
                }
            }
        }

        private void ShowJoystickData()
        {
            //Welcher Joystick wurde ausgewählt
            int selectedJoystickIndex = Convert.ToInt32(comboBox_JoystickNumber.SelectedItem);

            //Wähle von allen Joysticks nur den ausgewählten aus
            if (selectedJoystickIndex < joystickStates.Count)
            {
                int counter = 1;
                int topIndex = lst_inputs.TopIndex;

                object[] selectedJoystick = (object[])joystickStates[Convert.ToInt32(selectedJoystickIndex)];
                for (int i = 0; i < ((bool[])selectedJoystick[3]).Length; i++)
                {
                    if (((bool[])selectedJoystick[3])[i])
                    {
                        //Zeige den gedrückten Button
                        if (counter <= lst_inputs.Items.Count)
                        {
                            lst_inputs.Items[counter - 1] = "B" + i;
                        }
                        else
                        {
                            lst_inputs.Items.Add("B" + i);
                        }
                        counter++;
                    }
                }
                for (int i = 0; i < ((int[])selectedJoystick[1]).Length; i++)
                {
                    if (((int[])selectedJoystick[1])[i] != 0)
                    {
                        //Zeige den Joystick-Wert nur, wenn er != 0 ist
                        if (counter <= lst_inputs.Items.Count)
                        {
                            lst_inputs.Items[counter - 1] = ((string[])selectedJoystick[2])[i] + "  " + ((int[])selectedJoystick[1])[i];
                        }
                        else
                        {
                            lst_inputs.Items.Add(((string[])selectedJoystick[2])[i] + "  " + ((int[])selectedJoystick[1])[i]);
                        }
                        counter++;
                    }
                }
                for (int o = lst_inputs.Items.Count - counter; o >= 0; o--)
                {
                    lst_inputs.Items[lst_inputs.Items.Count - o - 1] = "";
                }
                if (lst_inputs.Items.Count > topIndex)
                {
                    lst_inputs.TopIndex = topIndex;
                }
            }
            else
            {
                if (lst_inputs.Items.Count > 0) { lst_inputs.Items.Clear(); }
            }
        }
        #endregion

        #region Main
        private void Main()
        {
            //Lösche alle Infos über die Joysticks
            joystickStates.Clear();

            for (int i = 0; i < MainSticks.Length; i++)
            {
                //Speichere die Infos von jedem einzelnen Joystick
                stickHandle(MainSticks[i], i);
            }

            //Zeige dem Nutzer Infos über die Joysticks
            ShowJoystickData();


            //Wenn Aktiv
            if (check_active.Checked)
            {
                if (MainSticks.Length > 0)
                {
                    //Überprüfe die einzelnen Regler
                    handleVControllers();

                    if (!bgw_readScreen.IsBusy)
                    {
                        //Überprüfe ob Text zu lesen ist
                        bgw_readScreen.RunWorkerAsync();
                    }

                    //Überprüfe die einzelnen Joystick knöpfe
                    HandleButtons();
                }
                else
                {
                    check_active.Checked = false;
                    Sprache.ShowMessageBox("Kein Joystick angeschlossen!", "No joystick connected!");
                }
            }


            if (Log.DebugInfoList.Count > listBox_debugInfo.Items.Count)
            {
                bool autoScroll = false;
                if (listBox_debugInfo.TopIndex == listBox_debugInfo.Items.Count - 38)
                {
                    autoScroll = true;
                }

                for (int i = listBox_debugInfo.Items.Count; i < Log.DebugInfoList.Count; i++)
                {
                    listBox_debugInfo.Items.Add(Log.DebugInfoList[i]);
                }

                if (autoScroll)
                {
                    listBox_debugInfo.TopIndex = listBox_debugInfo.Items.Count - 1;
                }
            }
        }
        #endregion

        #region handleVControllers
        private void handleVControllers()
        {
            //Alle aktiven VControllers durchgehen
            for (int i = 0; i < activeVControllers.Count; i++)
            {
                VirtualController vc = activeVControllers[i];
                int timefactornumber = 0;

                if (vc.currentJoystickValue < 0)
                {
                    if (!vc.isMasterController)
                    {
                        //Wenn kein Kombihebel dann darf der Wert nicht kleiner null
                        vc.currentJoystickValue = 0;
                    }
                    else
                    {
                        //Wenn es ein MasterController ist, dann nehme im Bremsbereich den 2. Zeitfaktor
                        timefactornumber = 1;
                    }
                }

                ConvertLongPress(vc);
                if (vc.istStufenlos)
                {
                    //Stufenlos
                    //Differenz berechnen
                    int diff = vc.currentJoystickValue - vc.currentSimValue;
                    if (Math.Abs(diff) > 1 && vc.waitToFinishMovement == false)
                    {
                        Log.Add(vc.name + ":move from " + vc.currentSimValue + " to " + vc.currentJoystickValue, true);
                        vc.cancelScan = 1;
                        new Thread(() =>
                        {
                            vc.waitToFinishMovement = true;
                            if (diff > 0)
                            {
                                //mehr
                                if (diff < 4 || false)//Ach keine Ahnung irgendwie mal ist es ungenau und manchmal ist es mit dieser Funktion genauer
                                {
                                    //(Gedacht ist) Wenn der Knopfdruck sehr kurz ist dann ist ein niedriger Zeitwert besser
                                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(vc.increaseKey), Convert.ToInt32(diff * (1000.0 / Convert.ToDouble(vc.timefactor[timefactornumber] * 1.5))));
                                }
                                else
                                {
                                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(vc.increaseKey), Convert.ToInt32(diff * (1000.0 / Convert.ToDouble(vc.timefactor[timefactornumber]))));
                                }
                            }
                            else if (diff < 0)
                            {
                                //weniger
                                if (diff > -4 || false)//Ach keine Ahnung irgendwie mal ist es ungenau und manchmal ist es mit dieser Funktion genauer
                                {
                                    //(Gedacht ist) Wenn der Knopfdruck sehr kurz ist dann ist ein niedriger Zeitwert besser
                                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(vc.decreaseKey), Convert.ToInt32(diff * (-1) * (1000.0 / Convert.ToDouble(vc.timefactor[timefactornumber] * 1.5))));
                                }
                                else
                                {
                                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(vc.decreaseKey), Convert.ToInt32(diff * (-1) * (1000.0 / Convert.ToDouble(vc.timefactor[timefactornumber]))));
                                }
                            }
                            vc.waitToFinishMovement = false;
                            vc.cancelScan = -1;
                            vc.getText = 3;
                        }).Start();
                        vc.currentSimValue = vc.currentJoystickValue;
                    }
                    else if (Math.Abs(diff) == 1 && vc.waitToFinishMovement == false)
                    {
                        Log.Add(vc.name + ":No movement because of tolerance of +-1");
                        vc.currentSimValue = vc.currentJoystickValue;
                    }
                }
                else
                {
                    //Stufen
                    if (vc.waitToFinishMovement == false)
                    {
                        //Zahl zu Stufe umwandeln
                        int currentNotch = Convert.ToInt32(Math.Round(vc.currentJoystickValue * (Convert.ToDouble(vc.stufen) / 100), 0));
                        //Differenz berechnen
                        int diff = currentNotch - vc.currentSimValue;
                        if (diff != 0)
                        {
                            Log.Add(vc.name + ":move from " + vc.currentSimValue + " to " + vc.currentJoystickValue, true);
                            vc.cancelScan = 1;
                            new Thread(() =>
                            {
                                vc.waitToFinishMovement = true;
                                if (diff > 0)
                                {
                                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(vc.increaseKey), vc.timefactor[timefactornumber] * Math.Abs(diff));
                                }
                                else if (diff < 0)
                                {
                                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(vc.decreaseKey), vc.timefactor[timefactornumber] * Math.Abs(diff));
                                }
                                Thread.Sleep(80);
                                vc.waitToFinishMovement = false;
                                vc.cancelScan = -1;
                                vc.getText = 3; //Anfrage für 3x Texterkennung
                            }).Start();
                            vc.currentSimValue = currentNotch;
                        }
                    }
                }
            }

            void ConvertLongPress(VirtualController vc)
            {
                foreach (int[] singleLongPress in vc.longPress)
                {
                    if (!vc.waitToFinishMovement)
                    {
                        int ist = vc.currentSimValue;
                        int soll = vc.currentJoystickValue;
                        int untere_grenze = singleLongPress[0];
                        int obere_grenze = singleLongPress[1];
                        int dauer = singleLongPress[2];

                        if (ist <= untere_grenze && obere_grenze <= soll)
                        {
                            //Mehr
                            vc.cancelScan = 1;
                            //Der Joystick kommt an der Langdruckstelle vorbei
                            if (ist == untere_grenze)
                            {
                                //Der sim-Regler ist genau an der Grenze zur Langdruckstelle
                                Log.Add(vc.name + ":Long press from " + untere_grenze + " to " + obere_grenze, true);
                                Keyboard.HoldKey(Keyboard.ConvertStringToKey(vc.increaseKey), dauer);
                                vc.currentSimValue = obere_grenze;
                                vc.getText = VirtualController.getTextDefault;
                                Thread.Sleep(100);
                            }
                            else if (ist < untere_grenze)
                            {
                                //Passe den soll wert so an, dass der sim-Regler an der Grenze stehen bleibt
                                Log.Add(vc.name + ":Set value to " + untere_grenze + " insted of " + vc.currentJoystickValue + " (moving up)", true);
                                if (vc.istStufenlos)
                                {
                                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(vc.increaseKey), 10);
                                    vc.currentJoystickValue = untere_grenze;
                                }
                            }
                            vc.cancelScan = -1;
                        }
                        else if (soll <= untere_grenze && obere_grenze <= ist)
                        {
                            //Weniger
                            vc.cancelScan = 1;
                            //Der Joystick kommt an der Langdruckstelle vorbei
                            if (ist == obere_grenze)
                            {
                                //Der sim-Regler ist genau an der Grenze zur Langdruckstelle
                                Log.Add(vc.name + ":Long press from " + obere_grenze + " to " + untere_grenze, true);
                                Keyboard.HoldKey(Keyboard.ConvertStringToKey(vc.decreaseKey), dauer);
                                vc.currentSimValue = untere_grenze;
                                vc.getText = VirtualController.getTextDefault;
                                Thread.Sleep(100);
                            }
                            else if (ist > obere_grenze)
                            {
                                //Passe den soll wert so an, dass der sim-Regler an der Grenze stehen bleibt
                                Log.Add(vc.name + ":Set value to " + obere_grenze + " insted of " + vc.currentJoystickValue + " (moving down)", true);
                                if (vc.istStufenlos)
                                {
                                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(vc.decreaseKey), 10);
                                    vc.currentJoystickValue = obere_grenze;
                                }
                            }
                            vc.cancelScan = -1;
                        }
                    }
                }
            }
        }
        #endregion

        #region ReadScreen
        private void bgw_readScreen_DoWork(object sender, DoWorkEventArgs e)
        {
            int noResultValue = -99999;

            int requestcount = 0;
            for (int i = 0; i < activeVControllers.Count; i++)
            {
                VirtualController vc = activeVControllers[i];
                if (vc.getText > 0)
                {
                    //Anzahl der verschiedenen Anfragen
                    requestcount++;
                }
            }

            lbl_requests.Invoke((MethodInvoker)delegate { lbl_requests.Text = "Text requests:" + requestcount.ToString(); });

            if (requestcount > 0)
            {
                //Die erste Zeile lesen
                Stopwatch stopwatch = Stopwatch.StartNew();
                string result = GetText(Screenshot(true));
                stopwatch.Stop();

                string second_result = "";

                lbl_originalResult.Invoke((MethodInvoker)delegate { lbl_originalResult.Text = result; });
                groupBox_ScanErgebnisse.Invoke((MethodInvoker)delegate { groupBox_ScanErgebnisse.Show(); });
                lbl_scantime.Invoke((MethodInvoker)delegate { lbl_scantime.Text = Sprache.Translate("Scanzeit:", "Scantime:") + stopwatch.ElapsedMilliseconds + "ms"; });

                for (int i = 0; i < activeVControllers.Count; i++)
                {
                    VirtualController vc = activeVControllers[i];

                    if (vc.getText > 0)
                    {
                        if (vc.requestStartTime == new DateTime())
                        {
                            vc.requestStartTime = DateTime.Now;
                        }

                        if (vc.cancelScan == 0)
                        {
                            //Finde den Indikator vom gelesenen Text
                            string indicator = GetBestMainIndicator(result, vc);

                            if (indicator == "")
                            {
                                //Falls kein Indikator gefunden und die 2. Zeile noch nicht gelesen wurde, lese die 2. Zeile
                                if (second_result == "") { second_result = GetText(Screenshot(false)); lbl_alternativeResult.Invoke((MethodInvoker)delegate { lbl_alternativeResult.Text = second_result; }); }
                                //Überprüfe das 2. Ergebnis
                                result = second_result;
                                indicator = GetBestMainIndicator(result, vc);
                            }
                            else
                            {
                                lbl_alternativeResult.Invoke((MethodInvoker)delegate { lbl_alternativeResult.Text = ""; });
                            }

                            if (indicator != "")
                            {
                                //Wenn ein Indikator gefunden
                                int factor = 1;
                                if (ContainsBrakingArea(result, vc))
                                {
                                    //Bremsbereich
                                    factor = -1;
                                }
                                //Entferne den Indikator
                                result = result.Remove(0, result.IndexOf(indicator) + indicator.Length).Trim();

                                int detectedNumber = noResultValue;
                                int wordlength = 0;
                                foreach (string[] specialCase in vc.specialCases) //Sonderfälle
                                {
                                    if (ContainsWord(result, specialCase[0]))
                                    {
                                        if (specialCase[0].Length > wordlength)
                                        {
                                            //Den am besten passenden Sonderfall finden
                                            if (wordlength == 0) { Log.Add(vc.name + ":Special case->[" + specialCase[0] + "=" + specialCase[1] + "]", true); } else { Log.Add(vc.name + ":better one->[" + specialCase[0] + "=" + specialCase[1] + "]", true); }
                                            wordlength = specialCase[0].Length;
                                            detectedNumber = Convert.ToInt32(specialCase[1]) * factor;//Der faktor soll entgegenwirken sodass die Specialcases wörtlich genommen werden
                                        }
                                    }
                                }

                                if (detectedNumber == noResultValue)
                                {
                                    //Kein SpecialCase gefunden
                                    int indexOfPercent = result.IndexOf("%");
                                    string result_withoutPercent = "";

                                    if (indexOfPercent != -1)
                                    {
                                        result_withoutPercent = result.Remove(indexOfPercent, result.Length - indexOfPercent);
                                    }
                                    try
                                    {
                                        int number = Convert.ToInt32(result_withoutPercent);
                                        if (vc.cancelScan == 0)
                                        {
                                            detectedNumber = number;
                                        }
                                    }
                                    catch
                                    {
                                        Log.Error("Could not get a number out of (removing percent method) " + result_withoutPercent);
                                        try
                                        {
                                            //Isoliere die Zahl
                                            int number = Convert.ToInt32(Regex.Match(result, @"\d+").Value);
                                            if (vc.cancelScan == 0)
                                            {
                                                detectedNumber = number;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Log.Error("Could not get a number out of (isolating method)" + result);
                                            Log.ErrorException(ex);
                                        }
                                    }
                                }
                                if (detectedNumber != noResultValue && vc.cancelScan == 0)
                                {
                                    vc.currentSimValue = detectedNumber * factor;
                                    Log.Add(vc.name + ":" + detectedNumber + " (" + result + ")", true);
                                    vc.getText--;
                                    //Reset Time
                                    vc.requestStartTime = new DateTime();
                                }
                            }
                            else
                            {
                                //Wenn nichts gefunden dann drücke eine Taste vom Regler
                                if (vc.requestStartTime != new DateTime() && DateTime.Now.Subtract(vc.requestStartTime).TotalMilliseconds >= 3000)
                                {
                                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(vc.decreaseKey), 1);
                                    vc.requestStartTime = DateTime.Now;
                                    Log.Add(vc.name + ":Nothing found! Trying to show Text again");
                                }
                            }
                        }
                        else
                        {
                            if (vc.cancelScan == -1)
                            {
                                vc.cancelScan = 0;
                            }
                        }
                    }
                }
            }
            else
            {
                groupBox_ScanErgebnisse.Invoke((MethodInvoker)delegate { groupBox_ScanErgebnisse.Hide(); });
            }

            string GetBestMainIndicator(string result, VirtualController virtualController)
            {
                VirtualController vc = virtualController;
                double bestMatchDistance = 0;
                string bestMatchWord = "";

                //Gehe alle Indikatoren durch
                foreach (string indicator in vc.mainIndicators)
                {
                    if (ContainsWord(result, indicator))
                    {
                        //Indikator 1 zu 1 gefunden
                        bestMatchWord = indicator;
                        break;
                    }
                    else
                    {
                        //Wenn kein Indikator 1 zu 1 gefunden wurde, versuche etwas zu finden, was ähnlich ist

                        int indicatorWordCount = indicator.Split(' ').Count();
                        string[] splitResult = result.Split(' ');

                        for (int j = 0; j < splitResult.Length - indicatorWordCount; j++)
                        {
                            string str = "";
                            for (int o = 0; o < indicatorWordCount; o++)
                            {
                                str += splitResult[o + j] + " ";
                            }
                            str = str.Trim();

                            double distance = GetDamerauLevenshteinDistanceInPercent(str, indicator, 3);
                            if (distance > bestMatchDistance && distance >= 0.8)
                            {
                                bestMatchDistance = distance;
                                bestMatchWord = str;
                            }
                        }
                    }
                }

                if (bestMatchWord != "")
                {
                    return bestMatchWord;
                }
                else
                {
                    return "";
                }
            }
            bool ContainsBrakingArea(string result, VirtualController virtualController)
            {
                VirtualController vc = virtualController;
                double bestMatchDistance = 0;
                string bestMatchWord = "";

                //Gehe alle Indikatoren durch
                foreach (string indicator in vc.textindicators_brakearea)
                {
                    if (ContainsWord(result, indicator))
                    {
                        //Indikator 1 zu 1 gefunden
                        bestMatchWord = indicator;
                        break;
                    }
                    else
                    {
                        //Wenn kein Indikator 1 zu 1 gefunden wurde, versuche etwas zu finden, was ähnlich ist
                        int indicatorWordCount = indicator.Split(' ').Count();
                        string[] splitResult = result.Split(' ');

                        for (int j = 0; j < splitResult.Length - indicatorWordCount; j++)
                        {
                            string str = "";
                            for (int o = 0; o < indicatorWordCount; o++)
                            {
                                str += splitResult[o + j] + " ";
                            }
                            str = str.Trim();

                            double distance = GetDamerauLevenshteinDistanceInPercent(str, indicator, 3);
                            if (distance > bestMatchDistance && distance >= 0.8)
                            {
                                bestMatchDistance = distance;
                                bestMatchWord = str;
                            }
                        }
                    }
                }

                if (bestMatchWord != "")
                {
                    Log.Add(vc.name + ":Is braking area [" + bestMatchWord + "]", true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private void bgw_readScreen_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Update Picturebox
            if (((Bitmap)((object[])e.UserState)[0]).Height != 1) { pictureBox_Screenshot_original.Image = (Bitmap)((object[])e.UserState)[0]; }
            if (((Bitmap)((object[])e.UserState)[1]).Height != 1) { pictureBox_Screenshot_alternativ.Image = (Bitmap)((object[])e.UserState)[1]; }
        }
        private void bgw_readScreen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        #endregion

    }
}
