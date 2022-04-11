using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSW2_Controller.Properties;

namespace TSW2_Controller
{
    internal class MessageClass
    {
        public static void Show(string Deutsch, string Englisch)
        {
            if(Sprache.SprachenName == "Deutsch")
            {
                MessageBox.Show(Deutsch);
            }
            else
            {
                MessageBox.Show(Englisch);
            }
        }
        public static string Convert(string Deutsch, string Englisch)
        {
            if (Sprache.SprachenName == "Deutsch")
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
