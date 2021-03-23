using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Curs_Seminar_4
{
    public static class Engine
    {
        public static List<myPoint> points = new List<myPoint>();
        public static void drawPoint(Graphics grp)
        {
            foreach (myPoint p in points)
            {
                p.draw(grp);
            }
        }

        public static void drawLines(Graphics grp, int[] latura)
        {
            for (int i = 0; i < points.Count; i++)
            {
                grp.DrawLine(Pens.Red, points[i].X + latura[i] / 2, points[i].Y, points[i].X + latura[i] / 2, points[i].Y + latura[i]);
                grp.DrawLine(Pens.Red, points[i].X, points[i].Y + latura[i] / 2, points[i].X + latura[i], points[i].Y + latura[i] / 2);
                grp.DrawLine(Pens.Green, points[i].X, points[i].Y, points[i].X + latura[i], points[i].Y + latura[i]);
                grp.DrawLine(Pens.Green, points[i].X + latura[i], points[i].Y, points[i].X, points[i].Y + latura[i]);
            }
        }

        public static void remove()
        {
            points.RemoveAt(points.Count - 1);
        }
    }
}
