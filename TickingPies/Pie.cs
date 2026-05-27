using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickingPies
{
    public class Pie
    {
        public Pie(int radius, Point center, Color color)
        {
            Radius = radius;
            Center = center;
            Color = color;
            i = 360;
        }

        public int Radius { get; set; }
        public Point Center { get; set; }
        public Color Color { get; set; }
        public int i { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillPie(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius, 0, i);
            b.Dispose();
        }
    }
}
