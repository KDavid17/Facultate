namespace Laborator3
{
    public class Line
    {
        private Point p1;
        private Point p2;

        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public Line(double x1, double y1, double x2, double y2)
        {
            p1 = new Point(x1, y1);
            p2 = new Point(x2, y2);
        }

        public override string ToString()
        {
            return $"[{p1}, {p2}]";
        }

        public double Length
        {
            get
            {
                return p1.DistanceTo(p2);
            }
        }
    }
}