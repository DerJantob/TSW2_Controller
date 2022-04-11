using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSW2_Controller
{
    internal class Tcfg
    {
        public static int zug = 0;
        public static int beschreibung = 1;
        public static int joystickNummer = 2;
        public static int joystickInput = 3;
        public static int invertieren = 4;
        public static int inputTyp = 5;
        public static int inputUmrechnen = 6;
        public static int tastenKombination = 7;
        public static int aktion = 8;
        public static int art = 9;
        public static int schritte = 10;
        public static int specials = 11;
        public static int zeitfaktor = 12;
        public static int laengerDruecken = 13;

        public static string nameForGlobal = "_Global";

        public static string configpfad = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TSW2_Controller\Trainconfig.csv";
        public static string configSammelungPfad = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TSW2_Controller\TrainConfigs\";
        public static string vollerlogpfad;
        public static string logOrdnerpfad = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TSW2_Controller\Log\";
        public static string configstandardpfad = @".\TrainConfigs\StandardTrainconfig.csv";
    }
}
