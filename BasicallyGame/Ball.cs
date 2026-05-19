using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicallyGame
{
    [Serializable]
    public class Ball
    {
        public Ball( Color color, Point center)
        {
            Radius = 25;
            Color = color;
            Center = center;
        }

        public int Radius { get; set; }
        public Color Color { get; set; }
        public Point Center { get; set; }
        public int dx { get; set; }
        public int dy { get; set; }
        public bool Paused { get; set; } = false;
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
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
        public void Move(int width, int height)
        {
            if (Paused)
            {
                return;
            }
            if (Center.X+dx <= 0 || Center.X+dx >= width)
            {
                dx = -dx;
            }
            if (Center.Y + dy <= 0 || Center.Y + dy >= height)
            {
                dy = -dy;
            }
            Center = new Point(Center.X+dx, Center.Y+dy);
        }
    }
}
