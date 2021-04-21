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

        List<Polygon> triangles = new List<Polygon>();
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

            Point point1, point2, point3;

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

                    if (!IsTriangleOrientedClockwise(point1, point2, point3))
                    {
                        bool inside = false;

                        for (int j = i + 2; j < triangulationPoints.Count - 1; j++)
                        {
                            if (IsPointInTriangle(point1, point2, point3, triangulationPoints[j]))
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

                            triangulationPoints.RemoveAt(i);

                            PointCollection trianglePoints = new PointCollection
                            {
                                point1,
                                point2,
                                point3
                            };

                            triangles.Add(new Polygon());
                            triangles[triangles.Count - 1].Points = trianglePoints;

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
                    PointCollection trianglePoints = new PointCollection
                            {
                                new Point(triangulationPoints[0].X, triangulationPoints[0].Y),
                                new Point(triangulationPoints[1].X, triangulationPoints[1].Y),
                                new Point(triangulationPoints[2].X, triangulationPoints[2].Y),
                            };

                    triangles.Add(new Polygon());
                    triangles[triangles.Count - 1].Points = trianglePoints;

                    done = true;
                }
            }
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

        public bool IsTriangleOrientedClockwise(Point p1, Point p2, Point p3)
        {
            bool isClockWise = true;

            double determinant = p1.X * p2.Y + p3.X * p1.Y + p2.X * p3.Y - p1.X * p3.Y - p3.X * p2.Y - p2.X * p1.Y;

            if (determinant > 0)
            {
                isClockWise = false;
            }

            return isClockWise;
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

        private void DualTree_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < triangles.Count - 1; i++)
            {
                for (int j = i + 1; j < triangles.Count; j++)
                {
                    int s = 0;
                    
                    for (int k = 0; k < 3; k++)
                    {
                        for (int z = 0; z < 3; z++)
                        {
                            if (triangles[i].Points[k] == triangles[j].Points[z])
                            {
                                s++;
                            }
                        }
                    }

                    if (s == 2)
                    {
                        Point p1 = new Point((triangles[i].Points[0].X + triangles[i].Points[1].X + triangles[i].Points[2].X) / 3,
                                        (triangles[i].Points[0].Y + triangles[i].Points[1].Y + triangles[i].Points[2].Y) / 3);
                        DrawPoint(p1, Brushes.Purple);

                        Refresh();

                        Point p2 = new Point((triangles[j].Points[0].X + triangles[j].Points[1].X + triangles[j].Points[2].X) / 3,
                                        (triangles[j].Points[0].Y + triangles[j].Points[1].Y + triangles[j].Points[2].Y) / 3);
                        DrawPoint(p2, Brushes.Purple);

                        Refresh();

                        Line tempLine = new Line()
                        {
                            Stroke = Brushes.Purple,
                            StrokeThickness = 2,
                            X1 = p1.X,
                            Y1 = p1.Y,
                            X2 = p2.X,
                            Y2 = p2.Y
                        };

                        myCanvas.Children.Add(tempLine);
                    }
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.RemoveRange(1, myCanvas.Children.Count - 1);

            anglesDegrees = new List<int>();

            allPointsList = new List<Point>();

            triangles = new List<Polygon>();

            AreaText.Text = "";

            CoordsList.Items.Clear();
        }
    }
}
