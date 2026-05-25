using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorRectangles_V2
{
    public class RectangleForm
    {
        public RectangleForm(Color color, int width, int height)
        {
            Color = color;
            this.width = width;
            this.height = height;
        }
        public Color Color { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Point TopLeft { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillRectangle(b, TopLeft.X, TopLeft.Y, width, height);
            b.Dispose();
        }
    }
}
