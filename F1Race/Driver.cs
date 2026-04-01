using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Race
{
    public class Driver
    {
        public Driver(string ime, int vozrast, bool prvVozac)
        {
            Ime = ime;
            Vozrast = vozrast;
            PrvVozac = prvVozac;
            Krugovi = new List<Lap>();
        }

        public string Ime { get; set; }
        public int Vozrast { get; set; }
        public bool PrvVozac { get; set; }
        public List<Lap> Krugovi { get; set; }

        public override string ToString()
        {
            string s = Ime + " (" + Vozrast + ") " + " - " + PrvVozac;
            return s;
        }

    }
}
