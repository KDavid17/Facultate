using System;

namespace Problema_7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n Introduceti numarul de elemente din vector: ");
                long Numar = long.Parse(Console.ReadLine()), i;

                if (Numar < 1)
                {
                    throw new Exception();
                }

                Console.Write("\n Introduceti elementele: \n");
                long[] Vector1 = new long[Numar], Vector2 = new long[Numar];

                for (i = 0; i < Numar; i++)
                {
                    Console.Write($"\n Element {i + 1}: ");
                    Vector1[i] = long.Parse(Console.ReadLine());
                }

                Rotire(Vector1, Vector2, Numar);

                Vector1 = Vector2;

                Console.Write("\n Vectorul obtinut este: ");

                for (i = 0; i < Numar; i++)
                {
                    Console.Write(Vector1[i] + " ");
                }

                Console.Write("\n\n");
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }
        private static void Rotire(long[] Vector1, long[] Vector2, long Numar)
        {
            long i;

            for (i = 0; i < Numar - 1; i++)
            {
                Vector2[i] = Vector1[i + 1];
            }

            Vector2[i] = Vector1[0];
        }
    }
}
