using System;
using System.Numerics;

namespace Operatii_Cu_Numere_Mari
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                long suma = 0;

                string Numar = Console.ReadLine();

                Console.Write(Numar);
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }

        private static void Numere_2()
        {
            long i;

            Console.Write("\n Introduceti primul numar: ");
            string Numar1String = Console.ReadLine();

            long[] Vector1 = new long[Numar1String.Length];

            Console.Write("\n Introduceti al doilea numar: ");
            string Numar2String = Console.ReadLine();

            long[] Vector2 = new long[Numar2String.Length];


        }
        private static void Adunare()
        {
            
        }
    }
}
