using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PartialForms
{
    class Engine
    {
        public static List<myPoint> points = new List<myPoint>();
        public static void draw(Graphics grp)
        {
            foreach (myPoint p in points)
            {
                p.draw(grp);
            }
        }
    }
}
