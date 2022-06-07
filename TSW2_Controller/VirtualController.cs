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
        public string[] mainIndicators;
        public string[] textindicators_throttlearea;
        public string[] textindicators_brakearea;
        public string increaseKey;
        public string decreaseKey;
        public int timefactor;

        public int currentJoystickValue;
        public int currentSimValue;
        public int cancelScan; //0=false 1=true -1=wait til current scan is done
        public int stufen;
        public int getText;
        public bool waitToFinishMovement;
        public bool istStufenlos = false;


        public void InsertFileArray(string[] stringArray)
        {
            name = stringArray[0];
            increaseKey = stringArray[1];
            decreaseKey = stringArray[2];
            mainIndicators = ConvertStringToArray(stringArray[3]);
            textindicators_throttlearea = ConvertStringToArray(stringArray[4]);
            textindicators_brakearea = ConvertStringToArray(stringArray[5]);
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
