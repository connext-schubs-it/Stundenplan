using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplan.Klassen
{
    class Wochenplan
    {
        public Schultag[] Schultage { get; set; }

        public Wochenplan(Schultag[] Schultage)
        {
            Schultage = Schultage;
        }
    }
}
