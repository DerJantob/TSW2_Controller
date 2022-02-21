using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSW2_Controller.Properties;

namespace TSW2_Controller
{
    public partial class FormWasIstNeu : Form
    {
        public FormWasIstNeu(string prevVersion)
        {
            InitializeComponent();
            showText(prevVersion);
        }

        public List<string> ChangeLog(Version version)
        {
            List<string> changelog = new List<string>();


            #region 1.0.1
            if (new Version("1.0.1").CompareTo(version) > 0)
            {
                changelog.Add("v1.0.1" + "\n");

                if (Settings.Default.Sprache == "de-DE")
                {
                    changelog.Add("- !Text Indikatoren aus Config entfernt!");
                    changelog.Add("- Text Indikatoren wurden in die Einstellungen verlegt");
                    changelog.Add("- Fix für Hin und her schwankenden Kombihebel");
                    changelog.Add("- changelog hinzugefügt");
                }
                else
                {
                    changelog.Add("- !Removed text indicators from config !");
                    changelog.Add("- Text indicators have been moved to Settings");
                    changelog.Add("- Fix for combo lever swaying back and forth ");
                    changelog.Add("- changelog added");
                }

                changelog.Add("----------------------------------------");
            }
            #endregion
            #region 1.0.2
            if (new Version("1.0.2").CompareTo(version) > 0)
            {
                changelog.Add("v1.0.2" + "\n");

                if (Settings.Default.Sprache == "de-DE")
                {
                    changelog.Add("- Bessere Texterkennung");
                    changelog.Add("- Besserer Umgang mit den Einrastpositionen");
                    changelog.Add("- Scanergebnisse ab jetzt im Menü zu sehen");
                    changelog.Add("- Debug Log Tabelle verkleinert");
                }
                else
                {
                    changelog.Add("- Better text recognition ");
                    changelog.Add("- Better handling of the snap positions ");
                    changelog.Add("- Scan results can now be seen in the menu ");
                    changelog.Add("- Debug log table reduced");
                }

                changelog.Add("----------------------------------------");
            }
            #endregion
            #region 1.0.3
            if (new Version("1.0.3").CompareTo(version) > 0)
            {
                changelog.Add("v1.0.3" + "\n");

                if (Settings.Default.Sprache == "de-DE")
                {
                    changelog.Add("- csv Datei (TrainConfig) kann nun in den Einstellungen bearbeitet werden");
                    changelog.Add("     - Knöpfe und Regler kann man selber leichter hinzufügen");
                    changelog.Add("- Englisch hinzugefügt");
                    changelog.Add("- Verbesserungen für langsame Joystick Bewegungen");
                    changelog.Add("- Auflösungseingabe verändert");
                    changelog.Add("- Langdruckstellen können nun bei der \"Zeitfaktor finden\" Seite getestet werden");
                }
                else
                {
                    changelog.Add("- csv file (TrainConfig) can now be edited in the settings ");
                    changelog.Add("     - It's easier to add buttons and controls yourself");
                    changelog.Add("- Added English ");
                    changelog.Add("- Improvements for slow joystick movements");
                    changelog.Add("- Resolution input changed");
                    changelog.Add("- Long press points can now be tested on the \"Find time factor\" page");
                }

                changelog.Add("----------------------------------------");
            }
            #endregion

            return changelog;
        }

        public void showText(string prevVersion)
        {
            Version version = new Version(prevVersion);
            List<string> changelog = new List<string>();
            string changelogOutput = "";

            changelog = ChangeLog(version);

            foreach (string s in changelog)
            {
                changelogOutput = changelogOutput + s + "\n";
            }

            richTextBox_Output.Text = changelogOutput.ToString();
        }

        private void richTextBox_Output_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            ((RichTextBox)sender).Height = e.NewRectangle.Height + 5;
            ((RichTextBox)sender).Width = e.NewRectangle.Width + 5;
        }
    }
}
