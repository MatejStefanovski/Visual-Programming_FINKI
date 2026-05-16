using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackHole
{
    public partial class Form1 : Form
    {
        Scene scene;
        int balls;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            timer1.Interval = 50;
            DoubleBuffered = true;
            balls = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Ball b in scene.Balls)
            {
                b.Move(this.Height, this.Width);
            }
            List<Ball> forDelete = new List<Ball>();
            for (int i=0; i<scene.Balls.Count; i++)
            {
                for (int j=i+1; j<scene.Balls.Count; j++)
                {
                    Ball b1 = scene.Balls[i];
                    Ball b2 = scene.Balls[j];
                    if (b1.isHit(b2))
                    {
                        if (b1.Color == Color.Black)
                        {
                            forDelete.Add(b2);
                            
                        }
                        else if (b2.Color == Color.Black)
                        {
                            forDelete.Add(b1);
                        }
                        else if (b1.Color == b2.Color)
                        {
                            if (b1.Radius > b2.Radius)
                            {
                                b1.Radius += 5;
                                forDelete.Add(b2);
                                if (b1.Radius >= 50)
                                {
                                    b1.moving = false;
                                    b1.Color = Color.Black;
                                }
                            }
                            else
                            {
                                b2.Radius += 5;
                                forDelete.Add(b1);
                                if (b2.Radius >= 50)
                                {
                                    b2.moving = false;
                                    b2.Color = Color.Black;
                                }
                            }
                        }
                    }
                }
            }
            for (int i=0; i<forDelete.Count; i++)
            {
                scene.Balls.Remove(forDelete[i]);
            }
            balls-=forDelete.Count;
            toolStripStatusLabel1.Text = balls.ToString();
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Random r = new Random();
            foreach (Ball ball in scene.Balls)
            {
                if (ball.isHit(e.Location))
                {
                    if (ball.moving == true)
                    {
                        ball.moving = false;
                        return;
                    }
                    ball.moving = true;
                    int x = r.Next(4);
                    if (x == 0)
                        ball.dx = 5;
                    else if (x==1)
                        ball.dx = -5;
                    else if (x==2)
                        ball.dy = 5;
                    else
                        ball.dy = -5;
                    return;
                }
            }
            int t = r.Next(2);
            Ball b = null;
            if (t == 0)
            {
                b = new Ball(e.Location, Color.Red);
                balls++;
            }
            else
            {
                b = new Ball(e.Location, Color.Blue);
                balls++;
            }
            toolStripStatusLabel1.Text = balls.ToString();
            scene.Balls.Add(b);
            int x1 = r.Next(4);
            if (x1 == 0)
                b.dx = 5;
            else if (x1 == 1)
                b.dx = -5;
            else if (x1 == 2)
                b.dy = 5;
            else
                b.dy = -5;
            Invalidate();
        }
    }
}
