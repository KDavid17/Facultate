using System;

namespace Problema_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, Delta;

            try                                             // Citirea datelor.
            {
                Console.Write("\n Introduceti primul coeficient: ");
                a = double.Parse(Console.ReadLine());

                Console.Write("\n Introduceti al doilea coeficient: ");
                b = double.Parse(Console.ReadLine());

                Console.Write("\n Introduceti constanta: ");
                c = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei.\n");

                return;
            }

            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)                                     // Cazul a = b = c = 0.
                    {
                        Console.WriteLine($"\n Ecuatia: {a} * x ^ 2 + {b} * x + {c} = 0 are ca solutie orice numar complex. \n");
                    }
                    else                                            // Cazul a = b = 0.
                    {
                        Console.WriteLine($"\n Ecuatia: {a} * x ^ 2 + {b} * x + {c} = 0 nu are solutie. \n");
                    }
                }
                else
                {
                    if (c == 0)                                     // Cazul a = c = 0.
                    {
                        Console.WriteLine($"\n Solutia ecuatiei: {a} * x ^ 2 + {b} * x + {c} = 0 este: x = 0 . \n");
                    }
                    else                                            // Cazul a = 0.
                    {
                        Console.WriteLine($"\n Solutia ecuatiei: {a} * x ^ 2 + {b} * x + {c} = 0 este: x = {-c / b} . \n");
                    }
                }
            }
            else
            {
                if (b == 0 && c == 0)                               // Cazul b = c = 0.
                {
                    Console.WriteLine($"\n Solutia ecuatiei: {a} * x ^ 2 + {b} * x + {c} = 0 este: x = 0 . \n");
                }
                else
                {
                    if (b * b > 4 * a * c)                          // Verificam daca Delta e negativ sau pozitiv.
                    {
                        Delta = Math.Sqrt(b * b - 4 * a * c);
                    }
                    else                                            
                    {
                        Delta = -Math.Sqrt(-(b * b - 4 * a * c));
                    }

                    if (Delta < 0)                                  // Cazul Delta < 0.
                    {
                        Console.WriteLine($"\n Ecuatia: {a} * x ^ 2 + {b} * x + {c} = 0 nu are solutii reale. \n");
                        Console.WriteLine($" Solutiile complexe ale ecuatiei sunt: x = {-b / (2 * a)} + i * {-Delta} si x = {-b / (2 * a)} - i * {-Delta} .\n");
                    }
                    else if (Delta == 0)                            // Cazul Delta = 0.
                    {
                        Console.WriteLine($"\n Solutia unica a ecuatiei: {a} * x ^ 2 + {b} * x + {c} = 0 este: x = {-b / (2 * a)} . \n");
                    }
                    else                                            // Cazul Delta > 0.
                    {
                        Console.Write($"\n Cele doua solutii ale ecuatiei: {a} * x ^ 2 + {b} * x + {c} = 0 sunt: ");
                        Console.WriteLine($"x = {(-b + Delta) / (2 * a)} si x = {(-b - Delta) / (2 * a)} . \n");
                    }
                }
            }
        }
    }
}
