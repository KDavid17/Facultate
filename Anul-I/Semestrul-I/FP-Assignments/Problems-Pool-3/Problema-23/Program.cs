using System;
using System.Collections.Generic;

namespace Problema_22
{
    class Program
    {
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

            Console.Write("\n\n Reuniunea: ");
            Reuniunea(Vector1, Vector2);

            Console.Write("\n\n Intersectia: ");
            Intersectia(Vector1, Vector2);

            Console.Write("\n\n Vector1 - Vector2 : ");
            V1_V2(Vector1, Vector2);

            Console.Write("\n\n Vector2 - Vector1 : ");
            V2_V1(Vector1, Vector2);

            Console.Write("\n\n");
        }

        private static void V1_V2(List<int> Vector1, List<int> Vector2)
        {
            List<int> Vector3 = new List<int>();

            for (int i = 0; i < Vector1.Count; i++)
            {
                if (Vector3.Contains(Vector1[i]) == false && Vector2.Contains(Vector1[i]) == false)
                {
                    Vector3.Add(Vector1[i]);
                }
            }

            for (int i = 0; i < Vector3.Count; i++)
            {
                Console.Write(Vector3[i] + " ");
            }
        }
        private static void V2_V1(List<int> Vector1, List<int> Vector2)
        {
            List<int> Vector3 = new List<int>();

            for (int i = 0; i < Vector2.Count; i++)
            {
                if (Vector3.Contains(Vector2[i]) == false && Vector1.Contains(Vector2[i]) == false)
                {
                    Vector3.Add(Vector2[i]);
                }
            }

            for (int i = 0; i < Vector3.Count; i++)
            {
                Console.Write(Vector3[i] + " ");
            }
        }
        private static void Intersectia(List<int> Vector1, List<int> Vector2)
        {
            List<int> Vector3 = new List<int>();

            for (int i = 0; i < Vector1.Count; i++)
            {
                if (Vector3.Contains(Vector1[i]) == false && Vector2.Contains(Vector1[i]) == true)
                {
                    Vector3.Add(Vector1[i]);
                }
            }

            for (int i = 0; i < Vector3.Count; i++)
            {
                Console.Write(Vector3[i] + " ");
            }
        }
        private static void Reuniunea(List<int> Vector1, List<int> Vector2)
        {
            List<int> Vector3 = new List<int>();

            for (int i = 0; i < Vector1.Count; i++)
            {
                if (Vector3.Contains(Vector1[i]) == false)
                {
                    Vector3.Add(Vector1[i]);
                }
            }

            for (int i = 0; i < Vector2.Count; i++)
            {
                if (Vector3.Contains(Vector2[i]) == false)
                {
                    Vector3.Add(Vector2[i]);
                }
            }

            for (int i = 0; i < Vector3.Count; i++)
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