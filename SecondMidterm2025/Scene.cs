using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondMidterm2025
{
    [Serializable]
    public class Scene
    {
        public List<Ball> Balls { get; set; }

        public int numBalls { get; set; }

        public Scene()
        {
            Balls = new List<Ball>();
            numBalls = 0;
        }

        public void AddBall(Ball b)
        {
            Balls.Add(b);
            numBalls++;
        }

        public void Draw(Graphics g)
        {
            foreach (Ball b in Balls)
            {
                b.Draw(g);
            }
        }
        public void Move(int width, int height)
        {
            foreach (Ball b in Balls)
            {
                b.Move();

                if (b.X - b.Radius <= 0 || b.X + b.Radius >= width)
                    b.dx *= -1;

                if (b.Y - b.Radius <= 0 || b.Y + b.Radius >= height)
                    b.dy *= -1;
            }

            HandleCollisions();
        }

        public void HandleCollisions()
        {
            for (int i = 0; i < Balls.Count; i++)
            {
                for (int j = i + 1; j < Balls.Count; j++)
                {
                    if (Balls[i].Collides(Balls[j]))
                    {
                        Ball a = Balls[i];
                        Ball b = Balls[j];

                        if (a.Color == Color.Black)
                        {
                            Balls.Remove(b);
                            numBalls--;
                            return;
                        }
                        if (b.Color == Color.Black)
                        {
                            Balls.Remove(a);
                            numBalls--;
                            return;
                        }
                        if (a.Color == b.Color && a.Color!=Color.Black && b.Color!=Color.Black)
                        {
                            Ball bigger = null;
                            if (a.Radius > b.Radius)
                            {
                                bigger = new Ball(
                                (a.X + b.X) / 2,
                                (a.Y + b.Y) / 2,
                                a.Color,
                                a.dx,
                                a.dy
                                );
                                bigger.Radius = a.Radius + 5;
                            }
                            else if (a.Radius <= b.Radius)
                            {
                                bigger = new Ball(
                                (a.X + b.X) / 2,
                                (a.Y + b.Y) / 2,
                                b.Color,
                                a.dx,
                                a.dy
                                );
                                bigger.Radius = b.Radius + 5;
                            }
                            Balls.RemoveAt(j);
                            Balls.RemoveAt(i);
                            if (bigger.Radius < 50)
                            {
                                Balls.Add(bigger);
                            }
                            else
                            {
                                bigger.Color = Color.Black;
                                bigger.dx = 0;
                                bigger.dy = 0;
                                Balls.Add(bigger);
                            }
                            numBalls--;
                            return;
                        }
                    }
                }
            }
        }

        public int RedBalls()
        {
            return Balls.Count(b => b.Color == Color.Red);
        }

        public int BlueBalls()
        {
            return Balls.Count(b => b.Color == Color.Blue);
        }
    }
}
