using System;
using System.Collections.Generic;

namespace Get_2nd_largest_num
{
    class Program
    {
        static void Main()
        {
            List<int> int_list = new List<int>() { 7, 1, 3, 4};

            int num_1 = int_list[0];
            int num_2 = int_list[1];

            for (int i = 2; i < int_list.Count; i+=2)
            {
                if (int_list[i] > num_1)
                {
                    num_1 = int_list[i];
                }

                if (int_list[i + 1] > num_2)
                {
                    num_2 = int_list[i + 1];
                }
            }

            Console.WriteLine(Math.Min(num_1, num_2));
            Console.ReadLine();
        }
    }
}
