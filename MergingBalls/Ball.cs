using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergingBalls
{
    [Serializable]
    public class Ball
    {
        public Ball(Color color, Point center)
        {
            Raduis = 25;
            Color = color;
            Center = center;
            dx = 0;
            dy = 0;
            black = false;
        }

        public int Raduis { get; set; }
        public Color Color { get; set; }
        public Point Center { get; set; }
        public int dx { get; set; }
        public int dy { get; set; }
        public bool black { get; set; }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X-Raduis, Center.Y-Raduis, 2*Raduis, 2*Raduis);
            b.Dispose();
        }
        public void Move()
        {
            if (!black)
            {
                Center = new Point(Center.X+dx, Center.Y+dy);
            }
        }
        public void HitWall(int width, int height)
        {
            if (Center.X>width-50 || Center.X < 50)
            {
                dx = -dx;
            }
            if (Center.Y > height - 50 || Center.Y < 50)
            {
                dy = -dy;
            }
        }
        public bool isHit(Ball b)
        {
            double temp = Math.Sqrt(Math.Pow(Center.X - b.Center.X, 2) + Math.Pow(Center.Y - b.Center.Y, 2));
            if (temp < Raduis + b.Raduis)
            {
                return true;
            }
            return false;
        }
    }
}
