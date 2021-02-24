using System;

namespace Problema_9
{
    class Program
    {
        static void Main(string[] args)
        {
            long Numar;
            int i, k = 0;

            try                                                         // Citirea datelor.
            {
                Console.Write("\n Introduceti numarul: ");
                Numar = long.Parse(Console.ReadLine());

                int[] Divizori = new int[(int)Math.Sqrt(Numar)];

                Console.Write($"\n Divizorii numarului {Numar} sunt: ");

                for (i = 1; i < Math.Sqrt(Numar); i++)                  // Prima parte de divizori.
                {
                    if (Numar % i == 0)
                    {
                        Console.Write(i + " ");

                        Divizori[k] = i;

                        k++;
                    }
                }

                if (Math.Sqrt(Numar) * (int)Math.Sqrt(Numar) == Numar)  // Cazul de patrat perfect.
                {
                    Console.Write(Math.Sqrt(Numar) + " ");
                }

                for (i = k - 1; i >= 0; i--)                            // A doua parte de divizori.
                {
                    Console.Write(Numar / Divizori[i] + " ");
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