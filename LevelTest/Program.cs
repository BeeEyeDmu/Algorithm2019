using System;

namespace LevelTest
{
    class Program
    {
        const int SIZE = 10000;
        static int[] a = new int[SIZE];
        
        static void Main(string[] args)
        {
            Random r = new Random();

            // 1. 랜덤하게 10000개의 숫자를 생성하고 배열에 저장하라
            for (int i = 0; i < SIZE; i++)
                a[i] = r.Next();

            PrintArray(a);

            //2. 배열 안의 10000개의 숫자 중 가장 작은 수와 가장 큰 수, 평균을 계산하여 출력하라
            int max = a[0];
            int min = a[0];
            long sum = 0;
            foreach(var v in a)
            {
                if (v > max) max = v;
                if (v < min) min = v;
                sum += v;
            }
            Console.WriteLine("\nMin={0}, Max={1}, Avg={2}", min, max, (double)sum/SIZE);

            //3. 배열에서 특정한 값을 찾아 배열의 몇 번째 원소인지를 출력하라.
            int searchValue;

            Console.Write("\n찾고자 하는 값을 입력하세요: ");
            searchValue = int.Parse(Console.ReadLine());

            for (int i=0; i<SIZE; i++)
                if(a[i] == searchValue)
                    Console.WriteLine("... {0}는 {1}번째 인덱스에 있습니다", searchValue, i);

            // 4. 배열을 정렬하라
            Array.Sort(a);
            PrintArray(a);

            Console.Write("\n찾고자 하는 값을 입력하세요: ");
            searchValue = int.Parse(Console.ReadLine());

            // 5. 정렬된 배열에서 특정한 값을 찾아 배열의 몇 번째 원소인지를 출력하라(Binary Search)
            Console.WriteLine("Binary Search : {0}", Array.BinarySearch(a, searchValue));
            Console.WriteLine("Binary Search : {0}", BinarySearch(a, searchValue));
        }

        // 배열의 앞부분 20개, 뒷부분 20개 출력
        private static void PrintArray(int[] a)
        {
            for (int i = 0; i < 20; i++)
                Console.Write("{0,11}{1}", a[i], (i + 1) % 10 != 0 ? "" : "\n");
            Console.WriteLine("...");
            for (int i = SIZE-20; i < SIZE; i++)
                Console.Write("{0,11}{1}", a[i], (i + 1) % 10 != 0 ? "" : "\n");
        }

        private static int BinarySearch(int[] arr, int searchV)
        {
            int low = 0, high = arr.Length - 1, mid;

            while (low <= high)
            {
                mid = (low + high) / 2;

                if (searchV < arr[mid])
                    high = mid - 1;
                else if (searchV > arr[mid])
                    low = mid + 1;
                else
                    return mid;
            }
            return -1;
        }
    }
}
