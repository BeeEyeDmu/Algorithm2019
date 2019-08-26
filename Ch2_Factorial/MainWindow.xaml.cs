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
using System.Diagnostics;

namespace Ch2_Factorial
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

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      long f = long.Parse(txtNumber.Text);

      var watch = System.Diagnostics.Stopwatch.StartNew();
      lstResult.Items.Add(Factoral(f));
      watch.Stop();
      var elapsedMs = watch.ElapsedMilliseconds;
      lstResult.Items.Add(elapsedMs);
      //lstResult.Items.Add($"실행시간은 {elapsedMs}ms");

      
      watch = System.Diagnostics.Stopwatch.StartNew();
      lstResult.Items.Add(RecFact(f));
      watch.Stop();
      elapsedMs = watch.ElapsedMilliseconds;
      lstResult.Items.Add(elapsedMs);
      //lstResult.Items.Add($"실행시간은 {elapsedMs}ms");

      
    }

    private long RecFact(long f)
    {
      if (f == 1)
        return 1;
      else
        return RecFact(f - 1) * f;
    }

    private long Factoral(long f)
    {
      long fact = 1;
      for (int i = 1; i <= f; i++)
        fact *= i;
      return fact;
    }
  }
}
