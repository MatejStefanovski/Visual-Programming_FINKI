using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorCircles
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
        public void RemoveBall(Ball ball)
        {
            Balls.Remove(ball);
        }
        public void Draw(Graphics g)
        {
            foreach (Ball b in Balls)
            {
                b.Draw(g);
            }
        }
        public void Select(Point p)
        {
            foreach (Ball b in Balls)
            {
                if (b.Contains(p))
                {
                    b.Selected = !b.Selected;
                    return;
                }
            }
        }
        public void DeleteSelected()
        {
            Balls.RemoveAll(x => x.Selected);
        }
    }
}
