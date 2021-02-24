using System;

namespace Problema_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n Introduceti numarul de elemente din vector: ");
                long Numar = long.Parse(Console.ReadLine());

                Console.Write("\n Introduceti elementele: \n\n Element 1: ");

                long[] Vector = new long[Numar];
                Vector[0] = long.Parse(Console.ReadLine());

                long Suma = Vector[0];

                for (long i = 1; i < Numar; i++)
                {
                    Console.Write($"\n Element {i + 1}: ");
                    Vector[i] = long.Parse(Console.ReadLine());

                    Suma += Vector[i];
                }

                Console.Write($"\n Suma elementelor din vector este egala cu: {Suma} \n\n");
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }
    }
}
