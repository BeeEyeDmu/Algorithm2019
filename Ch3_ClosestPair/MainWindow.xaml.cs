using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Ch3_ClosestPair
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public class XComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (int)(((Point)x).X - ((Point)y).X);
        }
    }

    public class YComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (int)(((Point)x).Y - ((Point)y).Y);
        }
    }

    public partial class MainWindow : Window
    {
        Point[] points = new Point[P];
        const int P = 100;

        public MainWindow()
        {
            InitializeComponent();

            // Test Array.Sort() with IComparer

            //MakePointArray();

            //IComparer xComp = new XComparer();
            //Array.Sort(points, xComp);
            
            //PrintArray();

            //IComparer yComp = new YComparer();
            //Array.Sort(points, yComp);

            //PrintArray();
        }

        private void PrintArray()
        {
            foreach(var p in points)
                Console.WriteLine(p.X + ", " + p.Y);
        }

        private void MakePointArray()
        {
            Random r = new Random();

            //foreach(var p in points)
            for (int i = 0; i < P; i++)
            {
                points[i].X = r.Next(400);
                points[i].Y = r.Next(400);
            }

            foreach (var p in points)
            {
                Rectangle rect = new Rectangle();
                rect.Width = 3;
                rect.Height = 3;
                rect.Stroke = Brushes.Black;
                Canvas.SetLeft(rect, p.X - 1);
                Canvas.SetTop(rect, p.Y - 1);
                canvas1.Children.Add(rect);
            }
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            MakePointArray();
        }

        Point p1, p2;
        int minI, minJ;

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            // Brute Force
            // BruteForce();

            // Divide and Conquer
            ClosestPair(points, 0, P-1);    // points[] 배열의 인덱스
        }

        private double ClosestPair(Point[] points, int left, int right)
        {
            int mid = (right - left + 1) / 2;
            Point midP = points[mid];

            double dl = ClosestPair(points, 0, mid);
            double dr = ClosestPair(points, mid+1, right);

            double d = Math.Min(dl, dr);

            Point[] strip = new Point[P];
            int stripIndex = 0;
            for(int i=left; i<right; i++)
            {
                if(Math.Abs(points[i].X - midP.X)  < d)
                {
                    strip[stripIndex++] = points[i];
                }
            }
            return Math.Min(d, StripClosest(strip, --stripIndex, d));
        }

        private double StripClosest(Point[] strip, int size, double min)
        {
            Array.Sort(strip, new YComparer());
            for (int i = 0; i < size; i++)
                for (int j = i + 1; j < size && strip[j].Y - strip[i].Y < min; j++)
                    if (StripDist(strip, i, i) < min)
                        min = StripDist(strip, i, i);
            return min;
        }

        private double StripDist(Point[] strip, int i, int j)
        {
            return Math.Sqrt((strip[i].X - strip[j].X) * (strip[i].X - strip[j].X) +
              (strip[i].Y - strip[j].Y) * (strip[i].Y - strip[j].Y));
        }

        private void BruteForce()
        {
            double min = double.MaxValue;
            for (int i = 0; i < P; i++)
            {
                for (int j = i + 1; j < P; j++)
                {
                    double d = Dist(i, j);
                    if (d < min)
                    {
                        min = d;
                        p1 = points[i];
                        p2 = points[j];
                        minI = i;
                        minJ = j;
                    }
                }
            }
            HighLight(p1, p2);
        }

        private void HighLight(Point p1, Point p2)
        {
            Line line = new Line();
            line.X1 = p1.X;
            line.Y1 = p1.Y;
            line.X2 = p2.X;
            line.Y2 = p2.Y;
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 2;
            canvas1.Children.Add(line);
            MessageBox.Show(String.Format("({0},{1})-({2},{3})", line.X1, line.Y1, line.X2, line.Y2));
        }

        private double Dist(int i, int j)
        {
            return Math.Sqrt((points[i].X - points[j].X) * (points[i].X - points[j].X) +
              (points[i].Y - points[j].Y) * (points[i].Y - points[j].Y));
        }
    }
}
