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

namespace SecondMidterm2025
{
    public partial class Form1 : Form
    {
        Scene scene = new Scene();
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scene.Move(Width, Height);
            UpdateStatus();
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Color color;
            if (random.Next(2) == 0)
            {
                color = Color.Red;
            }
            else
            {
                color = Color.Blue;
            }
            int a = random.Next(2);
            int dx = random.Next(2) == 0 ? 5 : -5;
            int dy = random.Next(2) == 0 ? 5 : -5;
            if (a == 0)
            {
                dy = 0;
            }
            else
            {
                dx = 0;
            }
            Ball c = new Ball(e.X, e.Y, color, dx, dy);
            scene.AddBall(c);
            UpdateStatus();
            Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }
        private void UpdateStatus()
        {
            toolStripStatusLabel2.Text = "Red: " + scene.RedBalls();
            toolStripStatusLabel3.Text = "Blue: " + scene.BlueBalls();
            toolStripStatusLabel1.Text = "Balls: " + scene.numBalls;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, scene);
                fs.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                scene = (Scene)bf.Deserialize(fs);
                fs.Close();
                UpdateStatus();
                Invalidate();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene = new Scene();
            UpdateStatus();
            Invalidate();
        }
    }
}
