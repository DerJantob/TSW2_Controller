using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSW2_Controller
{
    public class Keyboard
    {
        const int PauseBetweenStrokes = 50;
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(Keys bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int KEY_DOWN_EVENT = 0x0001; //Key down flag
        const int KEY_UP_EVENT = 0x0002; //Key up flag

        public static Keys increaseThrottle = Keys.A;
        public static Keys increaseBrake = Keys.Oem7;
        public static Keys decreaseThrottle = Keys.D;
        public static Keys decreaseBrake = Keys.Oem3;

        private static List<object[]> keyList = new List<object[]>();

        public static void initKeylist()
        {
            Log.Add("InitKeyList");
            keyList.Add(new object[] { "space", Keys.Space });
            keyList.Add(new object[] { "esc", Keys.Escape });
            keyList.Add(new object[] { "tab", Keys.Tab });
            keyList.Add(new object[] { "insert", Keys.Insert });
            keyList.Add(new object[] { "home", Keys.Home });
            keyList.Add(new object[] { "pageUp", Keys.Prior });
            keyList.Add(new object[] { "del", Keys.Delete });
            keyList.Add(new object[] { "end", Keys.End });
            keyList.Add(new object[] { "pageDown", Keys.Next });
            keyList.Add(new object[] { "up", Keys.Up });
            keyList.Add(new object[] { "down", Keys.Down });
            keyList.Add(new object[] { "right", Keys.Right });
            keyList.Add(new object[] { "left", Keys.Left });
            keyList.Add(new object[] { "alt", Keys.Menu });
            keyList.Add(new object[] { "altl", Keys.LMenu });
            keyList.Add(new object[] { "altr", Keys.RMenu });
            keyList.Add(new object[] { "ctrl", Keys.ControlKey });
            keyList.Add(new object[] { "lctrl", Keys.LControlKey });
            keyList.Add(new object[] { "rctrl", Keys.RControlKey });
            keyList.Add(new object[] { "win", Keys.LWin });
            keyList.Add(new object[] { "rwin", Keys.RWin });
            keyList.Add(new object[] { "shift", Keys.ShiftKey });
            keyList.Add(new object[] { "lshift", Keys.LShiftKey });
            keyList.Add(new object[] { "rshift", Keys.RShiftKey });
            keyList.Add(new object[] { "oem1", Keys.Oem1 });
            keyList.Add(new object[] { "oem2", Keys.Oem2 });
            keyList.Add(new object[] { "oem3", Keys.Oem3 });
            keyList.Add(new object[] { "oem4", Keys.Oem4 });
            keyList.Add(new object[] { "oem5", Keys.Oem5 });
            keyList.Add(new object[] { "oem6", Keys.Oem6 });
            keyList.Add(new object[] { "oem7", Keys.Oem7 });
            keyList.Add(new object[] { "oem8", Keys.Oem8 });
            keyList.Add(new object[] { "+", Keys.Oemplus });
            keyList.Add(new object[] { "comma", Keys.Oemcomma });
            keyList.Add(new object[] { ".", Keys.OemPeriod });
            keyList.Add(new object[] { "-", Keys.OemMinus });
            keyList.Add(new object[] { "capslock", Keys.CapsLock });
            keyList.Add(new object[] { "back", Keys.Back });
            keyList.Add(new object[] { "return", Keys.Return });
            keyList.Add(new object[] { "print", Keys.Snapshot });
            keyList.Add(new object[] { "scroll", Keys.Scroll });
            keyList.Add(new object[] { "pause", Keys.Pause });
            keyList.Add(new object[] { "numlock", Keys.NumLock });
            keyList.Add(new object[] { "num0", Keys.NumPad0 });
            keyList.Add(new object[] { "num1", Keys.NumPad1 });
            keyList.Add(new object[] { "num2", Keys.NumPad2 });
            keyList.Add(new object[] { "num3", Keys.NumPad3 });
            keyList.Add(new object[] { "num4", Keys.NumPad4 });
            keyList.Add(new object[] { "num5", Keys.NumPad5 });
            keyList.Add(new object[] { "num6", Keys.NumPad6 });
            keyList.Add(new object[] { "num7", Keys.NumPad7 });
            keyList.Add(new object[] { "num8", Keys.NumPad8 });
            keyList.Add(new object[] { "num9", Keys.NumPad9 });
            keyList.Add(new object[] { "num/", Keys.Divide });
            keyList.Add(new object[] { "num*", Keys.Multiply });
            keyList.Add(new object[] { "num-", Keys.Subtract });
            keyList.Add(new object[] { "num+", Keys.Add });
            keyList.Add(new object[] { "numenter", Keys.Return });
            keyList.Add(new object[] { "numcomma", Keys.Delete });
            keyList.Add(new object[] { "0", Keys.D0 });
            keyList.Add(new object[] { "1", Keys.D1 });
            keyList.Add(new object[] { "2", Keys.D2 });
            keyList.Add(new object[] { "3", Keys.D3 });
            keyList.Add(new object[] { "4", Keys.D4 });
            keyList.Add(new object[] { "5", Keys.D5 });
            keyList.Add(new object[] { "6", Keys.D6 });
            keyList.Add(new object[] { "7", Keys.D7 });
            keyList.Add(new object[] { "8", Keys.D8 });
            keyList.Add(new object[] { "9", Keys.D9 });
            keyList.Add(new object[] { "f1", Keys.F1 });
            keyList.Add(new object[] { "f2", Keys.F2 });
            keyList.Add(new object[] { "f3", Keys.F3 });
            keyList.Add(new object[] { "f4", Keys.F4 });
            keyList.Add(new object[] { "f5", Keys.F5 });
            keyList.Add(new object[] { "f6", Keys.F6 });
            keyList.Add(new object[] { "f7", Keys.F7 });
            keyList.Add(new object[] { "f8", Keys.F8 });
            keyList.Add(new object[] { "f9", Keys.F9 });
            keyList.Add(new object[] { "f10", Keys.F10 });
            keyList.Add(new object[] { "f11", Keys.F11 });
            keyList.Add(new object[] { "f12", Keys.F12 });
            keyList.Add(new object[] { "a", Keys.A });
            keyList.Add(new object[] { "b", Keys.B });
            keyList.Add(new object[] { "c", Keys.C });
            keyList.Add(new object[] { "d", Keys.D });
            keyList.Add(new object[] { "e", Keys.E });
            keyList.Add(new object[] { "f", Keys.F });
            keyList.Add(new object[] { "g", Keys.G });
            keyList.Add(new object[] { "h", Keys.H });
            keyList.Add(new object[] { "i", Keys.I });
            keyList.Add(new object[] { "j", Keys.J });
            keyList.Add(new object[] { "k", Keys.K });
            keyList.Add(new object[] { "l", Keys.L });
            keyList.Add(new object[] { "m", Keys.M });
            keyList.Add(new object[] { "n", Keys.N });
            keyList.Add(new object[] { "o", Keys.O });
            keyList.Add(new object[] { "p", Keys.P });
            keyList.Add(new object[] { "q", Keys.Q });
            keyList.Add(new object[] { "r", Keys.R });
            keyList.Add(new object[] { "s", Keys.S });
            keyList.Add(new object[] { "t", Keys.T });
            keyList.Add(new object[] { "u", Keys.U });
            keyList.Add(new object[] { "v", Keys.V });
            keyList.Add(new object[] { "w", Keys.W });
            keyList.Add(new object[] { "x", Keys.X });
            keyList.Add(new object[] { "y", Keys.Y });
            keyList.Add(new object[] { "z", Keys.Z });
        }

        public static void HoldKey(Keys key, int duration)
        {
            keybd_event(key, 0, KEY_DOWN_EVENT, 0);
            System.Threading.Thread.Sleep(duration);
            keybd_event(key, 0, KEY_UP_EVENT, 0);
        }

        public static void KeyDown(Keys key)
        {
            keybd_event(key, 0, 0, 0);
        }

        public static void KeyUp(Keys key)
        {
            keybd_event(key, 0, KEY_UP_EVENT, 0);
        }

        public static void ProcessAktion(string input)
        {
            string[] inputarray = input.Split('_');

            if (inputarray.Length >= 3)
            {
                for (int i = 0; i < inputarray.Length; i += 3)
                {
                    if (inputarray[i + 1] == "[press]")
                    {
                        //SendKeys.Send(inputarray[i]);
                        Keyboard.HoldKey(ConvertStringToKey(inputarray[i]), 0);
                    }
                    else if (inputarray[i + 1] == "[down]")
                    {
                        KeyDown(ConvertStringToKey(inputarray[i]));
                    }
                    else if (inputarray[i + 1] == "[up]")
                    {
                        KeyUp(ConvertStringToKey(inputarray[i]));
                    }
                    else if (inputarray[i + 1].Contains("[hold"))
                    {
                        int time = 0;
                        string s = inputarray[i + 1];
                        s = s.Replace("[hold", "").Replace("]", "");

                        try
                        {
                            time = Convert.ToInt32(s);
                        }
                        catch { }

                        HoldKey(ConvertStringToKey(inputarray[i]), time);
                    }
                    else
                    {
                        MessageBox.Show("Error:" + inputarray[i + 1]);
                    }

                    if (inputarray[i + 2].Contains("[") && inputarray[i + 2].Contains("]"))
                    {
                        int time = 0;
                        string s = inputarray[i + 2];
                        s = s.Replace("[", "").Replace("]", "");
                        try
                        {
                            time = Convert.ToInt32(s);
                        }
                        catch
                        {
                            MessageBox.Show("Error:" + inputarray[i + 2]);
                        }
                        Thread.Sleep(time);
                    }

                }
            }
        }

        public static Keys ConvertStringToKey(string input)
        {
            foreach (object[] obj in keyList)
            {
                if (input == (string)obj[0])
                {
                    return (Keys)obj[1];
                }
            }

            Log.Error("Unknown key:"+input,true);
            return Keys.None;
        }

        public static string ConvertKeyToString(Keys key)
        {
            foreach (object[] obj in keyList)
            {
                if (key == (Keys)obj[1])
                {
                    return (string)obj[0];
                }
            }

            Log.Error("Unknown key:" + key.ToString(), true);
            return "";
        }
    }
}
