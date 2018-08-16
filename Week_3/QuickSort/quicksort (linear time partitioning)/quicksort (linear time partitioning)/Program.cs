using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort__Linear_time_partitioning_
{
    class Program
    {
        public int q;

        static void Main()
        {
            int[] numbers = new int[] { 6, 3, 0, 2, 9, 4, 12, 0, 7, 10, 19, 8, 17, 11 };

            int left = 0;
            int right = numbers.Length - 1;

            numbers = QuickSorter(numbers, left, right);

            foreach (int item in numbers)
            {
                Console.WriteLine(item);
                Console.ReadLine();
            }
        }

        static int[] QuickSorter(int[] numbers, int left, int right)
        {
            if (right <= left)
            {
                return numbers;
            }

            int p = left; // start of numbers < pivot
            int q = left; // start of numbers > pivot
            int pivot = numbers[right];

            for (int examineNow = left; examineNow < right; examineNow++)
            {
                int currentNumber = numbers[examineNow];

                if (currentNumber < pivot)
                {
                    numbers[examineNow] = numbers[q];
                    numbers[q] = currentNumber;
                    q++;
                }
            }

            numbers[right] = numbers[q];
            numbers[q] = pivot;

            // we do not need to include the pivot since we already know where its position after sorting should be
            QuickSorter(numbers, left, q - 1);
            QuickSorter(numbers, (q + 1), right);

            return numbers;
        }
    }
}
