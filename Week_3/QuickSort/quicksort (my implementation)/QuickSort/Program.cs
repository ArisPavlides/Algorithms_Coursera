using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main()
        {
            int[] numbers = new int[] { 2, 20, 0,  2, 1, 17, 13, 9, 6, 19, 5, 11, 10, 10};

            numbers = QuickSorter(numbers);

            foreach (int item in numbers)
            {
                Console.WriteLine(item);
                Console.ReadLine();
            }
        }

        static int[] QuickSorter(int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return numbers;
            }

            int pivot = numbers.Length - 1;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < numbers.Length - 1; i++ )
            {
                if (numbers[i] <= numbers[pivot])
                {
                    left.Add(numbers[i]);
                }

                else
                {
                    right.Add(numbers[i]);
                }
            }

            left = QuickSorter(left.ToArray()).ToList();
            right = QuickSorter(right.ToArray()).ToList();

            List<int> sorted = new List<int>();

            while (left.Count > 0)
            {
                sorted.Add(left[0]);
                left.RemoveAt(0);
            }

            sorted.Add(numbers[pivot]);

            while (right.Count > 0)
            {
                sorted.Add(right[0]);
                right.RemoveAt(0);
            }

            return sorted.ToArray();
        }
    }
}
