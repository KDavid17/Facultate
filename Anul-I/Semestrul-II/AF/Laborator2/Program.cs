using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs2
{
    class Program
    {
        static void Main(string[] args)
        {
           // problema1();
           // problema2();
           // problema3();
        }

        private static void problema3()
        {
            Console.Write("\n Introduceti lungimea vectorului: ");
            int numar = int.Parse(Console.ReadLine());

            Console.Write("\n Introduceti elementele vectorului: ");

            int[] vector1 = new int[numar], vector2 = new int[1001];

            Random aleator = new Random();

            for (int i = 0; i < numar; i++)
            {
                vector1[i] = aleator.Next(0, 1001);

                Console.Write(vector1[i] + " ");
            }

            Console.Write("\n\n Vectorul sortat: ");

            for (int i = 0; i < numar; i++)
            {
                vector2[vector1[i]]++;
            }

            for (int i = 0; i < 1001; i++)
            {
                while (vector2[i] != 0)
                {
                    Console.Write(i + " ");

                    vector2[i]--;
                }
            }
        }

        private static void problema2()
        {
            Console.Write("\n Introduceti numarul: ");
            int numar = int.Parse(Console.ReadLine()), min = 10;

            bool zero = false;
            int[] vector = new int[11];

            Console.Write("\n Cel mai mare numar cu cifrele date: ");

            while (numar != 0)
            {
                vector[numar % 10]++;

                if (numar % 10 < min && numar % 10 != 0)
                {
                    min = numar % 10;
                }

                if (numar % 10 == 0 && zero == false)
                {
                    zero = true;
                }

                numar /= 10;
            }

            for (int i = 9; i >= 0; i--)
            {
               for (int j = vector[i]; j > 0; j--)
               {
                    Console.Write(i);
               }
            }

            Console.Write("\n\n Cel mai mic numar cu cifrele date: ");

            if (zero == true)
            {
                Console.Write(min);

                vector[min]--;
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = vector[i]; j > 0; j--)
                {
                    Console.Write(i);
                }
            }

            Console.Write("\n\n");
        }

        private static void problema1()
        {
            Console.Write("\n Introduceti primul numar: ");
            int numar1 = int.Parse(Console.ReadLine());

            Console.Write("\n Introduceti al doilea numar: ");
            int numar2 = int.Parse(Console.ReadLine());

            bool[] vector1 = new bool[11], vector2 = new bool[11];

            Console.Write("\n Cifrele comune: ");

            while (numar1 != 0)
            {
                vector1[numar1 % 10] = true;

                numar1 /= 10;
            }

            while (numar2 != 0)
            {
                vector2[numar2 % 10] = true;

                numar2 /= 10;
            }

            for (int i = 0; i <= 10; i++)
            {
                if (vector1[i] == true && vector2[i] == true)
                {
                    Console.Write(i + " ");
                }
            }

            Console.Write("\n\n");
        }
    }
}
