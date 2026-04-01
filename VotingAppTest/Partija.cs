using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAppTest
{
    public class Partija
    {
        public Partija(int rbr, string shortame, string name)
        {
            Rbr = rbr;
            Shortame = shortame;
            Name = name;
            Votes = 0;
        }

        public int Rbr { get; set; }
        public string Shortame { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
        public override string ToString()
        {
            string s = Rbr + ". " + Shortame;
            return s;
        }
        public void AddVotes(int votes)
        {
            Votes += votes;
        }
    }
}
