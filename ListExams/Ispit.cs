using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExams
{
    public class Ispit
    {
        public Ispit(string mesec, int godina)
        {
            Mesec = mesec;
            Godina = godina;
            Zadaca1 = new Zadaca();
            Zadaca2 = new Zadaca();
        }

        public string Mesec { get; set; }
        public int Godina { get; set; }
        public Zadaca Zadaca1 { get; set; }
        public Zadaca Zadaca2 { get; set; }

        public override string ToString()
        {
            string s = Mesec + " - " + Godina;
            return s;
        }
    }
}
