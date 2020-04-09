using Stundenplan.Klassen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Stundenplan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WochenplanReihe Wochenplan { get; }

        public Stunde AusgewaehlteStunde
        {
            get => (Stunde)GetValue(AusgewaehlteStundeProperty);
            set => SetValue(AusgewaehlteStundeProperty, value);
        }

        // Using a DependencyProperty as the backing store for AusgewaehlteStunde.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AusgewaehlteStundeProperty =
            DependencyProperty.Register("AusgewaehlteStunde", typeof(Stunde), typeof(MainWindow), new PropertyMetadata(null));

      public MainWindow()
      {
         int kalenderwoche = (DateTime.Now.DayOfYear / 7) + 1;

         Schultag montag = new Schultag("Montag", new List<Stunde>
           {
                new Stunde("Deutsch",1),
                new Stunde("Mathe",3),
           });
         Schultag dienstag = new Schultag("Dienstag", new List<Stunde>
         {
                new Stunde("Sport",1),
         });
         Schultag mittwoch = new Schultag("Mittwoch", new List<Stunde>
         {
                new Stunde("Englisch",2),
         });
         Schultag donnerstag = new Schultag("Donnerstag", new List<Stunde>
         {
                new Stunde("Deutsch",4),
         });
         Schultag freitag = new Schultag("Freitag", new List<Stunde>
         {
                new Stunde("Deutsch",2),
         });

         if (kalenderwoche % 2 == 0)
         {
            montag.Stunden.Add(new Stunde("Deutsch", 2));
            montag.Stunden.Sort((x, y) => x.StundeID > y.StundeID ? 1 : -1);
         }
         else
         {
            montag.Stunden.Add(new Stunde("Englisch", 2));
            montag.Stunden.Sort((x, y) => x.StundeID > y.StundeID ? 1 : -1);
         }


         Wochenplan = new WochenplanReihe(montag, dienstag, mittwoch, donnerstag, freitag);
         InitializeComponent();
      }

        private void Stunde_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            AusgewaehlteStunde = (Stunde)clickedButton.DataContext;
        }
    }

    public class WochenplanReihe
    {
        public Schultag Montag { get; set; }
        public Schultag Dienstag { get; set; }
        public Schultag Mittwoch { get; set; }
        public Schultag Donnerstag { get; set; }
        public Schultag Freitag { get; set; }

        public List<Schultag> Schultage { get; }

        public WochenplanReihe(Schultag montag, Schultag dienstag, Schultag mittwoch, Schultag donnerstag, Schultag freitag)                                                                       
        {
            Montag = montag;
            Dienstag = dienstag;
            Mittwoch = mittwoch;
            Donnerstag = donnerstag;
            Freitag = freitag;

            Schultage = new List<Schultag>()
            {
                montag,
                dienstag,
                mittwoch,
                donnerstag,
                freitag
            };
        }
    }
}
