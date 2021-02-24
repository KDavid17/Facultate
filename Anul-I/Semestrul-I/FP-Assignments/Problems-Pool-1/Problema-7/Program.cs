using System;

namespace Problema_7
{
    class Program
    {
        static void Main(string[] args)
        {
            double Numar1, Numar2;                                              // Citirea datelor.

            try
            {
                Console.Write("\n Introduceti primul numar: ");
                (Numar1, Numar2) = (double.Parse(Console.ReadLine()), 0);       // (Numar1, 0)

                Console.Write("\n Introduceti al doilea numar: ");
                (Numar1, Numar2) = (double.Parse(Console.ReadLine()), Numar1);  // (Numar2, Numar1)

                Console.Write($"\n Cele doua numere: {Numar2} si {Numar1}"); 
                Console.WriteLine($" au devenit in urma inversarii: {Numar1} si {Numar2} . \n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei.\n");
            }
        }
    }
}
