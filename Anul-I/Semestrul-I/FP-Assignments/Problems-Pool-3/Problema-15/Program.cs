using System;
using System.Collections.Generic;

namespace Problema_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n Introduceti numarul de elemente: ");
            int Numar = int.Parse(Console.ReadLine()), i;

            List<int> Vector = new List<int>();
            Random Aleator = new Random();

            Console.Write("\n Vectorul inainte de eliminarea elementelor care se repeta: \n\n");

            for (i = 0; i < Numar; i++)
            {
                Vector.Add(Aleator.Next(0, Numar));

                Console.Write(Vector[i] + " ");
            }

            Eliminare(Vector);

            Console.Write("\n\n Vectorul dupa eliminarea elementelor care se repeta: \n\n");

            for (i = 0; i < Vector.Count; i++)
            {
                Console.Write(Vector[i] + " ");
            }

            Console.Write("\n\n");
        }

        private static void Eliminare(List<int> Vector)
        {
            int i, j, k, Element;

            for (i = 0; i < Vector.Count - 1; i++)
            {
                Element = Vector[i];

                for (j = i + 1; j < Vector.Count; j++)
                {
                    if (Vector[j] == Element)
                    {
                        for (k = j + 1; k < Vector.Count; k++)
                        {
                            Vector[k - 1] = Vector[k];
                        }

                        Vector.RemoveAt(k - 1);

                        j--;
                    }
                }
            }
        }
    }
}
