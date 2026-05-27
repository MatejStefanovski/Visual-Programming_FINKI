using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEllipses
{
    public class FormEllipse
    {
        public FormEllipse(Color color, Point topLeft, int w, int h)
        {
            Color = color;
            TopLeft = topLeft;
            width = w;
            height = h;
        }

        public int width { get; set; }
        public int height { get; set; }
        public Color Color { get; set; }
        public Point TopLeft { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, TopLeft.X, TopLeft.Y, width, height);
            b.Dispose();
        }
    }
}
