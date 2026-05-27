using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsInBox
{
    [Serializable]
    public class Line
    {
        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public Point p1 { get; set; }
        public Point p2 { get; set; }
        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 3);
            g.DrawLine(p, p1, p2);
            p.Dispose();
        }
        public bool IsHit(Ball b)
        {
            Rectangle rect = new Rectangle(
            Math.Min(p1.X, p2.X) - b.Raduis,
            Math.Min(p1.Y, p2.Y) - b.Raduis,
            Math.Abs(p1.X - p2.X) + 2 * b.Raduis,
            Math.Abs(p1.Y - p2.Y) + 2 * b.Raduis);

            return rect.Contains(b.Center);
        }
    }
}
