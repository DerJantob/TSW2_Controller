using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSW2_Controller
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Tcfg.vollerlogpfad = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TSW2_Controller\Log\log"+DateTime.Now.ToString("yyyyMMdd_HH_mm_ss")+".txt";
            Log.RemoveUnnecessaryLogs();

            Application.Run(new FormMain());
        }
    }
}
