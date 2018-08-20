using System;
using System.Collections.Generic;
using System.Linq;

namespace Deterministic_Selection
{
    class Program
    {
        static void Main()
        {
            List<int> num_list = new List<int>() { 5, 3, 9, 1, 4, 8, 0, 7, 2, 6};

            int i_order_stat = Deterministic_Selector(num_list, 0, num_list.Count - 1);

            Console.WriteLine(i_order_stat);
            Console.ReadLine();
        }

        static int Deterministic_Selector(List<int> num_list, int start, int end)
        {
            if (end <= start)
            {
                return num_list[start];
            }

            int order_stat_req = 7;
            int order_stat_found = 0;

            int pivot_idx = Partitioning(num_list, start, end);

            if (pivot_idx == order_stat_req - 1)
            {
                return num_list[pivot_idx];
            }

            else if (pivot_idx > order_stat_req - 1)
            {
                order_stat_found = Deterministic_Selector(num_list, start, pivot_idx - 1);
            }

            else
            {
                order_stat_found = Deterministic_Selector(num_list, pivot_idx + 1, end);
            }

            return order_stat_found;
        }

        static int Partitioning(List<int> num_list, int start, int end)
        {
            List<int> medians = new List<int>();
            List<int> select_five = new List<int>();

            for (int k = start; k <= end; k++)
            {
                select_five.Add(num_list[k]);

                if ((k + 1) % 5 == 0 || (k == end && k - start < 4))
                {
                    List<int> ordered = Split_Lists(select_five); // sort the subarray

                    int median = (ordered.Count % 2 == 0) ? ordered[(ordered.Count / 2) - 1] : ordered[ordered.Count / 2];
                    medians.Add(median);
                    select_five.Clear();
                }
            }

            List<int> ordered_med = Split_Lists(medians);
            int pivot = (ordered_med.Count % 2 == 0) ? ordered_med[(ordered_med.Count / 2) - 1] : ordered_med[ordered_med.Count / 2];

            int i = start;
            int j = end;

            while (true)
            {
                while (num_list[i] < pivot) { i++; }
                while (num_list[j] > pivot) { j--; }

                if (i >= j)
                {
                    break;
                }

                int swap = num_list[i];
                num_list[i] = num_list[j];
                num_list[j] = swap;
            }

            return j;
        }

        static List<int> Split_Lists(List<int> num_array)
        {
            if (num_array.Count == 1) { return num_array; }

            else
            {
                int num_elements = num_array.Count;
                int split = num_elements / 2;

                List<int> left = num_array.GetRange(0, split);
                List<int> right = num_array.Except(left).ToList();

                List<int> list1 = Split_Lists(left);
                List<int> list2 = Split_Lists(right);

                return Merge_Lists(list1, list2);
            }
        }

        static List<int> Merge_Lists(List<int> list1, List<int> list2)
        {
            List<int> merged_list = new List<int>();

            while (list1.Count > 0 || list2.Count > 0)
            {
                if (list1.Count > 0 && list2.Count > 0)
                {
                    if (list1[0] < list2[0])
                    {
                        merged_list.Add(list1[0]);
                        list1.RemoveAt(0);
                    }

                    else
                    {
                        merged_list.Add(list2[0]);
                        list2.RemoveAt(0);
                    }
                }
                else if (list2.Count == 0)
                {
                    while (list1.Count > 0)
                    {
                        merged_list.Add(list1[0]);
                        list1.RemoveAt(0);
                    }
                }
                else
                {
                    while (list2.Count > 0)
                    {
                        merged_list.Add(list2[0]);
                        list2.RemoveAt(0);
                    }
                }
            }
            return merged_list;
        }
    }
}
