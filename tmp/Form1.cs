using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tmp
{
    public partial class Form1 : Form
    {
        Scene scene;
        bool black;
        Point cursor;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            DoubleBuffered = true;
            black = false;
            cursor = new Point();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!black)
            {
                Ball b = new Ball(e.Location, 25, Color.Black);
                black = true;
                scene.Balls.Add(b);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int t = r.Next(4);
            int x = r.Next(50, this.Width - 50);
            int y = r.Next(50, this.Height - 50);
            Ball b = new Ball(new Point(x, y), 25, Color.Red);
            if (t == 0)
            {
                b.dx = 5;
            }
            else if (t==1)
            {
                b.dx = -5;
            }
            else if (t == 2)
            {
                b.dy = 5;
            }
            else
            {
                b.dy = -5;
            }
            scene.AddBall(b);
            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (Ball ball in scene.Balls)
            {
                ball.Move();
                ball.HitWall(this.Width, this.Height);
            }
            HitBall();
            Invalidate();
        }
        public void HitBall()
        {
            if (!black)
            {
                return;
            }
            Ball bl = null;
            foreach(Ball ball in scene.Balls)
            {
                if (ball.Color == Color.Black)
                {
                    bl = ball;
                    break;
                }
            }
            List<Ball> forDelete = new List<Ball>();
            foreach(Ball b in scene.Balls)
            {
                if (b!=bl && b.isHit(bl))
                {
                    if (bl.Radius < 50)
                    {
                        bl.Radius += 5;
                    }
                    forDelete.Add(b);
                }
            }
            foreach (Ball b in forDelete)
            {
                scene.Balls.Remove(b);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = e.Location;
            if (black)
            {
                Ball b = null;
                foreach(Ball ball in scene.Balls)
                {
                    if (ball.Color == Color.Black)
                    {
                        b=ball;
                        break;
                    }
                }
                b.Center = cursor;
            }
            HitBall();
            Invalidate();
        }
    }
}
