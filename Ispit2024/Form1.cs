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

namespace Ispit2024
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
            if (e.Button == MouseButtons.Left)
            {
                Random r = new Random();
                int x = r.Next(10, 31);
                Ball b = new Ball(x, Color.Red, e.Location);
                scene.AddBall(b);
            }
            else if (e.Button == MouseButtons.Right)
            {
                foreach (Ball b in scene.Balls)
                {
                    if (b.IsHit(e.Location))
                    {
                        b.Selected = !b.Selected;
                        break;
                    }
                }
            }
            Invalidate();
        }
        public void brisi(Ball b)
        {
            List<Ball> forDelete = new List<Ball>();
            foreach(Ball ball in scene.Balls)
            {
                if (ball == b)
                {
                    continue;
                }
                if (b.IsHit(ball))
                {
                    forDelete.Add(ball);
                }
            }
            if (forDelete.Count == 0)
            {
                return;
            }
            foreach (Ball ball in forDelete)
            {
                scene.Balls.Remove(ball);
            }
            scene.Balls.Remove(b);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Ball b in scene.Balls)
            {
                if (b.Color == Color.Red)
                {
                    b.Color = Color.Yellow;
                }
                else if (b.Color == Color.Yellow)
                {
                    b.Color = Color.Green;
                }
                else
                {
                    b.Color = Color.Red;
                }

                if (b.Radius < 50)
                {
                    if (b.Radius + 5 > 50)
                    {
                        b.Radius = 50;
                    }
                    else
                    {
                        b.Radius += 5;
                    }
                }
            }
            List<Ball> copy = new List<Ball>(scene.Balls);
            foreach (Ball b in copy)
            {
                if (scene.Balls.Contains(b))
                {
                    brisi(b);
                }
            }
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int step = 10;
            foreach (Ball b in scene.Balls)
            {
                if (!b.Selected)
                {
                    continue;
                }
                if (e.KeyCode == Keys.Up && b.Center.Y - step - 60 >= 0)
                {
                    b.Center = new Point(b.Center.X, b.Center.Y - step);
                }
                else if (e.KeyCode == Keys.Down && b.Center.Y + step <= this.Height-60)
                {
                    b.Center = new Point(b.Center.X, b.Center.Y + step);
                }
                else if (e.KeyCode == Keys.Left && b.Center.X - step >= 0)
                {
                    b.Center = new Point(b.Center.X - step, b.Center.Y);
                }
                else if (e.KeyCode == Keys.Right && b.Center.X + step <= this.Width-60)
                {
                    b.Center = new Point(b.Center.X + step, b.Center.Y);
                }
            }
            Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, scene);
                fs.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                scene = (Scene)bf.Deserialize(fs);
                fs.Close();
                Invalidate();
            }
        }
    }
}
