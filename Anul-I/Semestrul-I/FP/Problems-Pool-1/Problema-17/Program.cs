using System;

namespace Problema_17
{
    class Program
    {
        static void Main(string[] args)
        {
            long Numar1, Numar2, Auxiliar, Produs;

            try                                                     // Citirea datelor.
            {
                Console.Write("\n Introduceti primul numar: ");
                Numar1 = long.Parse(Console.ReadLine());

                Console.Write("\n Introduceti al doilea numar: ");
                Numar2 = long.Parse(Console.ReadLine());

                Produs = Numar1 * Numar2;                           // Produs pentru c.m.m.m.c.

                while (Numar2 != 0)                                 // Algoritmul lui Euclid.
                {
                    Auxiliar = Numar1 % Numar2;
                    Numar1 = Numar2;
                    Numar2 = Auxiliar;
                }
                
                Console.WriteLine($"\n Cel mai mare divizor comun este: {Numar1} .");

                Console.WriteLine($"\n Cel mai mic multiplu comun este: {Produs / Numar1} . \n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
    }
}
