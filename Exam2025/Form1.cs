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

namespace Exam2025
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
            foreach(Ball b in scene.Balls)
            {
                b.Move();
                b.HitWall(this.Width-40, this.Height-70);
                foreach (Ball b2 in scene.Balls)
                {
                    if (b2 != b)
                    {
                        if (b.IsHit(b2) && b2.Color==Color.Gray)
                        {
                            b.Energy = -1;
                            b.Color = Color.Gray;
                            b.dx = 0;
                            b.dy = 0;
                        }
                    }
                }
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int dx = 0, dy = 0;
            Random r = new Random();
            int temp = r.Next(4);
            if (temp == 0)
            {
                dx = 5;
            }
            else if (temp == 1)
            {
                dy = 5;
            }
            else if (temp == 2)
            {
                dx = -5;
            }
            else
            {
                dy = -5;
            }
            Ball b = new Ball(Color.Red, e.Location, dx, dy);
            scene.Balls.Add(b);
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
