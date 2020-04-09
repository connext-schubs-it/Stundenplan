﻿using Stundenplan.Klassen;
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
            Schultag montag = new Schultag("Montag", new Stunde[]
            {
                new Stunde("Deutsch", "Tomato", "Herr Müller", "D123"),
                new Stunde("Mathe", "PeachPuff", "Herr Meier", "D123"),
            });
            Schultag dienstag = new Schultag("Dienstag", new Stunde[]
            {
                new Stunde("Sport", "Salmon", "Herr Müller", "Sporthalle"),
            });
            Schultag mittwoch = new Schultag("Mittwoch", new Stunde[]
            {
                new Stunde("Englisch", "Wheat", "Frau Test", "D212"),
            });
            Schultag donnerstag = new Schultag("Donnerstag", new Stunde[]
            {
                new Stunde("Deutsch", "BlanchedAlmond", "Herr Müller", "D123"),
            });
            Schultag freitag = new Schultag("Freitag", new Stunde[]
            {
                new Stunde("Deutsch", "#FFFDF5E6", "Herr Müller", "D123"),
            });

            Wochenplan = new WochenplanReihe(montag, dienstag, mittwoch, donnerstag, freitag);

            InitializeComponent();
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