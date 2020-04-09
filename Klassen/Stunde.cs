namespace Stundenplan.Klassen
{
    public class Stunde
    {
        public Fach Fach { get; set; }
        public string Raum { get; set; }
        public int StundenID { get; set; }

        public Stunde(Fach fach, string raum, int stundenID)
        {
            Fach = fach;
            Raum = raum;
            StundenID = stundenID;
        }
    }

}
