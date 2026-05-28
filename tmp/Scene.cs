using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmp
{
    public class Scene
    {
        public List<Ball> Balls { get; set; }
        public Scene() 
        {
            Balls = new List<Ball>();
        }
        public void AddBall(Ball b)
        {
            Balls.Add(b);
        }
        public void Draw(Graphics g)
        {
            foreach (Ball b in Balls)
            {
                b.Draw(g);
            }
        }
    }
}
