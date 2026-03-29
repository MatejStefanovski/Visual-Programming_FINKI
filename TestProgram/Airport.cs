using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram
{
    public class Airport
    {
        public Airport(string city, string name, string shortname)
        {
            City = city;
            Name = name;
            Shortname = shortname;
            Destinations = new List<Destination>();
        }

        public string City { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public List<Destination> Destinations { get; set; }

        public void AddAir(Destination d)
        {
            Destinations.Add(d);
        }
        public override string ToString()
        {
            string s = Shortname + " - " + Name + " - " + City;
            return s;
        }
    }
}
