using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsInBox
{
    public partial class Form1 : Form
    {
        Scene scene;
        bool first = false;
        Point p1;
        Point Current;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            DoubleBuffered = true;
            p1 = new Point();
            Current = new Point();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
            if (first)
            {
                Pen p = new Pen(Color.Black, 3);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                e.Graphics.DrawLine(p, p1, Current);
                p.Dispose();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Ball b = new Ball(Color.Red, e.Location);
                Random r = new Random();
                int t = r.Next(4);
                if (t == 0)
                {
                    b.dx = 5;
                }
                else if (t == 1)
                {
                    b.dy = 5;
                }
                else if (t == 2)
                {
                    b.dx = -5;
                }
                else
                {
                    b.dy = -5;
                }
                scene.AddBall(b);
            }
            else
            {
                if (!first)
                {
                    first = true;
                    p1 = e.Location;
                }
                else
                {
                    Current = e.Location;
                    Line l = new Line(p1, Current);
                    scene.AddLine(l);
                    first = false;
                }
            }
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Ball b in scene.Balls)
            {
                b.Move();
                b.HitWall(this.Width, this.Height);
                foreach (Line l in scene.Lines)
                {
                    if (l.IsHit(b))
                    {
                        b.dx = -b.dx;
                        b.dy = -b.dy;
                        b.Number++;
                    }
                }
            }
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Current = e.Location;
            Invalidate();
        }
    }
}
