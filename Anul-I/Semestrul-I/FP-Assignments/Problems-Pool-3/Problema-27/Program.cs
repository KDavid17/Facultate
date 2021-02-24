using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_27
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n Introduceti lugimea vectorului: ");
            int Numar = int.Parse(Console.ReadLine());

            Console.Write("\n Vectorul inainte de sortare: ");
            List<int> Vector = CitireVector(Numar);

            Console.Write("\n\n Introduceti valoarea indexului: ");
            int Index = int.Parse(Console.ReadLine());

            Vector.Sort();

            Console.Write("\n Valoarea de pe pozitia Index dupa sortare este: ");
            Console.Write(Vector[Index] + "\n\n");
        }
        private static List<int> CitireVector(int Numar)
        {
            Random Aleator = new Random();
            List<int> Vector = new List<int>();

            for (int i = 0; i < Numar; i++)
            {
                Vector.Add(Aleator.Next(0, Numar));

                Console.Write(Vector[i] + " ");
            }

            return Vector;
        }
    }
}
