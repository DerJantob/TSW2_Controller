using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSW2_Controller
{
    public partial class FormZeitfaktor2 : Form
    {
        int anleitungsschritt = 1;
        int fertig = 100;
        int timervalue = 7;
        int firstTimefactor = 0;
        string controller = "";
        bool istStufenlos = false;
        bool istKombihebel = false;

        public string resultString = "";

        VirtualController virtualController = new VirtualController();

        public FormZeitfaktor2(string selectedController, bool isContinuouslyVariable)
        {
            InitializeComponent();

            lbl_ERROR.Text = "";

            controller = selectedController;
            istStufenlos = isContinuouslyVariable;

            if (File.Exists(Tcfg.controllersConfigPfad))
            {
                using (var reader = new StreamReader(Tcfg.controllersConfigPfad))
                {
                    int counter = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        string[] values = line.Split(',');
                        if (counter > 0)
                        {
                            //Skip first line
                            VirtualController vc = new VirtualController();
                            vc.InsertFileArray(values);
                            if (vc.name == controller)
                            {
                                virtualController = vc;
                                istKombihebel = vc.isMasterController;
                            }
                        }
                        counter++;
                    }
                }
            }

            if (virtualController.name != null)
            {
                Anleitung();
            }
            else
            {
                Sprache.ShowMessageBox("ERROR " + controller + " nicht gefunden!", "ERROR " + controller + " not found!");
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void Anleitung()
        {
            List<string> anleitungstext = new List<string>();

            if (anleitungsschritt == 1)
            {
                if (!istKombihebel)
                {
                    if (istStufenlos)
                    {
                        anleitungstext.Add("Anleitung:");
                        anleitungstext.Add("Stelle den stufenlosen Regler auf einen kleinen, in % angezeigten Wert.");
                        anleitungstext.Add("Überprüfe, ob man von diesem Wert aus, bis auf das Maximum kommen kann, ohne, dass der Regler ins stocken kommt.");

                        anleitungsschritt = fertig;
                    }
                    else
                    {
                        anleitungstext.Add("Anleitung:");
                        anleitungstext.Add("Stelle den Stufenregler auf eine, in der Mitte liegenden, Position.");
                        anleitungstext.Add("Es wird gleich die Position vor und hinter dieser Position getestet.");

                        anleitungsschritt = fertig;
                    }
                }
                else
                {
                    anleitungstext.Add("Anleitung:");
                    anleitungstext.Add("Stelle den Kombihebel auf einen kleinen, im Schubbereich liegenden, in % angezeigten Wert.");
                    anleitungstext.Add("Überprüfe, ob man von diesem Wert aus, bis auf das Maximum kommen kann, ohne, dass der Regler ins stocken kommt.");
                    anleitungsschritt = fertig;
                }
            }
            else if (anleitungsschritt == 2)
            {
                if (istKombihebel)
                {
                    anleitungstext.Add("Stelle den Kombihebel nun auf einen kleinen, im Bremsbereich liegenden, in % angezeigten Wert.");
                    anleitungstext.Add("Überprüfe, ob man von diesem Wert aus, bis auf die maximale Bremskraft kommen kann, ohne, dass der Regler ins stocken kommt.");
                    anleitungsschritt = fertig;
                }
            }
            else if (anleitungsschritt >= 100)
            {
                anleitungstext.Add("Klicke nun auf \"Start\" und wechsle innerhalt von 7 Sekunden zum Simulator.");
                anleitungstext.Add("Drücke dann keine Taste mehr und bewege auch nicht mehr die Kamera, bis sich der Regler 5 Sekunden lang nicht mehr bewegt.");
                btn_weiter.Hide();
                btn_start.Show();
            }

            anleitungsschritt++;
            lbl_anleitung.Text = string.Join("\n", anleitungstext);
        }

        private void btn_weiter_Click(object sender, EventArgs e)
        {
            Anleitung();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            lbl_ERROR.Text = "";
            timer1.Start();
            btn_start.Enabled = false;
            btn_start.Text = "7";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btn_start.Text = timervalue.ToString();
            timervalue--;
            if (timervalue < 0)
            {
                timer1.Stop();
                if (istKombihebel)
                {
                    if (firstTimefactor == 0)
                    {
                        Kombihebel(1);
                    }
                    else
                    {
                        Kombihebel(2);
                    }
                }
                else
                {
                    if (istStufenlos)
                    {
                        Stufenlos();
                    }
                    else
                    {
                        Stufen();
                    }
                }
            }
        }
        string GetBestMainIndicator(string result, VirtualController virtualController)
        {
            VirtualController vc = virtualController;
            double bestMatchDistance = 0;
            string bestMatchWord = "";

            //Gehe alle Indikatoren durch
            foreach (string indicator in vc.mainIndicators)
            {
                if (FormMain.ContainsWord(result, indicator))
                {
                    //Indikator 1 zu 1 gefunden
                    bestMatchWord = indicator;
                    break;
                }
                else
                {
                    //Wenn kein Indikator 1 zu 1 gefunden wurde, versuche etwas zu finden, was ähnlich ist

                    int indicatorWordCount = indicator.Split(' ').Count();
                    string[] splitResult = result.Split(' ');

                    for (int j = 0; j < splitResult.Length - indicatorWordCount; j++)
                    {
                        string str = "";
                        for (int o = 0; o < indicatorWordCount; o++)
                        {
                            str += splitResult[o + j] + " ";
                        }
                        str = str.Trim();

                        double distance = FormMain.GetDamerauLevenshteinDistanceInPercent(str, indicator, 3);
                        if (distance > bestMatchDistance && distance >= 0.8)
                        {
                            bestMatchDistance = distance;
                            bestMatchWord = str;
                        }
                    }
                }
            }

            if (bestMatchWord != "")
            {
                return bestMatchWord;
            }
            else
            {
                return "";
            }
        }

        int convertTextToNumber(string input)
        {
            int indexOfPercent = input.IndexOf("%");
            string result_withoutPercent = "";
            int number = -99999;

            if (indexOfPercent != -1)
            {
                result_withoutPercent = input.Remove(indexOfPercent, input.Length - indexOfPercent);
            }
            try
            {
                number = Convert.ToInt32(result_withoutPercent);
            }
            catch
            {
                Log.Error("Could not get a number out of (removing percent method) " + result_withoutPercent);
                try
                {
                    //Isoliere die letzte Zahl
                    number = Convert.ToInt32(Regex.Matches(input, @"\d+")[Regex.Matches(input, @"\d+").Count - 1].Value);
                }
                catch (Exception ex)
                {
                    Log.Error("Could not get a number out of (isolating method)" + input);
                    Log.ErrorException(ex);
                }
            }

            return number;
        }

        private void Stufenlos()
        {
            FormMain formMain = new FormMain();

            Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.increaseKey), 0);
            Thread.Sleep(500);

            string startText = null;
            int startNumber = -99999;
            string endText = null;
            int endNumber = -99999;
            string indicator = null;

            while (startText != "" && startNumber == -99999)
            {
                startText = FormMain.GetText(formMain.Screenshot(true));
                indicator = GetBestMainIndicator(startText, virtualController);
                if (indicator != "")
                {
                    startText = startText.Remove(0, startText.IndexOf(indicator) + indicator.Length).Trim();
                    startNumber = convertTextToNumber(startText);
                }
            }
            if (startNumber != -99999)
            {
                Thread.Sleep(100);
                Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.increaseKey), 1000);
                Thread.Sleep(100);

                while (endText != "" && endNumber == -99999)
                {
                    endText = FormMain.GetText(formMain.Screenshot(true));
                    if (endText.Contains(indicator))
                    {
                        endText = endText.Remove(0, endText.IndexOf(indicator) + indicator.Length).Trim();
                    }
                    endNumber = convertTextToNumber(endText);
                }
                if (endNumber == -99999)
                {
                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.decreaseKey), 500);
                    Thread.Sleep(100);
                    startNumber = -99999;
                    endNumber = 200;
                    while (startText != "" && startNumber == -99999)
                    {
                        startText = FormMain.GetText(formMain.Screenshot(true));
                        if (startText.Contains(indicator))
                        {
                            startText = startText.Remove(0, startText.IndexOf(indicator) + indicator.Length).Trim();
                        }
                        startNumber = convertTextToNumber(startText);
                    }
                    if (startNumber != -99999 && endNumber != -99999)
                    {
                        startNumber = startNumber * 2;
                    }
                }
            }

            if (startNumber != -99999 && endNumber != -99999)
            {
                int diff = endNumber - startNumber;
                resultString = Convert.ToString(diff);
                Close();
            }
            else
            {
                lbl_ERROR.Text = "Konnte keine Zahl lesen!";
                btn_start.Text = "Start";
                btn_start.Enabled = true;
                timervalue = 7;
            }
        }

        private void Kombihebel(int schritt)
        {
            if (schritt == 1)
            {
                FormMain formMain = new FormMain();

                Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.increaseKey), 0);
                Thread.Sleep(500);

                string startText = null;
                int startNumber = -99999;
                string endText = null;
                int endNumber = -99999;
                string indicator = null;
                firstTimefactor = 0;

                while (startText != "" && startNumber == -99999)
                {
                    startText = FormMain.GetText(formMain.Screenshot(true));
                    indicator = GetBestMainIndicator(startText, virtualController);
                    if (indicator != "")
                    {
                        startText = startText.Remove(0, startText.IndexOf(indicator) + indicator.Length).Trim();
                        startNumber = convertTextToNumber(startText);
                    }
                }
                if (startNumber != -99999)
                {
                    Thread.Sleep(100);
                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.increaseKey), 1000);
                    Thread.Sleep(100);

                    while (endText != "" && endNumber == -99999)
                    {
                        endText = FormMain.GetText(formMain.Screenshot(true));
                        if (endText.Contains(indicator))
                        {
                            endText = endText.Remove(0, endText.IndexOf(indicator) + indicator.Length).Trim();
                        }
                        endNumber = convertTextToNumber(endText);
                    }
                    if (endNumber == -99999)
                    {
                        Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.decreaseKey), 500);
                        Thread.Sleep(100);
                        startNumber = -99999;
                        endNumber = 200;
                        while (startText != "" && startNumber == -99999)
                        {
                            startText = FormMain.GetText(formMain.Screenshot(true));
                            if (startText.Contains(indicator))
                            {
                                startText = startText.Remove(0, startText.IndexOf(indicator) + indicator.Length).Trim();
                            }
                            startNumber = convertTextToNumber(startText);
                        }
                        if (startNumber != -99999 && endNumber != -99999)
                        {
                            startNumber = startNumber * 2;
                        }
                    }
                }

                if (startNumber != -99999 && endNumber != -99999)
                {
                    int diff = endNumber - startNumber;
                    firstTimefactor = diff;

                    anleitungsschritt = 2;
                    btn_start.Hide();
                    btn_weiter.Show();
                    btn_start.Text = "Start";
                    btn_start.Enabled = true;
                    timervalue = 7;
                    Anleitung();
                }
                else
                {
                    lbl_ERROR.Text = "Konnte keine Zahl lesen!";
                    btn_start.Text = "Start";
                    btn_start.Enabled = true;
                    timervalue = 7;
                }
            }
            else if (schritt == 2)
            {
                FormMain formMain = new FormMain();

                Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.decreaseKey), 0);
                Thread.Sleep(500);

                string startText = null;
                int startNumber = -99999;
                string endText = null;
                int endNumber = -99999;
                string indicator = null;

                while (startText != "" && startNumber == -99999)
                {
                    startText = FormMain.GetText(formMain.Screenshot(true));
                    indicator = GetBestMainIndicator(startText, virtualController);
                    if (indicator != "")
                    {
                        startText = startText.Remove(0, startText.IndexOf(indicator) + indicator.Length).Trim();
                        startNumber = convertTextToNumber(startText);
                    }
                }
                if (startNumber != -99999)
                {
                    Thread.Sleep(100);
                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.decreaseKey), 1000);
                    Thread.Sleep(100);

                    while (endText != "" && endNumber == -99999)
                    {
                        endText = FormMain.GetText(formMain.Screenshot(true));
                        if (endText.Contains(indicator))
                        {
                            endText = endText.Remove(0, endText.IndexOf(indicator) + indicator.Length).Trim();
                        }
                        endNumber = convertTextToNumber(endText);
                    }
                    if (endNumber == -99999)
                    {
                        Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.increaseKey), 500);
                        Thread.Sleep(100);
                        startNumber = -99999;
                        endNumber = 200;
                        while (startText != "" && startNumber == -99999)
                        {
                            startText = FormMain.GetText(formMain.Screenshot(true));
                            if (startText.Contains(indicator))
                            {
                                startText = startText.Remove(0, startText.IndexOf(indicator) + indicator.Length).Trim();
                            }
                            startNumber = convertTextToNumber(startText);
                        }
                        if (startNumber != -99999 && endNumber != -99999)
                        {
                            startNumber = startNumber * 2;
                        }
                    }
                }

                if (startNumber != -99999 && endNumber != -99999)
                {
                    int diff = endNumber - startNumber;
                    resultString = Convert.ToString(firstTimefactor + "|" + diff);
                    Close();
                }
                else
                {
                    lbl_ERROR.Text = "Konnte keine Zahl lesen!";
                    btn_start.Text = "Start";
                    btn_start.Enabled = true;
                    timervalue = 7;
                }
            }
        }

        private void Stufen()
        {
            FormMain formMain = new FormMain();

            Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.increaseKey), 0);
            Thread.Sleep(500);

            string startText = null;
            string indicator = "";

            Regex rgx = new Regex("[^a-zA-Z0-9 -]");

            int nextStep_Value = 0;
            int overskip_Value = 0;

            while (startText != "" && indicator == "")
            {
                startText = FormMain.GetText(formMain.Screenshot(true));
                indicator = GetBestMainIndicator(startText, virtualController);
                if (indicator != "")
                {
                    startText = startText.Remove(0, startText.IndexOf(indicator) + indicator.Length).Trim();
                    startText = rgx.Replace(startText, "");
                }
            }

            bool success = false;
            if (indicator != "")
            {
                for (int i = 5; i < 1000; i += 5)
                {
                    Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.increaseKey), i);
                    Thread.Sleep(80);
                    string currentReading = FormMain.GetText(formMain.Screenshot(true));
                    indicator = GetBestMainIndicator(currentReading, virtualController);
                    if (indicator != "")
                    {
                        currentReading = currentReading.Remove(0, currentReading.IndexOf(indicator) + indicator.Length).Trim();
                        currentReading = rgx.Replace(currentReading, "");
                    }
                    if (currentReading != startText)
                    {
                        success = true;
                        nextStep_Value = i;
                        break;
                    }
                }
                if (success)
                {
                    success = false;
                    Thread.Sleep(500);
                    for (int i = 30; i < 2000; i += 5)
                    {
                        Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.decreaseKey), nextStep_Value + i);
                        Thread.Sleep(80);
                        string currentReading = FormMain.GetText(formMain.Screenshot(true));
                        indicator = GetBestMainIndicator(currentReading, virtualController);
                        if (indicator != "")
                        {
                            currentReading = currentReading.Remove(0, currentReading.IndexOf(indicator) + indicator.Length).Trim();
                            currentReading = rgx.Replace(currentReading, "");
                        }
                        if (currentReading != startText)
                        {
                            success = true;
                            overskip_Value = nextStep_Value + i;
                            break;
                        }
                        else
                        {
                            Keyboard.HoldKey(Keyboard.ConvertStringToKey(virtualController.increaseKey), nextStep_Value + 30);
                            Thread.Sleep(80);
                        }
                    }
                }
                if (success)
                {
                    resultString = Convert.ToString(Math.Round((Convert.ToDouble(overskip_Value - nextStep_Value) / 2) + nextStep_Value, 0));
                    Close();
                }
                else
                {
                    lbl_ERROR.Text = "Fehler!";
                }
            }
            else
            {
                lbl_ERROR.Text = "Textindikator nicht gefunden!";
            }
        }

    }
}
