using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExams
{
    public class Zadaca
    {
        public Zadaca() 
        {
            Description = "";
            Points = 0;
        }
        public Zadaca(string description, int points)
        {
            Description = description;
            Points = points;
        }

        public string Description { get; set; }
        public int Points { get; set; }


    }
}
