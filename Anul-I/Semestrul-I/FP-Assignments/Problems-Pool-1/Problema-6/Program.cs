using System;

namespace Problema_6
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;

            try                                                 // Citirea datelor.
            {
                Console.Write("\n Introduceti lungimea primei laturi: ");
                a = double.Parse(Console.ReadLine());

                Console.Write("\n Introduceti lungimea celei de a doua laturi: ");
                b = double.Parse(Console.ReadLine());

                Console.Write("\n Introduceti lungimea celei de a treia laturi: ");
                c = double.Parse(Console.ReadLine());

                if (a + b >= c && b + c >= a && c + a >= b)     // Conditia de existenta a unui triunghi.
                {
                    Console.WriteLine($"\n Laturile de lungimi: {a}, {b} si {c} pot forma un triunghi. \n");
                }
                else
                {
                    Console.WriteLine($"\n Laturile de lungimi: {a}, {b} si {c} nu pot forma un triunghi. \n");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n Nu ati introdus date procesabile conform cerintei. \n");
            }
        }
    }
}
