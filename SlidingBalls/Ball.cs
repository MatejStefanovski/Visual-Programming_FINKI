using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingBalls
{
    [Serializable]
    public class Ball
    {
        public Ball(Color color, Point center)
        {
            Color = color;
            Center = center;
        }

        public Color Color { get; set; }
        public int Radius { get; set; } = 30;
        public Point Center { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X-Radius, Center.Y-Radius, 2*Radius, 2*Radius);
            b.Dispose();
        }
        public bool Touches(Ball b)
        {
            double temp = Math.Sqrt(Math.Pow((Center.X - b.Center.X), 2) + Math.Pow((Center.Y - b.Center.Y), 2));
            if (temp <= Radius * 2)
            {
                return true;
            }
            return false;
        }
        public bool Touches(Point p)
        {
            double temp = Math.Sqrt(Math.Pow((Center.X - p.X), 2) + Math.Pow((Center.Y - p.Y), 2));
            if (temp < Radius)
            {
                return true;
            }
            return false;
        }
        public bool OutOfBounds(int width, int height)
        {
            if (Center.X - Radius < 0 || Center.X + Radius > width)
            {
                return true;
            }
            if (Center.Y-Radius < 0 || Center.Y+Radius > height)
            {
                return true;
            }
            return false;
        }
    }
}
