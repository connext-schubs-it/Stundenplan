using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Stundenplan.Klassen
{
   public class Fach
   {
      public string Titel { get; set; }
      public Brush Color { get; set; }
      public string Lehrer { get; set; }

      public Fach(string titel, Brush brush, string lehrer)
      {
          Titel = titel;
          Color = brush;
          Lehrer = lehrer;
      }
   }
}
