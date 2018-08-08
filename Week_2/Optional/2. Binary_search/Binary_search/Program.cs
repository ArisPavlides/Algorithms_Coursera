using System;
using System.Collections.Generic;
using System.Linq;

namespace Binary_search
{
    class Program
    {
        static void Main()
        {
            List<int> int_list = new List<int>() { 2, 4, 6, 8, 10, 9, 7, 5, 3, 1};

            int max_num = int.MinValue;

            for (int i = 0; i < int_list.Count; i++)
            { if (max_num < int_list[i]) { max_num = int_list[i]; } };

            int_list.Remove(max_num);

            Console.WriteLine(Binary_Search(int_list));
            Console.ReadLine();
        }

        static int Binary_Search(List<int> int_list)
        {
            if (int_list.Count == 2)
            {
                return Math.Max(int_list[0], int_list[1]);
            }

            int num_elements = int_list.Count();
            int split = num_elements / 2;

            List<int> left = int_list.GetRange(0, split);
            List<int> right = int_list.Except(left).ToList();

            int high_num = 0;

            if (int_list[split - 1] > int_list[split])
            {
                high_num = Binary_Search(left);
            }

            else
            {
                high_num = Binary_Search(right);
            }

            return high_num;
        }
    }
}
