using System;

namespace Problema_17
{

    class Program
    {
        private static long Suma0Maxim = 0;
        /// <summary>
        /// Programul aduna aparitiile de 0 si descreste cu 1 pentru fiecare caracter '1' citit.
        /// Cat timp suma valorilor 0 este mereu >= 0, avem o secventa corecta de paranteze,
        /// iar la final aceasta suma trebuie sa fie 0.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                long Suma0 = 0;

                Console.Write("\n Introduceti secventa cu un singur spatiu intre cifre. La final apasati 'Enter'! \n");
                Console.Write("\n Secventa: ");
                char Cifra = Console.ReadKey().KeyChar;

                if (Cifra != '0' && Cifra != '1')
                {
                    Console.Write("\n");
                    throw new Exception();
                }

                while (Cifra != '2')
                {
                    if (Suma0 >= 0)
                    {
                        Suma0 = Verificare(Cifra, Suma0);
                    }

                    Cifra = CitireCifra();

                    if (Cifra == '2')
                    {
                        break;
                    }
                    else if (Cifra == '3')
                    {
                        throw new Exception();
                    }
                }

                Console.Write("\n\n Secventa " + (Suma0 != 0 ? "nu reprezinta o secventa de paranteze corecte.\n\n" : "" +
                    $"reprezinta o secventa de paranteze corecta. Nivelul maxim de incuibare: {Suma0Maxim}\n\n"));
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");
            }
        }
        private static long Verificare(char Cifra, long Suma0)
        {
            if (Cifra == '0')
            {
                Suma0++;

                if (Suma0 > Suma0Maxim)
                {
                    Suma0Maxim = Suma0;
                }
            }
            else
            {
                Suma0--;

                if (Suma0 < 0)
                {
                    Suma0 = -1;
                }
            }

            return Suma0;
        }
        private static char CitireCifra()
        {
            char Cifra = Console.ReadKey().KeyChar;

            if (Cifra == ' ')
            {
                Cifra = Console.ReadKey().KeyChar;
            }
            else if ((int)Cifra == 13)
            {
                return '2';
            }
            else
            {
                Console.Write("\n");
                return '3';
            }

            if (Cifra != '0' && Cifra != '1')
            {
                Console.Write("\n");
                return '3';
            }

            return Cifra;
        }
    }
}
