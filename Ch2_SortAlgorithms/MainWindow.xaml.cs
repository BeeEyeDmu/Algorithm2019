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

namespace Ch2_SortAlgorithms
{
    /// <summary>
    /// 10만개의 정렬: 65초와 31ms 2천배
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] a = new int[1000000]; // 1억개

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnRandom_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < int.Parse(txtNo.Text); i++)
                a[i] = r.Next();

            tbQuad.Text = "";
            tbLog.Text = "";
            //PrintArray(a);
        }

        // N*N 정렬알고리즘(버블정렬)
        private void BtnQuad_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = int.Parse(txtNo.Text) - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int t = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = t;
                    }
                }
            }
            watch.Stop();
            tbQuad.Text = watch.ElapsedMilliseconds + "ms";
            PrintArray(a);
        }

        // NlnN 알고리즘(퀵정렬)
        private static void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right])
                        return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        private void PrintArray(int[] a)
        {
            for (int i = 0; i < int.Parse(txtNo.Text); i++)
                Console.WriteLine(a[i]);
        }

        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Quick_Sort(a, 0, int.Parse(txtNo.Text) - 1);

            watch.Stop();
            tbLog.Text = watch.ElapsedMilliseconds + "ms";
            PrintArray(a);
        }
    }
}
