using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports
{
    public class Destination
    {
        public Destination(string name, int distance, int price)
        {
            Name = name;
            Distance = distance;
            Price = price;
        }

        public string Name { get; set; }
        public int Distance { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            string s = Name + " " + Distance + "km " + Price + " EUR\n";
            return s;
        }
    }
}
