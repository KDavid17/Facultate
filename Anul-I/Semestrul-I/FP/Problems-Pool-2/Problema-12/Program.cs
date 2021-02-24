using System;

namespace Problema_1
{
    class Program
    {
        private static long Numar, NumarAnterior = 0, NumarAuxiliar = 0, Suma = 0;
        private static bool PrimulNumar = false, Grup = false, Consecutiv = false;
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
                        Cerinta();

                        NumarAuxiliar = 0;

                        Numar--;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                if (Grup == true && Consecutiv == true)
                {
                    Suma++;
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
        /// *Notatie: grup de numere consecutive = g.n.c.
        /// Presupunem exemplul: 0 1 2 3 0 5 5 0 6 0 . Primul g.n.c. ar fi {1 2 3}. Primul numar diferit de 0
        /// este 1. Se verifica daca urmatorul numar este diferit de 0 si este consecutiv (adica daca 2 - 1 = 1).
        /// In caz afirmativ, avem momentan g.n.c. {1 2}. La fel se verifica si pentru 3 si avem g.n.c. {1 2 3}.
        /// Se citeste valoare 0, deci daca avem un g.n.c. (sa fie minim 2 numere, iar toate consecutive) 
        /// suma finala va creste cu 1. {5 5} are minim 2 numere dar nu are numerele consecutive. 
        /// {6} nu este g.n.c. deoarece consta dintr-un singur numar.
        /// </summary>
        private static void Cerinta()
        {
            if (PrimulNumar == true)
            {
                if (NumarAuxiliar != 0)
                {
                    if (Grup == true && Consecutiv == true)
                    {
                        if (NumarAuxiliar - NumarAnterior != 1)
                        {
                            Consecutiv = false;
                        }
                    }
                    else
                    {
                        if (NumarAuxiliar - NumarAnterior == 1)
                        {
                            Grup = true;

                            Consecutiv = true;
                        }
                    }

                    NumarAnterior = NumarAuxiliar;
                }
                else
                {
                    if (Grup == true && Consecutiv == true)
                    {
                        Suma++;
                    }

                    Grup = false;

                    Consecutiv = false;

                    PrimulNumar = false;
                }
            }
            else
            {
                if (NumarAuxiliar != 0)
                {
                    PrimulNumar = true;

                    NumarAnterior = NumarAuxiliar;
                }
            }
        }
        private static void Afisare()
        {
            Console.Write($"\n\n Numarul de grupuri de numere diferite de 0 din secventa este: {Suma}\n\n");
        }
    }
}