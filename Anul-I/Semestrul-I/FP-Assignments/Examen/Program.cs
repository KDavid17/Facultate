using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    class Program
    {
        static void Main(string[] args)
        {
            // Problema1();
            // Problema2();
            // Problema3();
            // Problema4();
            // Problema5();
             Problema6();
            // Problema7();
        }

        private static void Problema7()
        {
            try
            {
                Console.Write("\n Introduceti numarul: ");
                int Numar = int.Parse(Console.ReadLine()), Cifra;

                Cifra = Functie(Numar, 10);

                if (Cifra == 10)
                {
                    Console.Write("\n -1 \n\n");
                }
                else
                {
                    Console.Write("\n Cea mai mica cifra para din numarul dat este: " + Cifra + "\n\n");
                }
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }

        private static int Functie(int Numar, int Cifra)
        {
            if (Numar == 0 || Cifra == 0)
            {
                return Cifra;
            }
            else
            {
                if (Cifra > Numar % 10 && Numar % 10 % 2 == 0)
                {
                    Cifra = Numar % 10;
                }

                return Functie(Numar / 10, Cifra);
            }
        }

        private static void Problema6()
        {
            try
            {
                Console.Write("\n Introduceti parametrul: ");
                int Numar = int.Parse(Console.ReadLine()), z = 0, Valoare;

                Console.Write($"\n Primele {Numar} elemente ale sirului sunt: ");

                if (Numar == 1)
                {
                    Console.Write(1);
                }
                else if (Numar == 2)
                {
                    Console.Write(1 + "," + 1);
                }
                else if (Numar == 3)
                {
                    Console.Write(1 + "," + 1 + "," + 1);
                }
                else
                {
                    if ((int)Math.Sqrt(Numar) == Math.Sqrt(Numar))
                    {
                        Valoare = (int)Math.Sqrt(Numar);
                    }
                    else
                    {
                        Valoare = (int)Math.Sqrt(Numar) + 1;
                    }

                    for (int i = 1; i <= Valoare; i++)
                    {
                        for (int j = 1; j <= i; j++)
                        {
                            for (int k = 1; k <= i; k++)
                            {
                                if (z != Numar)
                                {
                                    Console.Write(j + ",");

                                    z++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                Console.Write("\n\n");
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }

        private static void Problema5()
        {
            Console.Write("\n Introduceti inaltimea pisicii: ");
            int Inaltime = int.Parse(Console.ReadLine());

            // Distanta dintre Ecuator si Pamant este de 15 cm. (L = pi * R + 1 -> deoarece e mai mare
            // cu 1 => distanta dintre Pamant si Ecuator = R + 1 / 2 * pi - R = 15 cm)

            Console.Write("\n" + Verifica(Inaltime) + "\n\n");
        }

        private static bool Verifica(int Inaltime)
        {
            if (Inaltime <= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void Problema4()
        {
            try
            {
                Console.Write("\n Introduceti dimensiunea matricii: ");
                int Dimensiune = int.Parse(Console.ReadLine()), i, j, Suma = 0;

                Console.Write("\n Introduceti elementele matricii: \n\n");
                int[,] Matrice = new int[Dimensiune, Dimensiune];

                for (i = 0; i < Dimensiune; i++)
                {
                    for (j = 0; j < Dimensiune; j++)
                    {
                        Matrice[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                for (i = 0; i < Dimensiune; i++)
                {
                    for (j = 0; j < Dimensiune; j++)
                    {
                        if (i + j > Dimensiune - 1)
                        {
                            if (Prim(Matrice[i, j]) == true)
                            {
                                Suma += Matrice[i, j];
                            }
                        }
                    }
                }

                Console.Write("\n Suma elementelor prime de sub diagonala principala este: ");
                Console.Write(Suma + "\n\n");
            }
            catch (Exception)
            {
                Console.Write(" Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }
        private static bool Prim(int Numar)
        {

            if (Numar == 2)
            {
                return true;
            }
            else if (Numar % 2 == 0)
            {
                return false;
            }
            else
            {
                for (int i = 3; i * i < Numar; i += 2)
                {
                    if (Numar % i == 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private static void Problema3()
        {
            Console.Write("\n Introduceti numerele din lista: \n\n");
            try
            {
                int Numar1 = int.Parse(Console.ReadLine());
                int Numar2 = int.Parse(Console.ReadLine());

                if (Numar1 < Numar2)
                {
                    (Numar1, Numar2) = (Numar2, Numar1);
                }

                int Numar3 = int.Parse(Console.ReadLine());

                if (Numar3 > Numar2 && Numar3 < Numar1)
                {
                    (Numar2, Numar3) = (Numar3, Numar2);
                }
                else if (Numar3 > Numar1)
                {
                    (Numar2, Numar3) = (Numar3, Numar2);
                    (Numar1, Numar2) = (Numar2, Numar1);
                }

                int Numar;

                while ((Numar = int.Parse(Console.ReadLine())) != 0)
                {
                    if (Numar > Numar3 && Numar < Numar2)
                    {
                        Numar3 = Numar;
                    }
                    else if (Numar >= Numar2 && Numar < Numar1)
                    {
                        Numar3 = Numar2;
                        Numar2 = Numar;
                    }
                    else if (Numar >= Numar1)
                    {
                        Numar3 = Numar2;
                        Numar2 = Numar1;
                        Numar1 = Numar;
                    }
                }

                Console.Write("\n Cele mai mari 3 numere din lista sunt: ");
                Console.Write(Numar1 + " " + Numar2 + " " + Numar3 + "\n\n");

            }
            catch (Exception)
            {
                Console.Write(" Nu ati introdus date procesabile conform cerintei. \n\n");
            }

        }

        private static void Problema2()
        {
            try
            {
                Console.Write("\n Introduceti lungimea vectorului: ");
                int Numar = int.Parse(Console.ReadLine()), i, j;

                int[] Vector = new int[Numar];

                Console.Write("\n Introduceti elementele vectorului: \n\n");

                for (i = 0; i < Numar; i++)
                {
                    Vector[i] = int.Parse(Console.ReadLine());
                }

                Console.Write("\n Introduceti valoarea t: ");
                int t = int.Parse(Console.ReadLine());

                for (i = 0; i < Vector.Length - 1; i++)
                {
                    for (j = i + 1; j < Vector.Length; j++)
                    {
                        if (Vector[i] + Vector[j] == t)
                        {
                            Console.Write($"\n Indicii elementelor care au suma {t} sunt: " + i + " si " + j + "\n\n");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }

        private static void Problema1()
        {
            try
            {
                Console.Write("\n Introduceti numarul: ");
                int Numar = int.Parse(Console.ReadLine()), Cifre = 0, Rezultat, Copie = Numar;

                Console.Write($"\n Complementul fata de 9 al numarului {Numar} este: ");

                while (Numar != 0)
                {
                    Cifre++;

                    Numar /= 10;
                }

                Rezultat = (int)Math.Pow(10, Cifre) - Copie - 1;

                Console.Write(Rezultat + "\n\n");
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }
    }
}
