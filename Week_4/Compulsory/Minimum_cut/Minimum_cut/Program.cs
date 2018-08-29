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
            string path = @"C:\Users\Aris\Documents\Algorithms_Coursera\Week_4\Compulsory\test_data.txt";
            string[][] _adj = File.ReadLines(path).Select(line => line.Split('\t')).ToArray();

            var graph = new Graph();
            graph.nodes = new List<Nodes>();

            for (int i = 0; i < _adj.GetLength(0); i++)
            {
                var node = new Nodes();
                node.name = _adj[i][0];
                node.list_member = _adj[i][0];

                graph.nodes.Add(node);
            }

            int nodeINT = 0;

            foreach (var node in graph.nodes)
            {
                node.Neighbours = new List<Nodes>();

                for (int columns = 0; columns < _adj[nodeINT].GetLength(0); columns++)
                {
                    if (columns != 0) // if col
                    {
                        var neighbour = new Nodes();
                        neighbour.name = _adj[nodeINT][columns];

                        node.Neighbours.Add(neighbour);
                    }
                }

                nodeINT++;
            }
            
            int num_cuts;

            // if a node has no neighbours, then the minimum cut is zero
            for (int i = 0; i < graph.nodes.Count; i++)
            {
                if (graph.nodes[i].Neighbours.Count == 0)
                {
                    num_cuts = 0;
                }
            }

            num_cuts = Exec_MinCut.Count_Cuts(graph.nodes);

            Console.WriteLine(num_cuts);
            Console.ReadLine();
        }
    }
}
