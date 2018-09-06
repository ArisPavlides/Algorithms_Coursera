using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_cut
{
    class Exec_MinCut
    {
        public static int Count_Cuts(List<Adjacency_List> arcs, List<Nodes> nodes)
        {            
            int total_trials = Convert.ToInt32(Math.Pow(nodes.Count, 2) * Math.Log(nodes.Count));
            int min_cuts_found = 0;

            // initialise the optimisation variable by setting it equal to the total number of arcs in the graph
            min_cuts_found = arcs.Count;

            Random rnd = new Random(); // seed the random number generator to get comparable results
            int trial_num = 0;

            // repeat until number of trials reached
            while (trial_num < total_trials)
            {                
                foreach (Nodes node in nodes) { node.List_member = node.Name; } // reset the list_membership of the nodes

                List<Adjacency_List> shuffled_arcs = arcs.OrderBy(a => Guid.NewGuid()).ToList();
                int shuffled_idx = 0;

                // repeat until the minimum cut is created
                int num_nodes = nodes.Count;

                while (num_nodes > 2)
                {
                    string node_i_list = shuffled_arcs[shuffled_idx].node_i.List_member; // list membership of node_i
                    string node_j_list = shuffled_arcs[shuffled_idx].node_j.List_member; // list membership of node_j

                    if (node_i_list != node_j_list)
                    {
                        // fuse the nodes by assigning them to the same list
                        foreach (Nodes node in nodes)
                        {
                            if (node.List_member == node_j_list) { node.List_member = node_i_list; }
                        }

                        num_nodes--;
                    }

                    shuffled_idx++;
                }

                int cut_arcs_num = 0;
                string left_list_name = nodes[0].List_member;

                foreach (Adjacency_List arc in shuffled_arcs)
                {
                    // if node_i == left_list_name find the list membership of node_j
                    string node_i_list = arc.node_i.List_member;

                    if (node_i_list == left_list_name)
                    {
                        // if list of node_i != list membership of node_j then add 1
                        string node_j_list = arc.node_j.List_member;

                        if (node_i_list != node_j_list) { cut_arcs_num++; }
                    }
                }

                if (min_cuts_found > cut_arcs_num) { min_cuts_found = cut_arcs_num; }

                trial_num++;
            }        

            return min_cuts_found;
        }
    }
}
