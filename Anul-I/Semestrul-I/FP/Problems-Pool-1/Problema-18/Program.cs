using System;

namespace Problema_18
{
    class Program
    {
        static void Main(string[] args)
        {
            long Numar;
            sbyte Contor = 0;

            try                                                 // Citirea datelor.
            {
                Console.Write("\n Introduceti numarul: ");
                Numar = long.Parse(Console.ReadLine());

                if (Numar <= 1)
                {
                    throw new Exception();
                }

                Console.Write($"\n Descompunerea in factori primi a numarului {Numar} este: ");

                if (Numar % 2 == 0)                             // Verificam divizibilitatea cu 2.
                {
                    while (Numar % 2 == 0)
                    {
                        Contor++;

                        Numar /= 2;
                    }
                    Console.Write($"2 ^ {Contor} ");

                    Contor = 0;

                    if (Numar > 1)
                    {
                        Console.Write("x ");
                    }
                }
                                                                // Verificam divizibilitatea cu numerele impare.
                for (int i = 3; i <= (int)Math.Sqrt(Numar); i++)
                {
                    if (Numar % i == 0)
                    {
                        while (Numar % i == 0)
                        {
                            Contor++;

                            Numar /= i;
                        }
                        Console.Write($"{i} ^ {Contor} ");

                        Contor = 0;

                        if (Numar > 1)
                        {
                            Console.Write("x ");
                        }
                    }
                }

                if (Numar > 1)                                  // Caz de numar prim la puterea 1.
                {
                    Console.Write($"{Numar} ^ 1");
                }

                Console.WriteLine("\n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
    }
}
