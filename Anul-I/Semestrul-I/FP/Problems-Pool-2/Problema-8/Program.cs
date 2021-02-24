using System;

namespace Problema_8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n Introduceti al catelea numar doriti sa il aflati: ");
                long Numar = long.Parse(Console.ReadLine());

                if (Numar == 1)
                {
                    Console.Write($"\n Primul numar din sirul lui Fibonacci este: 0\n");
                }
                else if (Numar == 2 || Numar == 3)
                {
                    Console.Write($"\n Al {Numar}-lea numar din sirul lui Fibonacci este: 1\n");
                }
                else if (Numar > 3)
                {
                    Console.Write($"\n Al {Numar}-lea numar din sirul lui Fibonacci este: {Fibonacci(Numar)}\n\n");
                }
                else
                {
                    throw new Exception();
                }          
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
        private static long Fibonacci(long Numar)
        {
            if (Numar == 2 || Numar == 3)
            {
                return 1;
            }

            return Fibonacci(Numar - 1) + Fibonacci(Numar - 2);
        }
    }
}
