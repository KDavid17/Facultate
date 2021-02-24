using System;

namespace Balanced_Ternary_Expansion
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Date = false;
            do
            {
                Console.Write("\n Introduceti baza din care se va face conversia: ");
                string Baza_1 = Console.ReadLine();

                if (Baza_1 == "10")
                {
                    Date = true;

                    Conversie_Din_10();
                }
                else if (Baza_1 == "BTE" || Baza_1 == "bte")
                {
                    Date = true;

                    Conversie_Din_BTE();
                }
            }
            while (Date == false);
        }

        private static void Conversie_Din_10()
        {
            for (int i = 0; i <= 13; i++)
            {
                string Numar_Initial = i.ToString();

                string Numar_Final = Conversie_In_BTE(long.Parse(Numar_Initial));

                Afisare("BTE", Numar_Final);
            }
        }
        private static void Conversie_Din_BTE()
        {

        }
        private static string Conversie_In_BTE(long Parte)
        {
            Parte = Conversie_In_Baza_3(Parte);

            bool Tinut_Minte = false;

            string Numar_Final = Parte.ToString(), Parte_1, Parte_2;

            for (int i = Numar_Final.Length - 1; i >= 0; i--)
            {
                if (Numar_Final[i] == '2' || (Numar_Final[i] == '1' && Tinut_Minte == true))
                {
                    Parte_1 = Numar_Final.Substring(0, i);

                    Parte_2 = Numar_Final.Substring(i + 1, Numar_Final.Length - i - 1);

                    Numar_Final = Parte_1 + "T" + Parte_2;

                    Tinut_Minte = true;
                }
                else if (Numar_Final[i] == '0' && Tinut_Minte == true)
                {
                    Parte_1 = Numar_Final.Substring(0, i);

                    Parte_2 = Numar_Final.Substring(i + 1, Numar_Final.Length - i - 1);

                    Numar_Final = Parte_1 + "1" + Parte_2;

                    Tinut_Minte = false;
                }
            }

            if (Tinut_Minte == true)
            {
                Numar_Final = "1" + Numar_Final;
            }

            return Numar_Final;
        }
        private static long Conversie_In_Baza_3(long Parte)
        {
            long Convertit = 0;

            while (Parte != 0)
            {
                Convertit = Convertit * 10 + Parte % 3;

                Parte /= 3;
            }

            return Invers(Convertit);
        }
        private static long Invers(long Convertit)
        {
            long Temporar = 0;

            while (Convertit != 0)
            {
                Temporar = Temporar * 10 + Convertit % 10;

                Convertit /= 10;
            }

            return Temporar;
        }

        private static void Afisare(string Baza_Tinta, string Numar_Final)
        {
            Console.Write($"\n Numarul initial in urma conversiei in baza {Baza_Tinta} este: {Numar_Final}\n\n");
        }
    }
}
