using System;

namespace Problema_19
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Succes = false;
            sbyte Cifra1, Cifra2 = -1;
            long Numar;

            try                                                     // Citirea datelor.
            {
                Console.Write("\n Introduceti numarul: ");
                Numar = long.Parse(Console.ReadLine());

                Console.Write($"\n Numarul {Numar} ");

                Cifra1 = (sbyte)(Numar % 10);                       // Prima cifra.

                Numar /= 10;

                while (Numar > 0)
                {
                    if (Numar % 10 != Cifra1 && Cifra2 == -1)       // Conditie pentru a 2-a cifra.
                    {
                        Cifra2 = (sbyte)(Numar % 10);

                        Succes = true;
                    }
                    else if (Numar % 10 != Cifra1 && Numar % 10 != Cifra2)
                    {
                        Succes = false;                             // Conditie pentru o a 3-a cifra.

                        Numar = 0;
                    }

                    Numar /= 10;
                }

                Console.WriteLine(Succes == true ? "este format doar din 2 cifre care se pot repeta. \n" : "nu este format doar din 2 cifre care se pot repeta. \n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
    }
}