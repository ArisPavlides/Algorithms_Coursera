using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomised_Selection
{
    class Program
    {
        static void Main()
        {
            List<int> num_list = new List<int>() { 9, 2, 1, 3, 8, 7, 0, 6, 4};

            int n_order_stat = Randomised_Selector(num_list, 0, num_list.Count - 1);

            Console.WriteLine(n_order_stat);
            Console.ReadLine();
        }

        static int Randomised_Selector(List<int> num_list, int start, int end)
        {
            if (end <= start)
            {
                return num_list[start];
            }

            int order_stat_req = 2;
            int order_stat_found = 0;

            int pivot_idx = Partitioning(num_list, start, end);

            if (pivot_idx == order_stat_req - 1)
            {
                return num_list[pivot_idx];
            }

            else if (pivot_idx > order_stat_req - 1)
            {
                order_stat_found = Randomised_Selector(num_list, start, pivot_idx - 1);
            }

            else
            {
                order_stat_found = Randomised_Selector(num_list, pivot_idx + 1, end);
            }

            return order_stat_found;
        }

        static int Partitioning(List<int> num_list, int start, int end)
        {
            Random rnd = new Random();
            int pivot_idx = rnd.Next(start, end + 1); // creates a number between start and end

            int pivot = num_list[start];
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
    }
}
