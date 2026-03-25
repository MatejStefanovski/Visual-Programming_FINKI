using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports
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

        public override string ToString()
        {
            string s = Shortname + " - " + Name + " - " + City;
            return s;
        }
        public void AddDest(Destination d)
        {
            Destinations.Add(d);
        }
    }
}
