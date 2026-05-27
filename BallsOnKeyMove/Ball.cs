using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsOnKeyMove
{
    [Serializable]
    public class Ball
    {
        public Ball(Color color, int radius, Point center)
        {
            Color = color;
            Radius = radius;
            Center = center;
            Selected = false;
        }

        public Color Color { get; set; }
        public int Radius { get; set; }
        public Point Center { get; set; }
        public bool Selected { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X-Radius, Center.Y-Radius, 2*Radius, 2*Radius);
            Pen p = new Pen(Color.Black, 3);
            if (Selected)
            {
                g.DrawEllipse(p, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
            }
            p.Dispose();
            b.Dispose();
        }
        public bool isHit(Ball b)
        {
            double t = Math.Sqrt(Math.Pow(Center.X-b.Center.X, 2) + Math.Pow(Center.Y-b.Center.Y, 2));
            if (t <= Radius + b.Radius)
            {
                return true;
            }
            return false;
        }
        public bool isHit(Point p)
        {
            double t = Math.Sqrt(Math.Pow(Center.X - p.X, 2) + Math.Pow(Center.Y - p.Y, 2));
            if (t <= Radius)
            {
                return true;
            }
            return false;
        }
    }
}
