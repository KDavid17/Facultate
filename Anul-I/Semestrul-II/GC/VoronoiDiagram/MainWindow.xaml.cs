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

namespace VoronoiDiagram
{
    public partial class MainWindow : Window
    {
        List<Polygon> myTriangles = new List<Polygon>();
        List<Color> myPointsColor = new List<Color>();
        List<Point> myPoints = new List<Point>();
        List<int> positions = new List<int>();
        Point p1 = new Point();
        Point p2 = new Point();

        public MainWindow()
        {
            InitializeComponent();

            Polygon myPolygon = new Polygon
            {
                Stroke = Brushes.Black,
                Fill = Brushes.White,
                StrokeThickness = 2,
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
            myCanvas.RenderTransform = new ScaleTransform(1, -1, 0, myCanvas.Height / 2);
        }

        private void RandomPoints_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            double rn1, rn2;

            for (int i = 0; i < int.Parse(NumberOfRandomPoints.Text); i++)
            {
                rn1 = rnd.Next(1, (int)(myCanvas.Width));
                rn2 = rnd.Next(1, (int)(myCanvas.Height));

                rn1 = Math.Floor(rn1);
                rn2 = Math.Floor(rn2);

                Point d = new Point(rn1, rn2);

                Color color = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));

                DrawPoint(d, 4, color);

                myPointsColor.Add(color);

                myPoints.Add(d);
            }

            Bar.Maximum = myCanvas.Height;
        }

        private void DelaunayTriangulation_Click(object sender, RoutedEventArgs e)
        {

            myPoints = myPoints.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();

            PointCollection myCol = new PointCollection
            {
                myPoints[0],
                myPoints[1],
                myPoints[2]
            };

            Polygon triangle = new Polygon
            {
                Stroke = Brushes.Magenta,
                StrokeThickness = 2
            };

            foreach (Point p in myCol)
            {
                triangle.Points.Add(p);
            }

            myTriangles.Add(triangle);

            myCol.Clear();

            for (int i = 3; i < myPoints.Count; i++)
            {
                int counter = myTriangles.Count;

                for (int j = 0; j < counter; j++)
                {
                    Polygon item = myTriangles[j];

                    bool isClockwise = IsTriangleOrientedClockwise(item.Points[0], item.Points[1], item.Points[2]);
                    Distance.Text = isClockwise.ToString();
                    if (IsInsideCircumcircle(item.Points[0], item.Points[1], item.Points[2], myPoints[i], isClockwise))
                    {
                        Distance.Text += "-0";
                        BoxX.Text = "%";
                        if (!IsInsideCircumcircle(item.Points[0], item.Points[1], myPoints[i], item.Points[2], isClockwise))
                        {
                            myTriangles.Remove(item);
                            Distance.Text += "1";

                            myCol.Add(item.Points[0]);
                            myCol.Add(item.Points[1]);
                            myCol.Add(myPoints[i]);

                            triangle = new Polygon
                            {
                                Stroke = Brushes.Magenta,
                                StrokeThickness = 2
                            };

                            foreach (Point p in myCol)
                            {
                                triangle.Points.Add(p);
                            }

                            myCol.Clear();

                            myTriangles.Add(triangle);

                            if (item.Points[1].Y > item.Points[0].Y && item.Points[2].Y < item.Points[0].Y ||
                                item.Points[1].Y < item.Points[0].Y && item.Points[2].Y > item.Points[0].Y)
                            {
                                myCol.Add(item.Points[0]);
                                myCol.Add(item.Points[2]);
                                myCol.Add(myPoints[i]);
                            }
                            else
                            {
                                myCol.Add(item.Points[1]);
                                myCol.Add(item.Points[2]);
                                myCol.Add(myPoints[i]);
                            }
                            triangle = new Polygon
                            {
                                Stroke = Brushes.Magenta,
                                StrokeThickness = 2
                            };

                            foreach (Point p in myCol)
                            {
                                triangle.Points.Add(p);
                            }

                            myCol.Clear();

                            myTriangles.Add(triangle);
                        }
                    }
                    else
                    {
                        double ramp1, ramp2, d1;

                        Point p1 = item.Points[0];

                        if (isClockwise == true)
                        {
                            ramp1 = (item.Points[1].Y - item.Points[0].Y) / (item.Points[1].X - item.Points[0].X);
                            ramp2 = (item.Points[2].Y - item.Points[0].Y) / (item.Points[2].X - item.Points[0].X);
                        }
                        else
                        {
                            ramp1 = (item.Points[2].Y - item.Points[0].Y) / (item.Points[2].X - item.Points[0].X);
                            ramp2 = (item.Points[1].Y - item.Points[0].Y) / (item.Points[1].X - item.Points[0].X);
                        }

                        if (((d1 = ramp1 * (myPoints[i].X - item.Points[0].X) + item.Points[0].Y) > myPoints[i].Y &&
                                (ramp2 * (myPoints[i].X - item.Points[0].X) + item.Points[0].Y) > myPoints[i].Y) ||
                                (ramp1 * (myPoints[i].X - item.Points[0].X) + item.Points[0].Y) < myPoints[i].Y &&
                                (ramp2 * (myPoints[i].X - item.Points[0].X) + item.Points[0].Y) < myPoints[i].Y)
                        {
                            Distance.Text += " -2";

                            if (d1 < myPoints[i].Y)
                            {
                                Distance.Text += "3";
                                myCol.Add(item.Points[0]);
                                myCol.Add(item.Points[1]);
                                myCol.Add(myPoints[i]);
                            }
                            else
                            {
                                Distance.Text += "4";
                                myCol.Add(item.Points[0]);
                                myCol.Add(item.Points[2]);
                                myCol.Add(myPoints[i]);
                            }

                            triangle = new Polygon
                            {
                                Stroke = Brushes.Magenta,
                                StrokeThickness = 2
                            };

                            foreach (Point p in myCol)
                            {
                                triangle.Points.Add(p);
                            }

                            myCol.Clear();

                            myTriangles.Add(triangle);
                        }

                            myCol.Add(item.Points[1]);
                            myCol.Add(item.Points[2]);
                            myCol.Add(myPoints[i]);

                            triangle = new Polygon
                            {
                                Stroke = Brushes.Magenta,
                                StrokeThickness = 2
                            };
                            foreach (Point p in myCol)
                            {
                                triangle.Points.Add(p);
                            }

                            myCol.Clear();

                            myTriangles.Add(triangle);
                    }
                }
            }

            foreach (Polygon item in myTriangles)
            {
                if (myCanvas.Children.Contains(item) == false)
                {
                    myCanvas.Children.Add(item);
                }
            }
        }

        private bool IsTriangleOrientedClockwise(Point p1, Point p2, Point p3)
        {
            bool isClockWise = false;

            double determinant = (p2.X - p1.X) * (p2.Y + p1.Y) + (p3.X - p2.X) * (p3.Y + p2.Y) + (p1.X - p3.X) * (p1.Y + p3.Y);

            if (determinant > 0)
            {
                isClockWise = true;
            }

            return isClockWise;
        }

        private bool IsInsideCircumcircle(Point p1, Point p2, Point p3, Point p4, bool isOrientedClockwise)
        {
            bool isInside = false;

            if (isOrientedClockwise == true)
            {
                Point helper = new Point();
                helper.X = p2.X;
                helper.Y = p2.Y;
                p2.X = p3.X;
                p2.Y = p3.Y;
                p3.X = helper.X;
                p3.Y = helper.Y;
                Distance.Text += "#";
            }

            double determinant = ((p1.X - p4.X) * (p2.Y - p4.Y) - (p2.X - p4.X) * (p1.Y - p4.Y)) * ((p3.X - p4.X) * (p3.X - p4.X) + (p3.Y - p4.Y) * (p3.Y - p4.Y))
                               + ((p2.X - p4.X) * (p3.Y - p4.Y) - (p3.X - p4.X) * (p2.Y - p4.Y)) * ((p1.X - p4.X) * (p1.X - p4.X) + (p1.Y - p4.Y) * (p1.Y - p4.Y))
                               + ((p3.X - p4.X) * (p1.Y - p4.Y) - (p1.X - p4.X) * (p3.Y - p4.Y)) * ((p2.X - p4.X) * (p2.X - p4.X) + (p2.Y - p4.Y) * (p2.Y - p4.Y));

            if (determinant > 0)
            {
                isInside = true;
            }
            BoxX.Text = determinant.ToString();
            return isInside;
        }

        private void EuclideanVoronoi_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < myCanvas.Height; i++)
            {
                for (int j = 1; j < myCanvas.Width; j++)
                {
                    double distanceMin = myCanvas.Width * myCanvas.Height, distance;
                    int pos1 = 0;

                    for (int k = 0; k < myPoints.Count; k++)
                    {
                        distance = Math.Sqrt((j - myPoints[k].X) * (j - myPoints[k].X) + (i - myPoints[k].Y) * (i - myPoints[k].Y));


                        if (distance <= distanceMin)
                        {
                            distanceMin = distance;

                            pos1 = k;
                        }
                    }

                    if (i == p1.Y && j == p1.X)
                    {
                        p2 = myPoints[pos1];

                        Distance.Text = distanceMin.ToString();
                    }

                    //DrawPoint(new Point(j, i), 1, myPointsColor[pos]);

                    positions.Add(pos1);

                    if (positions.Count > myCanvas.Width && (positions[positions.Count - 2] != pos1 || positions[positions.Count - 1 - (int)myCanvas.Width] != pos1))
                    {
                        DrawPoint(new Point(j, i), 1, Colors.Black);
                    }
                }

                if (i % 5 == 0)
                {
                    Bar.Dispatcher.Invoke(() => Bar.Value = i, DispatcherPriority.Background);
                }
            }

            Bar.Dispatcher.Invoke(() => Bar.Value = myCanvas.Height, DispatcherPriority.Background);

            myPoints = myPoints.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
        }

        private void ManhattanVoronoi_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < myCanvas.Height; i++)
            {
                for (int j = 1; j < myCanvas.Width; j++)
                {
                    double distanceMin = myCanvas.Width * myCanvas.Height, distance;
                    int pos = 0;

                    for (int k = 0; k < myPoints.Count; k++)
                    {
                        if ((distance = Math.Abs(j - myPoints[k].X) + Math.Abs(i - myPoints[k].Y)) < distanceMin)
                        {
                            distanceMin = distance;

                            pos = k;
                        }
                    }

                    DrawPoint(new Point(j, i), 1, myPointsColor[pos]);
                }

                if (i % 5 == 0)
                {
                    Bar.Dispatcher.Invoke(() => Bar.Value = i, DispatcherPriority.Background);
                }
            }

            Bar.Dispatcher.Invoke(() => Bar.Value = myCanvas.Height, DispatcherPriority.Background);
        }

        private void ChebyshevVoronoi_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < myCanvas.Height; i++)
            {
                for (int j = 1; j < myCanvas.Width; j++)
                {
                    double distanceMin = myCanvas.Width * myCanvas.Height, distance;
                    int pos = 0;

                    for (int k = 0; k < myPoints.Count; k++)
                    {
                        if ((distance = Math.Max(Math.Abs(j - myPoints[k].X), Math.Abs(i - myPoints[k].Y))) < distanceMin)
                        {
                            distanceMin = distance;

                            pos = k;
                        }
                    }

                    DrawPoint(new Point(j, i), 1, myPointsColor[pos]);
                }

                if (i % 5 == 0)
                {
                    Bar.Dispatcher.Invoke(() => Bar.Value = i, DispatcherPriority.Background);
                }
            }

            Bar.Dispatcher.Invoke(() => Bar.Value = myCanvas.Height, DispatcherPriority.Background);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.RemoveRange(1, myCanvas.Children.Count - 1);

            myPointsColor = new List<Color>();

            myPoints = new List<Point>();
        }

        private void DrawPoint(Point p, int size, Color color)
        {
            Ellipse myEllipse = new Ellipse()
            {
                Margin = new Thickness(p.X - size, p.Y - size, 0, 0),
                Width = 2 * size,
                Height = 2 * size,
                Fill = new SolidColorBrush(color)
            };

            myCanvas.Children.Add(myEllipse);
        }

        private void Refresh()
        {
            Thread.Sleep(1000);

            Action EmptyDelegate = delegate () { };

            myCanvas.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }

        private void AddPoint_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            Point p = new Point(double.Parse(BoxX.Text), double.Parse(BoxY.Text));

            p1 = p;

            Color color = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));

            DrawPoint(p, 4, color);
        }

        private void FindDistance_Click(object sender, RoutedEventArgs e)
        {
            Line myLine = new Line()
            {
                X1 = p1.X,
                Y1 = p1.Y,
                X2 = p2.X,
                Y2 = p2.Y,
                StrokeThickness = 2,
                Stroke = Brushes.Red,
                Fill = Brushes.Red
            };
            NumberOfRandomPoints.Text = $"{myLine.X1} + {myLine.X2} + {myLine.Y1} + {myLine.Y2}";
            myCanvas.Children.Add(myLine);
        }
    }
}
