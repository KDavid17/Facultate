namespace Curs1
{
    internal class Ladder
    {
        private int width, height;
        public Ladder(int width, int height)
        {
            this.width = width;
            this.height = height;

            for (int i = 0; i < height; i++)
            {
                Frame fr = new Frame(width);
            }
        }
    }
}