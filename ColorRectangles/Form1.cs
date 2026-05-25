using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorRectangles
{
    public partial class Form1 : Form
    {
        private Scene scene;

        private int clickCounter;

        private Point startPoint;
        private Point currentPoint;

        private Color currentColor;

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;
            KeyPreview = true;

            scene = new Scene();

            clickCounter = 0;
            currentColor = Color.Blue;

            UpdateStatus();
        }

        private void UpdateStatus()
        {
            toolStripStatusLabel1.Text = $"Rectangles: {scene.Rectangles.Count}";
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                clickCounter++;

                if (clickCounter % 2 == 1)
                {
                    startPoint = e.Location;
                    currentPoint = e.Location;
                }
                else
                {
                    scene.AddRectangle(
                        new RectangleShape(
                            startPoint,
                            e.Location,
                            currentColor
                        ));

                    UpdateStatus();
                }

                Invalidate();
            }

            else if (e.Button == MouseButtons.Right)
            {
                scene.ToggleSelection(e.Location);
                Invalidate();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clickCounter % 2 == 1)
            {
                currentPoint = e.Location;
                Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);

            if (clickCounter % 2 == 1)
            {
                Rectangle preview =
                    new Rectangle(
                        Math.Min(startPoint.X, currentPoint.X),
                        Math.Min(startPoint.Y, currentPoint.Y),
                        Math.Abs(startPoint.X - currentPoint.X),
                        Math.Abs(startPoint.Y - currentPoint.Y)
                    );

                Pen p = new Pen(Color.Black);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                e.Graphics.DrawRectangle(p, preview);

                p.Dispose();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                scene.DeleteSelected();

                UpdateStatus();

                Invalidate();
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                currentColor = dlg.Color;
            }
        }
    }
}