using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBets
{
    public class Team
    {
        public String Name { get; set; }
        public String Country { get; set; }

        public Team(String name, String country)
        {
            this.Name = name;
            this.Country = country;
        }
        public override String ToString() 
        {
            string s = Name + " - " + Country;
            return s;
        }
    }
}
