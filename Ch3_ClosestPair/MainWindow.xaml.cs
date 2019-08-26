using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Ch3_ClosestPair
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    Point[] points = new Point[P];
    const int P = 10;

    public MainWindow()
    {
      InitializeComponent();
      //Console.WriteLine(canvas1.Width + ", " + canvas1.Height);

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
      BruteForce();
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
