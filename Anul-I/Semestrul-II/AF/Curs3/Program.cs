using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem1();
            //Problem2();
            //Problem3();
            //Problem4();
            //Problem5();
            //Problem6();
            //Problem7();
        }

        private static void Problem7()
        {
            Console.Write("\n Introduceti dimensiunea matricii: ");
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[100, 100];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0 || j == 0 || j == size - 1 || i == size - 1)
                    {
                        matrix[i, j] = i + j + 2;
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + matrix[i - 1, j] + matrix[i - 1, j + 1];
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Problem6()
        {
            Console.Write("\n Introduceti dimensiunea matricii: ");
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[100, 100];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = i + j + 1;
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Problem5()
        {
            Console.Write("\n Introduceti numarul: ");
            int number = int.Parse(Console.ReadLine()), copy = number, counter = 0;

            while (copy != 0)
            {
                counter++;

                copy /= 10;
            }

            int[,] matrix = new int[10, 10];

            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter; j++)
                {
                    matrix[j, i] = number % 10; 
                }

                number /= 10;
            }

            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void Problem4()
        {
            Console.Write(" Introduceti numarul n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write(" Introduceti numarul m: ");
            int m = int.Parse(Console.ReadLine()), i, j;

            int[,] matrix = new int[n, m];

            Random rand = new Random();

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    matrix[i, j] = rand.Next(0, 100);

                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.Write("\n\n");

            int minRow = matrix[0, 0], minOverall;

            for (i = 1; i < n; i++)
            {
                if (matrix[0, i] < minRow)
                {
                    minRow = matrix[0, i];
                }
            }

            minOverall = minRow;

            for (i = 1; i < n; i++)
            {
                minRow = matrix[i, 0];

                for (j = 1; j < m; j++)
                {
                    if (matrix[i, j] < minRow)
                    {
                        minRow = matrix[i, j];
                    }
                }
                
                if (minRow > minOverall)
                {
                    minOverall = minRow;
                }
            }

            Console.Write(minOverall);
        }

        private static void Problem3()
        {
            Console.Write(" Introduceti numarul n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write(" Introduceti numarul m: ");
            int m = int.Parse(Console.ReadLine()), i, j;

            int[,] matrix = new int[n, m];

            Random rand = new Random();

            for (i = 0; i < n; i++)                    
            {
                for (j = 0; j < m; j++)
                {
                    matrix[i, j] = rand.Next(0, 100);

                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.Write("\n\n");

            for (i = 0; i < (Math.Min(n, m) / 2) + (Math.Min(n, m) % 2); i++)        
            {                                               
                for (j = i; j < m - i; j++)                 
                {
                    Console.Write(matrix[i, j] + " ");
                }                                       

                for (j = i + 1; j < n - i; j++)            
                {
                    Console.Write(matrix[j, m - i - 1] + " ");
                }

                for (j = m - i - 2; j >= i; j--)           
                {
                    Console.Write(matrix[n - i - 1, j] + " ");
                }

                for (j = n - i - 2; j >= i + 1; j--)           
                {
                    Console.Write(matrix[j, i] + " ");
                }
            }
        }

        private static void Problem2()
        {
            Random rand = new Random();

            Console.Write("\n Introduceti dimensiunea matricii: ");
            int dimension = int.Parse(Console.ReadLine()), i, j;

            int[,] matrix = new int[100, 100];

            Console.Write("\n Introduceti elementele matricii: \n\n");

            for (i = 0; i < dimension; i++)
            {
                for (j = 0; j < dimension; j++)
                {
                    matrix[i, j] = rand.Next(0, 9);

                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            for (i = 0; i < dimension; i++)
            {
                Console.Write(matrix[0, i] + " ");
            }    

            for (i = 1; i < dimension; i++)
            {
                Console.Write(matrix[i, dimension - 1] + " ");
            }

            for (i = dimension - 2; i >= 0; i--)
            {
                Console.Write(matrix[dimension - 1, i] + " ");
            }

            for (i = dimension - 2; i >= 1; i--)
            {
                Console.Write(matrix[i, 0] + " ");
            }
        }

        private static void Problem1()
        {
            Console.Write("\n Introduceti dimensiunea matricii: ");
            int dimension = int.Parse(Console.ReadLine());

            int[,] matrix = new int[100, 100];

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (i < j && i + j < dimension - 1)
                    {
                        matrix[i, j] = 1;
                    }
                    else if (i < j && i + j > dimension - 1)
                    {
                        matrix[i, j] = 2;
                    }
                    else if (i > j && i + j < dimension - 1)
                    {
                        matrix[i, j] = 3;
                    }
                    else if (i > j && i + j > dimension - 1)
                    {
                        matrix[i, j] = 4;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
