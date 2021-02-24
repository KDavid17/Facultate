using System;

namespace Problema_12
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

            QuickSort(Vector, 0, Numar - 1);

            Console.Write("\n\n Vectorul dupa sortare: \n\n");

            for (i = 0; i < Numar; i++)
            {
                Console.Write(Vector[i] + " ");
            }

            Console.Write("\n\n");
        }
        private static void QuickSort(int[] Vector, int MIN, int MAX)
        {
            if (MIN < MAX)
            {
                int Aux = Partitie(Vector, MIN, MAX);

                QuickSort(Vector, MIN, Aux - 1);
                QuickSort(Vector, Aux + 1, MAX);
            }
        }
        private static int Partitie(int[] Vector, int MIN, int MAX)
        {
            int Pivot = Vector[MAX], i = (MIN - 1);

            for (int j = MIN; j < MAX; j++)
            {
                
                if (Vector[j] < Pivot)
                {
                    i++;

                    (Vector[i], Vector[j]) = (Vector[j], Vector[i]);
                }
            }

            (Vector[i + 1], Vector[MAX]) = (Vector[MAX], Vector[i + 1]);

            return i + 1;
        }
    }
}