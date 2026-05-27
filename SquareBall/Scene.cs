using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareBall
{
    public class Scene
    {
        public List<Square> Squares { get; set; }
        public List<Ball> Balls { get; set; }
        public Scene()
        {
            Squares = new List<Square>();
            Balls = new List<Ball>();
        }
        public void Draw(Graphics g)
        {
            foreach (Square s in Squares)
            {
                s.Draw(g);
            }
            foreach (Ball b in Balls)
            {
                b.Draw(g);
            }
        }
        public void AddSquare(Square square)
        {
            Squares.Add(square);
        }
        public void AddBall(Ball ball)
        {
            Balls.Add(ball);
        }
    }
}
