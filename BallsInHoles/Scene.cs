using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsInHoles
{
    [Serializable]
    public class Scene
    {
        public List<Ball> Balls;
        public List<Hole> Holes;

        public Rectangle Bounds;

        [NonSerialized]
        Random rnd;

        public Scene(Rectangle bounds)
        {
            Bounds = bounds;

            Balls = new List<Ball>();
            Holes = new List<Hole>();

            rnd = new Random();

            GenerateHoles();
        }

        public void AddBall(Point p, Color color)
        {
            Balls.Add(new Ball(p, color, rnd));
        }

        public void Move()
        {
            foreach (Ball b in Balls)
            {
                b.Move(Bounds);
            }

            CheckHoles();
        }

        public void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Black, Bounds);

            foreach (Hole h in Holes)
            {
                h.Draw(g);
            }

            foreach (Ball b in Balls)
            {
                b.Draw(g);
            }
        }

        private void CheckHoles()
        {
            List<Ball> remove = new List<Ball>();

            foreach (Ball b in Balls)
            {
                foreach (Hole h in Holes)
                {
                    double dx = b.Center.X - h.Center.X;
                    double dy = b.Center.Y - h.Center.Y;

                    double dist = Math.Sqrt(dx * dx + dy * dy);

                    if (dist <= Ball.RADIUS)
                    {
                        h.Counter++;
                        remove.Add(b);
                        break;
                    }
                }
            }

            foreach (Ball b in remove)
            {
                Balls.Remove(b);
            }
        }

        public void GenerateHoles()
        {
            Holes.Clear();

            while (Holes.Count < 5)
            {
                Point p = new Point(
                    rnd.Next(
                        Bounds.Left + 50,
                        Bounds.Right - 50
                    ),
                    rnd.Next(
                        Bounds.Top + 50,
                        Bounds.Bottom - 50
                    )
                );

                bool overlap = false;

                foreach (Hole h in Holes)
                {
                    double dx = p.X - h.Center.X;
                    double dy = p.Y - h.Center.Y;

                    double dist =
                        Math.Sqrt(dx * dx + dy * dy);

                    if (dist < 2 * Hole.RADIUS)
                    {
                        overlap = true;
                        break;
                    }
                }

                if (!overlap)
                {
                    Holes.Add(new Hole(p));
                }
            }
        }
    }
}
