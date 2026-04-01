using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Race
{
    public class Lap
    {
        public Lap(int minuti, int sekundi)
        {
            Minuti = minuti;
            Sekundi = sekundi;
        }

        public int Minuti { get; set; }
        public int Sekundi { get; set; }

        public override string ToString()
        {
            string s = Minuti + ":" + Sekundi;
            return s;
        }
    }
}
