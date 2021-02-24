using System;

namespace Problema_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n Introduceti numarul de elemente: ");
            int Numar = int.Parse(Console.ReadLine()), i;

            int[] Vector = new int[Numar];
            Random Aleator = new Random();

            Console.Write("\n Vectorul inainte de interschimbare: \n\n");

            for (i = 0; i < Numar; i++)
            {
                Vector[i] = Aleator.Next(0, 2);

                Console.Write(Vector[i] + " ");
            }

            Interschimbare(Vector);

            Console.Write("\n\n Vectorul dupa interschimbare: \n\n");

            for (i = 0; i < Numar; i++)
            {
                Console.Write(Vector[i] + " ");
            }

            Console.Write("\n\n");
        }
        private static void Interschimbare(int[] Vector)
        {
            int Aparitii = 0, Pozitie = -1;

            for (int i = 0; i < Vector.Length; i++)
            {
                if (Vector[i] == 0)
                {
                    Aparitii++;

                    if (Pozitie == -1)
                    {
                        Pozitie = i;
                    }
                }
                else
                {
                    if (Aparitii != 0)
                    {
                        (Vector[i], Vector[Pozitie]) = (Vector[Pozitie], Vector[i]);

                        Pozitie++;
                    }
                }
            }
        }
    }
}
