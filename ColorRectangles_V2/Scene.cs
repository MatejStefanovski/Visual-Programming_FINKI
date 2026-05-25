using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorRectangles_V2
{
    public class Scene
    {
        public List<RectangleForm> lista { get; set; }
        public Scene()
        {
            lista = new List<RectangleForm>();
        }
        public void AddRect(RectangleForm r)
        {
            lista.Add(r);
        }
        public void Draw(Graphics g)
        {
            foreach (RectangleForm r in lista)
            {
                r.Draw(g);
            }
        }
    }
}
