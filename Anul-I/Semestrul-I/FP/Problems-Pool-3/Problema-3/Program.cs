using System;

namespace Problema_3
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

                Console.Write("\n Introduceti elementele: \n\n Element 1: ");
                long Maxim = long.Parse(Console.ReadLine()), Minim = Maxim;
                int i;
                string PozitieMaxim = "0", PozitieMinim = "0";

                long[] Vector = new long[Numar];
                Vector[0] = Maxim;

                for (i = 1; i < Numar; i++)
                {
                    Console.Write($"\n Element {i + 1}: ");
                    Vector[i] = long.Parse(Console.ReadLine());

                    if (Vector[i] < Minim)
                    {
                        Minim = Vector[i];

                        PozitieMinim = $"{i}";
                    }
                    else if (Vector[i] > Maxim)
                    {
                        Maxim = Vector[i];

                        PozitieMaxim = $"{i}";
                    }
                    else if (Vector[i] == Minim)
                    {
                        PozitieMinim += $"{i}";
                    }
                    else if (Vector[i] == Maxim)
                    {
                        PozitieMaxim += $"{i}";
                    }
                }

                Console.Write("\n Pozitiile pe care apare cel mai mic element din vector: ");

                for (i = 0; i < PozitieMinim.Length; i++)
                {
                    Console.Write(PozitieMinim[i] + " ");
                }

                Console.Write("\n\n Pozitiile pe care apare cel mai mare element din vector: ");

                for (i = 0; i < PozitieMaxim.Length; i++)
                {
                    Console.Write(PozitieMaxim[i] + " ");
                }

                Console.Write("\n\n");
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile confrom cerintei. \n");
            }
        }
    }
}
