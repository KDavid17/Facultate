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
        }

        private void RandomPoints_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            for (int i = 0; i < int.Parse(NumberOfRandomPoints.Text); i++)
            {
                Point p = new Point(rnd.Next(1, (int)(myCanvas.Width)), rnd.Next(1, (int)(myCanvas.Height)));

                Color color = Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));

                DrawPoint(p, 4, color);

                myPointsColor.Add(color);

                myPoints.Add(p);
            }

            Bar.Maximum = myCanvas.Height;
        }

        private void EuclideanVoronoi_Click(object sender, RoutedEventArgs e)
        {
            Point helper = new Point();

            for (int i = 1; i < myCanvas.Height; i++)
            {
                for (int j = 1; j < myCanvas.Width; j++)
                {
                    double distanceMin = myCanvas.Width * myCanvas.Height, distance;
                    int pos = 0;

                    for (int k = 0; k < myPoints.Count; k++)
                    {
                        if ((distance = Math.Sqrt((j - myPoints[k].X) * (j - myPoints[k].X) + (i - myPoints[k].Y) * (i - myPoints[k].Y))) < distanceMin)
                        {
                            distanceMin = distance;

                            pos = k;
                        }
                    }

                    if (i == p1.Y && j == p1.X)
                    {
                        p2 = myPoints[pos];

                        Distance.Text = distanceMin.ToString();
                    }

                    //DrawPoint(new Point(j, i), 1, myPointsColor[pos]);

                    positions.Add(pos);

                    if (positions.Count > myCanvas.Width && (positions[positions.Count - 2] != pos || positions[positions.Count - 1 - (int)myCanvas.Width] != pos))
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
