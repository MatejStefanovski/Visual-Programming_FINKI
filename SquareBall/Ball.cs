using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareBall
{
    public class Ball
    {
        public Ball(Point center, int radius, Color color)
        {
            Center = center;
            Radius = radius;
            Color = color;
        }

        public Point Center { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2*Radius, 2 * Radius);
            b.Dispose();
        }
    }
}
