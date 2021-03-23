using System;
using System.Collections.Generic;
using System.IO;

namespace Laborator4
{
    public class Matrix
    {
        public Matrix Empty;
        public float[,] values;
        public int n;
        public int m;

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result += this.values[i, j].ToString() + " ";
                }

                result += "\n";
            }

            return result;
        }
        public Matrix()
        {
            
        }

        public Matrix(int n) 
        {
            this.n = n;
        }

        public Matrix(int n, int m)
        { 
            this.n = n;
            this.m = m;

            values = new float[n, m];
        }

        public Matrix(string fileName, bool dimension)
        {
            if (dimension)
            {
                TextReader load = new StreamReader(fileName);
                string buffer = load.ReadLine();
                n = int.Parse(buffer.Split(' ')[0]);
                m = int.Parse(buffer.Split(' ')[1]);
                values = new float[n, m];

                for (int i = 0; i < n; i++)
                {
                    string[] T = load.ReadLine().Split(' ');

                    for (int j = 0; j < m; j++)
                    {
                        values[i, j] = int.Parse(T[j]);
                    }
                }
            }
        }

        public Matrix multiply(Matrix toMultiply)
        {
            if(this.m != toMultiply.n)
            {
                return Empty;
            }
            else
            {
                Matrix Result =  new Matrix(this.n, toMultiply.m);

                for (int i = 0; i < this.n; i++)
                {
                    for (int j = 0; j < toMultiply.m; j++)
                    {
                        Result.values[i, j] = 0;
                        
                        for (int k = 0; k < toMultiply.n; k++)
                        {
                            Result.values[i, j] += this.values[i, k] * toMultiply.values[k, j];
                        }
                    }
                }

                return Result;
            }
        }
    }
}
