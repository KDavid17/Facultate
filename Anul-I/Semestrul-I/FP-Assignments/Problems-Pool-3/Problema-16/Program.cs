using System;

namespace Problema_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n Introduceti numarul de elemente: ");
            int Numar = int.Parse(Console.ReadLine()), i;

            int[] Vector = new int[Numar];
            Random Aleator = new Random();

            Console.Write("\n Vectorul: \n\n");

            for (i = 0; i < Numar; i++)
            {
                Vector[i] = Aleator.Next(1, Numar);

                Console.Write(Vector[i] + " ");
            }

            Console.Write("\n\n Cel mai mare divizor comun al elementelor vectorului este: ");

            if (Numar > 1)
            {
                int Divizor = cmmdc(Vector[0], Vector[1]);
                bool Prime = false;

                if (Divizor == 1)
                {
                    Prime = true;
                }
                else
                {
                    for (i = 2; i < Vector.Length; i++)
                    {
                        if (Vector[i] % Divizor != 0)
                        {
                            Prime = true;

                            i = Vector.Length;
                        }
                    }
                }

                if (Prime == false)
                {
                    Console.Write(Divizor + "\n\n");
                }
                else
                {
                    Console.Write(1 + "\n\n");
                }
            }
            else
            {
                Console.Write(Vector[0] + "\n\n");
            }
        }

        private static int cmmdc(int a, int b)
        {
            if (a % b != 0)
            {
                return cmmdc(b, a % b);
            }
            else return b;
        }
    }
}
