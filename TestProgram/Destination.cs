using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram
{
    public class Destination
    {
        public Destination(string name, int length, int price)
        {
            Name = name;
            Length = length;
            Price = price;
        }

        public string Name { get; set; }
        public int Length { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            string s = Name + " - " + Length + "km - " + Price + "EUR";
            return s;
        }
    }
}
