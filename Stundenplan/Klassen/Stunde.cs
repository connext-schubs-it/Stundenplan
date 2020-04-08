using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplan.Klassen
{
    public class Stunde
    {
        public string Titel { get; set; }
      public int aStunde { get; set; }

      public Stunde(string titel, int stunde)
        {
            Titel = titel;
            aStunde = stunde;
      }
    }

}
