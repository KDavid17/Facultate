using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Intersection
{
    public partial class MainWindow : Window
    {
        List<Line> myLines = new List<Line>();
        PointCollection myPoints = new PointCollection();
        Point currentPoint = new Point();
        Line line = new Line();

        public MainWindow()
        {
            

            InitializeComponent();

            Polygon myPolygon = new Polygon
            {
                Stroke = Brushes.Black,
                Fill = Brushes.White,
                StrokeThickness = 1,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            PointCollection points = new PointCollection
            {
                new Point(0, 0),
                new Point(myCanvas.Width, 0),
                new Point(myCanvas.Width, myCanvas.Height),
                new Point(0, myCanvas.Height)
            };

            myPolygon.Points = points;

            myCanvas.Children.Add(myPolygon);
        }

        private void Canvas_LeftMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(this);

                line = new Line();
            }
                
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                myLines.Remove(line);
                myCanvas.Children.Remove(line); // Deleting the old line
                line = new Line();
                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(myCanvas).X;
                line.Y2 = e.GetPosition(myCanvas).Y;

                myCanvas.Children.Add(line);
                myLines.Add(line);

            }
        }

        private void DrawPoint(Point p)
        {
            Ellipse myEllipse = new Ellipse()
            {
                Margin = new Thickness(p.X - 4, p.Y - 4, 0, 0),
                Fill = Brushes.Red,
                Width = 8,
                Height = 8
            };

            myCanvas.Children.Add(myEllipse);
        }

        public static bool IsPointInTriangle(Point p1, Point p2, Point p3, Point p)
        {
            bool isWithinTriangle = false;

            double denominator = ((p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y));

            double a = ((p2.Y - p3.Y) * (p.X - p3.X) + (p3.X - p2.X) * (p.Y - p3.Y)) / denominator;
            double b = ((p3.Y - p1.Y) * (p.X - p3.X) + (p1.X - p3.X) * (p.Y - p3.Y)) / denominator;
            double c = 1 - a - b;

            if (a > 0 && a < 1 && b > 0 && b < 1 && c > 0 && c < 1)
            {
                isWithinTriangle = true;
            }

            return isWithinTriangle;
        }

        private void IntersectionPoints_Click(object sender, RoutedEventArgs e)
        {
            double slope1 = (myLines[myLines.Count - 1].Y2 - myLines[myLines.Count - 1].Y1) / (myLines[myLines.Count - 1].X2 - myLines[myLines.Count - 1].X1);
            double slope2 = (myLines[0].Y2 - myLines[0].Y1) / (myLines[0].X2 - myLines[0].X1);

            double a1 = myLines[myLines.Count - 1].Y1 - slope1 * myLines[myLines.Count - 1].X1;
            double a2 = myLines[0].Y1 - slope2 * myLines[0].X1;

            Point p = new Point((a1 - a2) / (slope2 - slope1), a2 + slope2 * (a1 - a2) / (slope2 - slope1));

            DrawPoint(p);

            myPoints.Add(p);

            for (int i = 0; i < myLines.Count - 1; i++)
            {
                bool added = false;

                for (int j = i + 1; j < myLines.Count; j++)
                {
                    slope1 = (myLines[i].Y2 - myLines[i].Y1) / (myLines[i].X2 - myLines[i].X1);
                    slope2 = (myLines[j].Y2 - myLines[j].Y1) / (myLines[j].X2 - myLines[j].X1);

                    a1 = myLines[i].Y1 - slope1 * myLines[i].X1;
                    a2 = myLines[j].Y1 - slope2 * myLines[j].X1;

                    p = new Point((a1 - a2) / (slope2 - slope1), a2 + slope2 * (a1 - a2) / (slope2 - slope1));

                    if (p.X < myCanvas.Width && p.Y < myCanvas.Height && p.X > 0 && p.Y > 0)
                    {
                        if (added == false)
                        {
                            added = true;
                            
                            myPoints.Add(p);
                        }
                        DrawPoint(p);

                        Thread.Sleep(1000);

                        Action EmptyDelegate = delegate () { };

                        myCanvas.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    }
                }
            }

            

            Polygon myPolygon = new Polygon
            {
                Stroke = Brushes.Black,
                Fill = Brushes.LightSkyBlue,
                StrokeThickness = 1,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            myPolygon.Points = myPoints;

            myCanvas.Children.Add(myPolygon);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < myLines.Count; i++)
            {
                ListItems.Items.Add(myLines[i].X1 + " " + myLines[i].Y1 + " " + myLines[i].X2 + " " + myLines[i].Y2);
            }
            myCanvas.Children.RemoveRange(1, myCanvas.Children.Count - 1);

            ListItems.Items.Clear();

            myLines = new List<Line>();

            myPoints.Clear();
        }
    }
}
