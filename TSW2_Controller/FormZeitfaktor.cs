using Microsoft.VisualBasic;
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

namespace TSW2_Controller
{
    public partial class FormZeitfaktor : Form
    {
        public FormZeitfaktor()
        {
            InitializeComponent();
            radioChanged();
        }

        FormMain formMain = new FormMain();

        int counter;
        int startNumber;

        private void txt_Startwert_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txt_Startwert_TextChanged(object sender, EventArgs e)
        {
            try { if (Convert.ToInt32(txt_Startwert.Text) > 100) { txt_Startwert.Text = txt_Startwert.Text.Remove(txt_Startwert.Text.Length - 1); } } catch { }
        }

        private void SetUI(bool enabled)
        {
            if (enabled)
            {
                btn_start.Enabled = true;
                txt_Startwert.Enabled = true;
                radio_Bremse.Enabled = true;
                radio_Schub.Enabled = true;
                radio_Stufen.Enabled = true;
                radio_Stufenlos.Enabled = true;
                btn_start.Text = "Start";
            }
            else
            {
                btn_start.Enabled = false;
                txt_Startwert.Enabled = false;
                radio_Bremse.Enabled = false;
                radio_Schub.Enabled = false;
                radio_Stufen.Enabled = false;
                radio_Stufenlos.Enabled = false;
                radio_kombihebel.Enabled = false;
            }
        }

        private int GetNumber()
        {
            string result = FormMain.GetText(formMain.Screenshot(true));
            int index = result.IndexOf("%");
            result = result.Remove(index, result.Length - index);
            result = result.Remove(0, result.IndexOfAny("0123456789".ToArray()));

            return Convert.ToInt32(result);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            counter = 7;
            if (!radio_Stufenlos.Checked)
            {
                SetUI(false);
                btn_start.Text = counter.ToString();
                timer1.Start();
            }
            else
            {
                try
                {
                    if (txt_Startwert.Text != "")
                    {
                        startNumber = Convert.ToInt32(txt_Startwert.Text);
                        if (startNumber <= 60)
                        {
                            SetUI(false);

                            btn_start.Text = counter.ToString();
                            timer1.Start();
                        }
                        else
                        {
                            MessageBox.Show("Du solltest lieber einen kleineren Wert nehmen.\nVersuch es doch mal mit 10%");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Du hast noch keinen Startwert eingetragen!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                counter--;
                btn_start.Text = counter.ToString();
            }
            else
            {
                //Start
                timer1.Stop();
                if (radio_kombihebel.Checked)
                {
                    RunKombihebel();
                }
                else
                {
                    RunNormal();
                }
            }
        }


        private void RunNormal()
        {
            int delay = 1000;
            Keys taste_mehr;
            Keys taste_weniger;
            int endNumber = 0;

            if (radio_Schub.Checked)
            {
                taste_mehr = Keyboard.increaseThrottle;
                taste_weniger = Keyboard.decreaseThrottle;
            }
            else
            {
                taste_mehr = Keyboard.increaseBrake;
                taste_weniger = Keyboard.decreaseBrake;
            }

            bool wait = true;
            if (radio_Stufenlos.Checked)
            {
                while (wait)
                {
                    Keyboard.HoldKey(taste_mehr, delay);
                    Thread.Sleep(1000);
                    string result = FormMain.GetText(formMain.Screenshot(true));

                    if (result.Contains("%") && "0123456789".ToArray().Any(result.Contains))
                    {
                        int index = result.IndexOf("%");
                        result = result.Remove(index, result.Length - index);
                        result = result.Remove(0, result.IndexOfAny("0123456789".ToArray()));

                        try
                        {
                            endNumber = Convert.ToInt32(result);
                            wait = false;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                    }
                    else
                    {
                        Keyboard.HoldKey(taste_mehr, 1000);

                        Keyboard.HoldKey(Keys.Escape, 300);
                        this.Focus();
                        Interaction.Beep();
                        DialogResult dialog = MessageBox.Show("Keine Nummer Erkannt. Kann es sein, dass du beim Maximum gelandet bist?", "Fehler", MessageBoxButtons.YesNo);

                        if (dialog == DialogResult.Yes)
                        {
                            MessageBox.Show("OK dann Stelle den Regler nochmal auf " + startNumber + "%" + " und bestätige mit OK");
                            MessageBox.Show("Drücke nochmal auf OK, wechsle innerhalb von 7 Sekunden zum TSW und warte");
                            Thread.Sleep(7000);
                            delay = 800;
                            //Versuche es nochmal
                        }
                        else if (dialog == DialogResult.No)
                        {
                            while (true)
                            {
                                try
                                {
                                    string userinput = Interaction.InputBox("Auf welcher Zahl bist du gelandet?");
                                    endNumber = Convert.ToInt32(userinput);
                                    wait = false;
                                    break;
                                }
                                catch { }
                            }
                        }
                    }
                }

                if (endNumber - startNumber > 0)
                {
                    Keyboard.HoldKey(Keys.Escape, 300);
                    this.Focus();
                    Interaction.Beep();
                    MessageBox.Show("Fertig!\nAls Wert für die Zeitumrechnungkannst du nun " + Math.Round(Convert.ToDouble(endNumber - startNumber) * (1000.0 / delay), 0) + " eintragen");
                }
                else if (endNumber != -1)
                {
                    this.Focus();
                    Interaction.Beep();
                    MessageBox.Show("Hmm da hast du wohl etwas falsch gemacht. Die Startzahl sollte größer als die Endzahl sein.");
                }
            }
            else
            {
                Keyboard.HoldKey(taste_mehr, 0);
                Thread.Sleep(500);
                string grundstellung = FormMain.GetText(formMain.Screenshot(true));
                Thread.Sleep(500);

                int nextStep_Value = 0;
                int overskip_Value = 0;

                for (int i = 0; i < 2000; i += 5)
                {
                    Keyboard.HoldKey(taste_mehr, i);
                    Thread.Sleep(80);
                    if (FormMain.GetText(formMain.Screenshot(true)) != grundstellung)
                    {
                        nextStep_Value = i;
                        break;
                    }
                    Thread.Sleep(100);
                }
                if (nextStep_Value != 0)
                {
                    Thread.Sleep(1000);
                    for (int i = 30; i < 2000; i += 5)
                    {
                        Keyboard.HoldKey(taste_weniger, nextStep_Value + i);
                        Thread.Sleep(500);
                        if (FormMain.GetText(formMain.Screenshot(true)) != grundstellung)
                        {
                            overskip_Value = nextStep_Value + i;
                            break;
                        }
                        Keyboard.HoldKey(taste_mehr, nextStep_Value + 30);
                        Thread.Sleep(500);
                    }
                }
                if (overskip_Value != 0)
                {
                    Keyboard.HoldKey(Keys.Escape, 300);
                    this.Focus();
                    Interaction.Beep();
                    MessageBox.Show("Fertig!\nAls Wert für die Zeitumrechnungkannst du nun " + Math.Round((Convert.ToDouble(overskip_Value - nextStep_Value) / 2) + nextStep_Value, 0) + " eintragen");
                }
                else
                {
                    Keyboard.HoldKey(Keys.Escape, 300);
                    this.Focus();
                    Interaction.Beep();
                    MessageBox.Show("Hmm da hat etwas nicht funktioniert. Versuche es doch nochmal.");
                }
            }

            SetUI(true);
        }

        private void RunKombihebel()
        {
            int ersterZeitwert = 0;
            int zweiterZeitwert = 0;

            Keyboard.HoldKey(Keyboard.increaseThrottle, 0);
            Thread.Sleep(500);
            try
            {
                int startWert = 0;
                int endWert = 0;

                startWert = GetNumber();
                Keyboard.HoldKey(Keyboard.increaseThrottle, 1000);
                Thread.Sleep(500);
                endWert = GetNumber();
                ersterZeitwert = endWert - startWert;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            Keyboard.HoldKey(Keys.Escape, 300);
            this.Focus();
            Interaction.Beep();
            MessageBox.Show("Stelle den Regler nun auf den bremswert");
            MessageBox.Show("Drücke nochmal auf OK, wechsle innerhalb von 7 Sekunden zum TSW und warte");
            Thread.Sleep(7000);

            Keyboard.HoldKey(Keyboard.decreaseThrottle, 0);
            Thread.Sleep(500);
            try
            {
                int startWert = 0;
                int endWert = 0;

                startWert = GetNumber();
                Keyboard.HoldKey(Keyboard.decreaseThrottle, 1000);
                Thread.Sleep(500);
                endWert = GetNumber();
                zweiterZeitwert = endWert - startWert;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            Keyboard.HoldKey(Keys.Escape, 300);
            this.Focus();
            Interaction.Beep();
            MessageBox.Show("Fertig!\nDu kannst nun bei der Zeitumrechnung " + ersterZeitwert + "|" + zweiterZeitwert + " eintragen.");
        }


        private void radioChanged()
        {
            SetUI(true);
            if (radio_Stufenlos.Checked)
            {
                lbl_anleitung.Text = "- Stufenlosen Regler auf kleinen Wert stellen, vondem man mit konstanter Geschwindigkeit bis aufs Maximum kommen kann.\n\n- In das Textfeld den entsprechenden Prozentwert eintragen. (z.B. wenn Min. = 5% entspricht)\n\n- Start drücken und innerhalb von 7 Sekunden auf den TSW2 wechseln.\n\n- Auf Pause-Bildschirm warten.\n";
            }

            if (radio_Stufen.Checked)
            {
                lbl_anleitung.Text = "- Stufenregler auf Mittelwert stellen (die Stufe drüber und drunter sollten mit normaler Tastendrucklänge zu erreichen sein)\n\n- Start drücken und innerhalb von 7 Sekunden auf den TSW2 wechseln.\n\n- Auf Pause-Bildschirm warten.\n";
                txt_Startwert.Text = "";
                txt_Startwert.Enabled = false;
            }

            if (radio_kombihebel.Checked)
            {
                lbl_anleitung.Text = "- Kombihebel im Schubbereich auf kleinen, in % angezeigten Wert stellen. (z.B. 10%,13%,18%)\n\n- Start drücken und innerhalb von 7 Sekunden zum TSW2 wechseln.\n\n- Auf Pause-Bildschirm warten.\n\n- Kombihebel im Bremsbereich auf kleinstmöglichen, in % angezeigten Wert stellen. (z.B. 10%,13%,18%)\n\n- OK drücken\n\n- Auf Pause-Bildschirm warten";
                radio_Schub.Checked = true;
                radio_Bremse.Enabled = false;
                txt_Startwert.Text = "";
                txt_Startwert.Enabled = false;
            }
        }

        private void radio_kombihebel_CheckedChanged(object sender, EventArgs e)
        {
            radioChanged();
        }

        private void radio_Stufen_CheckedChanged(object sender, EventArgs e)
        {
            radioChanged();
        }

        private void radio_Stufenlos_CheckedChanged(object sender, EventArgs e)
        {
            radioChanged();
        }
    }
}
