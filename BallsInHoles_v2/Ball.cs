using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsInHoles_v2
{
    [Serializable]
    public class Ball
    {
        public Ball(Color color, int radius, Point center)
        {
            Color = color;
            Radius = radius;
            Center = center;
            Number = 0;
            dx = 0;
            dy = 0;
        }

        public Color Color { get; set; }
        public int Radius { get; set; }
        public Point Center { get; set; }
        public int Number { get; set; }
        public int dx { get; set; }
        public int dy { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X-Radius, Center.Y-Radius, 2*Radius, 2*Radius);
            if (Color == Color.Black)
            {
                Brush b2 = new SolidBrush(Color.White);
                Font f = new Font("Arial", 14);
                g.DrawString(Number.ToString(), f, b2, Center.X - 8, Center.Y - 10);
                b2.Dispose();
            }
            b.Dispose();
        }
        public bool HitBall(Ball ball)
        {
            double temp = Math.Sqrt(Math.Pow(Center.X - ball.Center.X, 2) + Math.Pow(Center.Y - ball.Center.Y, 2));
            if (temp <= Radius + ball.Radius)
            {
                return true;
            }
            return false;
        }
        public void HitWall(int width, int height)
        {
            if (Center.X >= width-50 || Center.X < 50)
            {
                dx = -dx;
            }
            if (Center.Y >= height-50 || Center.Y < 50)
            {
                dy = -dy;
            }
        }
        public void Move()
        {
            Center = new Point(Center.X+dx, Center.Y+dy);
        }
    }
}
