using System;
using System.Collections.Generic;

namespace Problema_22
{
    class Program
    {
        private static bool Schimbare = false;
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

                Schimbare = true;
            }

            Console.Write("\n\n Reuniunea: ");
            Reuniunea(Vector1, Vector2);

            Console.Write("\n\n Intersectia: ");
            Intersectia(Vector1, Vector2);


            if (Schimbare == false)
            {
                Console.Write("\n\n Vector1 - Vector2 : ");
                V1_V2(Vector1, Vector2);

                Console.Write("\n\n Vector2 - Vector1 : ");
                V2_V1(Vector1, Vector2);
            }
            else
            {
                Console.Write("\n\n Vector1 - Vector2 : ");
                V2_V1(Vector1, Vector2);

                Console.Write("\n\n Vector2 - Vector1 : ");
                V1_V2(Vector1, Vector2);
            }

            Console.Write("\n\n");
        }

        private static void V1_V2(List<int> Vector1, List<int> Vector2)
        {
            List<int> Vector3 = new List<int>();

            for (int i = 0; i < Vector1.Count; i++)
            {
                if (i < Vector2.Count)
                {
                    if (Vector1[i] == 1 && Vector2[i] == 0)
                    {
                        Vector3.Add(1);
                    }
                    else
                    {
                        Vector3.Add(0);
                    }
                }
                else
                {
                    if (Vector1[i] == 1)
                    {
                        Vector3.Add(1);
                    }
                    else
                    {
                        Vector3.Add(0);
                    }
                }
            }

            for (int i = 0; i < Vector3.Count; i++)
            {
                Console.Write(Vector3[i] + " ");
            }

            Console.Write(", adica multimea Vector1 - Vector2 este: ");

            for (int i = 0; i < Vector3.Count; i++)
            {
                if (Vector3[i] == 1)
                {
                    Console.Write(i + " ");
                }
            }
        }
        private static void V2_V1(List<int> Vector1, List<int> Vector2)
        {
            List<int> Vector3 = new List<int>();

            for (int i = 0; i < Vector2.Count; i++)
            {
                if (i < Vector1.Count)
                {
                    if (Vector2[i] == 1 && Vector1[i] == 0)
                    {
                        Vector3.Add(1);
                    }
                    else
                    {
                        Vector3.Add(0);
                    }
                }
                else
                {
                    if (Vector2[i] == 1)
                    {
                        Vector3.Add(1);
                    }
                    else
                    {
                        Vector3.Add(0);
                    }
                }
            }

            for (int i = 0; i < Vector3.Count; i++)
            {
                Console.Write(Vector3[i] + " ");
            }

            Console.Write(", adica multimea Vector2 - Vector1 este: ");

            for (int i = 0; i < Vector3.Count; i++)
            {
                if (Vector3[i] == 1)
                {
                    Console.Write(i + " ");
                }
            }
        }
        private static void Intersectia(List<int> Vector1, List<int> Vector2)
        {
            List<int> Vector3 = new List<int>();

            for (int i = 0; i < Vector2.Count; i++)
            {
                if (Vector1[i] == 1 && Vector2[i] == 1)
                {
                    Vector3.Add(1);
                }
                else
                {
                    Vector3.Add(0);
                }
            }

            for (int i = 0; i < Vector3.Count; i++)
            {
                Console.Write(Vector3[i] + " ");
            }

            Console.Write(", adica multimea intersectiei vectorilor este: ");

            for (int i = 0; i < Vector3.Count; i++)
            {
                if (Vector3[i] == 1)
                {
                    Console.Write(i + " ");
                }
            }
        }
        private static void Reuniunea(List<int> Vector1, List<int> Vector2)
        {
            List<int> Vector3 = new List<int>();

            for (int i = 0; i < Vector1.Count; i++)
            {
                if (Vector1[i] == 1)
                {
                    Vector3.Add(1);
                }
                else
                {
                    Vector3.Add(0);
                }
            }

            for (int i = 0; i < Vector2.Count; i++)
            {
                if (Vector3[i] == 0 && Vector2[i] == 1)
                {
                    Vector3[i] = 1;
                }
            }

            for (int i = 0; i < Vector3.Count; i++)
            {
                Console.Write(Vector3[i] + " ");
            }

            Console.Write(", adica multimea reuniunii vectorilor este: ");

            for (int i = 0; i < Vector3.Count; i++)
            {
                if (Vector3[i] == 1)
                {
                    Console.Write(i + " ");
                }
            }
        }
        private static List<int> CitireVector(int Numar)
        {
            Random Aleator = new Random();
            List<int> Vector1 = new List<int>();

            for (int i = 0; i < Numar; i++)
            {
                Vector1.Add(Aleator.Next(0, Numar));
            }

            for (int i = 0; i < Numar; i++)
            {
                if (Vector1.Contains(i) == true)
                {
                    Vector1[i] = 1;
                }
                else
                {
                    Vector1[i] = 0;
                }

                Console.Write(Vector1[i] + " ");
            }

            Console.Write(", adica multimea este: ");

            for (int i = 0; i < Numar; i++)
            {
                if (Vector1[i] == 1)
                {
                    Console.Write(i + " ");
                }
            }

            return Vector1;
        }
    }
}