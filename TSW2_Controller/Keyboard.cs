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


        public static void HoldKey(Keys key, int duration)
        {
            keybd_event(key, 0, KEY_DOWN_EVENT, 0);
            System.Threading.Thread.Sleep(duration);
            keybd_event(key, 0, KEY_UP_EVENT, 0);
        }

        public static void KeyDown(Keys key)
        {
            keybd_event(key, 0, KEY_DOWN_EVENT, 0);
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
            string x;
            switch (x = input)
            { 
                case ("space"):
                    return Keys.Space;
                case ("esc"):
                    return Keys.Escape;
                case ("tab"):
                    return Keys.Tab;
                case ("einfg"):
                    return Keys.Insert;
                case ("pos1"):
                    return Keys.Home;
                case ("bildauf"):
                    return Keys.Prior;
                case ("entf"):
                    return Keys.Delete;
                case ("ende"):
                    return Keys.End;
                case ("bildab"):
                    return Keys.Next;
                case ("hoch"):
                    return Keys.Up;
                case ("runter"):
                    return Keys.Down;
                case ("rechts"):
                    return Keys.Right;
                case ("links"):
                    return Keys.Left;
                case ("alt"):
                    return Keys.LMenu;
                case ("altgr"):
                    return Keys.RMenu;
                case ("strg"):
                    return Keys.LControlKey;
                case ("rstrg"):
                    return Keys.RControlKey;
                case ("win"):
                    return Keys.LWin;
                case ("rwin"):
                    return Keys.RWin;
                case ("shift"):
                    return Keys.LShiftKey;
                case ("rshift"):
                    return Keys.RShiftKey;
                case ("ü"):
                    return Keys.Oem1;
                case ("#"):
                    return Keys.Oem2;
                case ("ö"):
                    return Keys.Oem3;
                case ("ß"):
                    return Keys.Oem4;
                case ("^"):
                    return Keys.Oem5;
                case ("´"):
                    return Keys.Oem6;
                case ("ä"):
                    return Keys.Oem7;
                case ("+"):
                    return Keys.Oemplus;
                case ("komma"):
                    return Keys.Oemcomma;
                case ("."):
                    return Keys.OemPeriod;
                case ("-"):
                    return Keys.OemMinus;
                case ("capslock"):
                    return Keys.CapsLock;
                case ("zurück"):
                    return Keys.Back;
                case ("enter"):
                    return Keys.Return;
                case ("drucken"):
                    return Keys.Snapshot;
                case ("rollen"):
                    return Keys.Scroll;
                case ("pause"):
                    return Keys.Pause;
                case ("numlock"):
                    return Keys.NumLock;
                case ("num0"):
                    return Keys.NumPad0;
                case ("num1"):
                    return Keys.NumPad1;
                case ("num2"):
                    return Keys.NumPad2;
                case ("num3"):
                    return Keys.NumPad3;
                case ("num4"):
                    return Keys.NumPad4;
                case ("num5"):
                    return Keys.NumPad5;
                case ("num6"):
                    return Keys.NumPad6;
                case ("num7"):
                    return Keys.NumPad7;
                case ("num8"):
                    return Keys.NumPad8;
                case ("num9"):
                    return Keys.NumPad9;
                case ("num/"):
                    return Keys.Divide;
                case ("num*"):
                    return Keys.Multiply;
                case ("num-"):
                    return Keys.Subtract;
                case ("num+"):
                    return Keys.Add;
                case ("numenter"):
                    return Keys.Return;
                case ("numkomma"):
                    return Keys.Delete;
                case ("0"):
                    return Keys.D0;
                case ("1"):
                    return Keys.D1;
                case ("2"):
                    return Keys.D2;
                case ("3"):
                    return Keys.D3;
                case ("4"):
                    return Keys.D4;
                case ("5"):
                    return Keys.D5;
                case ("6"):
                    return Keys.D6;
                case ("7"):
                    return Keys.D7;
                case ("8"):
                    return Keys.D8;
                case ("9"):
                    return Keys.D9;
                case ("f1"):
                    return Keys.F1;
                case ("f2"):
                    return Keys.F2;
                case ("f3"):
                    return Keys.F3;
                case ("f4"):
                    return Keys.F4;
                case ("f5"):
                    return Keys.F5;
                case ("f6"):
                    return Keys.F6;
                case ("f7"):
                    return Keys.F7;
                case ("f8"):
                    return Keys.F8;
                case ("f9"):
                    return Keys.F9;
                case ("f10"):
                    return Keys.F10;
                case ("f11"):
                    return Keys.F11;
                case ("f12"):
                    return Keys.F12;
                case ("a"):
                    return Keys.A;
                case ("b"):
                    return Keys.B;
                case ("c"):
                    return Keys.C;
                case ("d"):
                    return Keys.D;
                case ("e"):
                    return Keys.E;
                case ("f"):
                    return Keys.F;
                case ("g"):
                    return Keys.G;
                case ("h"):
                    return Keys.H;
                case ("i"):
                    return Keys.I;
                case ("j"):
                    return Keys.J;
                case ("k"):
                    return Keys.K;
                case ("l"):
                    return Keys.L;
                case ("m"):
                    return Keys.M;
                case ("n"):
                    return Keys.N;
                case ("o"):
                    return Keys.O;
                case ("p"):
                    return Keys.P;
                case ("q"):
                    return Keys.Q;
                case ("r"):
                    return Keys.R;
                case ("s"):
                    return Keys.S;
                case ("t"):
                    return Keys.T;
                case ("u"):
                    return Keys.U;
                case ("v"):
                    return Keys.V;
                case ("w"):
                    return Keys.W;
                case ("x"):
                    return Keys.X;
                case ("y"):
                    return Keys.Y;
                case ("z"):
                    return Keys.Z;
                default:
                    MessageBox.Show("Fehler! Kenne die Taste \"" + x + "\" nicht");
                    return Keys.Space;
            }

        }
    }
}
