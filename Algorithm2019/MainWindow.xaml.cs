using System;
using System.Windows;

namespace Algorithm2019
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void BtnCalc_Click(object sender, RoutedEventArgs e)
    {
      tbResult.Text = "GCD = " + Euclid(Int32.Parse(txtNo1.Text), Int32.Parse(txtNo2.Text)).ToString();
    }

    private int Euclid(int a, int b)
    {
      Console.WriteLine("Euclid({0}, {1})", a, b);
      if (b == 0)
        return a;
      else
        return Euclid(b, a % b); 
    }
  }
}
