using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace QuickSort_CountComparisons
{
    class Program
    {
        public static int num_comps = 1;

        public static void Main()
        {
            //List<string> num_list_str = File.ReadAllLines("C:/Users/arisp/Documents/Algorithms/Week_3/Compulsory/unsorted_numbers.txt").ToList();
            //List<int> num_list = num_list_str.Select(int.Parse).ToList();

            List<int> num_list = new List<int>() { 5, 1, 3, 0, 2, 4 }; // should be 9 comparisons

            num_list = Quicksort(num_list, 0, num_list.Count - 1);

            Console.WriteLine(num_comps);
            Console.ReadLine();
        }

        static List<int> Quicksort(List<int> num_list, int low, int high)
        {
            if (low < high)
            {
                int split_idx = Partition(num_list, low, high);

                Quicksort(num_list, low, split_idx);
                Quicksort(num_list, split_idx + 1, high);
            }

            return num_list;
        }

        static int Partition(List<int> num_list, int low, int high)
        {
            num_comps += high - low - 1;

            int pivot = num_list[low];

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
    }
}