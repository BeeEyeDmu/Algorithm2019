using System;
using System.Windows;

namespace QuickSort
{
    public partial class MainWindow : Window
    {
        const int SIZE = 100000;
        const int MAX = 1000000;

        // 교과서 데이터
        // (1) int[] a = { 8, 3, 11, 9, 12, 2, 6, 15, 18, 10, 7, 14 };
        // (2) int[] a = { 247, 247, 247, 251, 253 }; 
        // (3) 0~9999 랜덤 숫자 3천개
        int[] a = new int[MAX];
        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
            MakeRandomArray();
            PrintArray();
        }

        private void PrintArray()
        {
            lbl.Text += "\n";
            for (int i = 0; i < 10; i++)
                lbl.Text += a[i].ToString() + " ";
            lbl.Text += "\n... ";
            for (int i = SIZE - 10; i < SIZE; i++)
                lbl.Text += a[i].ToString() + " ";
            //for (int i = 0; i < SIZE; i++)
            //    Console.Write("{0} ", a[i]);
            //Console.WriteLine();
        }

        private void MakeRandomArray()
        {
            for (int i = 0; i < SIZE; i++)
                a[i] = r.Next(MAX);
        }

        int partitionSize;
        private void Qsort_Click(object sender, RoutedEventArgs e)
        {
            // n2 알고리즘
            //partitionSize = 1000000;
            //MakeRandomArray();
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            //QuickSort(a, 0, SIZE - 1);
            //watch.Stop();
            //lbl.Text += "\n" + partitionSize + ": " + watch.ElapsedMilliseconds + "ms";

            // QuickSort의 partitionSize
            for (partitionSize = 0; partitionSize <= 200; partitionSize += 10)
            {
                MakeRandomArray();
                var watch = System.Diagnostics.Stopwatch.StartNew();
                QuickSort(a, 0, SIZE - 1);
                watch.Stop();
                lbl.Text += "\n"+partitionSize + ": " + watch.ElapsedMilliseconds + "ms";
                //PrintArray();
            }


            PrintArray();
        }

        // left와 right는 index임
        private void QuickSort(int[] a, int left, int right)
        {
            //Console.WriteLine("QuickSort({0}, {1})", left, right);
            //PrSortArray(left, right);
            //lbl.Text += string.Format("\nQuickSort({0}, {1})\n", left, right);
            
            if (left < right)
            {
                if (right - left <= partitionSize)   // N개 미만은 간단한 알고리즘으로 
                    simpleSort(a, left, right);
                else
                {
                    int p = Partition(a, left, right);

                    QuickSort(a, left, p - 1);
                    QuickSort(a, p + 1, right);
                }                
            }
        }

        private void simpleSort(int[] a, int left, int right)
        {
            for (int i = left; i < right; i++)
                for (int j = i + 1; j <= right; j++)
                    if (a[i] > a[j])
                    {
                        int t = a[i];
                        a[i] = a[j];
                        a[j] = t;
                    }
        }

        private void PrSortArray(int left, int right)
        {
            for (int i = left; i <= right; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
        }

        private int Partition(int[] a, int left, int right)
        {
            // 피봇을 a[left]와 a[rihgt] 중에서 선택하고, 피봇을 a[left]와 자리를 바꾼 후
            // 여기서는 맨 왼쪽 인덱스를 피봇으로 선택

            int pivot = a[left];    // pivot은 분할의 기준이 되는 숫자(인덱스 아님)

            // 피봇과 배열의 각 요소를 비교하여 피봇보다 작은 숫자들은 a[left]~a[p-1]로,
            // 피봇보다 큰 숫자들은 a[p+1]~a[right]로 옮기고

            int p = left++;  // 피봇 인덱스 지정하고 left는 그 다음부터 
            int upper = right;
            int lower = left;
            while (true)
            {
                while (left <= upper && a[left] <= pivot)
                    left++;
                while (right >= lower && a[right] >= pivot)
                    right--;

                // left, right 인덱스의 요소를 교환한다                
                if (left < right)
                {
                    //Console.WriteLine("{0} <-> {1}", left, right);
                    int t = a[left];
                    a[left] = a[right];
                    a[right] = t;
                }
                else
                    break;
            }

            // 피봇 a[p]와 a[right]를 바꾼다
            int tmp = a[p];
            a[p] = a[right];
            a[right] = tmp;

            //Console.WriteLine("pivot {0} <-> {1}", p, right);
            //PrintArray();

            return right;
        }
    }
}