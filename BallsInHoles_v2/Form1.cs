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

namespace BallsInHoles_v2
{
    public partial class Form1 : Form
    {
        Scene scene;
        Color currentColor;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            DoubleBuffered = true;
            currentColor = Color.Red;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Ball b = new Ball(currentColor, 25, e.Location);
            Random r = new Random();
            int t = r.Next(4);
            if (t == 0)
            {
                b.dx = 5;
            }
            else if (t == 1)
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
            UpdateStatus();
            Invalidate();
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            List<Ball> fordelete = new List<Ball>();
            foreach (Ball b in scene.Balls)
            {
                if (b.Color == Color.Black)
                {
                    fordelete.Add(b);
                }
            }
            foreach(Ball b in fordelete)
            {
                scene.Balls.Remove(b);
            }
            for (int i = 0; i<5; i++)
            {
                int x = r.Next(50, this.Width-50);
                int y = r.Next(50, this.Height-50);
                Ball b = new Ball(Color.Black, 30, new Point(x, y));
                bool notCollide = false;
                foreach (Ball ball in scene.Balls)
                {
                    if (ball.Color == Color.Black && ball != b)
                    {
                        if (ball.HitBall(b))
                        {
                            notCollide = true;
                        }
                    }
                }
                if (notCollide)
                {
                    i--;
                }
                else
                {
                    scene.Balls.Add(b);
                }
            }
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Ball> forDelete = new List<Ball>();
            foreach (Ball b in scene.Balls)
            {
                if (b.Color != Color.Black)
                {
                    b.Move();
                    b.HitWall(this.Width, this.Height);
                    foreach (Ball ball in scene.Balls)
                    {
                        if (ball != b && ball.Color == Color.Black)
                        {
                            if (b.HitBall(ball))
                            {
                                forDelete.Add(b);
                                ball.Number++;
                            }
                        }
                    }
                }
            }
            foreach(Ball b in forDelete)
            {
                scene.Balls.Remove(b);
            }
            UpdateStatus();
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
                Invalidate();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene = new Scene();
            Invalidate();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                currentColor = cd.Color;
            }
        }
        public void UpdateStatus()
        {
            int t = scene.Balls.Count - 5;
            if (t < 0)
            {
                toolStripStatusLabel1.Text = "Balls: 0";
                return;
            }
            toolStripStatusLabel1.Text = "Balls: "+t.ToString();
        }
    }
}
