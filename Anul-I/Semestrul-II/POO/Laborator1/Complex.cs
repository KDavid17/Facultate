using System;

namespace Laborator1
{
    public class Complex
    {
        public double re, im;

        public Complex(double re): this(re, 0)
        {

        }

        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public override string ToString()
        {
            return "(" + re.ToString() + ", " + im.ToString() + ")";
        }

        public Complex Add(Complex numb2)
        {
            return new Complex(re + numb2.re, im + numb2.im);
        }

        internal Complex Diff(Complex numb2)
        {
            return new Complex(re - numb2.re, im - numb2.im);
        }

        internal Complex Multiply(Complex numb2)
        {
            return new Complex(re * numb2.re - im * numb2.im, re * numb2.im + im * numb2.re);
        }

        internal Complex Divide(Complex numb2)
        {
            Complex denom = new Complex(numb2.re, -numb2.im);
            Complex num = new Complex(re, im).Multiply(denom);

            double reDenom = numb2.Multiply(denom).re;      

            return new Complex(num.re / reDenom, num.im / reDenom);
        }

        internal Complex Power(int exponent)
        {
            Complex pow = new Complex(re, im);

            for (int i = 2; i <= exponent; i++)
            {
                pow =  pow.Multiply(new Complex(re, im));
            }

            return pow;
        }
    }
}