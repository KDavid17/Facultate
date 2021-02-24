using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Moore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Legea lui Moore indica faptul ca puterea de calcul se dubleaza la fiecare 1.5 ani.
            // Astfel, o putere de calcul x devine peste 1.5 ani x * 2, peste 3 ani
            // x * 2 ^ 2 si asa mai departe.
            // Prin urmare, inmultim log2(n) cu 1.5 pentru a afla peste cati ani puterea de calcul
            // va fi de n ori mai mare.

            // Initializam valoarea intreaga n (de cate ori va creste puterea de calcul), respectiv
            // valoarea reala p (numarul de ani necesari evoluarii puterii de calcul)

            int n;
            double p;
            Console.Write("Introduceti puterea de calcul dorita: ");
            
            try
            {
                n = int.Parse(Console.ReadLine());      // Am convertit valoarea introdusa de la tastatura (n).

                if (n < 2)
                    throw new ArgumentException();    // Tratam cazul introducerii unui numar mai mic decat 2.

                p = Math.Log(n, 2) * 1.5;            // Am inmultit logaritmul in baza 2 din n cu perioada
                                                     // de timp dupa care puterea de calcul se dubleaza.
                
               
                // Tratarea unor cazuri pentru corectitudinea gramaticala.
                string d;    
                
                d = "Puterea de calcul va deveni de " + n;

                if (n >= 20)                             
                    d = d + " de";

                d = d + " ori mai mare peste " + p;    
                                                                    
                if (p >= 20)
                    d = d + " de";

                d = d + " ani.";

                Console.WriteLine();
                Console.WriteLine(d);               // Afisarea.
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine("Introduceti un numar natural mai mare sau egal cu 2!");
                Console.WriteLine();

                // Exceptia intra in vigoare in cazul unei initializari care nu este in conformitate cu cerinta.
            }
            
            
        }
    }
}
