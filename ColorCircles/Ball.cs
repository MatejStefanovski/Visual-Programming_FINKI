using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorCircles
{
    public class Ball
    {
        public Ball(Point center, int radius, Color color)
        {
            Center = center;
            Radius = radius;
            Color = color;
            Selected = false;
        }

        public Point Center { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }
        public bool Selected { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
            if (Selected)
            {
                Pen p = new Pen(Color.Red, 3);
                g.DrawEllipse(p, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
                p.Dispose();
            }
            b.Dispose();
        }
        public bool Contains(Point p)
        {
            double dist = Math.Sqrt(Math.Pow(Center.X - p.X, 2) + Math.Pow(Center.Y - p.Y, 2));
            return dist <= Radius;
        }
    }
}
