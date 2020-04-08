using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplan.Klassen
{
    public class Wochenplan
    {
        public Schultag[] Schultage { get; set; }

        public Wochenplan(Schultag[] schultage)
        {
            Schultage = schultage;
        }
    }
}
