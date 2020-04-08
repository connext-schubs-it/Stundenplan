using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplan.Klassen
{
    public class Wochenplan
    {
        public List<Schultag> Schultage { get; set; }

        public Wochenplan(List<Schultag> schultage)
        {
            Schultage = schultage;
        }
    }
}
