using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marire
{
    class Program
    {
        static void Main(string[] args)
        {
            // Problema4();
            // Problema5();
            Problema6();
        }

        private static void Problema4()
        {
            try
            {
                Console.Write(" Introduceti numarul n: ");          // Citirea datelor.
                int n = int.Parse(Console.ReadLine());

                Console.Write("\n Introduceti numarul p: ");
                int p = int.Parse(Console.ReadLine());

                Console.Write("\n Introduceti numarul q: ");
                int q = int.Parse(Console.ReadLine());              // 0 si 1 exista mereu.

                Console.Write("\n Numerele magice mai mici sau egale cu n sunt: 0, 1");

                for (int i = 2; i <= n; i++)                        // Parcurgem numerele de la 2 la n.
                {
                    if (Verificare(i, p, q) == true)                // Verificam conditia din cerinta.
                    {
                        Console.Write(", " + i);
                    }
                }

                Console.Write("\n\n");
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n");
            }

        }

        private static bool Verificare(int i, int p, int q)
        {
            // M-am gandit sa transform fiecare numar pe rand intr-un string pentru
            // a putea verifica pe rand daca fiecare cifra dintr-unul se gaseste in celalalt.
            // De exemplu: am convertit 43 intr-un string si am verificat daca fiecare
            // cifra din numarul 34 se regaseste in stringul respectiv.

            string numar_2 = Convert.ToString(Convertire(i, q));

            int numar1 = Convertire(i, p), copie = numar1;

            while (copie != 0)
            {
                if (numar_2.Contains(Convert.ToString(copie % 10)) == false)
                {
                    return false;
                }

                copie /= 10;
            }

            string numar_1 = Convert.ToString(Convertire(i, p));

            int numar2 = Convertire(i, q);

            copie = numar2;

            while (copie != 0)
            {
                if (numar_1.Contains(Convert.ToString(copie % 10)) == false)
                {
                    return false;
                }

                copie /= 10;
            }

            return true;
        }

        private static int Convertire(int numar_initial, int baza)
        {
            // M-am gandit la o metoda recursiva de a face conversia pentru a nu mai 
            // parcurge inca o data intreg numarul pentru a il roti. Ma refer ca initial
            // in metoda cu resturile ar fi dat opusul si mai trebuia implementata 
            // oglindirea numarului.

            if (numar_initial / baza == 0)
            {
                return numar_initial;
            }
            else
            {
                return Convertire(numar_initial / baza, baza) * 10 + numar_initial % baza;
            }
        }

        private static void Problema5()
        {
            try
            {
                Console.Write(" Introduceti numarul n: ");
                int n = int.Parse(Console.ReadLine());

                Console.Write(" Introduceti numarul m: ");
                int m = int.Parse(Console.ReadLine()), i, j, contor = 0;

                int[,] matrice = new int[n, m];

                bool pauza = false;

                Random aleator = new Random();
                
                for (i = 0; i < n; i++)                     // Dam valori aleatoare.
                {
                    for (j = 0; j < m; j++)
                    {
                        matrice[i, j] = aleator.Next(0,100);
                        
                        Console.Write(matrice[i, j] + " ");
                    }
                }

                Console.Write("\n\n");

                for (i = 0; i <= (n / 2) + (n % 2); i++)        // Parcurgem matricea de n / 2 ori
                {                                               // si in caz ca n e impar, inca o data.
                    for (j = i; j < m - i; j++)                 // De la stanga la dreapta.
                    {
                        Console.Write(matrice[i, j] + " ");

                        contor++;

                        if (contor == n * m)
                        {
                            pauza = true;
                            break;
                        }
                    }

                    if (pauza == true)                          // Pauza e folosit deoarece 
                    {                                           // programul mai face o operatie
                        break;                                  // unde si nu am avut timp sa identific
                    }                                           // problema.
                    
                    for (j = i + 1; j < n - i; j++)             // De sus in jos.
                    {
                        Console.Write(matrice[j, m - i - 1] + " ");

                        contor++;

                        if (contor == n * m)
                        {
                            pauza = true;
                                break;
                        }
                    }

                    if (pauza == true)
                    {
                        break;
                    }

                    for (j = m - i - 2; j >= i; j--)            // De la dreapta la stanga.
                    {
                        Console.Write(matrice[n - i - 1, j] + " ");

                        contor++;

                        if (contor == n * m)
                        {
                            pauza = true;
                            break;
                        }
                    }

                    if (pauza == true)
                    {
                        break;
                    }

                    for (j = n - i - 2; j >= i + 1; j--)             // De jos in sus.
                    {
                        Console.Write(matrice[j, i] + " ");

                        contor++;

                        if (contor == n * m)
                        {
                            pauza = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. ");
            }
        }

        private static void Problema6()
        {
            Console.Write(" Introduceti numarul n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("\n Introduceti numerele din sir: ");
            int[] vector = new int[n+5];

            for (int i = 1; i <= n; i++)
            {
                vector[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("\n Introduceti Q: ");
            int q = int.Parse(Console.ReadLine()), x, s, contor1 = 1;

            int[] vector2 = new int[q+5];

            Console.Write("\n Introduceti x,s :");

            for (int i = 1; i <= q; i++)                // Nu am avut timp de identificare a problemelor.
            {                                           // Programul trbeuia sa verifice si sa adune numerele
                int index = 1;                          // pana la s.

                x = int.Parse(Console.ReadLine());
                s = int.Parse(Console.ReadLine());

                int suma = 0, contor = 0;

                while (suma <= s && vector[index] <= x && index <= n)
                {
                    suma += vector[index];
                    contor++;
                    index++;
                }

                vector2[contor1] = suma;
                contor1++;
            }

            Console.Write("\n\n");

            for (int i = 1; i <= contor1; i++)
            {
                Console.Write(vector2[i] + "\n");
            }
        }
    }
}
