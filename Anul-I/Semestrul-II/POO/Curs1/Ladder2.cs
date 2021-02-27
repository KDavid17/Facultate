using System;

namespace Curs1
{
    internal class Ladder2
    {
        private int width;
        private int height;

        public Ladder2(int width, int height)
        {
            this.width = width;
            this.height = height;

            for (int i = 1; i <= height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i % 3 == 1)
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