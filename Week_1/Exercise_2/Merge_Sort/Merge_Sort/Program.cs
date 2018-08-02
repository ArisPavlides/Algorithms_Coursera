﻿using System;
using System.Collections.Generic;

namespace Merge_Sort
{
    class Program
    {
        static void Main()
        {
            List<int> num_array = new List<int>() { 9, 7, 1, 6, 8, 11, 2, 3, 13 };
            List<int> sorted_list = Split_Lists(num_array);

            foreach (int a in sorted_list)
            {
                Console.WriteLine(a);
                Console.ReadLine();
            }
        }

        static List<int> Split_Lists(List<int> num_array)
        {
            if (num_array.Count == 1) { return num_array; }

            else
            {
                int num_elements = num_array.Count;
                int split = num_elements / 2;

                List<int> left = new List<int>();
                List<int> right = new List<int>();

                for (int i = 0; i < num_elements; i++)
                {
                    if (i < split) { left.Add(num_array[i]); }
                    else { right.Add(num_array[i]); }
                };

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