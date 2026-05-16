using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHole
{
    public class Ball
    {
        public int Radius = 25;
        public Point Center;
        public Color Color;
        public int dx;
        public int dy;
        public bool moving;
        public Ball(Point center, Color color)
        {
            Center = center;
            Color = color;
            moving = true;
            dx = 0;
            dy = 0;
        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
            b.Dispose();
        }
        public bool isHit(Point point) 
        {
            double temp = Math.Sqrt(Math.Pow((Center.X - point.X), 2) + Math.Pow((Center.Y - point.Y), 2));
            if (temp <= Radius)
            {
                return true;
            }
            return false;
        }
        public bool isHit(Ball b)
        {
            double temp = Math.Sqrt(Math.Pow((Center.X - b.Center.X), 2) + Math.Pow((Center.Y - b.Center.Y), 2));
            if (temp <= 2*Radius)
            {
                return true;
            }
            return false;
        }
        public void Move(int height, int width)
        {
            if (moving)
            {
                if (dx != 0)
                {
                    Center = new Point(Center.X + dx, Center.Y);
                }
                else
                {
                    Center = new Point(Center.X, Center.Y + dy);
                }
                if (Center.X - Radius < 0 || Center.X + Radius > width)
                {
                    dx = -dx;
                }
                if (Center.Y - Radius < 0 || Center.Y + Radius > height)
                {
                    dy = -dy;
                }
            }
        }
    }
}
