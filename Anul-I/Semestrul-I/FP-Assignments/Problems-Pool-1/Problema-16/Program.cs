using System;

namespace Problema_16
{
    class Program
    {
        static void Main(string[] args)
        {
            long Numar1, Numar2, Numar3, Numar4, Numar5;

            try                                                 // Citirea si ordonarea datelor.
            {
                Console.Write("\n Introduceti primul numar: ");
                Numar1 = long.Parse(Console.ReadLine());

                Console.Write("\n Introduceti al doilea numar: ");
                Numar2 = long.Parse(Console.ReadLine());
                (Numar1, Numar2) = (Math.Min(Numar1, Numar2), Math.Max(Numar1, Numar2));

                Console.Write("\n Introduceti al treilea numar: ");
                Numar3 = long.Parse(Console.ReadLine());
                (Numar2, Numar3) = (Math.Min(Numar2, Numar3), Math.Max(Numar2, Numar3));
                (Numar1, Numar2) = (Math.Min(Numar1, Numar2), Math.Max(Numar1, Numar2));

                Console.Write("\n Introduceti al patrulea numar: ");
                Numar4 = long.Parse(Console.ReadLine());
                (Numar3, Numar4) = (Math.Min(Numar3, Numar4), Math.Max(Numar3, Numar4));
                (Numar2, Numar3) = (Math.Min(Numar2, Numar3), Math.Max(Numar2, Numar3));
                (Numar1, Numar2) = (Math.Min(Numar1, Numar2), Math.Max(Numar1, Numar2));

                Console.Write("\n Introduceti al cincilea numar: ");
                Numar5 = long.Parse(Console.ReadLine());
                (Numar4, Numar5) = (Math.Min(Numar4, Numar5), Math.Max(Numar4, Numar5));
                (Numar3, Numar4) = (Math.Min(Numar3, Numar4), Math.Max(Numar3, Numar4));
                (Numar2, Numar3) = (Math.Min(Numar2, Numar3), Math.Max(Numar2, Numar3));
                (Numar1, Numar2) = (Math.Min(Numar1, Numar2), Math.Max(Numar1, Numar2));

                Console.WriteLine($"\n Numerele introduse ordonate crescator sunt: {Numar1}, {Numar2}, {Numar3}, {Numar4}, {Numar5} . \n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
    }
}
