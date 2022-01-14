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
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int KEY_DOWN_EVENT = 0x0001; //Key down flag
        const int KEY_UP_EVENT = 0x0002; //Key up flag

        public static byte increaseThrottle = (byte)Keys.A;
        public static byte increaseBrake = (byte)Keys.Oem7;
        public static byte decreaseThrottle = (byte)Keys.D;
        public static byte decreaseBrake = (byte)Keys.Oem3;


        public static void HoldKey(byte key, int duration)
        {
            keybd_event(key, 0, KEY_DOWN_EVENT, 0);
            System.Threading.Thread.Sleep(duration);
            keybd_event(key, 0, KEY_UP_EVENT, 0);
        }

        public static void KeyDown(byte key)
        {
            keybd_event(key, 0, KEY_DOWN_EVENT, 0);
        }

        public static void KeyUp(byte key)
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

        public static byte ConvertStringToKey(string input)
        {
            switch (input)
            {
                case ("space"):
                    return (byte)Keys.Space;
                case ("esc"):
                    return (byte)Keys.Escape;
                case ("tab"):
                    return (byte)Keys.Tab;
                case ("einfg"):
                    return (byte)Keys.Insert;
                case ("pos1"):
                    return (byte)Keys.Home;
                case ("bildauf"):
                    return (byte)Keys.Prior;
                case ("entf"):
                    return (byte)Keys.Delete;
                case ("ende"):
                    return (byte)Keys.End;
                case ("bildab"):
                    return (byte)Keys.Next;
                case ("hoch"):
                    return (byte)Keys.Up;
                case ("runter"):
                    return (byte)Keys.Down;
                case ("rechts"):
                    return (byte)Keys.Right;
                case ("links"):
                    return (byte)Keys.Left;
                case ("ü"):
                    return (byte)Keys.Oem1;
                case ("#"):
                    return (byte)Keys.Oem2;
                case ("ö"):
                    return (byte)Keys.Oem3;
                case ("ß"):
                    return (byte)Keys.Oem4;
                case ("^"):
                    return (byte)Keys.Oem5;
                case ("´"):
                    return (byte)Keys.Oem6;
                case ("ä"):
                    return (byte)Keys.Oem7;
                case ("+"):
                    return (byte)Keys.Oemplus;
                case ("komma"):
                    return (byte)Keys.Oemcomma;
                case ("."):
                    return (byte)Keys.OemPeriod;
                case ("-"):
                    return (byte)Keys.OemMinus;
                case ("0"):
                    return (byte)Keys.D0;
                case ("1"):
                    return (byte)Keys.D1;
                case ("2"):
                    return (byte)Keys.D2;
                case ("3"):
                    return (byte)Keys.D3;
                case ("4"):
                    return (byte)Keys.D4;
                case ("5"):
                    return (byte)Keys.D5;
                case ("6"):
                    return (byte)Keys.D6;
                case ("7"):
                    return (byte)Keys.D7;
                case ("8"):
                    return (byte)Keys.D8;
                case ("9"):
                    return (byte)Keys.D9;
                case ("a"):
                    return (byte)Keys.A;
                case ("b"):
                    return (byte)Keys.B;
                case ("c"):
                    return (byte)Keys.C;
                case ("d"):
                    return (byte)Keys.D;
                case ("e"):
                    return (byte)Keys.E;
                case ("f"):
                    return (byte)Keys.F;
                case ("g"):
                    return (byte)Keys.G;
                case ("h"):
                    return (byte)Keys.H;
                case ("i"):
                    return (byte)Keys.I;
                case ("j"):
                    return (byte)Keys.J;
                case ("k"):
                    return (byte)Keys.K;
                case ("l"):
                    return (byte)Keys.L;
                case ("m"):
                    return (byte)Keys.M;
                case ("n"):
                    return (byte)Keys.N;
                case ("o"):
                    return (byte)Keys.O;
                case ("p"):
                    return (byte)Keys.P;
                case ("q"):
                    return (byte)Keys.Q;
                case ("r"):
                    return (byte)Keys.R;
                case ("s"):
                    return (byte)Keys.S;
                case ("t"):
                    return (byte)Keys.T;
                case ("u"):
                    return (byte)Keys.U;
                case ("v"):
                    return (byte)Keys.V;
                case ("w"):
                    return (byte)Keys.W;
                case ("x"):
                    return (byte)Keys.X;
                case ("y"):
                    return (byte)Keys.Y;
                case ("z"):
                    return (byte)Keys.Z;
                default:
                    return (byte)0;
            }

        }
    }
}
