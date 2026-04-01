using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokviumVezba
{
    public class Match
    {
        public Match(Tim team1, Tim team2, string code, int coef1, int coefX, int coef2)
        {
            Team1 = team1;
            Team2 = team2;
            Code = code;
            Coef1 = coef1;
            CoefX = coefX;
            Coef2 = coef2;
        }

        public Tim Team1 { get; set; }
        public Tim Team2 { get; set; }
        public string Code { get; set; }
        public int Coef1 { get; set; }
        public int CoefX { get; set; }
        public int Coef2 { get; set; }

        public override string ToString()
        {
            string s = Team1.Name + " - " + Team2.Name + " (" + Code + ")";
            return s;
        }
    }
}
