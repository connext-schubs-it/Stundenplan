namespace Stundenplan.Klassen
{
    public class Stunde
    {
        public string Raum { get; set; }
        public int StundenID { get; set; }
        
        public string Titel { get; set; }
        public string Lehrer { get; set; }

        public Stunde(string titel, string lehrer, string raum, int stundenID)
        {
            Titel = titel;
            Lehrer = lehrer;
            Raum = raum;
            StundenID = stundenID;
        }
    }

}
