using Stundenplan.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Stundenplan
{
   /// <summary>
   /// Interaktionslogik für StundeAnsicht.xaml
   /// </summary>
   public partial class StundeAnsicht : Window
   {
      public Stunde AusgewaehlteStunde
      {
         get => (Stunde)GetValue(AusgewaehlteStundeProperty);
         set => SetValue(AusgewaehlteStundeProperty, value);
      }

      // Using a DependencyProperty as the backing store for AusgewaehlteStunde.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty AusgewaehlteStundeProperty =
          DependencyProperty.Register("AusgewaehlteStunde", typeof(Stunde), typeof(StundeAnsicht), new PropertyMetadata(null));


      public StundeAnsicht(Stunde stunde)
      {
         AusgewaehlteStunde = stunde;

         InitializeComponent();
      }
   }
}
