using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PulsingCircles
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

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Ball b = new Ball(currentColor, e.Location);
            scene.AddBall(b);
            Invalidate();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
            }
        }
    }
}
