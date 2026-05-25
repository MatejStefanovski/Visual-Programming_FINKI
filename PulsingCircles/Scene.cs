using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulsingCircles
{
    public class Scene
    {
        List<Ball> balls = new List<Ball>();
        public Scene()
        {
            balls = new List<Ball>();
        }
        public void AddBall(Ball ball)
        {
            balls.Add(ball);
        }
        public void Draw(Graphics g)
        {
            foreach (Ball b in balls)
            {
                b.Draw(g);
            }
        }
    }
}
