using System;

namespace Problema_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int An;

            try                                             // Citirea datelor.
            {
                An = int.Parse(Console.ReadLine());

                if (An % 4 == 0)                            // Afisare daca un an este bisect sau nu.
                {
                    Console.WriteLine($"\n Anul {An} este bisect. \n");
                }
                else
                {
                    Console.WriteLine($"\n Anul {An} nu este bisect. \n");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
    }
}
