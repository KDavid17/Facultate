using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Test
{
    public static class Engine
    {
        public static List<myPoint> points = new List<myPoint>();
        public static void draw(Graphics grp)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                grp.DrawLine(Pens.Black, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
            }

            grp.DrawLine(Pens.Black, points[points.Count - 1].X, points[points.Count - 1].Y, points[0].X, points[0].Y);

            foreach (myPoint p in points)
            {
                p.draw(grp);
            }
            
        }

        public static void remove()
        {
            points.RemoveAt(points.Count - 1);
        }
    }
}
