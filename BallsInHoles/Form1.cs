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

namespace BallsInHoles
{
    public partial class Form1 : Form
    {
        Scene scene;
        Color currentColor = Color.Red;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Rectangle bounds = new Rectangle(50, 80, 900, 600);
            scene = new Scene(bounds);
            timer1.Interval = 50;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (scene.Bounds.Contains(e.Location))
            {
                scene.AddBall(e.Location, currentColor);
                UpdateStatus();
                Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scene.Move();
            UpdateStatus();
            Invalidate();
        }
        private void UpdateStatus()
        {
            toolStripStatusLabel1.Text = "# Balls: " + scene.Balls.Count;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            scene.GenerateHoles();
            Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                bf.Serialize(fs, scene);
                fs.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                scene = (Scene)bf.Deserialize(fs);
                fs.Close();
                UpdateStatus();
                Invalidate();
            }
        }
    }
}
