using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            Point myPoint = new Point(3, 5);
            Console.WriteLine(myPoint);

            Point p1 = new Point(2, 3);
            Point p2 = new Point(4, 5);

            Segment mySegment = new Segment(p1, p2);

            p1 = new Point(6, 7);
            p2 = new Point(8, 9);
            Segment mySegment2 = new Segment(p1, p2);

            p1 = new Point(0, 0);
            p2 = new Point(0, 1);
            Segment mySegment3 = new Segment(p1, p2);

            Console.WriteLine(mySegment);
            Console.WriteLine(mySegment2);
            Console.WriteLine(mySegment3);
        }
    }
}
