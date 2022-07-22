using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSW2_Controller.Properties;

namespace TSW2_Controller
{
    internal class Sprache
    {
        public static bool isGerman;
        public static string Zugauswahl()
        {
            return Translate("_Zugauswahl", "_Select train");
        }

        public static void ShowMessageBox(string Deutsch, string Englisch)
        {
            if (Settings.Default.Sprache == "de-DE")
            {
                MessageBox.Show(Deutsch);
            }
            else
            {
                MessageBox.Show(Englisch);
            }
        }

        public static void initLanguage()
        {
            if (Settings.Default.Sprache == "de-DE")
            {
                isGerman = true;
            }
            else
            {
                isGerman = false;
            }
        }

        public static string Translate(string Deutsch, string Englisch = "")
        {
            if (Settings.Default.Sprache == "de-DE")
            {
                return Deutsch;
            }
            else
            {
                return Englisch;
            }
        }
    }
}
