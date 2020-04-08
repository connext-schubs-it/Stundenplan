using Stundenplan.Klassen;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Stundenplan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

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
            DependencyProperty.Register("AnzahlSpalten", typeof(int), typeof(MainWindow), new PropertyMetadata(1));

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
            Schultag montag = new Schultag("Montag", new Stunde[]
            {
                new Stunde("Deutsch"),
                new Stunde("Mathe"),
            });
            Schultag dienstag = new Schultag("Dienstag", new Stunde[]
            {
                new Stunde("Sport"),
            });
            Schultag mittwoch = new Schultag("Mittwoch", new Stunde[]
            {
                new Stunde("Englisch"),
            });
            Schultag donnerstag = new Schultag("Donnerstag", new Stunde[]
            {
                new Stunde("Deutsch"),
            });
            Schultag freitag = new Schultag("Freitag", new Stunde[]
            {
                new Stunde("Deutsch"),
            });

            WochenplanData = new Wochenplan(
                new List<Schultag>() 
                {
                    montag,
                    dienstag, 
                    mittwoch, 
                    donnerstag, 
                    freitag

                });

            InitializeComponent();
        }

        private void Stunde_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            AusgewaehlteStunde = (Stunde)clickedButton.DataContext;
        }

        private void WochenansichtAendern(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button) sender;
            AnzahlSpalten = AnzahlSpalten == 1? 5: 1;
        }
    }
}
