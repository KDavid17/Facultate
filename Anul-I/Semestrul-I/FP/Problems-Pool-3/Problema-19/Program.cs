using System;

namespace Problema_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n Introduceti lungimea primului vector: ");
            int Numar1 = int.Parse(Console.ReadLine());

            Console.Write("\n Elementele primului vector: ");
            int[] Vector1 = CitireVector(Numar1);

            Console.Write("\n\n Introduceti lungimea celui de al doilea vector: ");
            int Numar2 = int.Parse(Console.ReadLine());

            Console.Write("\n Elementele celui de al doilea vector: ");
            int[] Vector2 = CitireVector(Numar2);

            int i, j, Aparitii = 0;
            bool Apare;

            for (i = 0; i < Numar1; i++)
            {
                if (Vector1[i] == Vector2[0])
                {
                    Apare = true;
                    if (i + Numar2 - 1 < Numar1)
                    {
                        for (j = i + 1; j <= i + Numar2 - 1; j++)
                        {
                            if (Vector1[j] != Vector2[j - i])
                            {
                                Apare = false;

                                break;
                            }
                        }

                        if (Apare == true)
                        {
                            Aparitii++;
                        }
                    }
                }
            }

            Console.Write("\n\n Numarul de aparitii al celui de al doilea vector in primul vector: ");
            Console.Write(Aparitii + "\n\n");
        }

        private static int[] CitireVector(int Numar)
        {
            Random Aleator = new Random();
            int[] Vector = new int[Numar];

            for (int i = 0; i < Numar; i++)
            {
                Vector[i] = Aleator.Next(1, 3);

                Console.Write(Vector[i] + " ");
            }

            return Vector;
        }
    }
}
