using System;

namespace Problema_1
{
    class Program
    {
        private static long Numar, NumarAuxiliar = 0, Separare = 0, NumarAnterior = 0;
        private static bool PrimulNumar = false, Crescator = false, Descrescator = false, Stop = false;
        private static bool MonotonCrescator1 = false, MonotonCrescator2 = false, MonotonDescrescator1 = false, MonotonDescrescator2 = false;
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
        /// Exemplu: {3 2 1 5 4}. Avem primul numar [3]. [2] < [3] -> Momentan secventa este descrescatoare.
        /// [1] < [2] -> Momentan secventa {3 2 1} este monoton descrescatoare - posibilitatea 2 (posibilitatea 2 = 
        /// secvente de forma {n, n-1, etc. p} unde daca am mai adauga un numar de forma [Numar > p && Numar < n] 
        /// secventa nu ar mai fi monotona). [5] > [1] -> Se trece la secventa monoton descrescatoare - 
        /// posibilitatea 1 (posibilitatea 1 = secvente de forma {k, n, n-1, etc. p | k <= p} unde daca am mai adauga
        /// un numar de forma [Numar > p || Numar < k] secventa nu ar mai fi monotona) deoarece pentru a fi monoton
        /// descrescatoare, secventa ar necesita una sau mai multe rotatii.
        /// 
        /// Analog pentru secventele crescatoare (dar cu semnele schimbate).
        /// </summary>
        private static void Cerinta()
        {
            if (PrimulNumar == true)
            {
                if (Crescator == false && Descrescator == false)
                {
                    if (NumarAuxiliar > NumarAnterior)
                    {
                        Crescator = true;
                    }
                    else if (NumarAuxiliar < NumarAnterior)
                    {
                        Descrescator = true;
                    }
                }
                else if (Crescator == true && Descrescator == false)
                {
                    TemporarCrescator();
                }
                else if (Crescator == false && Descrescator == true)
                {
                    TemporarDescrescator();
                }
                else if (MonotonCrescator1 == true)
                {
                    Crescator_1();

                }
                else if (MonotonCrescator2 == true)
                {
                    Crescator_2();
                }
                else if (MonotonDescrescator1 == true)
                {
                    Descrescator_1();
                }
                else if (MonotonDescrescator2 == true)
                {
                    Descrescator_2();
                }
            }
            else
            {
                PrimulNumar = true;

                Separare = NumarAuxiliar;
            }
        }
        private static void TemporarCrescator()
        {
            if (NumarAuxiliar < NumarAnterior)
            {
                if (NumarAuxiliar > Separare)
                {
                    MonotonDescrescator1 = true;
                }
                else
                {
                    MonotonCrescator1 = true;
                }
            }
            else
            {
                MonotonCrescator2 = true;
            }

            Descrescator = true;
        }
        private static void TemporarDescrescator()
        {
            if (NumarAuxiliar > NumarAnterior)
            {
                if (NumarAuxiliar < Separare)
                {
                    MonotonCrescator1 = true;
                }
                else
                {
                    MonotonDescrescator1 = true;
                }
            }
            else
            {
                MonotonDescrescator2 = true;
            }

            Crescator = true;
        }
        private static void Crescator_1()
        {
            if (NumarAuxiliar < NumarAnterior || NumarAuxiliar > Separare)
            {
                Stop = true;
            }
        }
        private static void Crescator_2()
        {
            if (NumarAuxiliar < NumarAnterior)
            {
                if (NumarAuxiliar <= Separare)
                {
                    MonotonCrescator2 = false;

                    MonotonCrescator1 = true;
                }
                else
                {
                    Stop = true;
                }
            }
        }
        private static void Descrescator_1()
        {
            if (NumarAuxiliar > NumarAnterior || NumarAuxiliar < Separare)
            {
                Stop = true;
            }
        }
        private static void Descrescator_2()
        {
            if (NumarAuxiliar > NumarAnterior)
            {
                if (NumarAuxiliar >= Separare)
                {
                    MonotonDescrescator2 = false;

                    MonotonDescrescator1 = true;
                }
                else
                {
                    Stop = true;
                }
            }
        }
        private static void Afisare()
        {
            if (Crescator == false && Descrescator == false)
            {
                Stop = true;
            }

            Console.Write("\n\n Secventa data " + (Stop == true ? "nu " : "") + "este monotona rotita. \n\n");
        }
    }
}