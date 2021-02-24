using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs1_Seminar1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ecuatieDreapta();
            //coliniaritateDrepte();
            //concurentaDreptelor();
        }

        private static void concurentaDreptelor()
        {
            Console.Write("\n Introduceti coeficientii lui d1: \n");

            Console.Write("\n a1: ");
            double a1 = double.Parse(Console.ReadLine());

            Console.Write("\n b1: ");
            double b1 = double.Parse(Console.ReadLine());

            Console.Write("\n c1: ");
            double c1 = double.Parse(Console.ReadLine());

            Console.Write("\n Introduceti coeficientii lui d2: \n");

            Console.Write("\n a2: ");
            double a2 = double.Parse(Console.ReadLine());

            Console.Write("\n b2: ");
            double b2 = double.Parse(Console.ReadLine());

            Console.Write("\n c2: ");
            double c2 = double.Parse(Console.ReadLine());

            Console.Write("\n Introduceti coeficientii lui d3: \n");

            Console.Write("\n a3: ");
            double a3 = double.Parse(Console.ReadLine());

            Console.Write("\n b3: ");
            double b3 = double.Parse(Console.ReadLine());

            Console.Write("\n c3: ");
            double c3 = double.Parse(Console.ReadLine());

            if (a1 * b2 * c3 + a2 * b3 * c1 + a3 * b1 * c2 == a1 * b3 * c2 + a2 * b1 * c3 + a3 * b2 * c1)
            {
                Console.Write("\n Dreptele sunt concurente. \n\n");
            }
            else
            {
                Console.Write("\n Dreptele nu sunt concurente. \n\n");
            }
        }

        private static void coliniaritateDrepte()
        {
            Console.Write("\n Introduceti coordonatele punctului A: \n");

            Console.Write("\n xA: ");
            double xA = double.Parse(Console.ReadLine());

            Console.Write("\n yA: ");
            double yA = double.Parse(Console.ReadLine());

            Console.Write("\n Introduceti coordonatele punctului B: \n");

            Console.Write("\n xB: ");
            double xB = double.Parse(Console.ReadLine());

            Console.Write("\n yB: ");
            double yB = double.Parse(Console.ReadLine());

            Console.Write("\n Introduceti coordonatele punctului C: \n");

            Console.Write("\n xC: ");
            double xC = double.Parse(Console.ReadLine());

            Console.Write("\n yC: ");
            double yC = int.Parse(Console.ReadLine());

            if (xA * yB + xB * yC + xC * yA == xA * yC + xB * yA + xC * yB)
            {
                Console.Write("\n Punctele sunt coliniare. \n\n");
            }
            else
            {
                Console.Write("\n Punctele nu sunt coliniare. \n\n");
            }
        }

        private static void ecuatieDreapta()
        {
            Console.Write("\n Introduceti coordonatele punctului A: \n");

            Console.Write("\n xA: ");
            double xA = double.Parse(Console.ReadLine());

            Console.Write("\n yA: ");
            double yA = double.Parse(Console.ReadLine());

            Console.Write("\n Introduceti coordonatele punctului B: \n");

            Console.Write("\n xB: ");
            double xB = double.Parse(Console.ReadLine());

            Console.Write("\n yB: ");
            double yB = double.Parse(Console.ReadLine());

            double x = yB - yA, y = xA - xB, termenLiber = xB * yA - xA * yB;
            
            Console.Write("\n Ecuatia dreptei AB: ");
            
            if (x == 0)
            {
                if (y == 0)
                {
                    Console.Write(termenLiber < 0 ? $"-{-termenLiber}" : $"{termenLiber}");
                }
                else
                {
                    Console.Write(y < 0 ? $"-{-y}y" : $"{y}y");
                    Console.Write(termenLiber < 0 ? $" - {-termenLiber}" : $" + {termenLiber}");
                }
            }
            else
            {
                if (y == 0)
                {
                    Console.Write(x < 0 ? $"-{-x}x" : $"{x}x");
                    Console.Write(termenLiber < 0 ? $" - {-termenLiber}" : $" + {termenLiber}");
                }
                else
                {
                    Console.Write(x < 0 ? $"-{-x}x" : $"{x}x");
                    Console.Write(y < 0 ? $" - {-y}y" : $" + {y}y");
                    Console.Write(termenLiber < 0 ? $" - {-termenLiber}" : $" + {termenLiber}");
                }
            }

            Console.Write(" = 0\n");

            y = -y;

            Console.Write("\n Distanta dintre puncte: " + Math.Sqrt(y * y + x * x) + "\n\n");
        }
    }
}
