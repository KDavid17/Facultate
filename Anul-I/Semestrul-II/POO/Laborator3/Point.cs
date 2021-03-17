using System;
using System.Collections.Generic;
namespace Laborator3
{
    public class Point
    {
        private double x, y;
        #region constructors

        Stack<Point> history = new Stack<Point>();

        public void GoBack()
        {

        }
        public Point(): this(0.0, 0.0)
        { 
            
        }
            

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(string str)
        {
            str = str.Trim();
        }

        
        #endregion
        public override string ToString()
        {
            return $"({x}; {y})";
        }

        public void MoveBy(double dx, double dy)
        {
            x += dx;
            y += dy;
        }

        public double DistanceTo(Point p2)
        {
            double x1, x2, y1, y2;

            x1 = x;
            y1 = y;
            
            x2 = p2.x;
            y2 = p2.y;

            return Math.Sqrt((x1 - x2)*(x1 - x2) + (y1 - y2)*(y1 - y2));
        }
        public double DistanceToOrigin()
        {
            return DistanceTo(new Point());
        }

    }
}