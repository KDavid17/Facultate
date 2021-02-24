using System;

namespace Problema_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n Introduceti numarul de elemente din vector: ");
                long Numar = long.Parse(Console.ReadLine());

                if (Numar < 1)
                {
                    throw new Exception();
                }

                Console.Write("\n Introduceti elementele: \n\n Element 1: ");
                long Maxim = long.Parse(Console.ReadLine()), Minim = Maxim, AparitiiMinim = 1, AparitiiMaxim = 1, i;

                long[] Vector = new long[Numar];
                Vector[0] = Maxim;

                for (i = 1; i < Numar; i++)
                {
                    Console.Write($"\n Element {i + 1}: ");
                    Vector[i] = long.Parse(Console.ReadLine());

                    if (Vector[i] < Minim)
                    {
                        Minim = Vector[i];

                        AparitiiMinim = 1;
                    }
                    else if (Vector[i] == Minim)
                    {
                        AparitiiMinim++;
                    }
                    else if (Vector[i] > Maxim)
                    {
                        Maxim = Vector[i];

                        AparitiiMaxim = 1;
                    }
                    else if (Vector[i] == Maxim)
                    {
                        AparitiiMaxim++;
                    }
                }

                Console.Write($"\n Minimul din vector este: {Minim} . Numar de aparitii: {AparitiiMinim}\n");
                Console.Write($"\n Maximul din vector este: {Maxim} . Numar de aparitii: {AparitiiMaxim}\n\n");
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }
    }
}
