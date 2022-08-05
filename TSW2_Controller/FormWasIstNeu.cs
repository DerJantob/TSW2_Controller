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


            #region 1.0.0
            if (new Version("1.0.0").CompareTo(version) > 0)
            {
                changelog.Add("v1.0.0" + "\n");

                if (Settings.Default.Sprache == "de-DE")
                {
                    changelog.Add("- Veröffentlichung");
                }
                else
                {
                    changelog.Add("- Release");
                }

                changelog.Add("----------------------------------------");
            }
            #endregion
            #region 1.0.1
            if (new Version("1.0.1").CompareTo(version) > 0)
            {
                changelog.Add("v1.0.1" + "\n");

                if (Settings.Default.Sprache == "de-DE")
                {
                    changelog.Add("- Textindikatoren wechseln mit der Sprache");
                    changelog.Add("- Sprache wird beim erstmaligen Start automatisch erkannt");
                    changelog.Add("- Fix für komisches Verhalten bei den Sonderfällen beim Kombihebel (muss also evtl überarbeitet werden)");
                    changelog.Add("- Andere kleinen Korrekturen");
                    changelog.Add("\n\n- Video tutorial hinzugefügt (auf englisch):\n  https://www.youtube.com/watch?v=OWzzWSfhy1s");
                }
                else
                {
                    changelog.Add("- Text indicators change with the language");
                    changelog.Add("- Language is automatically detected at first startup");
                    changelog.Add("- Fix for strange behavior in the special cases with the master controller (you should check it)");
                    changelog.Add("- Other small fixes");
                    changelog.Add("\n\n- Video tutorial added:\n  https://www.youtube.com/watch?v=OWzzWSfhy1s");
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
                    changelog.Add("- Fix: Kombihebel hat im Bremsbereich nicht mehr funktioniert, wenn ein Knopf hinzugefügt wurde");
                }
                else
                {
                    changelog.Add("- Fix: Master Controller didn't work in braking area, if a button was added");
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
                    changelog.Add("- Fix: Probleme mit der Textindikatoren-Reihenfolge");
                    changelog.Add("- Verbesserung: Auflisten von vielen Joystick-Informationen");
                }
                else
                {
                    changelog.Add("- Fix: Problems with the arrangement of text indicators");
                    changelog.Add("- Improvement: List multiple joystick information");
                }
            }
            #endregion
            #region 1.0.4
            if (new Version("1.0.4").CompareTo(version) > 0)
            {
                changelog.Add("v1.0.4" + "\n");

                if (Settings.Default.Sprache == "de-DE")
                {
                    changelog.Add("- Fix: Wenn man das Joystickverhalten geändert hat (Invertiert / Anderer Joy Modus), dann wurde das unabhängig von der Joynummer übernommen");
                    changelog.Add("- Fix/Verbessert: Tastenbelegung für Schub und Bremse einstellbar, damit verschiedene Tastaturlayouts funktionieren");
                    changelog.Add("- Verbessert: \"Update verfügbar\" ist ab jetzt klickbar");
                }
                else
                {
                    changelog.Add("- Fix: If you changed the joystick behavior (Inverted / Other Joy Mode), it was applied regardless of the joystick number");
                    changelog.Add("- Fix/Improvement: Key mapping for throttle and brake customizable to support different keyboard layouts");
                    changelog.Add("- Improvement: \"Update available\" now clickable");
                }

                changelog.Add("----------------------------------------");
            }
            #endregion
            #region 1.1.0
            if (new Version("1.1.0").CompareTo(version) > 0)
            {
                changelog.Add("v1.1.0" + "\n");

                if (Settings.Default.Sprache == "de-DE")
                {
                    changelog.Add("- Man kann nun in den Einstellungen zwischen TrainConfigs wechseln");
                    changelog.Add("- Hinzugefügt: Log datei");
                    changelog.Add("- Hinzugefügt: Menüstreifen in den Einstellungen");
                    changelog.Add("- Verbessert: Stufenregler schneller");
                    changelog.Add("- Verbessert: Fehlerhafte Benutzereingaben werden angezeigt");
                    changelog.Add("- Verbessert: Benennungen der Tasten verändert um verwirrung zu verhindern");
                    changelog.Add("- Verbessert: Tastenkombinationen können jetzt im Editor auch bearbeitet werden");
                    changelog.Add("- Verbessert: Man kann jetzt im Editor auch zwischen Einträgen einen weiteren einfügen");
                    changelog.Add("- Bugfix: Sonderfälle konnten das %-Zeichen nicht lesen");
                    changelog.Add("- Bugfix: Kombihebel kann nun mit der Bremse kombiniert werden");
                    changelog.Add("- Bugfix: Shift-Taste funktioniert jetzt korrekt");
                }
                else
                {
                    changelog.Add("- You can now switch between trainconfigs in the settings");
                    changelog.Add("- Added: Log file");
                    changelog.Add("- Added: Menustrip in the settings");
                    changelog.Add("- Improved: Notch controller faster");
                    changelog.Add("- Improved: Detect faulty user input and notify him about it");
                    changelog.Add("- Improved: Names of the keys changed to prevent confusion");
                    changelog.Add("- Improved: Keyboard shortcuts can now also be edited in the editor");
                    changelog.Add("- Improved: It is now possible to insert another entry between entries in the editor");
                    changelog.Add("- Bugfix: Special cases could not read \"%\"");
                    changelog.Add("- Bugfix: Master Controller can now be combined with the brake");
                    changelog.Add("- Bugfix: Shift key is now working correctly");
                }

                changelog.Add("----------------------------------------");
            }
            #endregion
            #region 1.1.1
            if (new Version("1.1.1").CompareTo(version) > 0)
            {
                changelog.Add("v1.1.1" + "\n");

                if (Settings.Default.Sprache == "de-DE")
                {
                    changelog.Add("- Windows 11 kompatibel");
                    changelog.Add("- Hinzugefügt: Joysticks können jetzt auch angeschlossen werden, während das Programm läuft");
                    changelog.Add("- Verbessert: Alte Logdateien werden automatisch gelöscht");
                }
                else
                {
                    changelog.Add("- Windows 11 compatible");
                    changelog.Add("- Added: Joysticks can now be plugged in while program is running");
                    changelog.Add("- Improved: Old logfiles get deleted automatically");
                }

                changelog.Add("----------------------------------------");
            }
            #endregion
            #region 1.1.2
            if (new Version("1.1.2").CompareTo(version) > 0)
            {
                changelog.Add("v1.1.2" + "\n");

                if (Settings.Default.Sprache == "de-DE")
                {
                    changelog.Add("- Verändert: Statt automatischem erkennen von neuen Joysticks gibt es jetzt einen Knopf dafür, da es Probleme damit gab");
                }
                else
                {
                    changelog.Add("- Changed: Instead of automatic detection of new joysticks, there is now a button for it, since there were problems with it");
                }

                changelog.Add("----------------------------------------");
            }
            #endregion
            #region 2.0.0
            if (new Version("2.0.0").CompareTo(version) > 0)
            {
                changelog.Add("v2.0.0" + "\n");

                if (Settings.Default.Sprache == "de-DE")
                {
                    changelog.Add("Es gibt ein neues tutorial:");
                    changelog.Add("https://youtu.be/Sej1L0p_myo");
                    changelog.Add("");
                    changelog.Add("- Das Bearbeiten der Züge komplett überarbeitet:");
                    changelog.Add("     - Benutzerdefinierte Regler:");
                    changelog.Add("         - Schub, Bremse, AFB, Kombihebel, direkte Bremse, elektrische Bremse, ... können nun auch benutzt werden");
                    changelog.Add("         - Man kann selber Regler hinzufügen und diesen dann Tasten und Textindikatoren zuweisen.");
                    changelog.Add("     - Das Verhalten des Reglers kann individuell angepasst werden");
                    changelog.Add("     - Zeitfaktor finden deutlich verbessert");
                    changelog.Add("     - Tastenkombinations-Editor verbessert");
                    changelog.Add("");
                    changelog.Add("- Verändert:\"Länger drücken\" ist nun richtungsabhängig. 2|3:200 löst also nur noch aus, wenn ich mich von z.B. 0 nach 5 bewege und nich umgekehrt.");
                    changelog.Add("");
                    changelog.Add("- Hinzugefügt: Import und Export von deinen TrainConfigs");
                    changelog.Add("- Verbessert: Die Texterkennung ist nun deutlich schneller (Hauptsächlich dank asdf1280)");
                    changelog.Add("- Verbessert: Die Texterkennung ist nun zuverlässiger");
                    changelog.Add("- Verbessert: Widescreen support (beta)");
                    changelog.Add("- Bugfix: Nach dem klicken auf \"Aktiv\" wurden sofort Tasten gedrückt");
                }
                else
                {
                    changelog.Add("I have made a new tutorial:");
                    changelog.Add("https://youtu.be/Sej1L0p_myo");
                    changelog.Add("");
                    changelog.Add("- Completely reworked the editing of the trains:");
                    changelog.Add("     - Custom controls:");
                    changelog.Add("         - Throttle, brake, AFB, master controller, direct Brake, electric Brake, ... can now also be use");
                    changelog.Add("         - You can add controllers yourself and then assign keys and text indicators to them.");
                    changelog.Add("     - The behavior of the controller can be customized");
                    changelog.Add("     - Find time factor significantly improved");
                    changelog.Add("     - Keyboard shortcut editor improved");
                    changelog.Add("");
                    changelog.Add("- Changed:\"Long press\" is now directional. 2|3:200 only triggers, if the stick moves from e.g. 0 to 5 and not the other way around.");
                    changelog.Add("");
                    changelog.Add("- Added: Import and export of your TrainConfigs");
                    changelog.Add("- Improved: Text recognition is now much faster (mainly thanks to asdf1280)");
                    changelog.Add("- Improved: Text recognition is now more reliable");
                    changelog.Add("- Improved: Widescreen support (beta)");
                    changelog.Add("- Bugfix: After clicking \"Activ\", the program immediately pressed keys");
                }

                changelog.Add("----------------------------------------");
            }
            #endregion
            #region 2.0.1
            if (new Version("2.0.1").CompareTo(version) > 0)
            {
                changelog.Add("v2.0.1" + "\n");

                if (Settings.Default.Sprache == "de-DE")
                {
                    changelog.Add("- Bugfix: Langsame Joystickbewegung wurde ignoriert");
                    changelog.Add("- Hinzugefügt: Knopf zum entfernen eines Reglers");
                    changelog.Add("- Kleine Verbesserung: Mehr Debuginfos");
                    changelog.Add("- Kleine Verbesserung: Texterkennung");
                }
                else
                {
                    changelog.Add("- Bugfix: Slow joystick movement was ignored");
                    changelog.Add("- Added: Button to remove a controller");
                    changelog.Add("- Small improvement: more debuginfos");
                    changelog.Add("- Small improvement: Text recognition");
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
            ((RichTextBox)sender).Width = e.NewRectangle.Width + 5;
        }
    }
}
