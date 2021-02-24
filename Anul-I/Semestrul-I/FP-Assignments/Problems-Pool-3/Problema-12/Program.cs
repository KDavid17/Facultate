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
            for (int i = 0; i < Vector.Length - 1; i++)
            {
                int Pozitie = i;

                for (int j = i + 1; j < Vector.Length; j++)
                {
                    if (Vector[j] < Vector[Pozitie])
                    {
                        Pozitie = j;
                    }
                }

                (Vector[i], Vector[Pozitie]) = (Vector[Pozitie], Vector[i]);
            }
        }
    }
}
