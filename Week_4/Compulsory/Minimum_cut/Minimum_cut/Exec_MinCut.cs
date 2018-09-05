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
            int total_trials = Convert.ToInt32(Math.Pow(nodes.Count, 2) * Math.Log(nodes.Count));
            int min_cuts_found = 0;

            // initialise the optimisation variable by setting it equal to the total number of arcs in the graph
            foreach (Nodes calc_arcs in nodes) { min_cuts_found += calc_arcs.Neighbours.Count; }

            Random rnd = new Random(); // seed the random number generator to get comparable results
            int trial_num = 0;

            // repeat until number of trials reached
            while (trial_num < total_trials)
            {
                int num_nodes = nodes.Count;

                foreach (Nodes node in nodes) { node.List_member = node.Name; } // reset the list_membership of the nodes

                // repeat until the minimum cut is created
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

                    // fuse the nodes by assigning them to the same list
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

                if (min_cuts_found > cut_arcs_num) { min_cuts_found = cut_arcs_num; }

                trial_num++;
            }        

            return min_cuts_found;
        }
    }
}
