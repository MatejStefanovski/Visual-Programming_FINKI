using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokviumVezba
{
    public class Tim
    {
        public Tim(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public string Name { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            string s = Name + " " + Country;
            return s;
        }
    }
}
