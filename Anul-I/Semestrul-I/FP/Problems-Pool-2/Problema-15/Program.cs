using System;

namespace Problema_15
{
    class Program
    {
        /// <summary>
        /// Programul cauta momentul cand numarul urmator citit este mai mic decat cel anterior,
        /// acest moment fiind marcat, si se verifica in continuare pana la sfarsitul secventei
        /// daca nu se introduc numere care ar face a doua parte a secventei sa nu mai fie
        /// monoton descrescatoare. Daca secventa este monoton crescatoare sau devine
        /// crescatoare dupa ce a descrescut, ea nu este bitonica.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\n Introduceti numarul de numere din secventa: ");
                long Numar = long.Parse(Console.ReadLine());

                Console.Write("\n Introduceti numerele: \n\n Numar 1: ");
                long NumarAnterior = long.Parse(Console.ReadLine()), NumarUrmator;

                bool Crescator = false, Descrescator = false, Stop = false;

                for (long i = 2; i <= Numar; i++)
                {
                    Console.Write($"\n Numar {i}: ");
                    NumarUrmator = long.Parse(Console.ReadLine());

                    if (Stop == false)
                    {
                        if (Crescator == false)
                        {
                            if (NumarUrmator > NumarAnterior)
                            {
                                Crescator = true;
                            }
                        }
                        else
                        {
                            if (Descrescator == false)
                            {
                                if (NumarUrmator < NumarAnterior)
                                {
                                    Descrescator = true;
                                }
                            }
                            else
                            {
                                if (NumarUrmator > NumarAnterior)
                                {
                                    Descrescator = false;

                                    Stop = true;
                                }
                            }
                        }
                    }

                    NumarAnterior = NumarUrmator;
                }

                Console.Write("\n Secventa data " + (Crescator == true && Descrescator == true ? "" : "nu ") +
                                    "este bitonica. \n\n");
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }
    }
}
