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

namespace DrawPolygons
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

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            scene.AddPoint(e.Location);
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            scene.UpdateCursor(e.Location);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
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
                scene=(Scene)bf.Deserialize(fs);
                Invalidate();
            }
        }
    }
}
