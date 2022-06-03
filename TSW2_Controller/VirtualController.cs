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
        public string[] textindicators;
        public string[] textindicators_throttlearea;
        public string[] textindicators_brakearea;
        public string increaseKey;
        public string decreaseKey;

        public string[] ConvertStringToArray(string input)
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
