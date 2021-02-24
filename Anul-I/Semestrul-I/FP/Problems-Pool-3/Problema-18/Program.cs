using System;

namespace Problema_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n Introduceti gradul functiei: ");
            int Numar = int.Parse(Console.ReadLine()), i;

            Console.Write("\n Introduceti valoarea lui X: ");
            int X = int.Parse(Console.ReadLine()), Suma = 0;

            Random Aleator = new Random();
            int[] Vector = new int[Numar + 1];

            Console.Write("\n Coeficientii: ");

            for (i = 0; i <= Numar; i++)
            {
                Vector[i] = Aleator.Next(0, Numar);

                Console.Write(Vector[i] + " ");
            }

            Console.Write($"\n\n Valoarea functiei in X = {X} este egala cu: ");

            for (i = 0; i <= Numar; i++)
            {
                Suma = Suma + (int)Math.Pow(X, i) * Vector[i];
            }

            Console.Write(Suma + "\n\n");
        }
    }
}
