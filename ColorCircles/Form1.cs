using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorCircles
{
    public partial class Form1 : Form
    {
        Scene scene;
        bool firstPoint;
        Point First;
        Point Current;
        Color color;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            firstPoint = false;
            First = new Point();
            Current = new Point();
            color = Color.Green;
            DoubleBuffered = true;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
            if (firstPoint)
            {
                int dist = (int)Math.Sqrt(Math.Pow(First.X - Current.X, 2) + Math.Pow(First.Y - Current.Y, 2));
                Pen p = new Pen(color, 3);
                p.DashStyle = DashStyle.Dot;
                e.Graphics.DrawEllipse(p, First.X - dist, First.Y - dist, 2 * dist, 2 * dist);
                p.Dispose();
            }
        }
        public void UpdateStatus()
        {
            int t = scene.Balls.Count;
            string temp = "Balls: " + t;
            toolStripStatusLabel1.Text = temp;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            bool flag = false;
            foreach (Ball b in scene.Balls)
            {
                if (b.Contains(e.Location))
                {
                    b.Selected = !b.Selected;
                    flag = true;
                }
            }
            if (flag)
            {
                return;
            }
            if (!firstPoint)
            {
                firstPoint = true;
                First = e.Location;
            }
            else
            {
                firstPoint = false;
                int dist = (int)Math.Sqrt(Math.Pow(First.X - e.Location.X, 2) + Math.Pow(First.Y - e.Location.Y, 2));
                Ball b = new Ball(First, dist, color);
                scene.AddBall(b);

            }
            UpdateStatus();
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Current = e.Location;
            Invalidate();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                color=dlg.Color;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<Ball> temp = new List<Ball>();
                foreach (Ball b in scene.Balls)
                {
                    if (b.Selected == true)
                    {
                        temp.Add(b);
                    }
                }
                foreach (Ball b in temp)
                {
                    scene.Balls.Remove(b);
                }
            }
            UpdateStatus();
            Invalidate();
        }
    }
}
