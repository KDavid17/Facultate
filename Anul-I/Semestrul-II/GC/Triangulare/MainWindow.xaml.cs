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

namespace Triangulare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Polygon removePolygon = new Polygon();

        List<Point> allPointsList = new List<Point>();
        List<int> anglesDegrees = new List<int>();

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

        private void Canvas_LeftMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                Point p = e.GetPosition(myCanvas);

                allPointsList.Add(p);

                DrawPoint(p, Brushes.DarkSlateGray, allPointsList.Count);
            }
        }

        private void Canvas_RightMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                Point p = e.GetPosition(myCanvas);

                removePolygon.Points.Remove(p);
            }
        }

        private void DrawPoint(Point p, SolidColorBrush brush, int pos)
        {
            Ellipse myEllipse = new Ellipse()
            {
                Margin = new Thickness(p.X - 4, p.Y - 4, 0, 0),
                Fill = brush,
                Width = 8,
                Height = 8
            };

            myCanvas.Children.Insert(pos, myEllipse);
        }

        private void DrawPolygon_Click(object sender, RoutedEventArgs e)
        {
            Polygon myPolygon = new Polygon
            {
                Stroke = Brushes.Black,
                Fill = Brushes.SandyBrown,
                StrokeThickness = 2,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            PointCollection allPoints = new PointCollection();

            foreach (var item in allPointsList)
            {
                allPoints.Add(item);
            }

            removePolygon.Points = allPoints;

            myPolygon.Points = allPoints;

            myCanvas.Children.Insert(1, myPolygon);
        }

        private void Triangulate_Click(object sender, RoutedEventArgs e)
        {
            bool done = false;

            Point point1 = new Point(), point2 = new Point(), point3 = new Point();

            List<Line> myLines = new List<Line>();
            List<Point> triangulationPoints = allPointsList.ToList();

            foreach (var item in allPointsList)
            {
                anglesDegrees.Add(2);
            }

            if (triangulationPoints.Count == 3)
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

                    if (i > triangulationPoints.Count - 1)
                    {
                        done = true;

                        break;
                    }

                    if (i == 0)
                    {
                        (point1, point2, point3) = (triangulationPoints[triangulationPoints.Count - 1], triangulationPoints[0], triangulationPoints[1]);
                    }
                    else if (i == triangulationPoints.Count - 1)
                    {
                        (point1, point2, point3) = (triangulationPoints[i - 1], triangulationPoints[i], triangulationPoints[0]);
                    }
                    else
                    {
                        (point1, point2, point3) = (triangulationPoints[i - 1], triangulationPoints[i], triangulationPoints[i + 1]);
                    }

                    angle = GetAngle(point1, point2, point3);

                    if (angle < 180)
                    {
                        bool inside = false;

                        for (int j = i + 2; j < triangulationPoints.Count - 1; j++)
                        {
                            if (IsPointOnTriangle(triangulationPoints[j], point1, point2, point3))
                            {
                                inside = true;

                                break;
                            }
                        }

                        if (inside == false)
                        {
                            found = true;

                            myLines.Add(new Line());
                            myLines[myLines.Count - 1].Stroke = Brushes.LightSkyBlue;
                            myLines[myLines.Count - 1].StrokeThickness = 2;
                            myLines[myLines.Count - 1].X1 = point1.X;
                            myLines[myLines.Count - 1].Y1 = point1.Y;
                            myLines[myLines.Count - 1].X2 = point3.X;
                            myLines[myLines.Count - 1].Y2 = point3.Y;

                            if (i == 0)
                            {
                                anglesDegrees[triangulationPoints.Count - 1 + allPointsList.Count - triangulationPoints.Count]++;
                                anglesDegrees[allPointsList.Count - triangulationPoints.Count + 1]++;
                            }
                            else if (i == anglesDegrees.Count - 1)
                            {
                                anglesDegrees[triangulationPoints.Count - 2]++;
                                anglesDegrees[allPointsList.Count - triangulationPoints.Count - 1]++;
                            }
                            else
                            {
                                anglesDegrees[allPointsList.Count - triangulationPoints.Count - 1]++;
                                anglesDegrees[allPointsList.Count - triangulationPoints.Count + 1]++;
                            }
                            foreach (var item in anglesDegrees)
                            {
                                Test.Text += item + "$$$";
                            }

                            triangulationPoints.RemoveAt(i);

                            myCanvas.Children.Add(myLines[myLines.Count - 1]);

                            Refresh();

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

                if (triangulationPoints.Count == 3)
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

            if (prod1 < 0 || prod2 < 0 || prod3 < 0)
            {
                return false;
            }

            return true;
        }

        private double GetAngle(Point point1, Point point2, Point point3)
        {
            double result = Math.Atan2(point1.Y - point2.Y, point1.X - point2.X) - Math.Atan2(point3.Y - point2.Y, point3.X - point2.X);

            result *= (180 / Math.PI);

            if (result > 0)
            {
                return result;
            }
            else
            {
                return 360 - Math.Abs(result);
            }
        }

        private void Refresh()
        {
            Thread.Sleep(1000);

            Action EmptyDelegate = delegate () { };

            myCanvas.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }

        private void Coloring_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.RemoveRange(2, allPointsList.Count);

            DrawPoint(allPointsList[0], Brushes.Red, 2);
            DrawPoint(allPointsList[1], Brushes.LimeGreen, 3);

            int helper1 = 1, helper2 = 2;

            for (int i = 3; i < allPointsList.Count - 1; i++)
            {
                Test.Text += anglesDegrees[i - 2] + "###";
                if (anglesDegrees[i - 2] % 2 == 0)
                {
                    if (helper1 == 1)
                    {
                        DrawPoint(allPointsList[i - 1], Brushes.Red, i + 1);

                        helper1 = helper2;
                        helper2 = 1;
                    }
                    else if (helper1 == 2)
                    {
                        DrawPoint(allPointsList[i - 1], Brushes.LimeGreen, i + 1);

                        helper1 = helper2;
                        helper2 = 2;
                    }
                    else
                    {
                        DrawPoint(allPointsList[i - 1], Brushes.Blue, i + 1);

                        helper1 = helper2;
                        helper2 = 3;
                    }
                }
                else
                {
                    if (6 - helper1 - helper2 == 1)
                    {
                        DrawPoint(allPointsList[i - 1], Brushes.Red, i + 1);

                        helper1 = helper2;
                        helper2 = 1;
                    }
                    else if (6 - helper1 - helper2 == 2)
                    {
                        DrawPoint(allPointsList[i - 1], Brushes.LimeGreen, i + 1);

                        helper1 = helper2;
                        helper2 = 2;
                    }
                    else
                    {
                        DrawPoint(allPointsList[i - 1], Brushes.Blue, i + 1);

                        helper1 = helper2;
                        helper2 = 3;
                    }
                }
                Refresh();
            }

            //if (helper2 == 1)
            //{
            //    DrawPoint(allPointsList[allPointsList.Count - 2], Brushes.Red, allPointsList.Count);
            //}
            //else if (helper2 == 2)
            //{
            //    DrawPoint(allPointsList[allPointsList.Count - 2], Brushes.Red, allPointsList.Count);
            //}
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.RemoveRange(1, myCanvas.Children.Count - 1);

            allPointsList = new List<Point>();
        }


    }
}
