﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplan.Klassen
{
    public class Stunde
    {
        public string Titel { get; set; }

        public string Details { get; set; }

        public Stunde(string titel, string details = "")
        {
            Titel = titel;
            Details = details;
        }
    }

}
