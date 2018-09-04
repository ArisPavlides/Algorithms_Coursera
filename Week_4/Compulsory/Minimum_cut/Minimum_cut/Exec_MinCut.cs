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

            Random rnd = new Random(1); // seed the random number generator to get comparable results

            while (num_nodes > 2)
            {               
                int node_a;  
                int node_b;

                while (true)
                {
                    node_a = rnd.Next(nodes.Count); // creates a number between 0 and nodes.Count
                    node_b = rnd.Next(nodes[node_a].Neighbours.Count); // creates a number between 0 and neighbours count

                    if (nodes[node_a].List_member != nodes[node_a].Neighbours[node_b].List_member) { break; }
                }

                string replace_list = nodes[node_a].Neighbours[node_b].List_member;

                foreach (Nodes node in nodes)
                {                    
                    if (node.List_member == replace_list) { node.List_member = nodes[node_a].List_member; }
                }

                num_nodes--;
            }

            int cut_arcs_num = 0;
            string left_list_name = nodes[0].List_member;

            foreach (Nodes node in nodes)
            {
                if (node.List_member == left_list_name) { cut_arcs_num += node.Neighbours.Count(p => (p.List_member != left_list_name)); }
            }           

            return cut_arcs_num;
        }
    }
}
