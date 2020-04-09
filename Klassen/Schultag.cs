using System.Collections.Generic;

namespace Stundenplan.Klassen
{
    public class Schultag
    {
        public string Wochentag { get; set; }

        public List<Stunde> Stunden { get; set; }

        public Schultag(string wochentag, List<Stunde> Schulstunden)
        {
            Wochentag = wochentag;
            Stunden = Schulstunden;
        }
    }
}
