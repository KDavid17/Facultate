using System;

namespace Problema_12
{
    class Program
    {
        static void Main(string[] args)
        {
            long a, b, Numar, Suma;

            try                                                 // Citirea datelor.
            {
                Console.Write("\n Introduceti marginea inferioara a intervalului: ");
                a = long.Parse(Console.ReadLine());

                Console.Write("\n Introduceti marginea superioara a intervalului: ");
                b = long.Parse(Console.ReadLine());     
                            
                Console.Write("\n Introduceti numarul: ");

                Numar = long.Parse(Console.ReadLine());

                if (b < a || Numar == 0)                        // Exceptie pentru date neprocesabile.
                {
                    throw new Exception();
                }

                Console.Write($"\n In intervalul [{a},{b}], numarul {Numar} divide ");

                Numar = Math.Abs(Numar);

                Suma = b / Numar - a / Numar;                   // Numarul de numere divizibile cu numarul dat.

                if ((a < 0 && b > 0) || a % Numar == 0)         // Adaugam 1 daca marginea inferioara este < 0
                {                                               // iar cea superioara > 0 sau daca marginea
                    Suma++;                                     // inferioara e divizibila cu numarul dat.
                }

                Console.Write(Suma + " numere. \n\n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
    }
}