using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickingPies
{
    public class Scene
    {
        public List<Pie> Pies { get; set; }
        public Scene()
        {
            Pies = new List<Pie>();
        }
        public void AddPie(Pie pie)
        {
            Pies.Add(pie);
        }
        public void Draw(Graphics g)
        {
            foreach (Pie pie in Pies)
            {
                pie.Draw(g);
            }
        }
    }
}
