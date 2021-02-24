using System;

namespace Problema_31
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int k = 0, nr = 0, c = 0, nr1 = 0;

                Console.Write("\n Introduceti lungimea vectorului: ");
                int Numar = int.Parse(Console.ReadLine());
                int[] Vector = new int[Numar];

                for (int i = 0; i < Numar; i++)
                {
                    Vector[i] = int.Parse(Console.ReadLine());
                    if(nr == 0)
                    {
                        nr = 1;
                        c = Vector[i];
                    }
                    else if(c != Vector[i])
                    {
                        nr--;
                    }
                    else
                    { 
                        nr++;
                    }
                }

                for (int i = 0; i < Numar; i++)
                {
                    if (Vector[i] == c)
                    {
                        nr1++;
                    }
                }
                if (nr1 >= Numar / 2 + 1)
                    {
                        Console.Write("DA" + c);
                    }
                    else
                    {
                        Console.Write("NU");
                    }
            }
            catch (Exception)
            {
                Console.Write("\n Nu au fost introduse date procesabile conform cerintei. \n");
            }
        }
    }
}
