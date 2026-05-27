using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TickingPies
{
    public partial class Form1 : Form
    {
        Scene scene;
        bool stop;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            stop = false;
            DoubleBuffered = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stop)
            {
                return;
            }
            List<Pie> fordelete = new List<Pie>();
            foreach (Pie p in scene.Pies)
            {
                p.i -= 5;
                if (p.i == 0)
                {
                    fordelete.Add(p);
                }
            }
            foreach (Pie p in fordelete)
            {
                scene.Pies.Remove(p);
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Pie pie = new Pie(25, e.Location, Color.Blue);
            scene.AddPie(pie);
            Invalidate();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stopToolStripMenuItem.Text == "Stop")
            {
                stopToolStripMenuItem.Text = "Start";
                stop = true;
            }
            else
            {
                stopToolStripMenuItem.Text = "Stop";
                stop = false;
            }
        }
    }
}
