using System;
using System.Collections.Generic;


namespace Problema_25
{
    class Program
    {
        private static bool Gata = false;
        static void Main(string[] args)
        {
            Console.Write("\n Introduceti lungimea primului vector: ");
            int Numar1 = int.Parse(Console.ReadLine());

            Console.Write("\n Primul vector arata astfel: ");
            List<int> Vector1 = CitireVector(Numar1);

            Console.Write("\n\n Introduceti lungimea celui de al doilea vector: ");
            int Numar2 = int.Parse(Console.ReadLine());

            Console.Write("\n Al doilea vector arata astfel: ");
            List<int> Vector2 = CitireVector(Numar2);

            if (Numar1 < Numar2)
            {
                (Vector1, Vector2) = (Vector2, Vector1);
            }

            Console.Write("\n\n Noul vector rezultat din interclasarea celor doi este: ");
            Interclasare(Vector1, Vector2);

            Console.Write("\n\n");
        }
        private static void Interclasare(List<int> Vector1, List<int> Vector2)
        {
            List<int> Vector3 = new List<int>();

            for (int i = 0; i < Vector1.Count; i++)
            {
                if (Gata == true)
                {
                    Vector3.Add(Vector1[i]);
                }
                else if (Gata == false)
                {
                    for (int j = 0; j < Vector2.Count; j++)
                    {
                        if (Vector1[i] < Vector2[j])
                        {
                            Vector3.Add(Vector1[i]);

                            i++;

                            j--;
                        }
                        else
                        {
                            Vector3.Add(Vector2[j]);
                        }
                    }
                }
                Gata = true;
            }

            for (int i = 0; i < Vector1.Count + Vector2.Count - 1; i++)
            {
                Console.Write(Vector3[i] + " ");
            }
        }
        private static List<int> CitireVector(int Numar)
        {
            Random Aleator = new Random();
            List<int> Vector = new List<int>();

            for (int i = 0; i < Numar; i++)
            {
                Vector.Add(Aleator.Next(0, Numar));
            }

            Vector.Sort();

            for (int i = 0; i < Numar; i++)
            {
                Console.Write(Vector[i] + " ");
            }

            return Vector;
        }
    }
}
