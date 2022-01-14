using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using SlimDX.DirectInput;
using System.IO;

namespace TSW2_Controller
{
    public partial class MainForm : Form
    {
        DirectInput input = new DirectInput();
        SlimDX.DirectInput.Joystick mainStick;
        Joystick[] MainSticks;

        public Rectangle res = Screen.PrimaryScreen.Bounds;

        List<string[]> trainConfig = new List<string[]>();
        List<string[]> activeTrain = new List<string[]>();
        List<string> trainNames = new List<string>();
        List<object[]> joystickStates = new List<object[]>(); // id, joyInputs, inputNames, buttons
        List<string> rawData = new List<string>();

        bool[] currentlyPressedButtons = new bool[128];
        bool[] previouslyPressedButtons = new bool[128];

        string[] throttleConfig; //{Index,Art,Schritte,Specials,Zeit,längerDrücken}
        string[] brakeConfig; //{Index,Art,Schritte,Specials,Zeit,LängerDrücken}
        string[] inputNames = { "JoyX", "JoyY", "JoyZ", "pov", "RotX", "RotY", "RotZ", "Sldr" };
        string[] kombihebel = { "", "" };

        bool isKombihebel = false;
        bool heldDown = false;
        bool cancelThrottleRequest = false;
        bool cancelBrakeRequest = false;

        int requestThrottle = 0;
        int requestBrake = 0;

        int schubIst = 0;
        int schubSoll = 0;

        public int bremseIst = 0;
        int bremseSoll = 0
        


        public MainForm()
        {
            InitializeComponent();

            //loadSettings();
            //comboBox_JoystickNumber.SelectedIndex = 0;
            //MainSticks = getSticks();
            //ReadTrainConfig();
            //ReadTrainNamesFromTrainconfig();
            //
            //timer_CheckSticks.Start();
        }

        public void loadSettings()
        {
            if (Properties.Settings.Default.res.IsEmpty)
            {
                Properties.Settings.Default.res = res;
                Properties.Settings.Default.Save();
            }
            else
            {
                res = Properties.Settings.Default.res;
            }

            if(Properties.Settings.Default.showDebug)
            {
                listBox_debugInfo.Show();
                lbl_bremse.Show();
                lbl_schub.Show();
            }
            else
            {
                listBox_debugInfo.Hide();
                lbl_bremse.Hide();
                lbl_schub.Hide();
            }

            lbl_resolution.Text = res.Width.ToString() + "x" + res.Height.ToString();
        }


        public void ReadTrainConfig()
        {
            trainConfig.Clear();
            using (var reader = new StreamReader(@".\Trainconfig.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    trainConfig.Add(values);
                }
            }
        }

        public void ReadTrainNamesFromTrainconfig()
        {
            trainNames.Clear();
            comboBox_Zugauswahl.Items.Clear();

            foreach (string[] str in trainConfig)
            {
                if (!trainNames.Any(str[0].Contains) && str[0] != "Zug" && str[0] != "Global")
                {
                    trainNames.Add(str[0]);
                }
            }
            comboBox_Zugauswahl.Items.AddRange(trainNames.ToArray());
        }

        public void getActiveTrain()
        {
            throttleConfig = new string[6];
            brakeConfig = new string[6];
            activeTrain.Clear();
            string selection = comboBox_Zugauswahl.Text;

            foreach (string[] str in trainConfig)
            {
                if (str[0] == selection || str[0] == "Global")
                {
                    activeTrain.Add(str);
                }
            }

            foreach (string[] str in activeTrain)
            {
                isKombihebel = false;
                if (str[Tcfg.aktion].Contains("Schub"))
                {
                    throttleConfig[0] = str[Tcfg.textIndex];
                    throttleConfig[1] = str[Tcfg.art];
                    throttleConfig[2] = str[Tcfg.schritte];
                    throttleConfig[3] = str[Tcfg.specials];
                    throttleConfig[4] = str[Tcfg.zeitumrechnung];
                    throttleConfig[5] = str[Tcfg.laengerDruecken];
                }
                else if (str[Tcfg.aktion].Contains("Kombihebel"))
                {
                    isKombihebel = true;
                    throttleConfig[0] = str[Tcfg.textIndex].Remove(str[Tcfg.textIndex].IndexOf("["), str[Tcfg.textIndex].Length - str[Tcfg.textIndex].IndexOf("["));
                    throttleConfig[1] = str[Tcfg.art];
                    throttleConfig[2] = str[Tcfg.schritte];
                    throttleConfig[3] = str[Tcfg.specials];
                    throttleConfig[4] = str[Tcfg.zeitumrechnung];
                    throttleConfig[5] = str[Tcfg.laengerDruecken];

                    string[] convert = str[Tcfg.textIndex].Remove(str[Tcfg.textIndex].Length - 1).Replace(throttleConfig[0], "").Replace("[", "").Split(']');
                    kombihebel[0] = convert[0];
                    kombihebel[1] = convert[1];
                }

                if (str[Tcfg.aktion].Contains("Bremse"))
                {
                    brakeConfig[0] = str[Tcfg.textIndex];
                    brakeConfig[1] = str[Tcfg.art];
                    brakeConfig[2] = str[Tcfg.schritte];
                    brakeConfig[3] = str[Tcfg.specials];
                    brakeConfig[4] = str[Tcfg.zeitumrechnung];
                    brakeConfig[5] = str[Tcfg.laengerDruecken];
                }
            }

        }

        public Joystick[] getSticks()
        {
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>();
            foreach (DeviceInstance device in input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
                    mainStick = new SlimDX.DirectInput.Joystick(input, device.InstanceGuid);
                    mainStick.Acquire();

                    foreach (DeviceObjectInstance deviceObject in mainStick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                        {
                            mainStick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
                        }
                    }

                    sticks.Add(mainStick);

                }
                catch (DirectInputException)
                {
                    throw;
                }

            }

            return sticks.ToArray();

        }

        void stickHandle(Joystick stick, int id)
        {
            bool[] buttons;
            int[] joyInputs = new int[8];

            JoystickState state = new JoystickState();
            state = stick.GetCurrentState();

            joyInputs[0] = state.X;
            joyInputs[1] = state.Y;
            joyInputs[2] = state.Z;
            joyInputs[3] = state.GetPointOfViewControllers()[0] + 1;
            joyInputs[4] = state.RotationX;
            joyInputs[5] = state.RotationY;
            joyInputs[6] = state.RotationZ;
            joyInputs[7] = state.GetSliders()[0];

            for (int i = 0; i < inputNames.Length; i++)
            {
                foreach (string[] strActiveTrain in activeTrain)
                {
                    if (strActiveTrain[Tcfg.joystickInput] == inputNames[i])
                    {
                        if (strActiveTrain[Tcfg.invert] == "1")
                        {
                            joyInputs[i] = joyInputs[i] * (-1);
                        }
                        if (strActiveTrain[Tcfg.inputTyp] == "1")
                        {
                            joyInputs[i] = (joyInputs[i] / (-2)) + 50;
                        }


                        if (strActiveTrain[Tcfg.inputUmrechnen].Length > 5)
                        {
                            string[] umrechnen = strActiveTrain[Tcfg.inputUmrechnen].Remove(strActiveTrain[Tcfg.inputUmrechnen].Length - 1).Replace("[", "").Split(']');

                            foreach (string single_umrechnen in umrechnen)
                            {
                                int index = single_umrechnen.IndexOf("=");
                                int gesuchteNummer = Convert.ToInt32(single_umrechnen.Remove(index, single_umrechnen.Length - index));
                                int entsprechendeNummer = Convert.ToInt32(single_umrechnen.Remove(0, index + 1));

                                if (joyInputs[i] == gesuchteNummer)
                                {
                                    joyInputs[i] = entsprechendeNummer;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            buttons = state.GetButtons();

            joystickStates.Add(new object[] { id, joyInputs, inputNames, buttons });
        }

        public int GetJoystickStateByName(string id, string input)
        {
            foreach (object[] obyJstk in joystickStates)
            {
                if ((int)obyJstk[0] == Convert.ToInt32(id))
                {
                    for (int i = 0; i < ((string[])obyJstk[2]).Length; i++)
                    {
                        if (((string[])obyJstk[2])[i] == input)
                        {
                            return ((int[])obyJstk[1])[i];
                        }
                    }
                }
            }
            return 0;
        }



        private void CheckSticks()
        {
            joystickStates.Clear();
            for (int i = 0; i < MainSticks.Length; i++)
            {
                stickHandle(MainSticks[i], i);
            }
            ShowJoystickData();

            if (check_active.Checked)
            {
                if (!bgw_Throttle.IsBusy && throttleConfig[0] != null)
                {
                    bgw_Throttle.RunWorkerAsync();
                }

                if (!bgw_Brake.IsBusy && !isKombihebel && brakeConfig[0] != null)
                {
                    bgw_Brake.RunWorkerAsync();
                }

                HandleButtons();
            }
            else
            {
                requestBrake = 0;
                requestThrottle = 0;
            }


            if (requestBrake > 0 || requestThrottle > 0)
            {
                if (!bgw_readScreen.IsBusy)
                {
                    bgw_readScreen.RunWorkerAsync();
                }
            }

            try
            {
                if (rawData.Count > 0)
                {
                    listBox_debugInfo.Items.AddRange(rawData.ToArray());
                }
                listBox_debugInfo.SelectedIndex = listBox_debugInfo.Items.Count - 1;
                rawData.Clear();
            }
            catch
            {

            }
        }

        private void bgw_Throttle_DoWork(object sender, DoWorkEventArgs e)
        {
            int currentThrottleJoystickState = 0;
            int tolerace = 100;

            for (int i = 0; i < activeTrain.Count; i++)
            {
                if (activeTrain[i].Contains("Schub"))
                {
                    if (throttleConfig[1] == "Stufen")
                    {
                        tolerace = 0;
                        currentThrottleJoystickState = GetJoystickStateByName(((string[])activeTrain[i])[Tcfg.joystickNummer], ((string[])activeTrain[i])[Tcfg.joystickInput]);
                        currentThrottleJoystickState = Convert.ToInt32(Math.Round(currentThrottleJoystickState * (Convert.ToDouble(throttleConfig[2]) / 100), 0));
                        break;
                    }
                    else if (throttleConfig[1] == "Stufenlos")
                    {
                        tolerace = 1;
                        currentThrottleJoystickState = GetJoystickStateByName(((string[])activeTrain[i])[Tcfg.joystickNummer], ((string[])activeTrain[i])[Tcfg.joystickInput]);
                        break;
                    }
                }
            }

            if (schubSoll != currentThrottleJoystickState || Math.Abs(schubSoll - schubIst) > tolerace)
            {
                if (currentThrottleJoystickState < 0 && !isKombihebel)
                {
                    currentThrottleJoystickState = 0;
                }
                requestThrottle = 5;

                schubSoll = currentThrottleJoystickState;
                ChangeGameState(true); ;

                cancelThrottleRequest = true;
            }

        }

        private void bgw_Brake_DoWork(object sender, DoWorkEventArgs e)
        {
            int currentBrakeJoystickState = 0;

            for (int i = 0; i < activeTrain.Count; i++)
            {
                if (activeTrain[i].Contains("Bremse"))
                {
                    if (brakeConfig[1] == "Stufen")
                    {
                        currentBrakeJoystickState = GetJoystickStateByName(((string[])activeTrain[i])[Tcfg.joystickNummer], ((string[])activeTrain[i])[Tcfg.joystickInput]);
                        currentBrakeJoystickState = Convert.ToInt32(Math.Round(currentBrakeJoystickState * (Convert.ToDouble(brakeConfig[2]) / 100), 0));
                        break;
                    }
                    else
                    {
                        currentBrakeJoystickState = GetJoystickStateByName(((string[])activeTrain[i])[Tcfg.joystickNummer], ((string[])activeTrain[i])[Tcfg.joystickInput]);
                        break;
                    }
                }

            }

            if (currentBrakeJoystickState < 0)
            {
                currentBrakeJoystickState = 0;
            }

            if (bremseSoll != currentBrakeJoystickState || (bremseSoll - bremseIst) != 0)
            {
                requestBrake = 5;

                bremseSoll = currentBrakeJoystickState;

                ChangeGameState(false);

                cancelBrakeRequest = true;

                bremseIst = bremseSoll;
            }
        }

        private void ChangeGameState(bool isThrottle)
        {
            //typ = 1 Stufenlos
            //typ = 2 Stufen
            //difference < 0 => schub zunehmen
            //difference > 0 => schub abnehmen

            if (isThrottle)
            {
                if (throttleConfig[1] == "Stufen")
                {
                    int diffSchub = schubIst - schubSoll;


                    for (int i = 0; i < Math.Abs(diffSchub); i++)
                    {
                        if (diffSchub > 0)
                        {
                            //weniger d
                            Keyboard.HoldKey(Keyboard.decreaseThrottle, Convert.ToInt32(throttleConfig[4]));
                            Thread.Sleep(80);
                        }
                        else if (diffSchub < 0)
                        {
                            //mehr a
                            Keyboard.HoldKey(Keyboard.increaseThrottle, Convert.ToInt32(throttleConfig[4]));
                            Thread.Sleep(80);
                        }
                    }
                    schubIst = schubSoll;
                }
                else if (throttleConfig[1] == "Stufenlos")
                {
                    int diffSchub = schubIst - schubSoll;

                    if (throttleConfig[5].Length > 0)
                    {
                        foreach (string single in throttleConfig[5].Remove(throttleConfig[5].Length - 1).Replace("[", "").Split(']'))
                        {
                            int index_minus = single.IndexOf("|");
                            int index_doppelpnkt = single.IndexOf(":");

                            int untere_grenze = Convert.ToInt32(single.Remove(index_minus, single.Length - index_minus));
                            int obere_grenze = Convert.ToInt32(single.Remove(0, index_minus + 1).Remove(single.Remove(0, index_minus + 1).IndexOf(":"), single.Remove(0, index_minus + 1).Length - single.Remove(0, index_minus + 1).IndexOf(":")));
                            int dauer = Convert.ToInt32(single.Remove(0, single.IndexOf(":") + 1));

                            if (schubIst <= untere_grenze && obere_grenze <= schubSoll)
                            {
                                rawData.Add("passe die Schubzunahme an");
                                diffSchub = schubIst - untere_grenze;
                                if (diffSchub >= -1)
                                {
                                    Keyboard.HoldKey(Keyboard.increaseThrottle, 200);
                                    Thread.Sleep(100);
                                    rawData.Add("Halte mehr gedrückt");
                                    schubIst = obere_grenze;
                                }
                            }
                            else if (schubSoll <= untere_grenze && obere_grenze <= schubIst)
                            {
                                diffSchub = schubIst - obere_grenze;
                                rawData.Add("passe die Schubabnahme an");
                                if (diffSchub <= 1)
                                {
                                    Keyboard.HoldKey(Keyboard.decreaseThrottle, 200);
                                    Thread.Sleep(100);
                                    rawData.Add("Halte weniger gedrückt");
                                    schubIst = untere_grenze;
                                }
                            }
                        }
                    }


                    if (diffSchub > 1)
                    {
                        //weniger d
                        Keyboard.HoldKey(Keyboard.decreaseThrottle, Convert.ToInt32(diffSchub * (1000.0 / Convert.ToDouble(throttleConfig[4]))));
                        Thread.Sleep(80);
                        schubIst = schubSoll;
                    }
                    else if (diffSchub < 1)
                    {
                        //mehr a
                        Keyboard.HoldKey(Keyboard.increaseThrottle, Convert.ToInt32(diffSchub * (-1) * (1000.0 / Convert.ToDouble(throttleConfig[4]))));
                        Thread.Sleep(80);
                        schubIst = schubSoll;
                    }
                }
            }
            else
            {
                if (brakeConfig[1] == "Stufen")
                {
                    int diffbrake = bremseIst - bremseSoll;


                    if (bremseSoll < 0 && false)
                    {
                        Keyboard.KeyDown(Keyboard.decreaseBrake);
                        heldDown = true;
                    }
                    else
                    {
                        if (heldDown)
                        {
                            Keyboard.KeyUp(Keyboard.decreaseBrake);
                        }

                        for (int i = 0; i < Math.Abs(diffbrake); i++)
                        {
                            if (diffbrake > 0)
                            {
                                //weniger ö
                                Keyboard.HoldKey(Keyboard.decreaseBrake, Convert.ToInt32(brakeConfig[4]));
                                Thread.Sleep(80);
                            }
                            else if (diffbrake < 0)
                            {
                                //mehr ä
                                Keyboard.HoldKey(Keyboard.increaseBrake, Convert.ToInt32(brakeConfig[4]));
                                Thread.Sleep(80);
                            }
                            Thread.Sleep(70);
                        }
                        bremseIst = bremseSoll;
                    }
                }
                else if (brakeConfig[1] == "Stufenlos")
                {
                    int diffBremse = bremseIst - bremseSoll;

                    if (brakeConfig[5].Length > 0)
                    {
                        foreach (string single in brakeConfig[5].Remove(brakeConfig[5].Length - 1).Replace("[", "").Split(']'))
                        {
                            int index_minus = single.IndexOf("|");
                            int index_doppelpnkt = single.IndexOf(":");

                            int untere_grenze = Convert.ToInt32(single.Remove(index_minus, single.Length - index_minus));
                            int obere_grenze = Convert.ToInt32(single.Remove(0, index_minus + 1).Remove(single.Remove(0, index_minus + 1).IndexOf(":"), single.Remove(0, index_minus + 1).Length - single.Remove(0, index_minus + 1).IndexOf(":")));
                            int dauer = Convert.ToInt32(single.Remove(0, single.IndexOf(":") + 1));

                            if (bremseIst <= untere_grenze && obere_grenze <= bremseSoll)
                            {
                                rawData.Add("passe die Schubzunahme an");
                                diffBremse = bremseIst - untere_grenze;
                                if (diffBremse >= -1)
                                {
                                    Keyboard.HoldKey(Keyboard.increaseBrake, 200);
                                    Thread.Sleep(100);
                                    rawData.Add("Halte mehr gedrückt");
                                    bremseIst = obere_grenze;
                                }
                            }
                            else if (bremseSoll <= untere_grenze && obere_grenze <= bremseIst)
                            {
                                diffBremse = bremseIst - obere_grenze;
                                rawData.Add("passe die Schubabnahme an");
                                if (diffBremse <= 1)
                                {
                                    Keyboard.HoldKey(Keyboard.decreaseBrake, 200);
                                    Thread.Sleep(100);
                                    rawData.Add("Halte weniger gedrückt");
                                    bremseIst = untere_grenze;
                                }
                            }
                        }
                    }


                    if (diffBremse > 1)
                    {
                        //weniger d
                        Keyboard.HoldKey(Keyboard.decreaseBrake, Convert.ToInt32(diffBremse * (1000.0 / Convert.ToDouble(brakeConfig[4]))));
                        Thread.Sleep(80);
                        schubIst = schubSoll;
                    }
                    else if (diffBremse < 1)
                    {
                        //mehr a
                        Keyboard.HoldKey(Keyboard.increaseBrake, Convert.ToInt32(diffBremse * (-1) * (1000.0 / Convert.ToDouble(brakeConfig[4]))));
                        Thread.Sleep(80);
                        schubIst = schubSoll;
                    }
                }
            }
        }

        public void HandleButtons()
        {
            for (int i = 0; i < activeTrain.Count; i++)
            {
                if (activeTrain[i][Tcfg.inputTyp] == "Button")
                {
                    int buttonNumber = Convert.ToInt32(activeTrain[i][Tcfg.joystickInput].Replace("B", ""));
                    currentlyPressedButtons[i] = ((bool[])((object[])joystickStates[Convert.ToInt32(activeTrain[i][Tcfg.joystickNummer])])[3])[buttonNumber];
                }
                else if (activeTrain[i][Tcfg.inputTyp].Contains("Button"))
                {
                    for (int o = 0; o < inputNames.Count(); o++)
                    {
                        if (activeTrain[i][Tcfg.joystickInput] == inputNames[o])
                        {
                            int joyButtonValue = GetJoystickStateByName(activeTrain[i][Tcfg.joystickNummer], inputNames[o]);
                            string[] convert = activeTrain[i][Tcfg.inputTyp].Replace("Button", "").Replace("[", "").Split(']');


                            currentlyPressedButtons[i] = false;
                            foreach (string single_convert in convert)
                            {
                                if (single_convert.Contains("="))
                                {
                                    if (joyButtonValue == Convert.ToInt32(single_convert.Remove(0, 1)))
                                    {
                                        currentlyPressedButtons[i] = true;
                                    }
                                    else
                                    {
                                        currentlyPressedButtons[i] = false;
                                        break;
                                    }
                                }
                                else if (single_convert.Contains(">"))
                                {
                                    if (joyButtonValue > Convert.ToInt32(single_convert.Remove(0, 1)))
                                    {
                                        currentlyPressedButtons[i] = true;
                                    }
                                    else
                                    {
                                        currentlyPressedButtons[i] = false;
                                        break;
                                    }
                                }
                                else if (single_convert.Contains("<"))
                                {
                                    if (joyButtonValue < Convert.ToInt32(single_convert.Remove(0, 1)))
                                    {
                                        currentlyPressedButtons[i] = true;
                                        break;
                                    }
                                    else
                                    {
                                        currentlyPressedButtons[i] = false;
                                        break;
                                    }
                                }

                            }
                        }
                    }
                }
            }


            for (int i = 0; i < currentlyPressedButtons.Count(); i++)
            {
                if (currentlyPressedButtons[i] != previouslyPressedButtons[i])
                {
                    if (currentlyPressedButtons[i] == true)
                    {
                        //on Press
                        Keyboard.ProcessAktion(activeTrain[i][Tcfg.aktion]);
                        Keyboard.KeyDown(Keyboard.ConvertStringToKey(activeTrain[i][Tcfg.buttonDown]));
                    }
                    else
                    {
                        //on release
                        Keyboard.KeyUp(Keyboard.ConvertStringToKey(activeTrain[i][Tcfg.buttonUp]));
                    }
                    previouslyPressedButtons[i] = currentlyPressedButtons[i];
                }
            }


        }

        private void ShowJoystickData()
        {
            lst_inputs.Items.Clear();
            int selectedJoystickIndex = Convert.ToInt32(comboBox_JoystickNumber.SelectedItem);

            //Wähle von allen Joysticks nur den ausgewählten aus
            if (selectedJoystickIndex < joystickStates.Count)
            {
                object[] selectedJoystick = (object[])joystickStates[Convert.ToInt32(selectedJoystickIndex)];
                for (int i = 0; i < ((bool[])selectedJoystick[3]).Length; i++)
                {
                    if (((bool[])selectedJoystick[3])[i])
                    {
                        //Zeige den gedrückten Button
                        lst_inputs.Items.Add("B" + i);
                    }
                }
                for (int i = 0; i < ((int[])selectedJoystick[1]).Length; i++)
                {
                    if (((int[])selectedJoystick[1])[i] != 0)
                    {
                        lst_inputs.Items.Add(((string[])selectedJoystick[2])[i] + "  " + ((int[])selectedJoystick[1])[i]);
                    }
                }
            }
        }


        private Bitmap Screenshot(bool normal)
        {
            int width = ConvertWidth(411);
            int height = ConvertHeight(30);
            int x1 = ConvertWidth(2022);
            int y1 = ConvertHeight(458);
            int y2 = ConvertHeight(530);

            Bitmap bmpScreenshot = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmpScreenshot);



            if (normal)
            {
                g.CopyFromScreen(x1, y1, 0, 0, new Size(width, height));
            }
            else
            {
                g.CopyFromScreen(x1, y2, 0, 0, new Size(width, height));
            }

            for (int y = 0; (y <= (bmpScreenshot.Height - 1)); y++)
            {
                for (int x = 0; (x <= (bmpScreenshot.Width - 1)); x++)
                {
                    Color inv = bmpScreenshot.GetPixel(x, y);
                    if (inv.R + inv.G + inv.B < 500)
                    {
                        inv = Color.FromArgb(0, 0, 0, 0);
                    }
                    inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    bmpScreenshot.SetPixel(x, y, inv);
                }
            }

            return bmpScreenshot;
        }

        public static string GetText(Bitmap imgsource)
        {
            var ocrtext = string.Empty;
            using (var engine = new TesseractEngine(@"./tessdata", "deu", EngineMode.Default))
            {
                using (var img = PixConverter.ToPix(imgsource))
                {
                    using (var page = engine.Process(img))
                    {
                        ocrtext = page.GetText();
                    }
                }
            }

            return ocrtext;
        }


        private void bgw_readScreen_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!isKombihebel)
            {
                string original_result = GetText(Screenshot(true));
                string alternative_result = "";
                string result = "";

                if (requestThrottle > 0 || requestBrake > 0)
                {
                    rawData.Add("reqThrot:" + requestThrottle + "   reqBrake:" + requestBrake);
                }
                if (original_result != "")
                {
                    rawData.Add("orig:" + original_result);
                }


                if (original_result == "")
                {
                    alternative_result = GetText(Screenshot(false));
                    rawData.Add("alt:" + alternative_result);
                }
                else if (throttleConfig[0] != null && brakeConfig[0] != null)
                {
                    if ((!original_result.Contains(throttleConfig[0]) && !original_result.Contains(brakeConfig[0])) || (requestBrake > 0 && requestThrottle > 0))
                    {
                        alternative_result = GetText(Screenshot(false));
                        rawData.Add("alt:" + alternative_result);
                    }
                }


                //Wenn nichts mehr gefunden wurde aber noch Werte gefordert wurden dann drücke die Taste kurz um den Text wieder zu zeigen
                if (requestBrake > 0 && !original_result.Contains(brakeConfig[0]) && !alternative_result.Contains(brakeConfig[0]))
                {
                    Keyboard.HoldKey(Keyboard.decreaseBrake, 1);
                }
                if (requestThrottle > 0 && !original_result.Contains(throttleConfig[0]) && !alternative_result.Contains(throttleConfig[0]))
                {
                    Keyboard.HoldKey(Keyboard.decreaseThrottle, 1);
                }

                if (throttleConfig[0] != null)
                {
                    if (original_result.Contains(throttleConfig[0]) || alternative_result.Contains(throttleConfig[0]))
                    {
                        #region Schub
                        if (original_result.Contains(throttleConfig[0]))
                        {
                            result = original_result;
                        }
                        else if (alternative_result.Contains(throttleConfig[0]))
                        {
                            result = alternative_result;
                        }
                        if (result.Contains(throttleConfig[0]))
                        {
                            int erkannterSchub = -99999;
                            result = result.Remove(0, result.IndexOf(throttleConfig[0]) + throttleConfig[0].Length).Replace("\n", "");
                            result = result.Remove(0, 1);
                            result = result.Replace("%", "");

                            if (throttleConfig[3].Length > 0)
                            {
                                foreach (string singleSpezial in throttleConfig[3].Remove(throttleConfig[3].Length - 1).Replace("[", "").Split(']'))
                                {
                                    int index = singleSpezial.IndexOf("=");
                                    string word = singleSpezial.Remove(index, singleSpezial.Length - index);
                                    int entsprechendeNummer = Convert.ToInt32(singleSpezial.Remove(0, index + 1));

                                    if (result == word && singleSpezial != "")
                                    {
                                        erkannterSchub = entsprechendeNummer;
                                        break;
                                    }
                                }
                            }

                            if (erkannterSchub == -99999)
                            {
                                try { erkannterSchub = Convert.ToInt32(result); } catch { }
                            }
                            if (erkannterSchub != -99999)
                            {
                                if (!cancelThrottleRequest)
                                {
                                    requestThrottle--;
                                    schubIst = erkannterSchub;
                                    rawData.Add("schub:" + erkannterSchub);
                                }
                                else
                                {
                                    cancelThrottleRequest = false;
                                }
                            }
                        }
                        #endregion
                    }
                }
                if (brakeConfig[0] != null)
                {
                    if (original_result.Contains(brakeConfig[0]) || alternative_result.Contains(brakeConfig[0]))
                    {
                        #region Bremse
                        if (original_result.Contains(brakeConfig[0]))
                        {
                            result = original_result;
                        }
                        else if (alternative_result.Contains(brakeConfig[0]))
                        {
                            result = alternative_result;
                        }
                        if (result.Contains(brakeConfig[0]))
                        {
                            int erkannteBremsleistung = -99999;
                            result = result.Remove(0, result.IndexOf(brakeConfig[0]) + brakeConfig[0].Length).Replace("\n", "");
                            result = result.Remove(0, 1);
                            result = result.Replace("%", "");

                            if (brakeConfig[3].Length > 0)
                            {
                                foreach (string singleSpezial in brakeConfig[3].Remove(brakeConfig[3].Length - 1).Replace("[", "").Split(']'))
                                {
                                    int index = singleSpezial.IndexOf("=");
                                    string word = singleSpezial.Remove(index, singleSpezial.Length - index);
                                    int entsprechendeNummer = Convert.ToInt32(singleSpezial.Remove(0, index + 1));

                                    if (result == word && singleSpezial != "")
                                    {
                                        erkannteBremsleistung = entsprechendeNummer;
                                        break;
                                    }
                                }
                            }

                            if (erkannteBremsleistung == -99999)
                            {
                                try { erkannteBremsleistung = Convert.ToInt32(result); } catch { }
                            }
                            if (erkannteBremsleistung != -99999)
                            {
                                if (!cancelBrakeRequest)
                                {
                                    requestBrake--;
                                    bremseIst = erkannteBremsleistung;
                                    rawData.Add("bremse:" + erkannteBremsleistung);
                                }
                                else
                                {
                                    cancelBrakeRequest = false;
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
            else
            {
                //isKombihebel
                readScreenkombihebel();
            }
        }

        private void readScreenkombihebel()
        {
            string original_result = GetText(Screenshot(true));
            string alternative_result = "";
            string result = "";

            if (requestThrottle > 0)
            {
                rawData.Add("reqThrot:" + requestThrottle);
            }
            if (original_result != "")
            {
                rawData.Add("orig:" + original_result);
            }


            if (!original_result.Contains(throttleConfig[0]))
            {
                alternative_result = GetText(Screenshot(false));
                rawData.Add("alt:" + alternative_result);
            }


            //Wenn nichts mehr gefunden wurde aber noch Werte gefordert wurden dann drücke die Taste kurz um den Text wieder zu zeigen
            if (requestThrottle > 0 && !original_result.Contains(throttleConfig[0]) && !alternative_result.Contains(throttleConfig[0]))
            {
                Keyboard.HoldKey(Keyboard.decreaseThrottle, 1);
            }


            if (original_result.Contains(throttleConfig[0]) || alternative_result.Contains(throttleConfig[0]))
            {
                if (original_result.Contains(throttleConfig[0]))
                {
                    result = original_result;
                }
                else if (alternative_result.Contains(throttleConfig[0]))
                {
                    result = alternative_result;
                }
                if (result.Contains(throttleConfig[0]) && result != "")
                {
                    try
                    {
                        int erkannterSchub = -99999;
                        int schubFaktor = 1;

                        result = result.Remove(0, result.IndexOf(throttleConfig[0]) + throttleConfig[0].Length).Replace("\n", "");
                        result = result.Remove(0, 1);
                        result = result.Replace("%", "");

                        if (result.Contains(kombihebel[1]))
                        {
                            schubFaktor = -1;
                        }
                        if (result.Contains(kombihebel[0]) || result.Contains(kombihebel[1]))
                        {
                            result = result.Replace(kombihebel[0], "").Replace(kombihebel[1], "");
                            result = result.Remove(result.Length - 1);
                        }

                        if (throttleConfig[3].Length > 0)
                        {
                            foreach (string singleSpezial in throttleConfig[3].Remove(throttleConfig[3].Length - 1).Replace("[", "").Split(']'))
                            {
                                int index = singleSpezial.IndexOf("=");
                                string word = singleSpezial.Remove(index, singleSpezial.Length - index);
                                int entsprechendeNummer = Convert.ToInt32(singleSpezial.Remove(0, index + 1));

                                if (result == word && singleSpezial != "")
                                {
                                    erkannterSchub = entsprechendeNummer;
                                    break;
                                }
                            }
                        }

                        if (erkannterSchub == -99999)
                        {
                            try { erkannterSchub = Convert.ToInt32(result); } catch { }
                        }
                        if (erkannterSchub != -99999)
                        {
                            if (!cancelThrottleRequest)
                            {
                                requestThrottle--;
                                schubIst = erkannterSchub * schubFaktor;
                                rawData.Add("schub:" + erkannterSchub);
                            }
                            else
                            {
                                cancelThrottleRequest = false;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void bgw_readScreen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbl_schub.Text = "Schub ist " + schubIst.ToString() + " und soll" + schubSoll.ToString();
            lbl_bremse.Text = "Bremse ist " + bremseIst.ToString() + " und soll " + bremseSoll.ToString();
        }



        private int ConvertHeight(int height)
        {
            return Convert.ToInt32(Math.Round((Convert.ToDouble(height) / 1440.0) * Convert.ToDouble(res.Height), 0));
        }

        private int ConvertWidth(int width)
        {
            return Convert.ToInt32(Math.Round((Convert.ToDouble(width) / 2560.0) * Convert.ToDouble(res.Width), 0));
        }


        private void timer_CheckSticks_Tick(object sender, EventArgs e)
        {
            CheckSticks();
        }

        private void comboBox_Zugauswahl_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_active.Checked = false;
            getActiveTrain();
        }

        private void btn_reloadConfig_Click(object sender, EventArgs e)
        {
            check_active.Checked = false;
            ReadTrainConfig();
            ReadTrainNamesFromTrainconfig();
        }

        private void bgw_readScreen_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void btn_einstellungen_Click(object sender, EventArgs e)
        {
            check_active.Checked = false;
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            loadSettings();
        }
    }
}
