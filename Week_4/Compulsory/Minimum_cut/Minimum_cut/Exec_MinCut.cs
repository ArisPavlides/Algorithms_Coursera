using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_cut
{
    class Exec_MinCut
    {
        public static int Count_Cuts(List<Nodes> nodes)
        {
            int num_nodes = nodes.Count;
            int num_arcs = 0;

            foreach (Nodes node in nodes)
            {
                num_arcs += node.Neighbours.Count;
            }

            Random rnd = new Random(0); // seed the random number generator to get comparable results

            while (num_nodes > 2)
            {               
                int node_a;  
                int node_b;

                while (true)
                {
                    node_a = rnd.Next(nodes.Count); // creates a number between 0 and nodes.Count
                    int node_a_neighb = rnd.Next(nodes[node_a].Neighbours.Count); // creates a number between 0 and neighbours count
                    node_b = Convert.ToInt32(nodes[node_a].Neighbours[node_a_neighb].name);

                    if (nodes[node_a].list_member != nodes[node_b].list_member) { break; }
                }

                string replace_list = nodes[node_b].list_member;

                foreach (Nodes node in nodes)
                {                    
                    if (node.list_member == replace_list) { node.list_member = nodes[node_a].list_member; }
                    if (node.list_member == nodes[node_a].list_member) { num_arcs -= node.Neighbours.Count(p => (p.name == node_a.ToString()) || (p.name == node_b.ToString())); }

                }

                num_nodes--;
            }

            return nodes[0].Neighbours.Count;
        }
    }
}
