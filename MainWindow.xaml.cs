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

        // Enthält die anzuzeigenden Daten für den Stundenplan
        public Wochenplan WochenplanData
        {
            get => (Wochenplan)GetValue(WochenplanDataProperty);
            set => SetValue(WochenplanDataProperty, value);
        }
        public static readonly DependencyProperty WochenplanDataProperty =
            DependencyProperty.Register("WochenplanData", typeof(Wochenplan), typeof(MainWindow), new PropertyMetadata(null));

        // Verwende diese Variable, um zwischen Wochen und Tagesansicht zu wechseln
        public int AnzahlSpalten
        {
            get => (int)GetValue(AnzahlSpaltenProperty);
            set => SetValue(AnzahlSpaltenProperty, value);
        }
        public static readonly DependencyProperty AnzahlSpaltenProperty =
            DependencyProperty.Register("AnzahlSpalten", typeof(int), typeof(MainWindow), new PropertyMetadata(5));

        // Titel für den aktuellen Zeitraum
        public string Zeitraum
        {
            get => (string)GetValue(ZeitraumProperty);
            set => SetValue(ZeitraumProperty, value);
        }
        public static readonly DependencyProperty ZeitraumProperty =
            DependencyProperty.Register("Zeitraum", typeof(string), typeof(MainWindow), new PropertyMetadata(null));

        public MainWindow()
        {
            generiereWochenplan(null);
            InitializeComponent();
        }

        
        ///<param name="wochentag">Übergebe den Wochentag als 1-5 oder null für die komplette Woche</param>
        private void generiereWochenplan(int? wochentag)
        {
            // Wird später gebraucht
            var kalenderwoche = (ausgewähltesDatum.DayOfYear / 7) + 1;

            var liste = new List<Schultag>();
            // Montag
            if (wochentag == 1 || wochentag == null)
            { 
                Schultag montag = new Schultag("Montag", new List<Stunde> 
                {
                    new Stunde("Mathe", "Herr Müller", "D123", 1)
                }); 
                montag.Stunden.Sort((x, y) => x.StundenID > y.StundenID ? 1 : -1); 
                liste.Add(montag);
            }
            // Dienstag
            if (wochentag == 2 || wochentag == null)
            {
                Schultag dienstag = new Schultag("Dienstag", new List<Stunde>
                {

                }); 
                dienstag.Stunden.Sort((x, y) => x.StundenID > y.StundenID ? 1 : -1); 
                liste.Add(dienstag);
            }
            // Mittwoch
            if (wochentag == 3 || wochentag == null)
            {
                Schultag mittwoch = new Schultag("Mittwoch", new List<Stunde>
                {

                }); 
                mittwoch.Stunden.Sort((x, y) => x.StundenID > y.StundenID ? 1 : -1); 
                liste.Add(mittwoch);
            }
            // Donnerstag
            if (wochentag == 4 || wochentag == null)
            {
                Schultag donnerstag = new Schultag("Donnerstag", new List<Stunde>
                {

                }); 
                donnerstag.Stunden.Sort((x, y) => x.StundenID > y.StundenID ? 1 : -1); 
                liste.Add(donnerstag);
            }
            // Freitag
            if (wochentag == 5 || wochentag == null)
            {
                Schultag freitag = new Schultag("Freitag", new List<Stunde>
                {

                }); 
                freitag.Stunden.Sort((x, y) => x.StundenID > y.StundenID ? 1 : -1); 
                liste.Add(freitag);
            }
            WochenplanData = new Wochenplan(liste);
        }

        private void zurTagesansichtWechseln(object sender, RoutedEventArgs e)
        {

        }

        private void zurWochenansichtWechseln(object sender, RoutedEventArgs e)
        {

        }

        private void Weiter(object sender, RoutedEventArgs e)
        {
            if (AnzahlSpalten == 1)
            {
                ausgewähltesDatum = ausgewähltesDatum.AddDays(1);
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

        }
        
        /*
         * Setzt den Titel für den aktuell gesetzten Zeitraum zb. 06.04.2020 - 12.04.2020
         */
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
    }
}
