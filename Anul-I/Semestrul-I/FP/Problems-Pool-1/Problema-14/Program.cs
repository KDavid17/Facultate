using System;

namespace Problema_14
{
    class Program
    {
        static void Main(string[] args)
        {
            string NumarString;                                 // Programul compara jumatatile numarului
            long Numar, Putere;                                 // pentru a determina daca este sau nu un
            int Lungime;                                        // palindrom.

            try                                                 // Citirea datelor.
            {
                NumarString = Console.ReadLine();               // Folosim initial un string pentru a 
                                                                // folosi lungimea numarului ulterior.
                Lungime = NumarString.Length;

                Putere = (long)Math.Pow(10, Lungime / 2);       // Cream 10 ^ (lungimea numarului / 2).
                
                Numar = long.Parse(NumarString);

                if (Lungime % 2 == 0)                           // Caz daca lungimea numarului este para.
                {
                    if (Numar / Putere == JumatateInvers(Numar, Lungime / 2))
                    {
                        Console.WriteLine($"\n Numarul {Numar} este palindrom. \n");
                    }
                    else
                    {
                        Console.WriteLine($"\n Numarul {Numar} nu este palindrom. \n");
                    }
                }
                else                                            // Caz daca lungimea numarului este impara. 
                {
                    if (Numar / (Putere * 10) == JumatateInvers(Numar, Lungime / 2))
                    {
                        Console.WriteLine($"\n Numarul {Numar} este palindrom. \n");
                    }
                    else
                    {
                        Console.WriteLine($"\n Numarul {Numar} nu este palindrom. \n");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
        private static long JumatateInvers(long Numar, int Lungime)
        {                                                       // Functia returneaza inversul jumatatii
            long JumatateNumar = 0;                             // numarului.

            while (Lungime != 0)
            {
                JumatateNumar = JumatateNumar * 10 + Numar % 10;

                Numar /= 10;

                Lungime--;
            }

            return JumatateNumar;
        }
    }
}
