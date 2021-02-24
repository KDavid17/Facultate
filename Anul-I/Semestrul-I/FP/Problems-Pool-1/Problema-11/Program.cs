using System;

namespace Problema_11
{
    class Program
    {
        static void Main(string[] args)
        {
            long Numar;

            try                                                 // Citirea datelor.
            {
                Console.Write("\n Introduce numarul: ");
                Numar = long.Parse(Console.ReadLine());

                Console.Write($"\n Cifrele numarului {Numar} scrise in ordine inversa sunt: ");
                while (Numar > 0)                               // Afisam pe rand ultima cifra a numarului.
                {
                    Console.Write(Numar % 10);

                    Numar /= 10;                                // Impartim succesiv cu 10.
                }
                Console.WriteLine("\n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
    }
}
