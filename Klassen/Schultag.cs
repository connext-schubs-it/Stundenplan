namespace Stundenplan.Klassen
{
    public class Schultag
    {
        public string Wochentag { get; set; }

        public Stunde[] Stunden { get; set; }

        public Schultag(string wochentag, Stunde[] Schulstunden)
        {
            Wochentag = wochentag;
            Stunden = Schulstunden;
        }
    }
}
