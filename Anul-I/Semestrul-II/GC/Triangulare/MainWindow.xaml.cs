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

namespace Triangulare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Point> allPointsList = new List<Point>();

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
                new Point(600, 0),
                new Point(600, 500),
                new Point(0, 500)
            };

            myPolygon.Points = points;

            myCanvas.Children.Add(myPolygon);
        }

        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                Point p = e.GetPosition(myCanvas);

                allPointsList.Add(p);

                DrawPoint(p);
            }
        }

        private void DrawPoint(Point p)
        {
            Ellipse myPoint = new Ellipse()
            {
                Margin = new Thickness(p.X - 3, p.Y - 3, 0, 0),
                Fill = Brushes.Red,
                Width = 6,
                Height = 6
            };

            myCanvas.Children.Add(myPoint);
        }

        private void DrawPolygon_Click(object sender, RoutedEventArgs e)
        {
            Polygon myPolygon = new Polygon
            {
                Stroke = Brushes.Black,
                Fill = Brushes.LightBlue,
                StrokeThickness = 1,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            PointCollection allPoints = new PointCollection();

            foreach (var item in allPointsList)
            {
                allPoints.Add(item);
            }

            myPolygon.Points = allPoints;

            myCanvas.Children.Insert(1, myPolygon);
        }

        private void Triangulate_Click(object sender, RoutedEventArgs e)
        {
            bool done = false;

            Point point1 = new Point(), point2 = new Point(), point3 = new Point();

            List<Line> myLines = new List<Line>();

            if (allPointsList.Count == 3)
            {
                done = true;
            }

            while (!done)
            {
                bool found = false;
                int i = 0;

                while (!found)
                {
                    double angle;

                    if (i > allPointsList.Count - 1)
                    {
                        done = true;

                        break;
                    }

                    if (i == 0)
                    {
                        (point1, point2, point3) = (allPointsList[allPointsList.Count - 1], allPointsList[0], allPointsList[1]);
                    }
                    else if (i == allPointsList.Count - 1)
                    {
                        (point1, point2, point3) = (allPointsList[i - 1], allPointsList[i], allPointsList[0]);
                    }
                    else
                    {
                        (point1, point2, point3) = (allPointsList[i - 1], allPointsList[i], allPointsList[i + 1]);
                    }

                    angle = GetAngle(point1, point2, point3);

                    if (angle < 180)
                    {
                        bool inside = false;
                        double area = Area(point1, point2, point3), area1, area2, area3;

                        for (int j = i + 2; j < allPointsList.Count - 1; j++)
                        {
                            if (IsPointOnTriangle(allPointsList[j], point1, point2, point3))
                            {
                                inside = true;

                                break;
                            }
                        }

                        if (inside == false)
                        {
                            for (int j = 0; j < i - 1; j++)
                            {
                                area1 = Area(allPointsList[j], point2, point3);
                                area2 = Area(point1, allPointsList[j], point3);
                                area3 = Area(point1, point2, allPointsList[j]);

                                if (area1 + area2 + area3 == area)
                                {
                                    inside = true;

                                    break;
                                }
                            }
                        }

                        if (inside == false)
                        {
                            found = true;

                            myLines.Add(new Line());
                            myLines[myLines.Count - 1].Stroke = Brushes.Green;
                            myLines[myLines.Count - 1].StrokeThickness = 2;
                            myLines[myLines.Count - 1].X1 = point1.X;
                            myLines[myLines.Count - 1].Y1 = point1.Y;
                            myLines[myLines.Count - 1].X2 = point3.X;
                            myLines[myLines.Count - 1].Y2 = point3.Y;

                            allPointsList.RemoveAt(i);

                            myCanvas.Children.Add(myLines[myLines.Count - 1]);
                        }
                        else
                        {
                            i++;
                        }
                    }
                    else
                    {
                        i++;
                    }
                }

                if (allPointsList.Count == 3)
                {
                    done = true;
                }
            }
        }

        private bool IsPointOnTriangle(Point point, Point point1, Point point2, Point point3)
        {
            Point p12 = new Point()
            {
                X = point2.X - point1.X,
                Y = point2.Y - point1.Y
            };
            Point p23 = new Point()
            {
                X = point3.X - point2.X,
                Y = point3.Y - point2.Y
            };
            Point p31 = new Point()
            {
                X = point1.X - point3.X,
                Y = point1.Y - point3.Y
            };

            Point pp1 = new Point()
            {
                X = point.X - point1.X,
                Y = point.Y - point1.Y
            };
            Point pp2 = new Point()
            {
                X = point.X - point2.X,
                Y = point.Y - point2.Y
            };
            Point pp3 = new Point()
            {
                X = point.X - point3.X,
                Y = point.Y - point3.Y
            };

            double prod1 = p12.X * pp1.Y - p12.Y * pp1.X;
            double prod2 = p23.X * pp2.Y - p23.Y * pp2.X;
            double prod3 = p31.X * pp3.Y - p31.Y * pp3.X;

            if (prod1 > 0 || prod2 > 0 || prod3 > 0)
            {
                return false;
            }

            return true;
        }

        private double Area(Point point1, Point point2, Point point3)
        {
            return Math.Abs((point1.X * (point2.Y - point3.Y) + point2.X * (point3.Y - point1.Y) + point3.X * (point1.Y - point2.Y)) / 2.0);
        }

        private double GetAngle(Point point1, Point point2, Point point3)
        {
            Point a = new Point()
            {
                X = point1.X - point2.X,
                Y = point1.Y - point2.Y
            };

            Point b = new Point()
            {
                X = point3.X - point2.X,
                Y = point3.Y - point2.Y
            };

            double aLen = Math.Sqrt(a.X * a.X + a.Y * a.Y), bLen = Math.Sqrt(b.X * b.X + b.Y * b.Y);
            double prod = a.X * b.X + a.Y * b.Y;

            if (prod > 0)
            {
                return (180 / Math.PI) * Math.Acos(prod / (aLen * bLen));
            }
            else
            {
                return 360 - (180 / Math.PI) * Math.Acos(prod / (aLen * bLen));
            }        
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.RemoveRange(1, myCanvas.Children.Count - 1);

            allPointsList = new List<Point>();
        }
    }
}
