using System;

namespace Problema_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n Introduceti lungimea primului sirag: ");
            int Numar1 = int.Parse(Console.ReadLine());

            Console.Write("\n Primul sirag arata astfel: ");
            int[] Vector1 = CitireVector(Numar1);

            Console.Write("\n\n Introduceti lungimea celui de al doilea sirag: ");
            int Numar2 = int.Parse(Console.ReadLine());

            Console.Write("\n Al doilea sirag arata astfel: ");
            int[] Vector2 = CitireVector(Numar2);

            int i1, i2, j1, j2, Aparitii = 0;
            bool Apare;

            for (i1 = 0; i1 < Numar1; i1++)
            {
                for (i2 = 0; i2 < Numar2; i2++)
                {
                    for (j1 = 0; j1 < Numar1; j1++)
                    {
                        if (Vector1[j1] == Vector2[0])
                        {
                            Apare = true;

                            if (j1 + Numar2 - 1 < Numar1)
                            {
                                for (j2 = j1 + 1; j2 <= j1 + Numar2 - 1; j2++)
                                {
                                    if (Vector1[j2] != Vector2[j2 - j1])
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

                    Vector2 = Rotire(Vector2);
                }

                Vector1 = Rotire(Vector1);
            }

            Console.Write("\n\n Numarul de suprapuneri: " + Aparitii + "\n\n");
        }
        private static int[] CitireVector(int Numar)
        {
            Random Aleator = new Random();
            int[] Vector = new int[Numar];

            for (int i = 0; i < Numar; i++)
            {
                Vector[i] = Aleator.Next(0, 2);

                Console.Write(Vector[i] + " ");
            }

            return Vector;
        }
        private static int[] Rotire(int[] Vector)
        {
            int Aux = Vector[0], i;

            for (i = 0; i < Vector.Length - 1; i++)
            {
                Vector[i] = Vector[i + 1];
            }

            Vector[i] = Aux;

            return Vector;
        }
    }
}
