using System;
using System.Collections.Generic;
using System.Drawing;

namespace ColorRectangles
{
    [Serializable]
    public class Scene
    {
        public List<RectangleShape> Rectangles { get; set; }

        public Scene()
        {
            Rectangles = new List<RectangleShape>();
        }

        public void Draw(Graphics g)
        {
            foreach (RectangleShape r in Rectangles)
            {
                r.Draw(g);
            }
        }

        public void AddRectangle(RectangleShape r)
        {
            Rectangles.Add(r);
        }

        public void ToggleSelection(Point p)
        {
            foreach (RectangleShape r in Rectangles)
            {
                if (r.Contains(p))
                {
                    r.Selected = !r.Selected;
                    return;
                }
            }
        }

        public void DeleteSelected()
        {
            Rectangles.RemoveAll(x => x.Selected);
        }
    }
}