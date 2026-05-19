using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2025
{
    [Serializable]
    public class Ball
    {
        public Ball(Color color, Point center, int ddx, int ddy)
        {
            Color = color;
            Center = center;
            Radius = 25;
            dx = ddx;
            dy = ddy;
            Energy = 15;
        }

        public Color Color { get; set; }
        public int Radius { get; set; }
        public Point Center { get; set; }
        public int Energy { get; set; }
        public int dx { get; set; }
        public int dy { get; set; }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
            b.Dispose();
        }
        public void Move()
        {
            Center = new Point(Center.X + dx, Center.Y + dy);
        }
        public bool IsHit(Ball b)
        {
            double temp = Math.Sqrt(Math.Pow((Center.X - b.Center.X), 2) + Math.Pow((Center.Y - b.Center.Y), 2));
            if (temp < 2 * Radius)
            {
                return true;
            }
            return false;
        }
        public void HitWall(int width, int height)
        {
            if (Center.X <= 0 || Center.X >= width)
            {
                dx = -dx;
                if (Energy >= 5)
                {
                    Energy -= 5;
                }
                if (Energy == 0)
                {
                    Energy = -1;
                    Color = Color.Gray;
                    dx = 0;
                    dy = 0;
                }
            }
            if (Center.Y <= 0 || Center.Y >= height)
            {
                dy = -dy;
                if (Energy >= 5)
                {
                    Energy -= 5;
                }
                if (Energy == 0)
                {
                    Energy = -1;
                    Color = Color.Gray;
                    dx = 0;
                    dy = 0;
                }
            }
        }
    }
}
