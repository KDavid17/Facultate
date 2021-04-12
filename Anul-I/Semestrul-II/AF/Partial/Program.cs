using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Partial
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercitiul1();
            //Exercitiul2();
        }

        private static void Exercitiul2()
        {
            string[] text = File.ReadAllLines("../../ex02.in.txt");

            string[] subtext = text[0].Split(' ');

            int n = subtext.Length;

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                subtext = text[i].Split(' ');

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(subtext[j]);
                }
            }

            while (n != 1)
            {
                n /= 2;

                int[,] tempMatrix = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        tempMatrix[i, j] = matrix[i * 2, j * 2] * matrix[i * 2 + 1, j * 2 + 1] - (matrix[i * 2, j * 2 + 1] * matrix[i * 2 + 1, j * 2]);

                        matrix[i, j] = tempMatrix[i, j];
                    }
                }
            }

            File.WriteAllText("../../ex02.out.txt", matrix[0, 0].ToString());
        }

        private static void Exercitiul1()
        {
            int[] fib = new int[45];

            fib[0] = 0;
            fib[1] = 1;
            fib[2] = 1;

            FibonacciElements(fib, 44); // Al 45-lea element din sirul lui Fibonacci este peste 1 miliard

            string text = File.ReadAllText("../../ex01.in.txt");

            string[] numbers = text.Split(' ');

            int[] results = new int[numbers.Length];

            for (int j = 0; j < numbers.Length; j++)
            {
                int min1, min2 = 0, numb = int.Parse(numbers[j]);

                for (int i = 0; i < 45; i++)
                {
                    if (numb == fib[i])
                    {
                        results[j] = 0;

                        break;
                    }
                    else
                    {
                        min1 = numb - fib[i];

                        if (min1 < 0)
                        {
                            if (Math.Abs(min1) < Math.Abs(min2))
                            {
                                results[j] = -min1;
                            }
                            else
                            {
                                results[j] = -min2;
                            }

                            break;
                        }
                        else
                        {
                            min2 = min1;
                        }
                    }
                }
            }

            string final = "";

            foreach (var item in results)
            {
                final += item.ToString() + " ";
            }

            File.WriteAllText("../../ex01.out.txt", final);
        }

        static int FibonacciElements(int[] fib, int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return fib[n] = FibonacciElements(fib, n - 2) + FibonacciElements(fib, n - 1);
            }
        }
    }
}
