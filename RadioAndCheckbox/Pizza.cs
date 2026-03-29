using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioAndCheckbox
{
    public class Pizza
    {
        public Pizza(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            string s = Name + " " + Price;
            return s;
        }
    }
}
