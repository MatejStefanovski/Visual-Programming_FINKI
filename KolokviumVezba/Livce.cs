using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokviumVezba
{
    public class Livce
    {
        public Livce(Match match, string tip)
        {
            this.match = match;
            this.tip = tip;
        }

        public Match match { get; set; }
        public string tip { get; set; }

        public override string ToString()
        {
            string s = match.ToString() + " - " + tip; 
            return s;
        }
    }
}
