using System;
using System.Drawing;

namespace ColorRectangles
{
    [Serializable]
    public class RectangleShape
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public Color Color { get; set; }
        public bool Selected { get; set; }

        public RectangleShape(Point start, Point end, Color color)
        {
            Start = start;
            End = end;
            Color = color;
            Selected = false;
        }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    Math.Min(Start.X, End.X),
                    Math.Min(Start.Y, End.Y),
                    Math.Abs(Start.X - End.X),
                    Math.Abs(Start.Y - End.Y)
                );
            }
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillRectangle(b, Bounds);
            if (Selected)
            {
                Pen p = new Pen(Color.Red, 3);
                g.DrawRectangle(p, Bounds);
                p.Dispose();
            }
            b.Dispose();
        }

        public bool Contains(Point p)
        {
            return Bounds.Contains(p);
        }
    }
}