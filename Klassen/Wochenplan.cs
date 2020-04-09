using System.Collections.Generic;

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
