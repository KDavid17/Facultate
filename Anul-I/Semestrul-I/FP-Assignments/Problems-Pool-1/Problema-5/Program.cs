using System;

namespace Problema_5
{
    class Program
    {
        /// <summary>
        /// Afisam cifra prin luarea ultimei cifre din impartirea numarului 
        /// initial la 10 la puterea k-1.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n Introduceti numarul: ");
                double Numar = long.Parse(Console.ReadLine());

                Console.Write("\n Introduceti numarul care da pozitia cifrei: ");
                sbyte Cifra = sbyte.Parse(Console.ReadLine());

                Numar = Math.Floor(Numar / Math.Pow(10, Cifra - 1));

                Console.Write(Numar != 0 ? $"\n A {Cifra}-a cifra a numarului introdus este: " +
                                           $"{Numar % 10} . \n\n" : throw new Exception());
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
    }
}
