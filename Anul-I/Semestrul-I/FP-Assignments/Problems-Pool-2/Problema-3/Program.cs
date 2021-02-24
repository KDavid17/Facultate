using System;

namespace Problema_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n Introduceti numarul: ");
                long Suma = 0, Produs = 1, Numar = long.Parse(Console.ReadLine());

                for (long i = 1; i <= Numar; i++)
                {
                    Suma += i;

                    Produs *= i;
                }

                Console.WriteLine($"\n Suma numerelor de la 1 la {Numar} este: {Suma}, iar produsul: {Produs} \n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
    }
}
