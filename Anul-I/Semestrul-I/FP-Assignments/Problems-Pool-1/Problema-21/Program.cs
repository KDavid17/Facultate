using System;

namespace Problema_21
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Gata = false;
            short Mijloc = 512, Margine = 1024;
            string Raspuns;

            try
            {
                while (Gata == false)
                {
                    Console.Write($"\n Numarul este mai mare sau egal cu {Mijloc}? \n\n Raspuns: ");

                    Raspuns = Console.ReadLine();

                    if (Raspuns == "")
                    {
                        throw new Exception();
                    }

                    if (Raspuns == "Da" || Raspuns == "DA" || Raspuns == "da" || Raspuns == "dA")
                    {
                        Mijloc = (short)((Mijloc + Margine) / 2);

                        if (Margine == Mijloc + 1)
                        {
                            Console.WriteLine($"\n Numarul la care v-ati gandit este: {Mijloc} \n");

                            Gata = true;
                        }
                    }
                    else if (Raspuns == "Nu" || Raspuns == "NU" || Raspuns == "nu" || Raspuns == "nU")
                    {
                        Mijloc = (short)((3 * Mijloc - Margine) / 2);

                        Margine = (short)((Mijloc * 2 + Margine) / 3);

                        if (Margine == Mijloc)
                        {
                            Console.WriteLine($"\n Numarul la care v-ati gandit este: {Mijloc} \n");

                            Gata = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
    }
}
