using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingBalls
{
    [Serializable]
    public class Scene
    {
        public List<Ball> Balls { get; set; }
        int touched;
        int width;
        int height;
        int dx;
        int dy;
        int MoveSpeed = 10;
        public Scene(int width, int height)
        {
            this.width = width;
            this.height = height;
            touched = -1;
            dx = 0;
            dy = 0;
            Balls = new List<Ball>();
        }
        public void AddBall(Point p)
        {
            Random r = new Random();
            int x = r.Next(2);
            Ball ball = null;
            if (x == 0)
            {
                ball = new Ball(Color.Blue, p);
            }
            else
            {
                ball = new Ball(Color.Green, p);
            }
            Balls.Add(ball);
        }
        public void AddRed(Point p)
        {
            Ball ball = new Ball(Color.Red, p);
            Balls.Add(ball);
        }
        public void Draw(Graphics g)
        {
            foreach (Ball b in Balls)
            {
                b.Draw(g);
            }
        }
        public bool Click(Point p)
        {
            if (touched != -1)
            {
                return false;
            }
            for (int i = 0; i < Balls.Count; i++)
            {
                if (Balls[i].Touches(p))
                {
                    touched = i;
                    break;
                }
            }
            if (touched != -1)
            {
                dx = 0;
                dy = 0;
                bool moving = Balls[touched].Color.Equals(Color.Red);
                if (moving)
                {
                    Random r = new Random();
                    int x = r.Next(4);
                    if (x == 0)
                    {
                        dx = MoveSpeed;
                    }
                    if (x == 1)
                    {
                        dx = -MoveSpeed;
                    }
                    if (x == 2)
                    {
                        dy = MoveSpeed;
                    }
                    if (x == 3)
                    {
                        dy = -MoveSpeed;
                    }
                }
                return moving;
            }
            return false;
        }
        public bool Move()
        {
            Balls[touched].Center = new Point(Balls[touched].Center.X+dx, Balls[touched].Center.Y + dy);
            for (int i=Balls.Count-1; i>=0; i--)
            {
                if (Balls[touched].Touches(Balls[i]))
                {
                    Balls.RemoveAt(i);
                }
                if (i < touched)
                {
                    touched--;
                }
            }
            if (Balls[touched].OutOfBounds(width, height))
            {
                Balls.RemoveAt(touched);
                touched = -1;
                dx = 0;
                dy = 0;
                return true;
            }
            return false;
        }
    }
}
