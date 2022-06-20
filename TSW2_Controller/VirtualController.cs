using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSW2_Controller
{
    internal class VirtualController
    {
        public string name;
        public string increaseKey;
        public string decreaseKey;
        public string[] mainIndicators;
        public string[] textindicators_throttlearea;
        public string[] textindicators_brakearea;
        public bool isMasterController = false;

        public int[] timefactor;
        public int currentJoystickValue;
        public int currentSimValue;
        public int cancelScan; //0=false 1=true -1=wait til current scan is done
        public int stufen;
        public int getText;
        public DateTime requestStartTime;
        public List<string[]> specialCases = new List<string[]>();
        public List<int[]> longPress = new List<int[]>();
        public bool waitToFinishMovement;
        public bool istStufenlos = false;


        public static string firstLine = "name,increase,decrease,main indicators,masterController,throttle_area,brake_area";
        public static int getTextDefault = 3;


        public string combineToString()
        {
            return name + "," + increaseKey + "," + decreaseKey + "," + String.Join("|", mainIndicators) + "," + Convert.ToString(isMasterController) + "," + String.Join("|", textindicators_throttlearea) + "," + String.Join("|", textindicators_brakearea);
        }

        public void InsertFileArray(string[] stringArray)
        {
            name = stringArray[0];
            increaseKey = stringArray[1];
            decreaseKey = stringArray[2];
            mainIndicators = ConvertStringToArray(stringArray[3]);
            isMasterController = Convert.ToBoolean(stringArray[4]);
            textindicators_throttlearea = ConvertStringToArray(stringArray[5]);
            textindicators_brakearea = ConvertStringToArray(stringArray[6]);
        }

        private string[] ConvertStringToArray(string input)
        {
            string[] result;

            result = input.Split('|');
            if (result.Count() == 1)
            {
                if (result[0] == "")
                {
                    result = new string[0];
                }
            }
            return result;
        }
    }
}
