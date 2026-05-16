using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsInHoles
{
    [Serializable]
    public class Ball
    {
        public static int RADIUS = 25;

        public Point Center;
        public int Dx;
        public int Dy;
        public Color Color;

        public Ball(Point center, Color color, Random rnd)
        {
            Center = center;
            Color = color;

            Dx = rnd.Next(0, 2) == 0 ? -1 : 1;
            Dy = rnd.Next(0, 2) == 0 ? -1 : 1;
        }

        public void Move(Rectangle bounds)
        {
            Center = new Point(Center.X + Dx * 10, Center.Y + Dy * 10);

            if (Center.X - RADIUS <= bounds.Left ||
                Center.X + RADIUS >= bounds.Right)
            {
                Dx *= -1;
            }

            if (Center.Y - RADIUS <= bounds.Top ||
                Center.Y + RADIUS >= bounds.Bottom)
            {
                Dy *= -1;
            }
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X - RADIUS, Center.Y - RADIUS, 2 * RADIUS, 2 * RADIUS);
            b.Dispose();
        }
    }
}
