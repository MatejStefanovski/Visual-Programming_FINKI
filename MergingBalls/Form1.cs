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

namespace MergingBalls
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

        private void Form1_MouseClick(object sender, MouseEventArgs e)
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
            int c = r.Next(2);
            if (c == 0)
            {
                b.Color = Color.Blue;
            }
            else
            {
                b.Color = Color.Red;
            }
            scene.AddBall(b);
            UpdateStatus();
            Invalidate();
        }
        public void UpdateStatus()
        {
            int count = 0;
            foreach (Ball b in scene.Balls)
            {
                count++;
            }
            toolStripStatusLabel1.Text = count.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Ball> forDelete = new List<Ball>();
            foreach (Ball b in scene.Balls)
            {
                b.Move();
                b.HitWall(this.Width, this.Height);
                foreach (Ball b2 in scene.Balls)
                {
                    if (b2 != b && b.isHit(b2))
                    {
                        if (b.black)
                        {
                            forDelete.Add(b2);
                            continue;
                        }
                        if (b2.black)
                        {
                            forDelete.Add(b);
                            continue;
                        }
                        if (b2.Color == b.Color)
                        {
                            if (b.Raduis > b2.Raduis)
                            {
                                b.Raduis += 5;
                                forDelete.Add(b2);
                            }
                            else
                            {
                                b2.Raduis += 5;
                                forDelete.Add(b);
                            }
                        }
                    }
                }
                if (b.Raduis >= 50)
                {
                    b.Color = Color.Black;
                    b.Raduis = 50;
                    b.black = true;
                    b.dx = 0;
                    b.dy = 0;
                }
            }
            foreach (Ball b in forDelete)
            {
                scene.Balls.Remove(b);
            }
            UpdateStatus();
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

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
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
            scene=new Scene();
            UpdateStatus();
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
