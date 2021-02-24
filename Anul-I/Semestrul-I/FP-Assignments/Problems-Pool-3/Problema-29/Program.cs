using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_29
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n Introduceti numarul de elemente: ");
            int Numar = int.Parse(Console.ReadLine()), i;

            int[] Vector = new int[Numar];
            Random Aleator = new Random();

            Console.Write("\n Vectorul inainte de sortare: \n\n");

            for (i = 0; i < Numar; i++)
            {
                Vector[i] = Aleator.Next(0, Numar);

                Console.Write(Vector[i] + " ");
            }

            Sort(Vector, 0, Numar - 1);

            Console.Write("\n\n Vectorul dupa sortare: \n\n");

            for (i = 0; i < Numar; i++)
            {
                Console.Write(Vector[i] + " ");
            }

            Console.Write("\n\n");
        }
        private static void Merge(int[] Vector, int Stanga, int Mijloc, int Dreapta)
        {
            int Numar1 = Mijloc - Stanga + 1, Numar2 = Dreapta - Mijloc, Temp = Stanga;

            int[] VectorStanga = new int[Numar1];
            int[] VectorDreapta = new int[Numar2];
            int i, j;

            for (i = 0; i < Numar1; i++)
            {
                VectorStanga[i] = Vector[Stanga + i];
            }
                
            for (j = 0; j < Numar2; j++)
            {
                VectorDreapta[j] = Vector[Mijloc + j + 1];
            }
                
            i = 0;
            j = 0;

            while (i < Numar1 && j < Numar2)
            {
                if (VectorStanga[i] <= VectorDreapta[j])
                {
                    Vector[Temp] = VectorStanga[i];

                    i++;
                }
                else
                {
                    Vector[Temp] = VectorDreapta[j];

                    j++;
                }

                Temp++;
            }

            while (i < Numar1)
            {
                Vector[Temp] = VectorStanga[i];

                i++;

                Temp++;
            }

            while (j < Numar2)
            {
                Vector[Temp] = VectorDreapta[j];

                j++;

                Temp++;
            }
        }
        private static void Sort(int[] Vector, int Stanga, int Dreapta)
        {
            if (Stanga < Dreapta)
            {
                int Mijloc = (Stanga + Dreapta) / 2;

                Sort(Vector, Stanga, Mijloc);

                Sort(Vector, Mijloc + 1, Dreapta);

                Merge(Vector, Stanga, Mijloc, Dreapta);
            }
        }
    }
}
