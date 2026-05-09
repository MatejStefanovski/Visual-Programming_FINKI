using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondMidterm2025
{
    [Serializable]
    public class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius = 25;
        public Color Color;
        public bool IsBlackHole = false;

        public Ball(int x, int y, Color color, int dx, int dy)
        {
            X = x;
            Y = y;
            Color=color;
            this.dx = dx;
            this.dy = dy;
        }

        public int dx { get; set; }
        public int dy { get; set; }

        public void Draw(Graphics g)
        {
            Brush b;

            if (IsBlackHole)
            {
                b = Brushes.Black;
            }
            else
            {
                b = new SolidBrush(Color);
            }
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            b.Dispose();
        }
        public void Move()
        {
            if (dx!=0)
                X += dx;
            else
                Y += dy;
        }

        public bool Collides(Ball other)
        {
            double distance = Math.Sqrt((X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y));
            return distance <= Radius + other.Radius;
        }
    }
}
