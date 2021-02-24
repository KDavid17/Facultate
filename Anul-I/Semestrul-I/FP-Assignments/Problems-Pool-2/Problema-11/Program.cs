using System;

namespace Problema_1
{
    class Program
    {
        private static long Numar;
        private static double Suma = 0, NumarAuxiliar = 0;
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
                        Suma += (1 / NumarAuxiliar);

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
        private static void Afisare()
        {
            Console.Write($"\n\n Suma inverselor numerelor din secventa data este: {Suma}\n\n");
        }
    }
}