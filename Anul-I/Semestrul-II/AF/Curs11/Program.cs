using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Curs11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem1();
            //Problem2();
            //Problem3();
        }

        private static void Problem3()
        {
            string text = File.ReadAllText(@"../../Ham.txt");

            string[] subtext = text.Split(' ');

            int numb1 = 0, numb2 = 0;

            for (int i = 0; i < subtext.Length; i++)
            {
                int aux = int.Parse(subtext[i]);
                if (aux % 2 != 0)
                {
                    if (numb1 != 0 && numb2 != 0)
                    {
                        numb1 = numb2;

                        numb2 = aux;
                    }
                    else if (numb1 != 0)
                    {
                        numb2 = aux;
                    }
                    else
                    {
                        numb1 = aux;
                    }
                }
            }

            if (numb1 == 0 || numb2 == 0)
            {
                Console.WriteLine("NU EXISTA");
            }
            else
            {
                Console.WriteLine(numb1 + " " + numb2);
            }
        }

        private static void Problem2()
        {
            Console.Write(" Introduceti dimensiunea: \n n:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(" Introduceti elementele matricii:");
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                   if (j + 1 != n && j > i && i + j + 1 > n)
                    {
                        sum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine(sum);
        }

        private static void Problem1()
        {
            Console.Write(" Introduceti n: ");
            int n = int.Parse(Console.ReadLine()), mxFact = 0, mxNr = 0;

            for (int i = 2; i <= n; i++)
            {
                int aux = Decomp(i);

                if (aux >= mxFact)
                {
                    mxNr = i;

                    mxFact = aux;
                }
            }

            Console.WriteLine(mxNr);
        }

        private static int Decomp(int numb)
        {
            int result = 0;

            if (numb % 2 == 0)
            {
                result++;

                while (numb % 2 == 0)
                {
                    numb /= 2;
                }
            }

            for (int i = 3; i * i <= numb; i += 2)
            {
                if (numb % i == 0)
                {
                    result++;

                    while (numb % i == 0)
                    {
                        numb /= i;
                    }
                }
            }

            if (numb > 1)
            {
                result++;
            }

            return result;
        }
    }
}
