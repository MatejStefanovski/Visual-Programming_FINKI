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

namespace MovingRectangles
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
            currentColor = Color.Blue;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                RectangleShape shape = null;
                foreach (RectangleShape r in scene.rectangles)
                {
                    if (r.isHit(e.Location) && !r.rotating)
                    {
                        shape = r;
                        break;
                    }
                }
                if (shape == null)
                {
                    return;
                }
                shape.moving = !shape.moving;
            }
            else
            {
                RectangleShape shape = null;
                foreach (RectangleShape r in scene.rectangles)
                {
                    if (r.isHit(e.Location) && !r.moving)
                    {
                        shape = r;
                        break;
                    }
                }
                if (shape == null)
                {
                    return;
                }
                shape.rotating = !shape.rotating;
            }
            Invalidate();
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RectangleShape r = new RectangleShape(currentColor, e.Location);
            scene.AddRect(r);
            Invalidate();
            UpdateStatus();
        }
        public void UpdateStatus()
        {
            toolStripStatusLabel1.Text = scene.rectangles.Count.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            List<RectangleShape> fordelete = new List<RectangleShape>();
            foreach(RectangleShape r in scene.rectangles)
            {
                r.Move();
                r.Rotate();
                if (r.TopLeft.X>Width || r.TopLeft.Y > Height)
                {
                    fordelete.Add(r);
                }
            }
            foreach (RectangleShape r in fordelete)
            {
                scene.rectangles.Remove(r);
            }
            UpdateStatus();
            Invalidate();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene = new Scene();
            Invalidate();
        }
    }
}
