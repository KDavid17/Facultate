using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n width: ");
            int width = int.Parse(Console.ReadLine());

            Console.Write("\n height: "); 
            int height = int.Parse(Console.ReadLine());

            Console.Write("\n Model 1: \n\n");

            new Ladder(width, height);

            Console.Write("\n Model 2: \n\n");

            new Ladder2(width, height);
        }
    }
}
