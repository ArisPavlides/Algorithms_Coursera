using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deterministic_Selection
{
    class Program
    {
        static void Main()
        {
            List<int> num_list = new List<int>() { 5, 3, 9, 1, 4, 8, 0, 7, 2, 6};

            int i_order_stat = Deterministic_Selector(num_list);

            Console.WriteLine(i_order_stat);
            Console.ReadLine();
        }

        static int Deterministic_Selector(List<int> num_list)
        {
            List<int> medians = new List<int>();
            List<int> select_five = new List<int>();

            for (int i = 0; i < num_list.Count; i++)
            {               
                select_five.Add(num_list[i]);

                if ((i + 1) % 5 == 0)
                {
                    Split_Lists(select_five); // sort the subarray

                    int median = (select_five.Count % 2 == 0) ? select_five[(select_five.Count / 2) - 1] : select_five[(select_five.Count / 2)];
                    medians.Add(median); 
                    select_five.Clear();
                }

            }

            return 0;
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
