using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSW2_Controller
{
    internal class Tcfg
    {
        public static int arrayLength = 15;

        public static int zug = 0;
        public static int beschreibung = 1;
        public static int reglerName = 2;
        public static int joystickNummer = 3;
        public static int joystickInput = 4;
        public static int invertieren = 5;
        public static int inputTyp = 6;
        public static int inputUmrechnen = 7;
        public static int tastenKombination = 8;
        public static int aktion = 9;
        public static int art = 10;
        public static int schritte = 11;
        public static int specials = 12;
        public static int zeitfaktor = 13;
        public static int laengerDruecken = 14;

        public static string nameForGlobal = "_Global";


        public static string configOrdnerPfad = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TSW2_Controller\TrainConfigs\";

        public static string configpfad = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TSW2_Controller\Trainconfig.csv";
        public static string controllersConfigPfad = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TSW2_Controller\Controllers.csv";

        public static string configstandardpfad = @".\Configs\TrainConfig\StandardTrainconfig.csv";
        public static string controllersstandardpfad_DE = @".\Configs\ControllerConfig\StandardControllers_DE.csv";
        public static string controllersstandardpfad_EN = @".\Configs\ControllerConfig\StandardControllers_EN.csv";

        public static string vollerlogpfad;
        public static string logOrdnerpfad = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TSW2_Controller\Log\";
    }
}
