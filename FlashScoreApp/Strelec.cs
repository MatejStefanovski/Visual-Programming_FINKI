using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashScoreApp
{
    public class Strelec
    {
        public Strelec(string name, string minute)
        {
            Name = name;
            Minute = minute;
        }

        public string Name { get; set; }
        public string Minute { get; set; }

        public override string ToString()
        {
            string s = Name + " " + Minute;
            return s;
        }
    }
}
