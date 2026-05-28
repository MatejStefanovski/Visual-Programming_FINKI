using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyingBalls
{
    public partial class Form1 : Form
    {
        Scene scene;
        int hit;
        int miss;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            DoubleBuffered = true;
            hit = 0;
            miss = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        public void UpdateStatus()
        {
            toolStripStatusLabel1.Text = "Balls Hit: " + hit;
            toolStripStatusLabel2.Text = "Balls Miss: " + miss;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Ball> fordelete = new List<Ball>();
            foreach (Ball b in scene.Balls)
            {
                b.Move();
                //b.HitWall(this.Width, this.Height);
                if (b.Center.X > this.Width - 20)
                {
                    miss++;
                    fordelete.Add(b);
                }
            }
            foreach (Ball b in fordelete)
            {
                scene.Balls.Remove(b);
            }
            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int y = r.Next(50, this.Height-50);
            Ball b = new Ball(25, Color.Red, new Point(0, y));
            scene.AddBall(b);
            int dd = r.Next(2);
            if (dd == 0)
            {
                b.dx = 5;
            }
            else if (dd == 1)
            {
                b.dx = 10;
            }
            UpdateStatus();
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            List<Ball> forDelete = new List<Ball>();
            bool flag = false;
            foreach (Ball b in scene.Balls)
            {
                if (b.isHit(e.Location))
                {
                    forDelete.Add(b);
                    flag = true;
                    hit++;
                }
            }
            foreach (Ball b in forDelete)
            {
                scene.Balls.Remove(b);
            }
            UpdateStatus();
            Invalidate();
        }
    }
}
