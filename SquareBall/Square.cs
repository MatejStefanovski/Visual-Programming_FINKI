using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareBall
{
    public class Square
    {
        public Square(int side, Color color, Point topLeft)
        {
            this.side = side;
            Color = color;
            TopLeft = topLeft;
        }

        public int side { get; set; }
        public Color Color { get; set; }
        public Point TopLeft { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillRectangle(b, TopLeft.X - side / 2, TopLeft.Y - side / 2, side, side);
        }
    }
}
