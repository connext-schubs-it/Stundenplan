namespace Stundenplan.Klassen
{
    public class Stunde
    {
        public Fach Fach { get; set; }
        public string Raum { get; set; }

        public Stunde(Fach fach, string raum)
        {
            Fach = fach;
            Raum = raum;
        }
    }

}
