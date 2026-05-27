using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsOnKeyMove
{
    public partial class Form1 : Form
    {
        Scene scene;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Ball> forDelete = new List<Ball>();
            foreach (Ball b in scene.Balls)
            {
                if (b.Radius < 50)
                {
                    b.Radius += 5;
                    if (b.Radius > 50)
                    {
                        b.Radius = 50;
                    }
                }
                foreach (Ball b2 in scene.Balls)
                {
                    if (b!=b2 && b.isHit(b2))
                    {
                        forDelete.Add(b);
                        forDelete.Add(b2);
                    }
                }
            }
            foreach (Ball b in forDelete)
            {
                scene.Balls.Remove(b);
            }
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
                Invalidate();
                return;
            }
            Random r = new Random();
            int x = r.Next(10, 30);
            Ball ball = new Ball(Color.Red, x, e.Location);
            scene.AddBall(ball);
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                foreach (Ball b in scene.Balls)
                {
                    if (b.Selected)
                    {
                        int x = b.Center.X;
                        int y = b.Center.Y - 10;
                        b.Center = new Point(x, y);
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                foreach (Ball b in scene.Balls)
                {
                    if (b.Selected)
                    {
                        int x = b.Center.X;
                        int y = b.Center.Y + 10;
                        b.Center = new Point(x, y);
                    }
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                foreach (Ball b in scene.Balls)
                {
                    if (b.Selected)
                    {
                        int x = b.Center.X - 10;
                        int y = b.Center.Y;
                        b.Center = new Point(x, y);
                    }
                }
            }
            else
            {
                foreach (Ball b in scene.Balls)
                {
                    if (b.Selected)
                    {
                        int x = b.Center.X + 10;
                        int y = b.Center.Y;
                        b.Center = new Point(x, y);
                    }
                }
            }
            List<Ball> forDelete = new List<Ball>();
            foreach (Ball b in scene.Balls)
            {
                foreach (Ball b2 in scene.Balls)
                {
                    if (b != b2 && b.isHit(b2))
                    {
                        forDelete.Add(b);
                        forDelete.Add(b2);
                    }
                }
            }
            foreach (Ball b in forDelete)
            {
                scene.Balls.Remove(b);
            }
            Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, scene);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene = new Scene();
            Invalidate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                scene = (Scene)bf.Deserialize(fs);
                Invalidate();
            }
        }
    }
}
