using System;

namespace Problema_11
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n Introduceti numarul: ");
                long Numar = long.Parse(Console.ReadLine());

                if (Numar < 2)
                {
                    throw new Exception();
                }
                else if (Numar == 2)
                {
                    Console.Write("\n Numerele prime mai mici sau egale cu 2 sunt: 2\n\n");
                }
                else
                {
                    long i;

                    Console.Write($"\n Numerele prime mai mici sau egale cu {Numar} sunt: 2 ");

                    for (i = 3; i <= Numar; i += 2)
                    {
                        if (VerificarePrim(i) == true)
                        {
                            Console.Write(i + " ");
                        }
                    }

                    Console.Write("\n\n");
                }
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }
        private static bool VerificarePrim(long Numar)
        {
            if (Numar % 2 == 0)
            {
                return false;
            }
            for (long i = 3; i * i <= Numar; i += 2)
            {
                if (Numar % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
