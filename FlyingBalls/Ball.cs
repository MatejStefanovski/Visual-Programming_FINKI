using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingBalls
{
    public class Ball
    {
        public Ball(int radius, Color color, Point center)
        {
            Radius = radius;
            Color = color;
            Center = center;
        }

        public int Radius { get; set; }
        public Color Color { get; set; }
        public Point Center { get; set; }
        public int dx { get; set; }
        public int dy { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X-Radius, Center.Y-Radius, 2*Radius, 2*Radius);
            b.Dispose();
        }
        public bool isHit(Point p)
        {
            double temp = Math.Sqrt(Math.Pow(Center.X - p.X, 2) + Math.Pow(Center.Y - p.Y, 2));
            if (temp < Radius)
            {
                return true;
            }
            return false;
        }
        public void Move()
        {
            Center = new Point(Center.X + dx, Center.Y + dy);
        }
        public void HitWall(int width, int height)
        {
            if (Center.X<20 || Center.X > width - 50)
            {
                dx = -dx;
            }
            if (Center.Y < 20 || Center.Y > height - 50)
            {
                dy = -dy;
            }
        }
    }
}
