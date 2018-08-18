using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace QuickSort_CountComparisons
{
    class Program
    {
        public static int num_comps = 0;

        public static void Main()
        {
            List<string> num_list_str = File.ReadAllLines("C:/Users/Aris/Desktop/unsorted_numbers.txt").ToList();
            List<int> num_list = num_list_str.Select(int.Parse).ToList();

            Quicksort(num_list, 0, num_list.Count - 1);

            Console.WriteLine(num_comps);
            Console.ReadLine();
        }

        static List<int> Quicksort(List<int> num_list, int low, int high)
        {
            if (low < high)
            {
                int split_idx = Partition(num_list, low, high);

                Quicksort(num_list, low, split_idx - 1);
                Quicksort(num_list, split_idx + 1, high);
            }

            return num_list;
        }

        static int Partition(List<int> num_list, int low, int high)
        {
            num_comps += high - low;

            int med_idx = ((high - low + 1) % 2) == 0 ? ((high - low + 1) / 2) - 1 : ((high - low + 1) / 2);
            int pivot_idx = GetMedian(low, med_idx, high, num_list);
            int pivot = num_list[pivot_idx];

            if (num_list[low] != pivot)
            {
                int swap = num_list[low];
                num_list[low] = pivot;
                num_list[pivot_idx] = swap;
            }

            int i = low;
            int j = high;

            while (true)
            {
                while (num_list[i] < pivot) { i++; }

                while (num_list[j] > pivot) { j--; }

                if (i >= j) { break; }

                else
                {
                    int swap = num_list[i];

                    num_list[i] = num_list[j];
                    num_list[j] = swap;
                }
            }

            return j;
        }

        static int GetMedian(int a, int b, int c, List<int> find_med)
        {
            int median;

            if (find_med[b] < find_med[a] && find_med[a] < find_med[c]) { median = a; }

            else if (find_med[c] < find_med[a] && find_med[a] < find_med[b]) { median = a; }

            else if (find_med[a] < find_med[b] && find_med[b] < find_med[c]) { median = b; }

            else if (find_med[c] < find_med[b] && find_med[b] < find_med[a]) { median = b; }

            else if (find_med[a] < find_med[c] && find_med[c] < find_med[b]) { median = c; }

            else { median = c; }

            return median;
        }
    }
}
