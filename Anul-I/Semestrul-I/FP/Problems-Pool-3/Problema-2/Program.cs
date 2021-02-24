using System;

namespace Problema_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n Introduceti numarul de elemente din vector: ");
                long Numar = long.Parse(Console.ReadLine());

                Console.Write("\n Introduceti valoarea cautata: ");
                long Cautat = long.Parse(Console.ReadLine()), Pozitie = -1;

                Console.Write("\n Introduceti elementele: \n\n Element 1: ");
                long[] Vector = new long[Numar];
                Vector[0] = long.Parse(Console.ReadLine());

                if (Cautat == Vector[0])
                {
                    Pozitie = 0;
                }

                for (long i = 1; i < Numar; i++)
                {
                    Console.Write($"\n Element {i + 1}: ");
                    Vector[i] = long.Parse(Console.ReadLine());

                    if (Pozitie == -1 && Cautat == Vector[i])
                    {
                        Pozitie = i;
                    }
                }

                Console.Write(Pozitie == -1 ? "\n-1\n\n" : $"\nPrima pozitie pe care apare {Cautat} este: {Pozitie}\n\n");
            }
            catch (Exception)
            {

            }

        }
    }
}
