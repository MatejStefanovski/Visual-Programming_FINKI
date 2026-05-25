using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulsingCircles
{
    public class Ball
    {
        public Ball(Color color, Point center)
        {
            Color = color;
            Center = center;
            Radius = 30;
        }

        public Color Color { get; set; }
        public Point Center { get; set; }
        public int Radius { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
            b.Dispose();
        }
        public bool isHit(Point point)
        {
            double temp = Math.Sqrt(Math.Pow(Center.X - Radius, 2) +  Math.Pow(Center.Y - Radius, 2));
            if (temp <= Radius)
            {
                return true;
            }
            return false;
        }
    }
}
