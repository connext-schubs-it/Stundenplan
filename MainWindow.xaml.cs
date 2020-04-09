using System;
using Stundenplan.Klassen;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

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
            Fach Mathe = new Fach("Mathe", Brushes.Blue, "Herr Müller");
            Fach Englisch = new Fach("Englisch", Brushes.Red, "Frau Meier");
            Fach Sport = new Fach("Sport", Brushes.Green, "Herr Kamp");
            Fach Informatik = new Fach("Informatik", Brushes.Cyan, "Frau Reich");

            liste = new List<Schultag>();
            if (wochentag == 1 || wochentag == null)
            {
                Schultag montag = new Schultag("Montag", new Stunde[]
                {
                    new Stunde(Mathe, "D123"),
                    new Stunde(Englisch, "D123")
                });
                // hier dann montag.Sort((x,y) => )
                liste.Add(montag);
            }
            if (wochentag == 2 || wochentag == null)
            {
                Schultag dienstag = new Schultag("Dienstag", new Stunde[]
                {
                    new Stunde(Sport, "Sporthalle")
                });
                liste.Add(dienstag);
            }
            if (wochentag == 3 || wochentag == null)
            {
                Schultag mittwoch = new Schultag("Mittwoch", new Stunde[]
                {
                    new Stunde(Englisch, "D212")
                });
                liste.Add(mittwoch);
            }
            if (wochentag == 4 || wochentag == null)
            {
                Schultag donnerstag = new Schultag("Donnerstag", new Stunde[]
                {
                    new Stunde(Informatik, "D123")
                });
                liste.Add(donnerstag);
            }
            if (wochentag == 5 || wochentag == null)
            {
                Schultag freitag = new Schultag("Freitag", new Stunde[]
                {
                    new Stunde(Informatik, "D123")
                });
                liste.Add(freitag);
            }
            WochenplanData = new Wochenplan(liste);
            getZeitraum();
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
