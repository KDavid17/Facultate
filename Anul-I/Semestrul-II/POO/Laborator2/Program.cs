using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n Introduceti '+' , '-' , '*' , '/' , '^' in functie de operatia dorita: ");
            char sign = Console.ReadKey().KeyChar;

            switch (sign)
            {
                case '+':

                    Addition();

                    break;

                case '-':

                    Subtraction();

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

                    Console.Write("\n\n Nu ati introdus date procesabile conform cerintei. \n\n");

                    break;
            }
        }

        private static void PowerRaising()
        {
            Console.Write("\n\n Introduceti numaratorul si numitorul numarului. \n\n Numarator: ");
            int numerator = int.Parse(Console.ReadLine());

            Console.Write("\n Numitor: ");
            int denominator = int.Parse(Console.ReadLine());

            Console.Write("\n Introduceti puterea la care sa fie ridicat numarul: ");
            int exponent = int.Parse(Console.ReadLine());

            if (denominator == 0)
            {
                Console.Write("\n Calcul imposibil din cauza impartirii la 0. \n\n");
            }
            else if (numerator == 0)
            {
                Console.Write($"\n (0, {denominator}) ^ {exponent} = 0 \n\n");
            }
            else
            {
                if (exponent != 0)
                {
                    if (exponent < 0)
                    {
                        Rational numb = new Rational(denominator, numerator);

                        Console.Write($"\n ({numerator}, {denominator}) ^ ({exponent}) = {numb.Raise(-exponent)} \n\n");
                    }
                    else
                    {
                        Rational numb = new Rational(numerator, denominator);

                        Console.Write($"\n ({numerator}, {denominator}) ^ {exponent} = {numb.Raise(exponent)} \n\n");
                    }
                }
                else
                {
                    Console.Write($"\n ({numerator}, {denominator}) ^ 0 = 1 \n\n");

                    return;
                }
            }
        }

        private static void Division()
        {
            Console.Write("\n\n Introduceti numaratorul si numitorul primului numar. \n\n Numarator: ");
            int numerator1 = int.Parse(Console.ReadLine());

            Console.Write("\n Numitor: ");
            int denominator1 = int.Parse(Console.ReadLine());

            Console.Write("\n Introduceti numaratorul si numitorul celui de al doilea numar. \n\n Numarator: ");
            int denominator2 = int.Parse(Console.ReadLine());

            Console.Write("\n Numitor: ");
            int numerator2 = int.Parse(Console.ReadLine());

            if (denominator1 == 0 || denominator2 == 0 || numerator2 == 0)
            {
                Console.Write("\n Calcul imposibil din cauza impartirii la 0. \n\n");
            }
            else if (numerator1 == 0)
            {
                Console.Write($"\n (0, {denominator1}) / ({numerator2}, {denominator2}) = 0 \n\n");
            }
            else
            {
                Rational numb1 = new Rational(numerator1, denominator1);
                Rational numb2 = new Rational(numerator2, denominator2);

                Console.Write($"\n ({numerator1}, {denominator1}) / ({denominator2}, {numerator2}) = {numb1.Multiply(numb2)} \n\n");
            }
        }

        private static void Multiplication()
        {
            Console.Write("\n\n Introduceti numaratorul si numitorul primului numar. \n\n Numarator: ");
            int numerator1 = int.Parse(Console.ReadLine());

            Console.Write("\n Numitor: ");
            int denominator1 = int.Parse(Console.ReadLine());

            Console.Write("\n Introduceti numaratorul si numitorul celui de al doilea numar. \n\n Numarator: ");
            int numerator2 = int.Parse(Console.ReadLine());

            Console.Write("\n Numitor: ");
            int denominator2 = int.Parse(Console.ReadLine());

            if (denominator1 == 0 || denominator2 == 0)
            {
                Console.Write("\n Calcul imposibil din cauza impartirii la 0. \n\n");
            }
            else if (numerator1 == 0 || numerator2 == 0)
            {
                Console.Write($"\n ({numerator1}, {denominator1}) * ({numerator2}, {denominator2}) = 0 \n\n");
            }
            else
            {
                Rational numb1 = new Rational(numerator1, denominator1);
                Rational numb2 = new Rational(numerator2, denominator2);

                Console.Write($"\n ({numerator1}, {denominator1}) * ({numerator2}, {denominator2}) = {numb1.Multiply(numb2)} \n\n");
            }
        }

        private static void Subtraction()
        {
            Console.Write("\n\n Introduceti numaratorul si numitorul primului numar. \n\n Numarator: ");
            int numerator1 = int.Parse(Console.ReadLine());

            Console.Write("\n Numitor: ");
            int denominator1 = int.Parse(Console.ReadLine());

            Console.Write("\n Introduceti numaratorul si numitorul celui de al doilea numar. \n\n Numarator: ");
            int numerator2 = int.Parse(Console.ReadLine());

            Console.Write("\n Numitor: ");
            int denominator2 = int.Parse(Console.ReadLine());

            if (denominator1 == 0 || denominator2 == 0)
            {
                Console.Write("\n Calcul imposibil din cauza impartirii la 0. \n\n");
            }
            else if (numerator1 == 0)
            {
                Console.Write($"\n ({numerator1}, {denominator1}) - ({numerator2}, {denominator2}) = ({-numerator2}, {denominator2}) \n\n");
            }
            else if (numerator2 == 0)
            {
                Console.Write($"\n ({numerator1}, {denominator1}) - ({numerator2}, {denominator2}) = ({numerator1}, {denominator1}) \n\n");
            }
            else
            {
                Rational numb1 = new Rational(numerator1, denominator1);
                Rational numb2 = new Rational(numerator2, denominator2);

                Console.Write($"\n ({numerator1}, {denominator1}) - ({numerator2}, {denominator2}) = {numb1.Subtract(numb2)} \n\n");
            }
        }

        private static void Addition()
        {
            Console.Write("\n\n Introduceti numaratorul si numitorul primului numar. \n\n Numarator: ");
            int numerator1 = int.Parse(Console.ReadLine());

            Console.Write("\n Numitor: ");
            int denominator1 = int.Parse(Console.ReadLine());

            Console.Write("\n Introduceti numaratorul si numitorul celui de al doilea numar. \n\n Numarator: ");
            int numerator2 = int.Parse(Console.ReadLine());

            Console.Write("\n Numitor: ");
            int denominator2 = int.Parse(Console.ReadLine());

            if (denominator1 == 0 || denominator2 == 0)
            {
                Console.Write("\n Calcul imposibil din cauza impartirii la 0. \n\n");
            }
            else if (numerator1 == 0)
            {
                Console.Write($"\n ({numerator1}, {denominator1}) + ({numerator2}, {denominator2}) = ({numerator2}, {denominator2}) \n\n");
            }
            else if (numerator2 == 0)
            {
                Console.Write($"\n ({numerator1}, {denominator1}) + ({numerator2}, {denominator2}) = ({numerator1}, {denominator1}) \n\n");
            }
            else
            {
                Rational numb1 = new Rational(numerator1, denominator1);
                Rational numb2 = new Rational(numerator2, denominator2);

                Console.Write($"\n ({numerator1}, {denominator1}) + ({numerator2}, {denominator2}) = {numb1.Add(numb2)} \n\n");
            }
        }
    }
}
