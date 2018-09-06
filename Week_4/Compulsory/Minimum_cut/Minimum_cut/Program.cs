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
            List<Nodes> nodes = new List<Nodes>();

            for (int i = 0; i < _adj.GetLength(0); i++)
            {
                Nodes node = new Nodes();
                node.Name = _adj[i][0];
                node.List_member = _adj[i][0];

                nodes.Add(node);
            }

            int nodeINT = 0;
            graph.Arcs = new List<Adjacency_List>();

            foreach (Nodes node in nodes)
            {
                string node_i = node.Name;

                for (int columns = 0; columns < _adj[nodeINT].GetLength(0) - 1; columns++)
                {
                    if (columns != 0) // if column is not the first one which contains the node name
                    {
                        Adjacency_List arc = new Adjacency_List();

                        string  node_j = _adj[nodeINT][columns];

                        arc.node_i = nodes.AsParallel().FirstOrDefault(item => item.Name == node_i); // AsParallel() splits up the search across multiple threads
                        arc.node_j = nodes.AsParallel().FirstOrDefault(item => item.Name == node_j); // AsParallel() splits up the search across multiple threads

                        graph.Arcs.Add(arc);
                    }
                }

                nodeINT++;
            }
            
            int num_cuts = 0;      

            num_cuts = Exec_MinCut.Count_Cuts(graph.Arcs, nodes); 

            Console.WriteLine(num_cuts);
            Console.ReadLine();
        }
    }
}
