using System;

namespace Problema_20
{
    class Program
    {
        static void Main(string[] args)
        {
            long Numarator, Numitor;

            try
            {
                Console.Write("\n Introduceti numaratorul: ");
                Numarator = long.Parse(Console.ReadLine());

                Console.Write("\n Introduceti numitorul: ");
                Numitor = long.Parse(Console.ReadLine());

                if (Numarator % Numitor == 0)
                {
                    Console.WriteLine($"\n Fractia {Numarator} / {Numitor} este egala cu: {(double)(Numarator / Numitor)}.0 \n");
                }
                else
                {
                    long Auxiliar = Numitor;

                    while (Numitor % 2 == 0)
                    {
                        Numitor /= 2;
                    }
                    while (Numitor % 5 == 0)
                    {
                        Numitor /= 5;
                    }

                    if (Numitor == 1 || Numarator % Numitor == 0)
                    {
                        Console.WriteLine($"\n Fractia {Numarator} / {Auxiliar} este egala cu: {(double)Numarator / (double)Auxiliar} \n");
                    }
                    else
                    {
                        Console.Write($"\n Fractia {Numarator} / {Auxiliar} este egala cu: {Numarator / Auxiliar}.");

                        long[] Perioada = new long[20];

                        for (int i = 0; i <= 20; i++)
                        {
                            Numarator *= 10;

                            Perioada[i] = Numarator / Numitor;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. ");
            }
        }
    }
}
