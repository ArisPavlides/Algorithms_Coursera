using System;
using System.Collections.Generic;
using System.Linq;

namespace Get_2nd_largest_num
{
    class Program
    {
        static void Main()
        {
            List<int> int_list = new List<int> { 5, 7, 25, 1, 17, 22, 3, 2, 0, 15, 9, 8, 12 };

            int max_val = int.MinValue;

            for (int i = 0; i < int_list.Count; i++)
            {
                if (int_list[i] > max_val) { max_val = int_list[i]; }
            }

            int_list.Remove(max_val);

            Console.WriteLine(Next_Large(int_list));
            Console.ReadLine();
        }

        static int Next_Large(List<int> int_list)
        {
            if (int_list.Count == 1)
            {
                return int_list[0];
            }

            else
            {
                int num_elements = int_list.Count;
                int split = num_elements / 2;

                List<int> left = int_list.GetRange(0, split);
                List<int> right = int_list.Except(left).ToList();

                int num1 = Next_Large(left);
                int num2 = Next_Large(right);

                return Math.Max(num1, num2);
            }
        }
    }
}