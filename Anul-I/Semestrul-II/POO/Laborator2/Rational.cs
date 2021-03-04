using System;

namespace Laborator2
{
    internal class Rational
    {
        public int numerator, denominator;

        public Rational(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public override string ToString()
        {
            return "(" + numerator + ", " + denominator + ")"; 
        }

        private int lcm(int a, int b)
        {
            return a * b / gcd(a, b);
        }

        private int gcd(int a, int b)
        {
            int c;

            while(b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }

            return a;
        }

        private void Simplify(ref int numb1, ref int numb2)
        {
            int divisor = gcd(numb1, numb2);

            numb1 /= divisor;
            numb2 /= divisor;
        }

        public Rational Add(Rational numb2)
        {
            Simplify(ref numerator, ref denominator);
            Simplify(ref numb2.numerator, ref numb2.denominator);

            if (denominator != numb2.denominator)
            {
                if (denominator % numb2.denominator != 0 && numb2.denominator % denominator != 0)
                {
                    int multiple = lcm(denominator, numb2.denominator);
                    int numeratorResult = numerator * (multiple / denominator) + 
                                            numb2.numerator * (multiple / numb2.denominator);
                    int divisor = gcd(numeratorResult, multiple);

                    return new Rational(numeratorResult / divisor, multiple / divisor);
                }
                else
                {
                    if (denominator < numb2.denominator)
                    {
                        int numeratorResult = numerator * (numb2.denominator / denominator) + numb2.numerator;
                        int divisor = gcd(numeratorResult, numb2.denominator);

                        return new Rational(numeratorResult / divisor, numb2.denominator / divisor);
                    }
                    else
                    {
                        int numeratorResult = numerator + numb2.numerator * (denominator / numb2.denominator);
                        int divisor = gcd(numeratorResult, denominator);

                        return new Rational(numeratorResult / divisor, denominator / divisor);
                    }
                }
            }
            else
            {
                int numeratorResult = numerator + numb2.numerator;
                int divisor = gcd(numeratorResult, denominator);

                return new Rational(numeratorResult / divisor, denominator / divisor);
            }
        }  

        public Rational Subtract(Rational numb2)
        {
            Simplify(ref numerator, ref denominator);
            Simplify(ref numb2.numerator, ref numb2.denominator);

            if (denominator != numb2.denominator)
            {
                if (denominator % numb2.denominator != 0 && numb2.denominator % denominator != 0)
                {
                    int multiple = lcm(denominator, numb2.denominator);
                    int numeratorResult = numerator * (multiple / denominator) -
                                            numb2.numerator * (multiple / numb2.denominator);
                    int divisor = gcd(numeratorResult, multiple);

                    return new Rational(numeratorResult / divisor, multiple / divisor);
                }
                else
                {
                    if (denominator < numb2.denominator)
                    {
                        int numeratorResult = numerator * (numb2.denominator / denominator) - numb2.numerator;
                        int divisor = gcd(numeratorResult, numb2.denominator);

                        return new Rational(numeratorResult / divisor, numb2.denominator / divisor);
                    }
                    else
                    {
                        int numeratorResult = numerator - numb2.numerator * (denominator / numb2.denominator);
                        int divisor = gcd(numeratorResult, denominator);

                        return new Rational(numeratorResult / divisor, denominator / divisor);
                    }
                }
            }
            else
            {
                int numeratorResult = numerator - numb2.numerator;
                int divisor = gcd(numeratorResult, denominator);

                return new Rational(numeratorResult / divisor, denominator / divisor);
            }
        }
        
        public Rational Multiply(Rational numb2)
        {
            Simplify(ref numerator, ref denominator);
            Simplify(ref numb2.numerator, ref numb2.denominator);
            Simplify(ref numerator, ref numb2.denominator);
            Simplify(ref denominator, ref numb2.numerator);

            Console.Write($"\n\n {numerator}, {denominator}     {numb2.numerator}, {numb2.denominator}\n\n");

            int numeratorResult = numerator * numb2.numerator;
            int denominatorResult = denominator * numb2.denominator;
            int divisor = gcd(numeratorResult, denominatorResult);

            return new Rational(numeratorResult / divisor, denominatorResult / divisor);
        }

        public Rational Raise(int exponent)
        {
            Simplify(ref numerator, ref denominator);

            Rational result = new Rational(numerator, denominator);

            for (int i = 2; i <= exponent; i++)
            {
                result = result.Multiply(new Rational(numerator, denominator));
            }

            return result;
        }
    }
}