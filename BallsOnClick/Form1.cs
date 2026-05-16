using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsOnClick
{
    public partial class Form1 : Form
    {
        Scene scene;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            DoubleBuffered = true;
            timer1.Interval = 50;
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
                    if(ball.moving == true)
                    {
                        ball.moving = false;
                        return;
                    }
                    ball.moving=true;
                    ball.dx = 0;
                    ball.dy = 0;
                    int x = r.Next(4);
                    if (x == 0)
                    {
                        ball.dx = -5;
                    }
                    else if (x == 1)
                    {
                        ball.dx = 5;
                    }
                    else if (x == 2)
                    {
                        ball.dy = -5;
                    }
                    else
                    {
                        ball.dy = 5;
                    }
                    return;
                }
            }
            int t = r.Next(2);
            Ball b = null;
            if (t == 0)
            {
                b = new Ball(Color.Red, e.Location);
            }
            else
            {
                b = new Ball(Color.Blue, e.Location);
            }
            scene.Balls.Add(b);
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(Ball b in scene.Balls)
            {
                b.Move(this.Width, this.Height);
            }
            Invalidate();
        }
    }
}
