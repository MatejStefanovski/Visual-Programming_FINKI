using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBets
{
    public class GameForTicket
    {
        public Game Game { get; set; }
        public int tip { get; set; }

        public GameForTicket(Game game, int tip)
        {
            Game = game;
            this.tip = tip;
        }
        public override string ToString()
        {
            return String.Format("{0} {1}", Game.ToString(), tip==0 ? "1" : tip==1 ? "X" : "2");
        }
    }
}
