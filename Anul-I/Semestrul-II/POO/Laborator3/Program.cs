using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator3
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(3.5, 4.5);
            Point p2 = new Point(2, 6.5);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine($"{p1.DistanceToOrigin().ToString("#.##")}");
            Console.WriteLine($"{p1.DistanceTo(p2).ToString("#.##")}");

            p1.MoveBy(2, 6.5);
            Console.WriteLine(p1);

            Line line1 = new Line(p1, p2);
            Line line2 = new Line(2.5, 9, 5, 8.5);

            Console.WriteLine($"{line1}");
            Console.WriteLine($"{line2.Length}");
        }
    }
}
