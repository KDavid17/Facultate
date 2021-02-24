using System;

namespace Problema_7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n Introduceti numarul de elemente din vector: ");
                long Numar = long.Parse(Console.ReadLine());

                if (Numar < 1)
                {
                    throw new Exception();
                }

                Console.Write("\n Introduceti numarul cautat: ");
                long Cautat = long.Parse(Console.ReadLine()), i, Pozitie;

                Console.Write("\n Introduceti elementele: \n");
                long[] Vector = new long[Numar];

                for (i = 0; i < Numar; i++)
                {
                    Console.Write($"\n Element {i + 1}: ");
                    Vector[i] = long.Parse(Console.ReadLine());
                }

                Pozitie = CautareBinara(0, Vector.Length - 1, Vector, Cautat);

                Console.Write(Pozitie == -1 ? "\n -1\n\n" : $"\n Numarul cautat se afla pe pozitia: {Pozitie}\n\n");
                                            ;
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }

        private static long CautareBinara(long Stanga, long Dreapta, long[] Vector, long Cautat)
        {
            long Mijloc;

            while (Stanga <= Dreapta)
            {
                Mijloc = (Stanga + Dreapta) / 2;

                if (Cautat == Vector[Mijloc])
                {
                    return Mijloc++;
                }
                else if (Cautat < Vector[Mijloc])
                {
                    Dreapta = Mijloc - 1;
                }
                else
                {
                    Stanga = Mijloc + 1;
                }
            }

            return -1;
        }
    }
}
