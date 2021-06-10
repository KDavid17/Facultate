using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        private Point()
        {

        }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }
    }
}
