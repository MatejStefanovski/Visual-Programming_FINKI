using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsOnClick
{
    public class Ball
    {
        public int Radius = 30;
        public Color Color;
        public Point Center;
        public int dx;
        public int dy;
        public bool moving;
        public Ball(Color color, Point center)
        {
            Color = color;
            Center = center;
            dx = 0;
            dy = 0;
            moving = false;
        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
            b.Dispose();
        }
        public bool isHit(Point p)
        {
            double temp = Math.Sqrt(Math.Pow(Center.X - p.X, 2) + Math.Pow(Center.Y - p.Y, 2));
            if (temp <= Radius)
            {
                return true;
            }
            return false;
        }
        public void Move(int width, int height)
        {
            if (moving)
            {
                if (dx != 0)
                {
                    Center = new Point(Center.X + dx, Center.Y);
                }
                else
                {
                    Center = new Point(Center.X, Center.Y + dy);
                }
                if (Center.X - Radius < 0 || Center.X + Radius > width)
                {
                    dx = -dx;
                }
                if (Center.Y - Radius < 0 || Center.Y + Radius > height)
                {
                    dy = -dy;
                }
            }
        }
    }
}
