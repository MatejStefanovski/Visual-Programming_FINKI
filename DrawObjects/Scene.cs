using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawObjects
{
    public class Scene
    {
        public Shape SelectedShape { get; set; } = null;
        public List<Shape> Shapes { get; set; }
        public Scene() {
            Shapes = new List<Shape>();
        }
        public void addShape(Shape s)
        {
            Shapes.Add(s);
        }
        public void DrawAll(Graphics g)
        {
            foreach (Shape s in Shapes)
            {
                s.Draw(g);
            }
        }
        public void Click(Point location, string ShapeType)
        {
            bool Found = false;
            foreach (Shape s in Shapes)
            {
                if (s.IsHit(location))
                {
                    Found = true;
                    s.Selected = !s.Selected;
                }
            }
            if (!Found)
            {
                if (ShapeType == "Circle")
                {
                    Shapes.Add(new Circle(Color.Red, 30, location));
                }
                else
                {
                    Shapes.Add(new Square(Color.Red, 60, location));
                }
            }
        }

        public void Pulse()
        {
            foreach (Shape s in Shapes)
            {
                s.Pulse();
            }
        }
    }
}
