using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ispit2024
{
    [Serializable]
    public class Ball
    {
        public Ball(int radius, Color color, Point center)
        {
            Radius = radius;
            Color = color;
            Center = center;
            Selected = false;
        }

        public int Radius { get; set; }
        public Color Color { get; set; }
        public Point Center { get; set; }
        public bool Selected { get; set; }
        public void Draw(Graphics g) 
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X-Radius, Center.Y-Radius, 2*Radius, 2*Radius);
            if (Selected)
            {
                Pen p = new Pen(Color.Black, 3);
                g.DrawEllipse(p, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                p.Dispose();
            }
            b.Dispose();
        }
        public bool IsHit(Ball b)
        {
            double r = Math.Sqrt(Math.Pow((Center.X - b.Center.X), 2) + Math.Pow((Center.Y - b.Center.Y), 2));
            if (r < b.Radius + Radius)
            {
                return true;
            }
            return false;
        }
        public bool IsHit(Point p)
        {
            double r = Math.Sqrt(Math.Pow((Center.X - p.X), 2) + Math.Pow((Center.Y - p.Y), 2));
            if (r < Radius)
            {
                return true;
            }
            return false;
        }
    }
}
