using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Curs_Seminar_6
{
    public static class Engine
    {
        public static List<myPoint> points = new List<myPoint>();

        public static void DrawPoint(Graphics grp)
        {
            foreach (myPoint p in points)
            {
                p.draw(grp);
            }
        }

        public static void LinesDraw(Graphics grp, List<myPoint> pointsFinal)
        {
            int i;

            for (i = 1; i < pointsFinal.Count; i++)
            {
                grp.DrawLine(Pens.Green, pointsFinal[i - 1].X, pointsFinal[i - 1].Y, pointsFinal[i].X, pointsFinal[i].Y);
            }

            grp.DrawLine(Pens.Green, pointsFinal[i - 1].X, pointsFinal[i - 1].Y, pointsFinal[0].X, pointsFinal[0].Y);
        }

        public static void Remove()
        {
            points.RemoveAt(points.Count - 1);
        }
    }
}
