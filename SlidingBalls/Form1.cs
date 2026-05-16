using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlidingBalls
{
    public partial class Form1 : Form
    {
        Scene scene;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene(this.Width, this.Height);
            DoubleBuffered = true;
            timer1.Interval = 50;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (scene.Move())
            {
                timer1.Stop();
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                scene.AddRed(e.Location);
                Invalidate();
                return;
            }
            if (scene.Click(e.Location))
            {
                timer1.Start();
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            scene.AddBall(e.Location);
            Invalidate();
        }
    }
}
