using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Segment
    {
        public Point P1 { get; private set; }
        public Point P2 { get; private set; }

        private Segment()
        {

        }

        public Segment(Point p1, Point p2)
        {
            this.P1 = p1;
            this.P2 = p2;
        }

        public override string ToString()
        {
            return P1 + " - " + P2;
        }
    }
}
