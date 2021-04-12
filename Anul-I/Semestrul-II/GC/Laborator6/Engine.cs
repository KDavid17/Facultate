using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Curs_Seminar_5
{
    public class Engine
    {
        public static List<myPoint> pointsAll = new List<myPoint>();
        public static List<myPoint> points1 = new List<myPoint>();
        public static List<myPoint> points2 = new List<myPoint>();

        public static void drawPoint(Graphics grp)
        {
            foreach (myPoint p in pointsAll)
            {
                p.draw(grp);
            }
        }

        public static void sortPoints()
        {
            for (int i = 0; i < pointsAll.Count - 1; ++i)
            {
                int minIndex = i;
                float aux;

                for (int j = i + 1; j < pointsAll.Count; ++j)
                {
                    if (pointsAll[j].X < pointsAll[minIndex].X)
                    {
                        minIndex = j;
                    }
                    else if (pointsAll[j].X == pointsAll[minIndex].X)
                    {
                        if (pointsAll[j].Y < pointsAll[minIndex].Y)
                        {
                            minIndex = j;
                        }
                    }

                    aux = pointsAll[minIndex].X;
                    pointsAll[minIndex].X = pointsAll[i].X;
                    pointsAll[i].X = aux;

                    aux = pointsAll[minIndex].Y;
                    pointsAll[minIndex].Y = pointsAll[i].Y;
                    pointsAll[i].Y = aux;
                }
            }
        }

        public static void drawLines(Graphics grp)
        {
            int i;

            for (i = 1; i < pointsAll.Count; i++)
            {
                grp.DrawLine(Pens.Red, pointsAll[i - 1].X, pointsAll[i - 1].Y, pointsAll[i].X, pointsAll[i].Y);
            }

            grp.DrawLine(Pens.Red, pointsAll[i - 1].X, pointsAll[i - 1].Y, pointsAll[0].X, pointsAll[0].Y);
        }
    }
}
