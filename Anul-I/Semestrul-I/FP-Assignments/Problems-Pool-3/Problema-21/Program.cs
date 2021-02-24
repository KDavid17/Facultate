using System;

namespace Problema_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n Introduceti lungimea primului vector: ");
            int Numar1 = int.Parse(Console.ReadLine());

            Console.Write("\n Primul vector arata astfel: ");
            int[] Vector1 = CitireVector(Numar1);

            Console.Write("\n\n Introduceti lungimea celui de al doilea vector: ");
            int Numar2 = int.Parse(Console.ReadLine());

            Console.Write("\n Al doilea vector arata astfel: ");
            int[] Vector2 = CitireVector(Numar2);

            int MIN = Math.Max(Numar1, Numar2), i;
            bool Contine = true;

            for (i = 0; i < MIN; i++)
            {
                if (Vector1[i] < Vector2[i])
                {
                    Console.Write("\n\n Ordinea lexicografica: Vector1 < Vector2 \n\n");

                    Contine = false;

                    break;
                }
                else if (Vector1[i] > Vector2[i])
                {
                    Console.Write("\n\n Ordinea lexicografica: Vector2 < Vector1 \n\n");

                    Contine = false;

                    break;
                }
            }

            if (Contine == true)
            {
                Console.Write("\n\n Ordinea lexicografica: Vector1 < Vector2 \n\n");

                Contine = false;
            }
        }
        private static int[] CitireVector(int Numar)
        {
            Random Aleator = new Random();
            int[] Vector = new int[Numar];

            for (int i = 0; i < Numar; i++)
            {
                Vector[i] = Aleator.Next(0, Numar);

                Console.Write(Vector[i] + " ");
            }

            return Vector;
        }
    }
}
