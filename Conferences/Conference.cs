using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences
{
    public class Conference
    {
        public Conference(string name, int year)
        {
            Name = name;
            Year = year;
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            string s = Year + ": " + Name;
            return s;
        }
    }
}
