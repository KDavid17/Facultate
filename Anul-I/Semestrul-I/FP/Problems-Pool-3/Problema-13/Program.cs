using System;

namespace Problema_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n Introduceti numarul de elemente: ");
            int Numar = int.Parse(Console.ReadLine()), i;

            int[] Vector = new int[Numar];
            Random Aleator = new Random();

            Console.Write("\n Vectorul inainte de sortare: \n\n");

            for (i = 0; i < Numar; i++)
            {
                Vector[i] = Aleator.Next(0, Numar);

                Console.Write(Vector[i] + " ");
            }

            Sort(Vector);

            Console.Write("\n\n Vectorul dupa sortare: \n\n");

            for (i = 0; i < Numar; i++)
            {
                Console.Write(Vector[i] + " ");
            }

            Console.Write("\n\n");
        }
        private static void Sort(int[] Vector)
        {
            for (int i = 1; i < Vector.Length; i++)
            {
                int Element = Vector[i], j = i - 1;

                while (j >= 0 && Vector[j] > Element)
                {
                    Vector[j + 1] = Vector[j];

                    j--;
                }

                Vector[j + 1] = Element;
            }
        }
    }
}
