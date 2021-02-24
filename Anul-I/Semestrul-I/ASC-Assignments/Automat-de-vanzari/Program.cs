using System;

namespace Automat_de_vanzari
{
    class Program
    {
        private static bool Rest = false;
        private static sbyte SumaRest = 0, SumaIntrodusa = 0;
        static void Main(string[] args)
        {
            Starea_A();
        }
        /// <summary>
        /// Suma: 0 ¢. Pentru Q (25 ¢) se revine la starea A si se apeleaza functia de afisare.
        /// Pentru N (5 ¢) se face trecerea la starea B. Pentru D (10 ¢) se face trecerea la starea C.
        /// </summary>
        private static void Starea_A()
        {
            Console.Write("|------------------------------------------| " +
                $"\n\n Suma disponibila: {SumaIntrodusa} ¢\n");

            if (Rest == false)
            {
                Console.Write("\n Introduceti o moneda: ");
                char Moneda = Console.ReadKey().KeyChar;

                Console.WriteLine("\n");

                if (Moneda >= 'a' && Moneda <= 'z')
                {
                    Moneda = (char)(Moneda - 32);
                }

                switch (Moneda)
                {
                    case 'N':
                        SumaIntrodusa = 5;
                        Starea_B();
                        break;

                    case 'D':
                        SumaIntrodusa = 10;
                        Starea_C();
                        break;

                    case 'Q':
                        Rest = true;
                        SumaRest = 5;
                        Starea_A();
                        break;

                    default:
                        Console.Write(" Moneda introdusa nu este valida. Introduceti una valida. \n\n");
                        Starea_A();
                        break;
                }
            }
            else
            {
                AfisareFinal();
            }
        }
        /// <summary>
        /// Suma: 5 ¢. Pentru Q (25 ¢) se revine la starea A si se restituie restul.
        /// Pentru N (5 ¢) si D (10 ¢) se face trecerea la starea C, respectiv starea D.
        /// </summary>
        private static void Starea_B()
        {
            Console.Write("|------------------------------------------| " +
                $"\n\n Suma disponibila: {SumaIntrodusa} ¢\n");

            if (Rest == false)
            {
                Console.Write("\n Introduceti o moneda: ");
                char Moneda = Console.ReadKey().KeyChar;

                Console.WriteLine("\n");

                if (Moneda >= 'a' && Moneda <= 'z')
                {
                    Moneda = (char)(Moneda - 32);
                }

                switch (Moneda)
                {
                    case 'N':
                        SumaIntrodusa = 10;
                        Starea_C();
                        break;

                    case 'D':
                        SumaIntrodusa = 15;
                        Starea_D();
                        break;

                    case 'Q':
                        Rest = true;
                        SumaRest = 10;
                        SumaIntrodusa = 0;
                        Starea_A();
                        break;

                    default:
                        Console.Write(" Moneda introdusa nu este valida. Introduceti una valida. \n\n");
                        Starea_B();
                        break;
                }
            }
        }
        /// <summary>
        /// Suma: 10 ¢. Pentru D (10 ¢) si Q (25 ¢) se revine la starea A si se restituie restul.
        /// Pentru N (5 ¢) se face trecerea la starea D.
        /// </summary>
        private static void Starea_C()
        {
            Console.Write("|------------------------------------------| " +
                $"\n\n Suma disponibila: {SumaIntrodusa} ¢\n");

            if (Rest == false)
            {
                Console.Write("\n Introduceti o moneda: ");
                char Moneda = Console.ReadKey().KeyChar;

                Console.WriteLine("\n");

                if (Moneda >= 'a' && Moneda <= 'z')
                {
                    Moneda = (char)(Moneda - 32);
                }

                switch (Moneda)
                {
                    case 'N':
                        SumaIntrodusa = 15;
                        Starea_D();
                        break;

                    case 'D':
                        Rest = true;
                        SumaRest = 0;
                        SumaIntrodusa = 0;
                        Starea_A();
                        break;

                    case 'Q':
                        Rest = true;
                        SumaRest = 15;
                        SumaIntrodusa = 0;
                        Starea_A();
                        break;

                    default:
                        Console.Write(" Moneda introdusa nu este valida. Introduceti una valida. \n\n");
                        Starea_C();
                        break;
                }
            }
        }
        /// <summary>
        /// Suma: 15 ¢. Pentru N (5 ¢) si D (10 ¢) se revine la starea A si se restituie restul.
        /// Pentru Q (15 ¢ + 25 ¢) se revine la starea B prin A deoarece raman 5 ¢ in automat.
        /// Restul maxim poate fi N (5 ¢) + D (10 ¢).
        /// </summary>
        private static void Starea_D()
        {
            Console.Write("|------------------------------------------| " +
                $"\n\n Suma disponibila: {SumaIntrodusa} ¢\n");

            if (Rest == false)
            {
                Console.Write("\n Introduceti o moneda: ");
                char Moneda = Console.ReadKey().KeyChar;

                Console.WriteLine("\n");

                if (Moneda >= 'a' && Moneda <= 'z')
                {
                    Moneda = (char)(Moneda - 32);
                }

                switch (Moneda)
                {
                    case 'N':
                        Rest = true;
                        SumaRest = 0;
                        SumaIntrodusa = 0;
                        Starea_A();
                        break;

                    case 'D':
                        Rest = true;
                        SumaRest = 5;
                        SumaIntrodusa = 0;
                        Starea_A();
                        break;

                    case 'Q':
                        Rest = true;
                        SumaRest = 15;
                        SumaIntrodusa = 5;
                        Starea_A();
                        break;

                    default:
                        Console.Write(" Moneda introdusa nu este valida. Introduceti una valida. \n\n");
                        Starea_D();
                        break;
                }
            }
        }
        /// <summary>
        /// Produsul este eliberat. Se restituie restul (daca exista) si se revine la
        /// starea B pentru cazurile: (N + N + N + Q) / (N + D + Q) / (D + N + Q),
        /// aici suma introdusa ajungand la 40 ¢ care in urma eliberarii produsului si
        /// a restului scade la N (5 ¢) -> starea B.
        /// </summary>
        private static void AfisareFinal()
        {
            Console.Write("\n Puteti ridica produsul. \n");

            switch (SumaRest)
            {
                case 0:
                    break;
                case 5:
                    Console.Write("\n Restul de 5 ¢ (N) v-a fost eliberat. \n");
                    break;
                case 10:
                    Console.Write("\n Restul de 10 ¢ (D) v-a fost eliberat. \n");
                    break;
                case 15:
                    Console.Write("\n Restul de 15 ¢ (N si D) v-a fost eliberat. \n");
                    break;
            }

            if (SumaIntrodusa != 0)
            {
                Console.WriteLine();

                Rest = false;
                SumaRest = 0;
                Starea_B();
            }
            else
            {
                Console.Write("\n O zi buna! ☻ \n\n");

                Console.WriteLine("|------------------------------------------| \n");
            }
        }
    }
}
