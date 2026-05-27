using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquareBall
{
    public partial class Form1 : Form
    {
        Scene scene;
        int shape;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            DoubleBuffered = true;
            shape = 0;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (shape == 0)
            {
                Ball b = new Ball(e.Location, 25, Color.Red);
                scene.AddBall(b);
            }
            else
            {
                Square s = new Square(50, Color.Blue, e.Location);
                scene.AddSquare(s);
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void ballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 0;
            Invalidate();
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 1;
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Ball b in scene.Balls)
            {
                b.Radius += 5;
                if (b.Radius > 50)
                {
                    b.Radius = 25;
                }
            }
            foreach (Square s  in scene.Squares)
            {
                s.side += 5;
                if (s.side > 100)
                {
                    s.side = 50;
                }
            }
            Invalidate();
        }
    }
}
