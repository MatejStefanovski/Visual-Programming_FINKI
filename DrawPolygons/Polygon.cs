using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawPolygons
{
    [Serializable]
    public class Polygon
    {
        public List<Point> points { get; set; }
        public bool isClosed { get; set; }
        public bool IsCloseToStart { get; set; }
        public Point cursor { get; set; } = new Point();
        public Polygon() 
        {
            points = new List<Point>();
        }
        public void AddPoint(Point point)
        {
            IsCloseToStart = NearStart();
            if (IsCloseToStart)
            {
                points.Add(points[0]);
                isClosed = true;
                IsCloseToStart = false;
            }
            else
            {
                points.Add(point);
            }
        }
        public bool NearStart()
        {
            if (points.Count < 3)
            {
                return false;
            }
            Point firstPoint = points[0];
            double distance = Math.Sqrt(Math.Pow(firstPoint.X - cursor.X, 2) + Math.Pow(firstPoint.Y - cursor.Y, 2));
            return distance <= 5;
        }
        public void UpdateCursor(Point p)
        {
            cursor = p;
            IsCloseToStart = NearStart();
        }
        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            Pen penDashed = new Pen(Color.Black, 1);
            penDashed.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Brush brush = new SolidBrush(Color.Blue);
            if (points.Count >= 2)
            {
                g.DrawLines(p, points.ToArray());
                if (IsCloseToStart)
                {
                    Point firstPoint = points[0];
                    g.FillEllipse(brush, firstPoint.X - 5, firstPoint.Y - 5, 10, 10);
                }
                if (isClosed)
                {
                    g.FillPolygon(brush, points.ToArray());
                }
            }
            if (points.Count > 0)
            {
                Point lastPoint = points[points.Count - 1];
                g.DrawLine(penDashed, lastPoint, cursor);
            }
        }
    }
}
