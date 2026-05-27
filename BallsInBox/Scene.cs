using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsInBox
{
    [Serializable]
    public class Scene
    {
        public List<Ball> Balls { get; set; }
        public List<Line> Lines { get; set; }
        public Scene()
        {
            Balls = new List<Ball>();
            Lines = new List<Line>();
        }
        public void AddBall(Ball b)
        {
            Balls.Add(b);
        }
        public void AddLine(Line l)
        {
            Lines.Add(l);
        }
        public void Draw(Graphics g)
        {
            foreach (Ball b in Balls)
            {
                b.Draw(g);
            }
            foreach (Line line in Lines)
            {
                line.Draw(g);
            }
        }

    }
}
