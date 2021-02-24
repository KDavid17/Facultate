using System;

namespace Problema_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b;
           
            try                                                     // Citirea datelor.
            {
                Console.Write("\n Introduceti coeficientul: ");
                a = double.Parse(Console.ReadLine());

                Console.Write("\n Introduceti constanta: ");
                b = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei.\n");

                return;
            }

            if (a == 0)
            {
                if(b == 0)                                          // Cazul a = b = 0.
                {
                    Console.WriteLine($"\n Ecuatia de gradul 1: {a} * x + {b} = 0 are ca solutie orice x din multimea numerelor complexe.\n");
                }
                else                                                // Cazul a = 0.
                {
                    Console.WriteLine($"\n Ecuatia de gradul 1: {a} * x + {b} = 0 nu are solutie.\n");
                }
            }
            else
            {
                if(b == 0)                                          // Cazul b = 0.
                {
                    Console.WriteLine($"\n Ecuatia de gradul 1: {a} * x + {b} are ca solutie x = 0 .\n");
                }
                else
                {
                    Console.WriteLine($"\n Ecuatia de gradul 1: {a} * x + {b} = 0 are ca solutie x = {-b/a} .\n");
                }
            }
        }
    }
}
