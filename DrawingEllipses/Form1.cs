using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingEllipses
{
    public partial class Form1 : Form
    {
        Scene scene;
        bool firstclick = false;
        Point cursor = new Point();
        Point first = new Point();
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
            if (firstclick)
            {
                Pen p = new Pen(Color.Black, 3);
                //double tmp = Math.Sqrt(Math.Pow(first.X - cursor.X, 2) + Math.Pow(first.Y + cursor.Y, 2));
                e.Graphics.DrawEllipse(p, Math.Min(first.X, cursor.X), Math.Min(first.Y, cursor.Y), Math.Abs(first.X-cursor.X), Math.Abs(first.Y-cursor.Y));
                p.Dispose();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = e.Location;
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!firstclick)
            {
                firstclick = true;
                cursor = e.Location;
                first = cursor;
            }
            else
            {
                firstclick = false;
                int width = Math.Abs(first.X - cursor.X);
                int height = Math.Abs(first.Y - cursor.Y);
                Point p = new Point(Math.Min(cursor.X, first.X), Math.Min(first.Y, cursor.Y));
                FormEllipse el = new FormEllipse(Color.Red, p, width, height);
                scene.AddEllipse(el);
                Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (FormEllipse el in scene.ellipses)
            {
                int r = (el.Color.R + 5) % 256;
                int g = (el.Color.G + 10) % 256;
                int b = (el.Color.B + 15) % 256;

                el.Color = Color.FromArgb(r, g, b);
            }
        }
    }
}
