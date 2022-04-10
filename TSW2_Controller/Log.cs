using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSW2_Controller
{
    public class Log
    {
        public static List<string> DebugInfoList = new List<string>();
        public Log()
        {
        }

        public static void Clear()
        {
            CheckPath();
            if (File.Exists(Tcfg.logpfad))
            {
                File.WriteAllText(Tcfg.logpfad, "");
            }
        }

        private static void CheckPath()
        {
            if (!Directory.Exists(Tcfg.logpfad.Replace("log.txt", "")))
            {
                Directory.CreateDirectory(Tcfg.logpfad.Replace("log.txt", ""));
            }
        }


        private static readonly object locker = new object();

        public static void Add(string message, bool ShowUser = false, int ebene = 0)
        {
            lock (locker)
            {
                string leerZeichen = "";
                while (ebene > 0)
                {
                    leerZeichen += "    ";
                    ebene--;
                }

                CheckPath();

                StreamWriter SW;
                SW = File.AppendText(Tcfg.logpfad);
                SW.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "             :" + leerZeichen + message);
                SW.Close();

                if (ShowUser)
                {
                    DebugInfoList.Add(message);
                }
            }
        }

        public static void Error(string message, bool ShowUser = false)
        {
            lock (locker)
            {
                CheckPath();

                StreamWriter SW;
                SW = File.AppendText(Tcfg.logpfad);
                SW.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "    " + "-Error-  :" + message);
                SW.Close();

                if (ShowUser)
                {
                    DebugInfoList.Add(message);
                }
            }
        }

        public static void ErrorException(Exception ex)
        {
            lock (locker)
            {
                CheckPath();

                StreamWriter SW;
                SW = File.AppendText(Tcfg.logpfad);
                SW.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "    " + "-Error-  :" + ex.ToString().Replace("\r\n", ""));
                SW.Close();
            }
        }
    }
}
