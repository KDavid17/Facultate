using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs1
{
    class Program
    {
        static void Main(string[] args)
        {
            // problema1();
            // problema2();
            // problema3();
            // problema4();
            // problema5();
        }
        private static void problema5()
        {
            try
            {
                Random aleator = new Random();

                Console.Write("\n Introduceti lungimea vectorului: ");
                int numar = int.Parse(Console.ReadLine());

                Console.Write("\n Introduceti elementele vectorului: ");
                int[] vector = new int[numar];

                for (int i = 0; i < numar; i++)
                {
                    vector[i] = int.Parse(Console.ReadLine());
                }

                Console.Write("\n Introduceti valoarea k: ");
                int k = int.Parse(Console.ReadLine()), pozitie = 0, verificare = 0, copie = k;

                Console.Write($"\n Cele mai mari {k} valori de 3 cifre care nu sunt in vector: ");

                insertionSort(vector, ref pozitie);

                for (int i = 999; i >= 100 && k > 0; i--)
                {
                    while (vector[pozitie] > i)
                    {
                        pozitie--;
                    }
                    if (vector[pozitie] != i)
                    {
                        Console.Write(i + " ");

                        verificare++;

                        k--;
                    }
                }
                
                if (verificare != copie)
                {
                    Console.Write($"\n\n Nu s-au gasit decat {verificare} elemente care sa respecte cerinta. ");
                }
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. ");
            }
        }
        private static void insertionSort(int[] vector, ref int pozitie)
        {
            int maxim;

            if (vector[0] > 99 && vector[0] < 1000)
            {
                maxim = vector[0];

                pozitie = 0;
            }
            else
            {
                maxim = 0;
            }

            for (int i = 1; i < vector.Length; i++)
            {
                int element = vector[i], j = i - 1;

                if (element > 99 && element < 1000 && element > maxim)
                {
                    maxim = element;

                    pozitie = i;
                }

                while (j >= 0 && vector[j] > element)
                {
                    if (vector[j] == maxim)
                    {
                        pozitie = j + 1;
                    }

                    vector[j + 1] = vector[j];

                    j--;
                }

                vector[j + 1] = element;
            }
        }

        private static void problema4()
        {
            try
            {
                Random aleator = new Random();

                Console.Write("\n Introduceti lungimea vectorului: ");
                int numar = int.Parse(Console.ReadLine());

                Console.Write("\n Introduceti elementele vectorului: ");
                int[] vector = new int[numar];

                for (int i = 0; i < numar; i++)
                {
                    vector[i] = aleator.Next(1, 30);
                    Console.Write(vector[i] + " ");
                }

                Console.Write("\n Puteri ale lui 2: ");

                for (int i = 0; i < numar; i++)
                {
                    if (putere4(vector[i]) == true)
                    {
                        Console.Write(vector[i] + " ");
                    }
                }

                Console.Write("\n");

                Console.Write("\n Numere perfecte: ");

                for (int i = 0; i < numar; i++)
                {
                    if (perfect4(vector[i]) == vector[i])
                    {
                        Console.Write(vector[i] + " ");
                    }
                }

                Console.Write("\n");

                Console.Write("\n Perechile de numere prime intre ele: ");

                for (int i = 0; i < numar - 1; i++)
                {
                    for (int j = i + 1; j < numar; j++)
                    {
                        if (cmmdc4(vector[i], vector[j]) == 1)
                        {
                            Console.Write("("  + vector[i] + "," + vector[j] + ") ");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus valori procesabile conform cerintei. ");
            }
        }
        private static int cmmdc4(int numar1, int numar2)
        {
            int aux; 

            if (numar1 == 1 || numar2 == 1)
            {
                return 1;
            }
            else
            {
                while (numar2 != 0)
                {
                    aux = numar1 % numar2;
                    numar1 = numar2;
                    numar2 = aux;
                }

                return numar1;
            }
        }
        private static int perfect4(int numar)
        {
            int suma = 1;

            for (int i = 2; i * i < numar; i++)
            {
                if (numar % i == 0)
                {
                    suma += i + numar / i;
                }
            }
            
            if (suma == 1)
            {
                return 0;
            }
            else
            {
                return suma;
            }      
        }
        private static bool putere4(int numar)
        {
            if (numar == 1)
            {
                return false;
            }
            else
            {
                return (numar != 0) && ((numar & (numar - 1)) == 0);
            }
        }

        private static void problema3()
        {
            try
            {
                Console.Write("\n Introduceti lungimea vectorului: ");
                int numar = int.Parse(Console.ReadLine()), i;

                Console.Write("\n Introduceti vectorul: ");
                int[] vector = new int[numar];

                for (i = 0; i < numar; i++)
                {
                    vector[i] = int.Parse(Console.ReadLine());
                }

                int element = vector[0], poz = 0;

                for (i = 1; i < numar; i++)
                {
                    if (vector[i] != element)
                    {
                        Console.Write(vector[i - 1] + " " + (i - poz) + " ");

                        poz = i;
                        
                        element = vector[i];
                    }
                }

                Console.Write(vector[poz] + " " + (i - poz) + " ");
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. ");
            }      
        }

        private static void problema2()
        {
            try
            {
                Console.Write("\n Introduceti lungimea vectorului: ");
                int numar = int.Parse(Console.ReadLine());

                Console.Write("\n Introduceti elementele vectorului: ");
                int[] vector = new int[numar];

                for (int i = 0; i < numar; i++)
                {
                    vector[i] = int.Parse(Console.ReadLine());
                }

                Console.Write("\n Vectorul nou: ");

                for (int i = 0; i < numar; i++)
                {
                    if (prim2(vector[i]) == true)
                    {
                        numar++;

                        Array.Resize(ref vector, numar);

                        for (int j = numar - 1; j > i; j--)
                        {
                            vector[j] = vector[j - 1];
                        }

                        vector[i + 1] = suma2(vector[i]);

                        i++;
                    }
                }

                for (int i = 0; i < numar; i++)
                {
                    Console.Write(vector[i] + " ");
                }
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. ");
            }
        }
        private static int suma2(int numar)
        {
            int suma = 0;

            while (numar != 0)
            {
                suma += numar % 10;

                numar /= 10;
            }

            return suma;
        }
        private static bool prim2(int numar)
        {
            if (numar < 2)
            {
                return false;
            }
            if (numar == 2)
            {
                return true;
            }
            if (numar % 2 == 0)
            {
                return false;
            }

            for (int i = 3; i * i <= numar; i += 2)
            {
                if (numar % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static void problema1()
        {
            try
            {
                Console.Write("\n Introduceti lungimea vectorului: ");
                int numar = int.Parse(Console.ReadLine());

                Console.Write("\n Introduceti vectorul: ");
                int[] vector = new int[numar];

                for (int i = 0; i < numar; i++)
                {
                    vector[i] = int.Parse(Console.ReadLine());
                }

                bool ok = true;

                for (int i = 0; i < numar / 2; i++)
                {
                    if (vector[i] != vector[numar - i - 1])
                    {
                        ok = false;

                        break;
                    }
                }

                if (ok == false)
                {
                    Console.Write("\n NU");
                }
                else
                {
                    Console.Write("\n DA");
                }
            }
            catch (Exception)
            {
                Console.Write("\n Nu ati introdus date procesabile conform cerintei. ");
            }
        }
    }
}
