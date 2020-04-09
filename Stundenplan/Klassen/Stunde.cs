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
        public string Color { get; set; }
        public string Lehrer { get; set; }
        public string Raum { get; set; }

        public Stunde(string titel, string color, string lehrer, string raum)
        {
            Titel = titel;
            Color = color;
            Lehrer = lehrer;
            Raum = raum;
        }
    }

}
