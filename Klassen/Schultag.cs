using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplan.Klassen
{
    class Schultag
    {
        public Stunde[] Stunden { get; set; }

        public Schultag(Stunde[] Schulstunden)
        {
            Stunden = Schulstunden;
        }
    }
}
