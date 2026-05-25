using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorRectangles_V2
{
    public partial class Form1 : Form
    {
        Scene scene;
        Point First;
        Point Second;
        bool first;
        Point cursor;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            DoubleBuffered = true;
            first = false;
            First = new Point();
            Second = new Point();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
            if (first)
            {
                Pen p = new Pen(Color.Black, 2);
                int x = Math.Min(First.X, cursor.X);
                int y = Math.Min(First.Y, cursor.Y);
                int w = Math.Abs(First.X - cursor.X);
                int h = Math.Abs(First.Y - cursor.Y);
                e.Graphics.DrawRectangle(p, x, y, w, h);
                p.Dispose();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!first)
            {
                First = e.Location;
                first = !first;
            }
            else
            {
                first = !first;
                Second = e.Location;
                RectangleForm r = new RectangleForm(Color.Blue, Math.Abs(First.X - Second.X), Math.Abs(First.Y-Second.Y));
                r.TopLeft = new Point(Math.Min(First.X, Second.X), Math.Min(First.Y, Second.Y));
                scene.AddRect(r);
                Second = new Point();
            }
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = e.Location;
            Invalidate();
        }
    }
}
