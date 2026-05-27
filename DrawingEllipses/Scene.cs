using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEllipses
{
    public class Scene
    {
        public List<FormEllipse> ellipses { get; set; }
        public Scene() 
        {
            ellipses = new List<FormEllipse>();
        }
        public void AddEllipse(FormEllipse el)
        {
            ellipses.Add(el);
        }
        public void Draw(Graphics g)
        {
            foreach(FormEllipse el in ellipses)
            {
                el.Draw(g);
            }
        }
    }
}
