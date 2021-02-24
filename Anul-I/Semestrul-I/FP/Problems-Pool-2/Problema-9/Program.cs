using System;

namespace Problema_1
{
    class Program
    {
        private static long Numar, NumarAnterior = 0, NumarAuxiliar = 0;
        private static bool Crescator = false, Descrescator = false, PrimulNumar = false;
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

                if (Numar < 2)
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
                        Cerinta();
                        
                        NumarAnterior = NumarAuxiliar;

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
        /// Facem verificarile necesare pentru a indeplini cerinta. Cazurile care nu reprezinta
        /// o secventa monotona sunt daca ambele valori de tip bool ('Crescator' si 'Descrescator')
        /// sunt egale (ambele false sau ambele adevarate).
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
                else if (Crescator != true || Descrescator != true)
                {
                    if (Crescator == false && Descrescator == true && NumarAuxiliar > NumarAnterior)
                    {
                        Crescator = true;
                    }

                    if (Crescator == true && Descrescator == false && NumarAuxiliar < NumarAnterior)
                    {
                        Descrescator = true;
                    }
                }
            }
            else
            {
                PrimulNumar = true;       
            }
        }
        private static void Afisare()
        {
            if (Crescator == true && Descrescator == true || Crescator == false && Descrescator == false)
            {
                Console.Write("\n\n Secventa data nu este monotona. \n\n");
            }
            else
            {
                if (Crescator == true)
                {
                    Console.Write("\n\n Secventa data este monoton crescatoare. \n\n");
                }
                else
                {
                    Console.Write("\n\n Secventa data este monoton descrescatoare. \n\n");
                }
            }
        }
    }
}
