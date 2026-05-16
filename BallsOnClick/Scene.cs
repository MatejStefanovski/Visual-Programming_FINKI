using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsOnClick
{
    public class Scene
    {
        public List<Ball> Balls { get; set; }
        public Scene()
        {
            Balls = new List<Ball>();
        }
        public void AddBall(Ball ball)
        {
            Balls.Add(ball);
        }
        public void Draw(Graphics g)
        {
            foreach (Ball ball in Balls)
            {
                ball.Draw(g);
            }
        }
    }
}
