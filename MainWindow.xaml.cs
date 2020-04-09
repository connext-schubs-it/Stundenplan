using System;
using Stundenplan.Klassen;
using System.Collections.Generic;
using System.Windows;

namespace Stundenplan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime ausgewähltesDatum = DateTime.Now;
        private List<Schultag> liste;
        public Wochenplan WochenplanData
        {
            get => (Wochenplan)GetValue(WochenplanDataProperty);
            set => SetValue(WochenplanDataProperty, value);
        }

        // Using a DependencyProperty as the backing store for AusgewaehlteStunde.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WochenplanDataProperty =
            DependencyProperty.Register("WochenplanData", typeof(Wochenplan), typeof(MainWindow), new PropertyMetadata(null));

        public int AnzahlSpalten
        {
            get => (int)GetValue(AnzahlSpaltenProperty);
            set => SetValue(AnzahlSpaltenProperty, value);
        }

        // Using a DependencyProperty as the backing store for AusgewaehlteStunde.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnzahlSpaltenProperty =
            DependencyProperty.Register("AnzahlSpalten", typeof(int), typeof(MainWindow), new PropertyMetadata(5));

        public string Zeitraum
        {
            get => (string)GetValue(ZeitraumProperty);
            set => SetValue(ZeitraumProperty, value);
        }

        // Using a DependencyProperty as the backing store for AusgewaehlteStunde.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZeitraumProperty =
            DependencyProperty.Register("Zeitraum", typeof(string), typeof(MainWindow), new PropertyMetadata(null));

        public MainWindow()
        {
            generiereWochenplan(null);
            InitializeComponent();
        }

        private void getZeitraum()
        {
            if (AnzahlSpalten == 1)
            {
                Zeitraum = ausgewähltesDatum.ToString("d");
            }
            else
            {
                DateTime montag = ausgewähltesDatum.AddDays(-(int) ausgewähltesDatum.DayOfWeek + 1);
                DateTime sonntag = ausgewähltesDatum.AddDays(7 - (int) ausgewähltesDatum.DayOfWeek);
                Zeitraum = montag.ToString("d") + " - " + sonntag.ToString("d");
            }
        }

        private void generiereWochenplan(int? wochentag)
        {
            liste = new List<Schultag>();
            //Bestehendes Grundgerüst für jede Woche aufbauen
            if (wochentag == 1 || wochentag == null)
            {
                Schultag montag = new Schultag("Montag", new List<Stunde>
                {
                    new Stunde("Deutsch", "Tomato", "Herr Müller", "D123", 1),
                    new Stunde("Mathe", "PeachPuff", "Herr Meier", "D123", 3)
                });
            hinzufuegen(montag);
            montag.Stunden.Sort((x, y) => x.StundenID > y.StundenID ? 1 : -1);
            liste.Add(montag);
            }
            if (wochentag == 2 || wochentag == null)
            {
                Schultag dienstag = new Schultag("Dienstag", new List<Stunde>
                {
                    new Stunde("Sport", "Salmon", "Herr Müller", "Sporthalle",1)
                });
            hinzufuegen(dienstag);
            dienstag.Stunden.Sort((x, y) => x.StundenID > y.StundenID ? 1 : -1);
            liste.Add(dienstag);
            }
            if (wochentag == 3 || wochentag == null)
            {
                Schultag mittwoch = new Schultag("Mittwoch", new List<Stunde>
                {
                    new Stunde("Englisch", "Wheat", "Frau Test", "D212",1)
                });
            hinzufuegen(mittwoch);
            mittwoch.Stunden.Sort((x, y) => x.StundenID > y.StundenID ? 1 : -1);
            liste.Add(mittwoch);
            }
            if (wochentag == 4 || wochentag == null)
            {
                Schultag donnerstag = new Schultag("Donnerstag", new List<Stunde>
                {
                    new Stunde("Deutsch", "BlanchedAlmond", "Herr Müller", "D123",1)
                });
            hinzufuegen(donnerstag);
            donnerstag.Stunden.Sort((x, y) => x.StundenID > y.StundenID ? 1 : -1);
            liste.Add(donnerstag);
            }
            if (wochentag == 5 || wochentag == null)
            {
                Schultag freitag = new Schultag("Freitag", new List<Stunde>
                {
                    new Stunde("Deutsch", "#FFFDF5E6", "Herr Müller", "D123",1)
                });
            hinzufuegen(freitag);
            freitag.Stunden.Sort((x, y) => x.StundenID > y.StundenID ? 1 : -1);
            liste.Add(freitag);
            }
            WochenplanData = new Wochenplan(liste);
            getZeitraum();
        }

      private Schultag hinzufuegen (Schultag schultag)
      {
         var kalenderwoche = (ausgewähltesDatum.DayOfYear / 7) + 1;

         if (kalenderwoche % 2 == 0)
         {
            switch (schultag.Wochentag)
            {
               case "Montag":
                  schultag.Stunden.Add(new Stunde("Englisch", "LightBlue", "Herr Witkowski", "B039", 2));
                  break;
               case "Dienstag":

                  break;
               case "Mittwoch":

                  break;
               case "Donnerstag":

                  break;
               case "Freitag":

                  break;
            }
         }
         else
         {
            switch (schultag.Wochentag)
            {
               case "Montag":
                  schultag.Stunden.Add(new Stunde("Englisch", "LightBlue", "Herr Witkowski", "B039", 2));
                  break;
               case "Dienstag":

                  break;
               case "Mittwoch":

                  break;
               case "Donnerstag":

                  break;
               case "Freitag":

                  break;
            }
         }
         return schultag;
      }

        private void zurTagesansichtWechseln(object sender, RoutedEventArgs e)
        {
            AnzahlSpalten = 1;
            generiereWochenplan((int)ausgewähltesDatum.DayOfWeek);
        }

        private void zurWochenansichtWechseln(object sender, RoutedEventArgs e)
        {
            AnzahlSpalten = 5;
            generiereWochenplan(null);
        }

        private void Weiter(object sender, RoutedEventArgs e)
        {
            if (AnzahlSpalten == 1)
            {
                if ((int) ausgewähltesDatum.DayOfWeek == 5)
                {
                    ausgewähltesDatum = ausgewähltesDatum.AddDays(3);
                }
                else
                {
                    ausgewähltesDatum = ausgewähltesDatum.AddDays(1);
                }
                generiereWochenplan((int)ausgewähltesDatum.DayOfWeek);
            }
            else
            {
                ausgewähltesDatum = ausgewähltesDatum.AddDays(7);
                generiereWochenplan(null);
            }
        }
        private void Zurueck(object sender, RoutedEventArgs e)
        {
            if (AnzahlSpalten == 1)
            {
                if ((int) ausgewähltesDatum.DayOfWeek == 1)
                {
                    ausgewähltesDatum = ausgewähltesDatum.AddDays(-3);
                }
                else
                {
                    ausgewähltesDatum = ausgewähltesDatum.AddDays(-1);
                }
                generiereWochenplan((int)ausgewähltesDatum.DayOfWeek);
            }
            else
            {
                ausgewähltesDatum = ausgewähltesDatum.AddDays(-7);
                generiereWochenplan(null);
            }
        }
    }
}
