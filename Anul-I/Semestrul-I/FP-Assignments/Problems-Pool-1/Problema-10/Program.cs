using System;

namespace Problema_10
{
    class Program
    {

        static void Main(string[] args)
        {
            long Numar;
            int i;

            try                                                 // Citirea datelor.
            {
                Console.Write("\n Introduceti numarul: ");
                Numar = long.Parse(Console.ReadLine());

                if (VerificarePrim(Numar) == true)              // Verificam daca numarul este prim.
                {
                    Console.WriteLine($"\n Numarul {Numar} este prim. \n");
                }
                else
                {
                    Console.WriteLine($"\n Numarul {Numar} nu este prim. \n");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
            
        }
        private static bool VerificarePrim(long Numar)
        {
            if (Numar == 0 || Numar == 1)                       // 0 si 1 nu sunt numere prime.
            {
                return false;
            }

            if (Numar % 2 == 0 && Numar != 2)                   // 2 este unicul numar par si prim.
            {
                return false;
            }

            for (int i = 3; i < Math.Sqrt(Numar); i += 2)       // Verificam daca numarul se imparte
            {                                                   // la vreun numar impar.
                if (Numar % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
