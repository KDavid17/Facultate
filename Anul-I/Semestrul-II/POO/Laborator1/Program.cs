using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n Alegeti operatia dorita din urmatoarele: +, -, *, /, ^ \n\n Optiunea: ");
            char sign = Console.ReadKey().KeyChar;
            
            switch (sign)
            {
                case '+':

                    Addition();

                    break;

                case '-':

                    Difference();

                    break;

                case '*':

                    Multiplication();

                    break;

                case '/':

                    Division();

                    break;

                case '^':

                    PowerRaising();

                    break;

                default:

                    Console.Write("\n Nu ati introdus date procesabile conform cerintei. \n\n");

                    break;
            }
        }

        private static void PowerRaising()
        {
            Console.Write("\n\n Introduceti primul numar unde reA = 'partea reala' si imA = 'partea imaginara'.");

            Console.Write("\n\n reA = ");
            double reA = double.Parse(Console.ReadLine());

            Console.Write("\n imA = ");
            double imA = double.Parse(Console.ReadLine());

            Console.Write("\n Introduceti puterea: ");
            int exponent = int.Parse(Console.ReadLine());

            Complex numb = new Complex(reA, imA);
            Complex result = numb.Power(exponent);

            Console.Write($"\n ({reA}, {imA}) ^ {exponent} = {result} \n\n");
        }

        private static void Division()
        {
            Console.Write("\n\n Introduceti primul numar unde reA = 'partea reala' si imA = 'partea imaginara'.");

            Console.Write("\n\n reA = ");
            double reA = double.Parse(Console.ReadLine());

            Console.Write("\n imA = ");
            double imA = double.Parse(Console.ReadLine());

            Console.Write("\n Introduceti al doilea numar unde reB = 'partea reala' si imB = 'partea imaginara'.");

            Console.Write("\n\n reA = ");
            double reB = double.Parse(Console.ReadLine());

            Console.Write("\n imA = ");
            double imB = double.Parse(Console.ReadLine());

            Complex numb1 = new Complex(reA, imA);
            Complex numb2 = new Complex(reB, imB);
            Complex div = numb1.Divide(numb2);

            Console.Write($"\n ({reA}, {imA}) / ({reB}, {imB}) = {div} \n\n");
        }

        private static void Multiplication()
        {
            Console.Write("\n\n Introduceti primul numar unde reA = 'partea reala' si imA = 'partea imaginara'.");

            Console.Write("\n\n reA = ");
            double reA = double.Parse(Console.ReadLine());

            Console.Write("\n imA = ");
            double imA = double.Parse(Console.ReadLine());

            Console.Write("\n Introduceti al doilea numar unde reB = 'partea reala' si imB = 'partea imaginara'.");

            Console.Write("\n\n reA = ");
            double reB = double.Parse(Console.ReadLine());

            Console.Write("\n imA = ");
            double imB = double.Parse(Console.ReadLine());

            Complex numb1 = new Complex(reA, imA);
            Complex numb2 = new Complex(reB, imB);
            Complex mult = numb1.Multiply(numb2);

            Console.Write($"\n ({reA}, {imA}) * ({reB}, {imB}) = {mult} \n\n");
        }

        private static void Difference()
        {
            Console.Write("\n\n Introduceti primul numar unde reA = 'partea reala' si imA = 'partea imaginara'.");

            Console.Write("\n\n reA = ");
            double reA = double.Parse(Console.ReadLine());

            Console.Write("\n imA = ");
            double imA = double.Parse(Console.ReadLine());

            Console.Write("\n Introduceti al doilea numar unde reB = 'partea reala' si imB = 'partea imaginara'.");

            Console.Write("\n\n reA = ");
            double reB = double.Parse(Console.ReadLine());

            Console.Write("\n imA = ");
            double imB = double.Parse(Console.ReadLine());

            Complex numb1 = new Complex(reA, imA);
            Complex numb2 = new Complex(reB, imB);
            Complex dif = numb1.Diff(numb2);

            Console.Write($"\n ({reA}, {imA}) - ({reB}, {imB}) = {dif} \n\n");
        }

        private static void Addition()
        {
            Console.Write("\n\n Introduceti primul numar unde reA = 'partea reala' si imA = 'partea imaginara'.");

            Console.Write("\n\n reA = ");
            double reA = double.Parse(Console.ReadLine());

            Console.Write("\n imA = ");
            double imA = double.Parse(Console.ReadLine());

            Console.Write("\n Introduceti al doilea numar unde reB = 'partea reala' si imB = 'partea imaginara'.");

            Console.Write("\n\n reA = ");
            double reB = double.Parse(Console.ReadLine());

            Console.Write("\n imA = ");
            double imB = double.Parse(Console.ReadLine());

            Complex numb1 = new Complex(reA, imA);
            Complex numb2 = new Complex(reB, imB);
            Complex sum = numb1.Add(numb2);

            Console.Write($"\n ({reA}, {imA}) + ({reB}, {imB}) = {sum} \n\n");
        }
    }
}
