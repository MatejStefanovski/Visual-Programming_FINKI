using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingRectangles
{
    [Serializable]
    public class RectangleShape
    {
        public RectangleShape(Color color, Point topleft)
        {
            Color = color;
            width = 100;
            height = 50;
            rotating = false;
            moving = false;
            TopLeft = topleft;
        }

        public int width { get; set; }
        public int height { get; set; }
        public Color Color { get; set; }
        public bool rotating { get; set; }
        public bool moving { get; set; }
        public Point TopLeft { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillRectangle(b, TopLeft.X-50, TopLeft.Y-25, width, height);
            b.Dispose();
        }
        public bool isHit(Point point)
        {
            Rectangle r = new Rectangle(TopLeft.X-50, TopLeft.Y-25, width, height);
            return r.Contains(point);
        }
        public void Move()
        {
            if (!moving)
            {
                return;
            }
            TopLeft = new Point(TopLeft.X, TopLeft.Y+height);
        }
        public void Rotate()
        {
            if (!rotating)
            {
                return;
            }
            int temp = height;
            height = width;
            width = temp;
        }
    }
}
