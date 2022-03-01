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
