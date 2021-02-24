using System;

namespace Problema_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double n, k;

            try                                             // Citirea datelor.
            {
                Console.Write("\n Introduceti primul numar: ");
                n = double.Parse(Console.ReadLine());

                Console.Write("\n Introduceti al doilea numar: ");
                k = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");

                return;
            }

            if (n % k == 0)                                 // Cazul afirmativ.
            {
                Console.WriteLine($"\n Numarul: {n} se divide cu numarul: {k} .\n");
            }
            else                                            // Cazul negativ.
            {
                Console.WriteLine($"\n Numarul: {n} nu se divide cu numarul: {k} .\n");
            }

        }
    }
}
