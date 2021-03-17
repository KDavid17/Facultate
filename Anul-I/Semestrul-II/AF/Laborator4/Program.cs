using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator4
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix A = new Matrix(@"..\..\matrix1.txt", true);
            

            Matrix B = new Matrix(@"..\..\matrix2.txt", true);

            Matrix C = A.multiply(B);

            Console.WriteLine(C);
        }
    }
}
