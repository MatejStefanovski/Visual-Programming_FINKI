using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashScoreApp
{
    public class Natprevar
    {
        public string Tip { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public string Rez { get; set; }

        public List<Strelec> HomeScorers { get; set; }
        public List<Strelec> AwayScorers { get; set; }

        public override string ToString()
        {
            return Home + " - " + Away + " (" + Rez + ")";
        }
    }
}
