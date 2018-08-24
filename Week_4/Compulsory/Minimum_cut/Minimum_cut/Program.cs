using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_cut
{
    class Program
    {
        static void Main()
        {
            string[] _adj = File.ReadAllLines("C:/Users/Aris/Documents/Algorithms_Coursera/Week_4/Compulsory/data.txt");

            var lls = new List<List<string>>();
            for (int i = 0; i < _adj.First().Split('\t').Length; i++)
            {

                lls.Add(_adj.Select(x => x.Split('\t')[i]).ToList());
            }
        }
    }
}
