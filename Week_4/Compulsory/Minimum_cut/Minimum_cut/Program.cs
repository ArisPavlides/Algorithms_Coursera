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
            string path = @"C:\Users\Aris\Documents\Algorithms_Coursera\Week_4\Compulsory\data.txt";
            string[][] _adj = File.ReadLines(path).Select(line => line.Split('\t')).ToArray();

            Graph graph = new Graph();
            graph.Nodes = new List<Nodes>();

            for (int i = 0; i < _adj.GetLength(0); i++)
            {
                Nodes node = new Nodes();
                node.Name = _adj[i][0];
                node.List_member = _adj[i][0];

                graph.Nodes.Add(node);
            }

            int nodeINT = 0;

            foreach (Nodes node in graph.Nodes)
            {
                node.Neighbours = new List<Nodes>();

                for (int columns = 0; columns < _adj[nodeINT].GetLength(0) - 1; columns++)
                {
                    if (columns != 0) // if column is not the first one which contains the node name
                    {
                        Nodes neighbour = new Nodes();
                        neighbour = graph.Nodes.FirstOrDefault(p => p.Name == _adj[nodeINT][columns]);

                    node.Neighbours.Add(neighbour);
                    }
                }

                nodeINT++;
            }
            
            int num_cuts = 0;
            bool connected_graph = true;
            
            // if a node has no neighbours, then the minimum cut is zero
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                if (graph.Nodes[i].Neighbours.Count == 0){ connected_graph = false; }
            }

            if (connected_graph) { num_cuts = Exec_MinCut.Count_Cuts(graph.Nodes); }

            Console.WriteLine(num_cuts);
            Console.ReadLine();
        }
    }
}
