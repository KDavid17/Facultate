using System;

namespace Problema_1
{
    class Program
    {
        private static long Numar, NumarAuxiliar = 0, MinimParte1 = 0, NumarAnterior = 0;
        private static bool PrimulNumar = false, Crescator = false, Descrescator = false, Stop = false;
        /// <summary>
        /// Pana cand 'Numar' = 0 (adica s-au inregistrat n - 1 spatii si 'Enter') citim un
        /// caracter pentru a determina daca numarul ce va fi introdus este negativ sau nu.
        /// In caz afirmativ initializam NumarAuxiliar cu negativul numarului. Se verifica
        /// daca subprogramul 'NumarCompus' intoarce valoarea de adevar (adica daca numarul introdus
        /// este corect) si se verifica conditia din cerinta. 'Numar' descreste din 1 in 1 pentru
        /// fiecare numar verificat (sau pentru delimitatorul {spatiu} dintre 2 numere).
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                char Cifra;

                Console.Write("\n Introduceti numarul de elemente din secventa: ");
                Numar = long.Parse(Console.ReadLine());

                if (Numar < 1)
                {
                    throw new Exception();
                }

                Console.Write("\n Introduceti numerele din secventa si apasati 'Enter' doar la final: ");

                while (Numar > 0)
                {
                    if ((Cifra = Console.ReadKey().KeyChar) == ' ')
                    {
                        throw new Exception();
                    }

                    if (Cifra == '-')
                    {
                        NumarAuxiliar = -long.Parse(Convert.ToString(Console.ReadKey().KeyChar));

                        Cifra = Console.ReadKey().KeyChar;
                    }

                    if (NumarCompus(Cifra) == true)
                    {
                        if (Stop == false)
                        {
                            Cerinta();

                            NumarAnterior = NumarAuxiliar;
                        }

                        NumarAuxiliar = 0;

                        Numar--;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                Afisare();
            }
            catch (Exception)
            {
                Console.Write("\n\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }

        }
        /// <summary>
        /// Cat timp Cifra este o cifra de la 0 la 9 construim numarul auxiliar si recitim Cifra.
        /// Tratam valorile introdus incorect prin returnarea 'false', iar prin 'true' se intelege
        /// ca numarul introdus este corect si poate fi folosit pentru verificarea conditiei in
        /// programul principal.
        /// </summary>
        /// <param name="Cifra"></param>
        /// <returns></returns>
        private static bool NumarCompus(char Cifra)
        {
            try
            {
                while (Cifra >= '0' && Cifra <= '9')
                {
                    NumarAuxiliar = NumarAuxiliar * 10 + long.Parse(Convert.ToString(Cifra));

                    Cifra = Console.ReadKey().KeyChar;
                }

                if ((Numar != 1 && (char)Cifra == 13) || (Cifra != ' ' && (char)Cifra != 13) || (Numar == 1 && (char)Cifra != 13))
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Exemplu: {3 4 5 1 2}. Am gasit primul numar [3], al doilea numar [4] fiind mai mare
        /// inseamna ca, momentan, secventa {3 4} este crescatoare. Citind [5] avem secventa
        /// {3 4 5} crescatoare. [1] < [5] si [1] < [3] inseamna ca, momentan,
        /// secventa {1 3 4 5} este crescatoare. [2] > [1] si [2] < [3] inseamna ca, momentan si
        /// final, secventa {1 2 3 4 5} este crescatoare rotita.
        /// Exemplu: {2 4 3}. Am gasit primul numar [2], al doilea numar [4] fiind mai mare
        /// inseamna ca, momentan, secventa {2 4} este crescatoare. Citind [3] avem
        /// [3] < [4] dar [3] > [2]. Prin urmare, nu exista nicio posibila rotire ca secventa
        /// {2 4 3} sa fie crescatoare (este chiar descrescatoare {4 3 2}).
        /// </summary>
        private static void Cerinta()
        {
            if (PrimulNumar == true)
            {
                if (Descrescator == false)
                {
                    if (Crescator == true)
                    {
                        if (NumarAuxiliar < NumarAnterior)
                        {
                            Descrescator = true;

                            if (NumarAuxiliar > MinimParte1)
                            {
                                Crescator = false;

                                Stop = true;
                            }
                        }
                    }
                    else if (NumarAuxiliar != NumarAnterior)
                    {
                        if (NumarAuxiliar < NumarAnterior)
                        {
                            Descrescator = true;
                        }

                        Crescator = true;
                    }
                }
                else
                {
                    if (NumarAuxiliar < NumarAnterior || NumarAuxiliar > MinimParte1)
                    {
                        Crescator = false;

                        Stop = true;
                    }
                }
            }
            else
            {
                PrimulNumar = true;

                MinimParte1 = NumarAuxiliar;
            }
        }
        private static void Afisare()
        {
            Console.Write("\n\n Secventa data " + (Crescator == true ? "este " : "nu este ") +
                            "o secventa crescatoare rotita. \n\n");
        }
    }
}