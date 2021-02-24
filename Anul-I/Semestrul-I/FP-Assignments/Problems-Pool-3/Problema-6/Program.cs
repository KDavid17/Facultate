using System;

namespace Problema_6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n Introduceti numarul de elemente din vector: ");
                long Numar = long.Parse(Console.ReadLine());

                Console.Write("\n Introduceti pozitia elementului pe care doriti sa il stergeti: ");
                long Pozitie = long.Parse(Console.ReadLine()), i;

                if (Numar < 1 || Pozitie < 0 || Pozitie >= Numar)
                {
                    throw new Exception();
                }

                long[] Vector = new long[Numar - 1];

                for (i = 0; i < Numar; i++)
                {
                    if (i == Pozitie)
                    {
                        Console.Write($"\n Element {i + 1}: ");

                        if (i != Numar - 1)
                        {
                            Vector[i] = long.Parse(Console.ReadLine());
                        }
                        else
                        {
                            Console.ReadLine();
                        }
                        
                        Numar--;
                    }

                    if (i != Numar)
                    {
                        Console.Write(i < Pozitie ? $"\n Element {i + 1}: " : $"\n Element {i + 2}: ");
                        Vector[i] = long.Parse(Console.ReadLine());
                    }
                }

                Console.Write("\n Vectorul obtinut este: ");

                for (i = 0; i < Numar; i++)
                {
                    Console.Write(Vector[i] + " ");
                }

                Console.Write("\n\n");
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }
    }
}
