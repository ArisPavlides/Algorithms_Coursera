using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Count_Comparisons_Alt
{
    class Program
    {
        private static int num_comparisons = 0;

        static void Main()
        {
            //List<string> num_list_str = File.ReadAllLines("C:/Users/Aris/Desktop/unsorted_numbers.txt").ToList();
            //List<int> num_list = num_list_str.Select(int.Parse).ToList();

            List<int> num_list = new List<int>() { 5, 1, 3, 0, 2, 4 };
            num_list = QuickSort(num_list, true);

            Console.WriteLine(num_comparisons);
            Console.ReadLine();
        }

        static List<int> QuickSort(List<int> num_list, bool count_comp)
        {
            if (count_comp) { num_comparisons = num_comparisons + Math.Max(0, num_list.Count - 1); }

            if (num_list.Count <= 1) { return num_list; }

            else
            {
                int median_idx = (int)Math.Floor(num_list.Count / 2.0 - 0.5);
                int pivot_idx = GetMedian(0, median_idx, num_list.Count - 1, num_list);
                int pivot = num_list[pivot_idx];
                int swap;

                if (num_list[0] != pivot)
                {
                    swap = num_list[0];
                    num_list[0] = pivot;
                    num_list[pivot_idx] = swap;
                }

                int i = 1;

                for (int j = i; j < num_list.Count; j++)
                {
                    if (num_list[j] < pivot)
                    {
                        swap = num_list[i];

                        num_list[i] = num_list[j];
                        num_list[j] = swap;

                        i++;
                    }
                }

                swap = num_list[i - 1];
                num_list[i - 1] = num_list[0];
                num_list[0] = swap;

                List<int> left = QuickSort(num_list.Take(i - 1).ToList(), true);
                List<int> right = QuickSort(num_list.Skip(i).ToList(), true);

                num_list.Clear();
                num_list.AddRange(left);
                num_list.Add(pivot);
                num_list.AddRange(right);

                return num_list;
            }
        }

        static int GetMedian(int a, int b, int c, List<int> find_med)
        {
            int median;

            if (find_med[b] < find_med[a] && find_med[a] < find_med[c])
            {
                median = a;
            }

            else if (find_med[c] < find_med[a] && find_med[a] < find_med[b])
            {
                median = a;
            }

            else if (find_med[a] < find_med[b] && find_med[b] < find_med[c])
            {
                median = b;
            }

            else if (find_med[c] < find_med[b] && find_med[b] < find_med[a])
            {
                median = b;
            }

            else if (find_med[a] < find_med[c] && find_med[c] < find_med[b])
            {
                median = c;
            }

            else
            {
                median = c;
            }

            return median;
        }
    }
}
