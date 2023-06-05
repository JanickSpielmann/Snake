using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Drawing.Image;

/* M404_Snake_Spielmann_J
 * 
 * INFW2022a
 * Spielmann Janick
 * 09.01.2023
 * 
 * © Spielmann Janick ©
*/


namespace M404_Snake_Spielmann_J
{
    public partial class frmSnake : Form
    {
        public Random Rnd = new Random();
        public List<PictureBox> Aepfel = new List<PictureBox>();
        public List<PictureBox> SchlangeTeile = new List<PictureBox>();
        public int Punkte;
        public int Countdown;
        public int Wachsen;
        public String Richtung;
        public int Skarliergroesse = 25;
        
        public frmSnake()
        {
            InitializeComponent();
            Reset();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrSpiel.Start();
            tmrCountdown.Start();
            btnStart.Enabled = false;
            btnEintragen.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BeendeSpielrunde(false);
            Reset();
            btnStart.Enabled = true;
        }
        private void btnEintragen_Click(object sender, EventArgs e)
        {
            btnEintragen.Enabled = false;
            lblListMitPunkte.Text += Convert.ToString(Punkte) + "\n";
            lblInfo.Text = "Ihren Punktestand von " + Punkte + " Punkte wurde erfolgreich in der Punkteliste eingetragen!";
        }
        /*
         * Es wird alles zurückgesetzt und ein neues Spielfeld wird generiert.
         * Alle Äpfel und Schlangenteile werden ausgeblendet und danach die ganze Liste der Apfel mit .Clear() gelehrt.
         * Alle Variabeln werden auf den vordefinierten wert gesetzt.
         * Ein neues Spielfeld wird generiert.
         */
        public void Reset()
        {
            foreach (PictureBox picApfel in Aepfel)
            {
                picApfel.Dispose();
            }
            Aepfel.Clear();
            foreach (PictureBox picSchlange in SchlangeTeile)
            {
                picSchlange.Dispose();
            }
            SchlangeTeile.Clear();
            Wachsen = 0;
            Punkte = 0;
            Countdown = 20;
            Richtung = "Right";
            txtPunkte.Text = Punkte.ToString();
            txtCountdown.Text = Countdown.ToString();
            tmrSpiel.Interval = 100;
            lblInfo.Text = "Sammle innerhalb von " + Countdown + " Sekunden die meisten Punkte!";
            SetSpielfeld();

        }
        /* Pro sekunde wird der Countdown um 1 subtrahiert
         * und im Countdown Textfeld ausgegeben
         * Erreicht der Countdown 0 wird das Spiel mit Sieg = false beendet
         */
        private void tmrCountdown_Tick(object sender, EventArgs e)
        {
            Countdown--;
            if (Countdown == 0)
            {
                BeendeSpielrunde(false);
            }
            txtCountdown.Text = Convert.ToString(Countdown);
        }

        /*
         * Ein neues Spielfeld besteht aus Äpfel und dem Schlangenkopf
         */
        public void SetSpielfeld()
        {
            ErstelleApfel();
            ErstelleSchlangenkopf();
        }

        /*
         * Es werden 10 neue Apfel erstellt und der Aepfel Liste hinzugefügt
         * Sie erhalten mit der Methode SetzeApfelwert() einen zufälligen wert zwischen 2 und 10
         */
        public void ErstelleApfel()
        {

            for (int i = 0; i < 10; i++)
            {
                PictureBox picApfel = new PictureBox();

                SetzeApfelwert(picApfel);
                Aepfel.Add(picApfel);
                picApfel.Size = new Size(Skarliergroesse, Skarliergroesse);
                picApfel.BackColor = Color.Transparent;
                pnlSpielfeld.Controls.Add(picApfel);
                picApfel.Location = new Point(Rnd.Next(0, (pnlSpielfeld.Width - picApfel.Width)), Rnd.Next(0, (pnlSpielfeld.Height - picApfel.Height)));
                picApfel.BringToFront();
            }
        }
        /* Jedem Apfel wird ein zufälliger Wert zwischen 2 und 10 und das entsprechende Bild gegeben
         * In dem das Image zu einer Bitmap konvertiert wird kann diese danach mit Size() in die grösse des objekts skaliert werden.
         * Dieser Teil mit dem Bitmaping musste ich im Internet nachschlagen: 
         * https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=windowsdesktop-7.0
         * Ich wusste wie es funktionieren sollte aber nicht wie ich es genau implementieren muss.
         */
        public void SetzeApfelwert(PictureBox picApfel)
        {

            int wert = Rnd.Next(2, 11);

            Bitmap apfelImage = new Bitmap(Properties.Resources.Apfel);

            switch (wert)
            {
                case 2:
                    apfelImage = new Bitmap(Properties.Resources.Apfel2);
                    break;
                case 3:
                    apfelImage = new Bitmap(Properties.Resources.Apfel3);
                    break;
                case 4:
                    apfelImage = new Bitmap(Properties.Resources.Apfel4);
                    break;
                case 5:
                    apfelImage = new Bitmap(Properties.Resources.Apfel5);
                    break;
                case 6:
                    apfelImage = new Bitmap(Properties.Resources.Apfel6);
                    break;
                case 7:
                    apfelImage = new Bitmap(Properties.Resources.Apfel7);
                    break;
                case 8:
                    apfelImage = new Bitmap(Properties.Resources.Apfel8);
                    break;
                case 9:
                    apfelImage = new Bitmap(Properties.Resources.Apfel9);
                    break;
                case 10:
                    apfelImage = new Bitmap(Properties.Resources.Apfel10);
                    break;
            }
            picApfel.Image = new Bitmap(apfelImage, new Size(Skarliergroesse, Skarliergroesse));
            picApfel.Tag = wert;
        }
        /* Wir erstellen eine Picturebox mit dem Kopf der Schlange genau in der Mitte des Spielfeldes
         */
        public void ErstelleSchlangenkopf()
        {
            PictureBox picSchlange = new PictureBox();

            SchlangeTeile.Insert(0, picSchlange);
            picSchlange.Size = new Size(Skarliergroesse, Skarliergroesse);
            picSchlange.Image = new Bitmap(new Bitmap(Properties.Resources.SchlangenKopfRechts), new Size(Skarliergroesse, Skarliergroesse));
            pnlSpielfeld.Controls.Add(picSchlange);
            picSchlange.Location = new Point((pnlSpielfeld.Width / 2) - (picSchlange.Width / 2), (pnlSpielfeld.Height / 2) - (picSchlange.Height / 2));
            picSchlange.BringToFront();
        }
        /* Diese Funktion ist zum beenden des Spiels, alle Timers werden angehalten und 
         * falls der wert Sieg = true ist wird den Punkten noch der Countdownwert * 20 dazugezählt
         * Der Infotext wird entsprechend ausgegeben
         */
        public void BeendeSpielrunde(bool sieg)
        {
            lblInfo.Text = "Das Spiel ist vorbei,\n";
            tmrCountdown.Stop();
            tmrSpiel.Stop();

            if (sieg)
            {
                Punkte += Countdown * 20;
                lblInfo.Text += "Sie haben gewonnen. :-)";
            }
            else
            {
                lblInfo.Text += "Sie haben leider verloren. :-(";
            }
            txtPunkte.Text = Punkte.ToString();
        }
        /* Zuforterst wird der Liste ein neue PictureBox eingefügt. Dies wird entsprechend der gedruckten Pfeiltaste in dem Feld als Kopf angezeigt
         * Um den Kopf richtig auszurichten wird die Funktion AendereBildSchlangenKopf aufgerufen.
         * Dann wird das letzte Teil der Schlange gelöscht sofern die Schlange nicht am wachsen ist.
         * Wenn die Schlange länger als nur der Kopf ist wird sie noch mit den Bilder für Körper und Schwanz versehen.
         */
        public void BewegeSchlange()
        {
            PictureBox picSchlange = new PictureBox();

            SchlangeTeile.Insert(0, picSchlange);
            picSchlange.Size = new Size(Skarliergroesse, Skarliergroesse);
            pnlSpielfeld.Controls.Add(picSchlange);
            picSchlange.Tag = Richtung;
            Bitmap schlangeKopfImage = new Bitmap(Properties.Resources.SchlangenKopfRechts);
            switch (Richtung)
            {
                case "Up":
                    picSchlange.Location = new Point(SchlangeTeile[1].Location.X, SchlangeTeile[1].Location.Y - picSchlange.Height);
                    break;
                case "Left":
                    picSchlange.Location = new Point(SchlangeTeile[1].Location.X - picSchlange.Width, SchlangeTeile[1].Location.Y);
                    break;
                case "Down":
                    picSchlange.Location = new Point(SchlangeTeile[1].Location.X, SchlangeTeile[1].Location.Y + picSchlange.Height);
                    break;
                case "Right":
                    picSchlange.Location = new Point(SchlangeTeile[1].Location.X + picSchlange.Width, SchlangeTeile[1].Location.Y);
                    break;
            }
            AendereBildSchlangenKopf(picSchlange);
            if (Wachsen != 0)
            {
                Wachsen--;

            }
            else
            {
                SchlangeTeile[SchlangeTeile.Count - 1].Dispose();
                SchlangeTeile.RemoveAt(SchlangeTeile.Count - 1);
            }
            if (SchlangeTeile.Count > 1)
            {
                AendereBildSchlangenKoerper();
                AendereBildSchlangenSchwanz();
            }
        }
        /* Der Kopf der Schlange wird anhand der Richtung mit dem entsprechenden Bild versehen.
         */
        private void AendereBildSchlangenKopf(PictureBox picSchlange)
        {
            Bitmap schlangeKopfImage = new Bitmap(Properties.Resources.SchlangenKopfRechts);
            switch (Richtung)
            {
                case "Up":
                    schlangeKopfImage = new Bitmap(Properties.Resources.SchlangenKopfOben);
                    break;
                case "Left":
                    schlangeKopfImage = new Bitmap(Properties.Resources.SchlangenKopfLinks);
                    break;
                case "Down":
                    schlangeKopfImage = new Bitmap(Properties.Resources.SchlangenKopfUnten);
                    break;
                case "Right":
                    schlangeKopfImage = new Bitmap(Properties.Resources.SchlangenKopfRechts);
                    break;
            }
            picSchlange.Image = new Bitmap(schlangeKopfImage, new Size(Skarliergroesse, Skarliergroesse));
            picSchlange.BringToFront();
        }
        /* Bei jedem Körperteil gibt es verschiedene optionen
         * Bei mir kommt es jeweils draufan von wo der Körper kommt und wo der Kopf ist.
         * Dies kann mit dem Abfragen der Tags ermittelt werden, da in diesen jeweils bei der Erstellung die aktuelle Richtung eingespeichert wird.
         * Somit kann die Aktuelle Richtung mit der Richtung des Kopfs verglichen werden um die Kurven einzubauen.
         * Aus der sicht der Schlange gibt es bei jeder Position eigenlich 3 optionen,
         * 1. Die Schlange dreht sich nach links.
         * 2. Die Schlange dreht sich nach rechts.
         * 3. Die Schlange geht in die gleiche Richtung weiter.
         * 
         * Jede dieser Richtungsänderungen ruft ein anderes Bild herbei. 
         * Somit gibt es 4x3 verschiedene Stellungsvarianten und 6 verschiedene Bilder. 
         */
        private void AendereBildSchlangenKoerper()
        {
            Bitmap schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeHorizontal);
            switch (SchlangeTeile[1].Tag.ToString()) 
            {
                case "Right":
                    if (SchlangeTeile[0].Tag.ToString() == "Up")
                    {
                        schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeLinks_Oben);

                    }
                    else if (SchlangeTeile[0].Tag.ToString() == "Down")
                    {
                        schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeLinks_Unten);
                    }
                    else
                    {
                        schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeHorizontal);
                    }

                    break;
                case "Left":
                    if (SchlangeTeile[0].Tag.ToString() == "Up")
                    {
                        schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeRechts_Oben);

                    }
                    else if (SchlangeTeile[0].Tag.ToString() == "Down")
                    {
                        schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeRechts_Unten);
                    }
                    else
                    {
                        schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeHorizontal);
                    }
                    break;

                case "Up":

                    if (SchlangeTeile[0].Tag.ToString() == "Right")
                    {
                        schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeRechts_Unten);

                    }
                    else if (SchlangeTeile[0].Tag.ToString() == "Left")
                    {
                        schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeLinks_Unten);
                    }
                    else
                    {
                        schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeVertikal);
                    }


                    break;
                case "Down":
                    if (SchlangeTeile[0].Tag.ToString() == "Right")
                    {
                        schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeRechts_Oben);

                    }
                    else if (SchlangeTeile[0].Tag.ToString() == "Left")
                    {
                        schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeLinks_Oben);
                    }
                    else
                    {
                        schlangeKoerperImage = new Bitmap(Properties.Resources.SchlangeVertikal);
                    }
                    break;

            }
            SchlangeTeile[1].Image = new Bitmap(schlangeKoerperImage, new Size(Skarliergroesse, Skarliergroesse));
        }

    /* Der Schwanz der Schlange wird anhand der Richtung des Körperteils ausgerichtet, er erhält hier das entsprechende Bild
    */ 
        private void AendereBildSchlangenSchwanz()
        {
            Bitmap schlangeSchwanzImage = new Bitmap(Properties.Resources.SchlangenEndeRechts);
            switch (SchlangeTeile[SchlangeTeile.Count - 2].Tag.ToString())
            {
                case "Up":
                    schlangeSchwanzImage = new Bitmap(Properties.Resources.SchlangenEndeUnten);
                    break;
                case "Left":
                    schlangeSchwanzImage = new Bitmap(Properties.Resources.SchlangenEndeRechts);
                    break;
                case "Down":
                    schlangeSchwanzImage = new Bitmap(Properties.Resources.SchlangenEndeOben);
                    break;
                case "Right":
                    schlangeSchwanzImage = new Bitmap(Properties.Resources.SchlangenEndeLinks);
                    break;

            }
            SchlangeTeile[SchlangeTeile.Count - 1].Image = new Bitmap(schlangeSchwanzImage, new Size(Skarliergroesse, Skarliergroesse));
        }
        /* Hier werden mit den Tasteneingaben die Richtung der Schlange geändert
         */
        protected override bool ProcessDialogKey(Keys keyData)
        {

            switch (keyData)
            {
                case Keys.Up:
                    Richtung = "Up";
                    break;
                case Keys.Left:
                    Richtung = "Left";
                    break;
                case Keys.Down:
                    Richtung = "Down";
                    break;
                case Keys.Right:
                    Richtung = "Right";
                    break;
            }
            return true;

        }
        /* Das ist der Spielablauf, alles ist in Funktionen ausgelagert 
         * und somit Besteht er  nur aus der Bewegung, dem evtl. Essen und den Kolisionsmöglichkeiten mit Wand und Körper
         * 
         */
        private void tmrSpiel_Tick(object sender, EventArgs e)
        {

            BewegeSchlange();

            EsseApfel();

            KolidiertMitSpielfeldlinie();
            KolidiertMitSchlangenkoerper();

        }
        /*
         * Es wird kontrolliert ob der Schlangenkopf auf eines der Äpfel in der Aepfel Liste trifft.
         * Falls Ja der Wert des Apfels den Punkten und dem Wachstum gutgeschrieben
         * Mit der Methode Beschleunigen() wird die Geschwindikeit angepasst
         */
        private void EsseApfel()
        {
            foreach (PictureBox picApfel in Aepfel)
            {
                if (SchlangeTeile[0].Bounds.IntersectsWith(picApfel.Bounds))
                {
                    Punkte += Convert.ToInt32(picApfel.Tag);
                    Wachsen += (int)picApfel.Tag;
                    txtPunkte.Text = Punkte.ToString();
                    Beschleunigen(Convert.ToInt32(picApfel.Tag));
                    picApfel.Dispose();
                    lblInfo.Text = "Sie haben soeben einen Apfel gegessen, Ihnen wurden  " + picApfel.Tag.ToString() + " Punkte Gutgeschrieben. \nAchtung, die Geschwindigkeit wurde erhöht!";
                    Aepfel.Remove(picApfel);
                    break;
                }
            }
            if (Aepfel.Count == 0)
            {
                BeendeSpielrunde(true);
            }
        }
        /* Falls die Minimalgeschwinidikeit von 10ms noch nicht erreicht wurde wird dem Timer des Spiels die entsprechenden Punkte abgezogen
         * Somit wird das Spiel schneller
         */
        private void Beschleunigen(int apfelpunkte)
        {
            if (tmrSpiel.Interval > 10)
            {
                tmrSpiel.Interval -= apfelpunkte;
            }
        }
        /*
         * Trifft der Kopf der Schlange auf den Aussenrand des Spielfeldes wird das Spiel mit Sieg = false Beendet. 
         */
        private void KolidiertMitSpielfeldlinie()
        {
            if (SchlangeTeile[0].Bounds.Left < pnlSpielfeld.ClientRectangle.Left ||
                SchlangeTeile[0].Bounds.Right > pnlSpielfeld.ClientRectangle.Right ||
                SchlangeTeile[0].Bounds.Top < pnlSpielfeld.ClientRectangle.Top ||
                SchlangeTeile[0].Bounds.Bottom > pnlSpielfeld.ClientRectangle.Bottom)
            {
                BeendeSpielrunde(false);
            }
        }
        /*
         * Trifft der Kopf der Schlange auf ein Körperteil wird das Spiel mit Sieg = false Beendet.
         * Das erste Körperteil hinter dem Kopf wird nicht geprüft, da dort die Schlange immer ein Körperteil berührt.
        */
        private void KolidiertMitSchlangenkoerper()
        {
            foreach (PictureBox picSchlange in SchlangeTeile)
            {

                if (SchlangeTeile[0].Bounds.IntersectsWith(picSchlange.Bounds) && picSchlange != SchlangeTeile[0])
                {
                    BeendeSpielrunde(false);
                }
            }
        }
    }
}