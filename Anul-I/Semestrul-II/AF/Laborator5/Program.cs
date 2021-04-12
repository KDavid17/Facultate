using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Laborator5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Problema1();
            // Problema2();
        }

        private static void Problema2()
        {
            Random rnd = new Random();

            Console.Write("\n Introduceti n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("\n Introduceti m: ");
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rnd.Next(0, 3);
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int k = 0; k < 1000; k++)
            {
                ChangeMatrix(matrix, n, m);
                Thread.Sleep(10);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void ChangeMatrix(int[,] matrix, int n, int m)
        {
            Random rnd = new Random();

            int ip1, jp1, ip2 = 0, jp2 = 0, adjacent;
            bool exists = true, correct = false;

            ip1 = rnd.Next(0, n);
            jp1 = rnd.Next(0, m);

            while (correct == false)
            {
                adjacent = rnd.Next(0, 8);

                switch (adjacent)
                {
                    case 0:
                        if (ip1 - 1 >= 0 && jp1 - 1 >= 0)
                        {
                            ip2 = ip1 - 1;
                            jp2 = jp1 - 1;
                            correct = true;
                        }
                        break;
                    case 1:
                        if (ip1 - 1 >= 0)
                        {
                            ip2 = ip1 - 1;
                            jp2 = jp1;
                            correct = true;
                        }
                        break;
                    case 2:
                        if (ip1 - 1 >= 0 && jp1 + 1 <= m - 1)
                        {
                            ip2 = ip1 - 1;
                            jp2 = jp1 + 1;
                            correct = true;
                        }
                        break;
                    case 3:
                        if (jp1 - 1 >= 0)
                        {
                            ip2 = ip1;
                            jp2 = jp1 - 1;
                            correct = true;
                        }
                        break;
                    case 4:
                        if (jp1 + 1 <= m - 1)
                        {
                            ip2 = ip1;
                            jp2 = jp1 + 1;
                            correct = true;
                        }
                        break;
                    case 5:
                        if (ip1 + 1 <= n - 1 && jp1 - 1 >= 0)
                        {
                            ip2 = ip1 + 1;
                            jp2 = jp1 - 1;
                            correct = true;
                        }
                        break;
                    case 6:
                        if (ip1 + 1 <= n - 1)
                        {
                            ip2 = ip1 + 1;
                            jp2 = jp1;
                            correct = true;
                        }
                        break;
                    case 7:
                        if (ip1 + 1 <= n - 1 && jp1 + 1 <= m - 1)
                        {
                            ip2 = ip1 + 1;
                            jp2 = jp1 + 1;
                            correct = true;
                        }
                        break;
                }
            }
            
            if (matrix[ip1, jp1] == 0 && matrix[ip2, jp2] == 1)
            {
                matrix[ip1, jp1] = 1;
            }
            else if (matrix[ip1, jp1] == 1 && matrix[ip2, jp2] == 0)
            {
                matrix[ip2, jp2] = 1;
            }
            else if ((matrix[ip1, jp1] == 1 && matrix[ip2, jp2] == 1) || (matrix[ip1, jp1] == 2 && matrix[ip2, jp2] == 2))
            {
                int check = rnd.Next(0, 2);

                if (check == 0)
                {
                    matrix[ip1, jp1] = 0;
                }
                else
                {
                    matrix[ip2, jp2] = 0;
                }
            }
            else if (matrix[ip1, jp1] == 2 && matrix[ip2, jp2] == 0)
            {
                matrix[ip1, jp1] = 0;
            }
            else if (matrix[ip1, jp1] == 1 && matrix[ip2, jp2] == 2)
            {
                matrix[ip1, jp1] = 2;
            }
            else if (matrix[ip1, jp1] == 2 && matrix[ip2, jp2] == 1)
            {
                matrix[ip2, jp2] = 2;
            }

        }

        private static void Problema1()
        {
            Random rnd = new Random();

            Console.Write("\n Introduceti n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("\n Introduceti m: ");
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rnd.Next(0, 2);
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            EliminateZeros(matrix, n, m);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void EliminateZeros(int[,] matrix, int n, int m)
        {
            int zeroCounter, oneCounter;
            bool exists = true;

            while (exists)
            {
                exists = false;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        zeroCounter = 0;
                        oneCounter = 0;

                        #region all-cases
                        if (matrix[i, j] == 1)
                        {
                            exists = true;

                            if (i - 1 >= 0)
                            {
                                if (j - 1 >= 0)
                                {
                                    if (matrix[i - 1, j - 1] == 0)
                                    {
                                        zeroCounter++;
                                    }
                                    else
                                    {
                                        oneCounter++;
                                    }
                                }

                                if (matrix[i - 1, j] == 0)
                                {
                                    zeroCounter++;
                                }
                                else
                                {
                                    oneCounter++;
                                }

                                if (j + 1 <= m - 1)
                                {
                                    if (matrix[i - 1, j + 1] == 0)
                                    {
                                        zeroCounter++;
                                    }
                                    else
                                    {
                                        oneCounter++;
                                    }
                                }
                            }

                            if (j - 1 >= 0)
                            {
                                if (matrix[i, j - 1] == 0)
                                {
                                    zeroCounter++;
                                }
                                else
                                {
                                    oneCounter++;
                                }
                            }

                            if (j + 1 <= m - 1)
                            {
                                if (matrix[i, j + 1] == 0)
                                {
                                    zeroCounter++;
                                }
                                else
                                {
                                    oneCounter++;
                                }
                            }

                            if (i + 1 <= n - 1)
                            {
                                if (j - 1 >= 0)
                                {
                                    if (matrix[i + 1, j - 1] == 0)
                                    {
                                        zeroCounter++;
                                    }
                                    else
                                    {
                                        oneCounter++;
                                    }
                                }

                                if (matrix[i + 1, j] == 0)
                                {
                                    zeroCounter++;
                                }
                                else
                                {
                                    oneCounter++;
                                }

                                if (j + 1 <= m - 1)
                                {
                                    if (matrix[i + 1, j + 1] == 0)
                                    {
                                        zeroCounter++;
                                    }
                                    else
                                    {
                                        oneCounter++;
                                    }
                                }
                            }
                        }
                        #endregion
                        if (zeroCounter >= oneCounter)
                        {
                            matrix[i, j] = 0;
                        }
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
