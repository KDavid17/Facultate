using System;

namespace Curs1
{
    internal class Frame
    {
        private int width;
        public Frame(int width)
        {
            this.width = width;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0)
                    {
                        Console.Write((j == 0 || j + 1 == width) ? "+" : "-");
                    }
                    else
                    {
                        Console.Write((j == 0 || j + 1 == width) ? "|" : " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}