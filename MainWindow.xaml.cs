using System.Collections.ObjectModel;
using System.Windows;

namespace Stundenplan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WochenplanReihe[] wochenplan;
        public MainWindow()
        {
            InitializeComponent();
            wochenplan = new WochenplanReihe[]{
                new WochenplanReihe("Deutsch","Musik", "Mathe", "Informatik","Englisch")
            };
            stundenplanData.ItemsSource = wochenplan;
        }

    }

    public class WochenplanReihe
    {
        public string Montag { get; set; }
        public string Dienstag { get; set; }
        public string Mittwoch { get; set; }
        public string Donnerstag { get; set; }
        public string Freitag { get; set; }

        public WochenplanReihe(string montag, string dienstag, string mittwoch, string donnerstag, string freitag)
        {
            Montag = montag;
            Dienstag = dienstag;
            Mittwoch = mittwoch;
            Donnerstag = donnerstag;
            Freitag = freitag;
        }
    }
}
