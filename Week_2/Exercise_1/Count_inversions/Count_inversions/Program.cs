using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Count_inversions
{
    class Program
    {
        public static long num_inv = 0;

        static void Main()
        {
            string[] int_arr = File.ReadAllLines(@"C:\Users\arisp\Documents\Algorithms\Week_2\Exercise_1\Integer_array.txt");
            List<int> int_list = int_arr.Select(Int32.Parse).ToList();

            //List<int> int_list = new List<int>() { 6, 5, 4, 3, 2, 1};
            List<int> sorted_list = Split_Lists(int_list);

            Console.WriteLine(num_inv);
            Console.ReadLine();

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
                        num_inv = num_inv + list1.Count();
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