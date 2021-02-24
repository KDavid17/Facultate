using System;

namespace Problema_13
{
    class Program
    {
        static void Main(string[] args)
        {
            long An_1, An_2, Diferenta;

            try
            {
                Console.Write("\n Introduceti primul an: ");
                (An_1, An_2) = (long.Parse(Console.ReadLine()), 0);

                Console.Write("\n Introduceti al doilea an: ");
                (An_1, An_2) = (An_1, long.Parse(Console.ReadLine()));

                if (An_1 < 0 || An_2 < 0)                       // Exceptie pentru numere negative.
                {
                    throw new Exception();
                }

                Console.Write($"\n Intre anii {An_1} si {An_2} sunt: ");

                if (An_2 < An_1)                                // Inversam valorile daca este necesar.
                {
                    (An_1, An_2) = (An_2, An_1);
                }

                Diferenta = An_2 / 4 - An_1 / 4;                // Diferenta intre cei doi ani.

                if (An_1 % 4 == 0)                              // Adaugam 1 daca primul an e bisect.
                {
                    Diferenta++;
                }

                Console.Write($"{Diferenta} ani bisecti. \n\n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
    }
}
