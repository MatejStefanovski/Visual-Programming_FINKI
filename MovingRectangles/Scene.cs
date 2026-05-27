using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingRectangles
{
    [Serializable]
    public class Scene
    {
        public List<RectangleShape> rectangles;
        public Scene()
        {
            rectangles = new List<RectangleShape>();
        }
        public void AddRect(RectangleShape rect)
        {
            rectangles.Add(rect);
        }
        public void Draw(Graphics g)
        {
            foreach (RectangleShape r in rectangles)
            {
                r.Draw(g);
            }
        }
    }
}
