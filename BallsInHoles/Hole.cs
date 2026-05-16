using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsInHoles
{
    public class Hole
    {
        public static int RADIUS = 30;

        public Point Center;
        public int Counter;

        public Hole(Point center)
        {
            Center = center;
            Counter = 0;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Black, Center.X - RADIUS, Center.Y - RADIUS, 2 * RADIUS, 2 * RADIUS);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(Counter.ToString(), new Font("Arial", 16),Brushes.White, Center, sf);
        }
    }
}
