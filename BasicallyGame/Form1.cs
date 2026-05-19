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

namespace BasicallyGame
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r1 = new Random();
            int width = r1.Next(20, this.Width-20);
            int height = r1.Next(20, this.Height-20);
            Point point = new Point(width, height);
            Ball b = new Ball(Color.Red, point);
            int dd = r1.Next(4);
            if (dd == 0)
            {
                b.dx = 10;
            }
            else if (dd == 1) 
            {
                b.dx = -10;
            }
            else if (dd == 2)
            {
                b.dy = 10;
            }
            else
            {
                b.dy = -10;
            }
            scene.AddBall(b);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Ball bl = null;
            foreach (Ball ball in scene.Balls)
            {
                ball.Move(this.Width, this.Height);
                if (ball.Color == Color.Black)
                {
                    bl = ball;
                }
            }
            if (bl == null)
            {
                Invalidate();
                return;
            }
            List<Ball> fordelete = new List<Ball>();
            foreach (Ball ball in scene.Balls)
            {
                if (ball.Color == Color.Black)
                {
                    continue;
                }
                if (ball.IsHit(bl))
                {
                    fordelete.Add(ball);
                    bl.Radius += 5;
                    if (bl.Radius > 50)
                    {
                        fordelete.Add(bl);
                        scene.black = false;
                    }
                }
            }
            foreach(Ball ball in fordelete)
            {
                scene.Balls.Remove(ball);
            }
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && scene.black == false)
            {
                Ball b = new Ball(Color.Black, e.Location);
                b.Radius = 25;
                scene.AddBall(b);
                scene.black = true;
            }
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Ball ball in scene.Balls)
            {
                if (ball.Color == Color.Black)
                {
                    ball.Center = new Point(e.X, e.Y);
                }
            }
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pauseToolStripMenuItem.Text == "Pause")
            {
                pauseToolStripMenuItem.Text = "Start";
                foreach (Ball b in scene.Balls)
                {
                    b.Paused = true;
                }
                timer1.Enabled = false;
            }
            else
            {
                foreach (Ball b in scene.Balls)
                {
                    b.Paused = false;
                }
                timer1.Enabled = true;
                pauseToolStripMenuItem.Text = "Pause";
            }
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene = new Scene();
        }
    }
}
