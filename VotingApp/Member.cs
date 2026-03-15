using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp
{
    public class Member
    {
        public Member(int redbr, string shortname, string longname, int votecount)
        {
            this.redbr = redbr;
            this.shortname = shortname;
            this.longname = longname;
            this.votecount = votecount;
        }

        public override string ToString()
        {
            string s = redbr + ". " + shortname + "\n";
            return s;
        }

        public void AddVotes(int votes)
        {
            votecount += votes;
        }

        public int redbr { get; set; }

        public string shortname { get; set; }

        public string longname { get; set; }

        public int votecount { get; set; }

    }
}
