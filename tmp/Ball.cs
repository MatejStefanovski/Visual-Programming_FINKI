using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmp
{
    public class Ball
    {
        public Ball(Point center, int radius, Color color)
        {
            Center = center;
            Radius = radius;
            Color = color;
            dx = 0;
            dy = 0;
        }

        public Point Center { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }
        public int dx { get; set; }
        public int dy { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X-Radius, Center.Y-Radius, 2*Radius, 2*Radius);
            b.Dispose();
        }
        public bool isHit(Ball b)
        {
            double temp = Math.Sqrt(Math.Pow(Center.X-b.Center.X, 2)+Math.Pow(Center.Y-b.Center.Y, 2));
            if (temp < 2*Radius)
            {
                return true;
            }
            return false;
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

        public void HitWall(int width, int height)
        {
            if (Center.X < 20 || Center.X > width - 50)
            {
                dx = -dx;
            }
            if (Center.Y < 50 || Center.Y > height - 50)
            {
                dy = -dy;
            }
        }

        public void Move()
        {
            Center = new Point(Center.X + dx, Center.Y + dy);
        }
    }
}
