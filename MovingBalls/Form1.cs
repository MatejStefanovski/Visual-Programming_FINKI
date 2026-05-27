using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingBalls
{
    public partial class Form1 : Form
    {
        Scene scene;
        bool firstclicked;
        Point First;
        Point Current;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            First = new Point();
            Current = new Point();
            firstclicked = false;
            DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
            if (!firstclicked)
            {
                return;
            }
            Pen p = new Pen(Color.Black, 2);
            int rad = (int)Math.Sqrt(Math.Pow(First.X - Current.X, 2) + Math.Pow(First.Y - Current.Y, 2));
            e.Graphics.DrawEllipse(p, First.X-rad, First.Y-rad, 2 * rad, 2 * rad);
            p.Dispose();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Current = e.Location;
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            bool flag = false;
            foreach (Ball b in scene.Balls)
            {
                if (b.isHit(e.Location))
                {
                    b.Selected = !b.Selected;
                    flag = true;
                }
            }
            if (flag)
            {
                return;
            }
            if (!firstclicked)
            {
                First = e.Location;
                firstclicked = true;
            }
            else
            {
                Current = e.Location;
                int rad = (int)Math.Sqrt(Math.Pow(First.X - Current.X, 2) + Math.Pow(First.Y - Current.Y, 2));
                Ball b = new Ball(rad, First, Color.Red);
                scene.AddBall(b);
                firstclicked = false;
                Random r = new Random();
                int x = r.Next(4);
                if (x == 0)
                {
                    b.dx = 5;
                }
                else if (x == 1)
                {
                    b.dx = -5;
                }
                else if (x == 2)
                {
                    b.dy = 5;
                }
                else
                {
                    b.dy = -5;
                }
            }
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(Ball b in scene.Balls)
            {
                if (b.Selected)
                {
                    b.Move();
                    b.HitWall(this.Width, this.Height);
                }
            }
        }
    }
}
