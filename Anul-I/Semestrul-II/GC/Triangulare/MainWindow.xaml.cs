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
                new Point(myCanvas.Width, 0),
                new Point(myCanvas.Width, myCanvas.Height),
                new Point(0, myCanvas.Height)
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

                DrawPoint(p, Brushes.DarkSlateGray);
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

        private void DrawPoint(Point p, SolidColorBrush brush)
        {
            Ellipse myEllipse = new Ellipse()
            {
                Margin = new Thickness(p.X - 8, p.Y - 8, 0, 0),
                Fill = brush,
                Width = 16,
                Height = 16
            };

            myCanvas.Children.Add(myEllipse);
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

            Point point1 = new Point(), point2 = new Point(), point3 = new Point(), helper = new Point();

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

            helper.X = triangulationPoints[0].X;
            helper.Y = triangulationPoints[0].Y;

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

                    CoordsList.Items.Add(angle);

                    if (angle < 180 && angle > -180)
                    {
                        bool inside = false;

                        for (int j = i + 2; j < triangulationPoints.Count - 1; j++)
                        {
                            if (IsPointInTriangle(triangulationPoints[j], point1, point2, point3))
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

                            anglesDegrees[allPointsList.IndexOf(point1)]++;
                            anglesDegrees[allPointsList.IndexOf(point3)]++;

                            helper.X = triangulationPoints[i].X;
                            helper.Y = triangulationPoints[i].Y;

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

        private bool IsPointInTriangle(Point point, Point point1, Point point2, Point point3)
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

            if (allPointsList[0].X < allPointsList[1].X)
            {
                if (prod1 < 0 || prod2 < 0 || prod3 < 0)
                {
                    return false;
                }
            }
            else
            {
                if (prod1 > 0 || prod2 > 0 || prod3 > 0)
                {
                    return false;
                }
            }


            return true;
        }

        private double GetAngle(Point point1, Point point2, Point point3)
        {
            double result;

            //result = Math.Atan2(point1.Y - point2.Y, point1.X - point2.X) - Math.Atan2(point3.Y - point2.Y, point3.X - point2.X);

            //result *= (180 / Math.PI);

            //result = Math.PI - result;
            //return result;

            Point e1 = new Point();
            Point e2 = new Point();
            e1.X = point2.X - point1.X;
            e1.Y = point2.Y - point1.Y;

            e2.X = point2.X - point3.X;
            e2.Y = point2.Y - point3.Y;

            result = Math.Atan2(e1.X * e1.Y - e2.Y * e2.X, e1.X * e2.X + e1.Y * e2.Y) * (180 / Math.PI);

            return result;
        }

        private void Coloring_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.RemoveRange(2, allPointsList.Count);

            DrawPoint(allPointsList[0], Brushes.Red);
            DrawPoint(allPointsList[1], Brushes.LimeGreen);

            int pointBehind2 = 1, pointBehind1 = 2;

            for (int i = 1; i < allPointsList.Count - 1; i++)
            {
                if (anglesDegrees[i] % 2 != 0)
                {
                    if (pointBehind2 == 1)
                    {
                        DrawPoint(allPointsList[i + 1], Brushes.Red);

                        pointBehind2 = pointBehind1;
                        pointBehind1 = 1;
                    }
                    else if (pointBehind2 == 2)
                    {
                        DrawPoint(allPointsList[i + 1], Brushes.LimeGreen);

                        pointBehind2 = pointBehind1;
                        pointBehind1 = 2;
                    }
                    else
                    {
                        DrawPoint(allPointsList[i + 1], Brushes.Blue);

                        pointBehind2 = pointBehind1;
                        pointBehind1 = 3;
                    }
                }
                else
                {
                    if (6 - pointBehind2 - pointBehind1 == 1)
                    {
                        DrawPoint(allPointsList[i + 1], Brushes.Red);

                        pointBehind2 = pointBehind1;
                        pointBehind1 = 1;
                    }
                    else if (6 - pointBehind2 - pointBehind1 == 2)
                    {
                        DrawPoint(allPointsList[i + 1], Brushes.LimeGreen);

                        pointBehind2 = pointBehind1;
                        pointBehind1 = 2;
                    }
                    else
                    {
                        DrawPoint(allPointsList[i + 1], Brushes.Blue);

                        pointBehind2 = pointBehind1;
                        pointBehind1 = 3;
                    }
                }
                Refresh();
            }
        }

        private void Refresh()
        {
            Thread.Sleep(1000);

            Action EmptyDelegate = delegate () { };

            myCanvas.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }

        private void Area_Click(object sender, RoutedEventArgs e)
        {
            double prod1 = 0, prod2 = 0;

            for (int i = 0; i < allPointsList.Count - 1; i++)
            {
                CoordsList.Items.Add(allPointsList[i]);

                prod1 += allPointsList[i].X * allPointsList[i + 1].Y;
                prod2 += allPointsList[i].Y * allPointsList[i + 1].X;
            }

            CoordsList.Items.Add(allPointsList[allPointsList.Count - 1]);

            AreaText.Text += Math.Abs((prod1 - prod2) / 2);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.RemoveRange(1, myCanvas.Children.Count - 1);

            anglesDegrees = new List<int>();

            allPointsList = new List<Point>();

            AreaText.Text = "";

            CoordsList.Items.Clear();
        }
    }
}
