using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_cut
{
    public class Graph
    {
        public List<Adjacency_List> Arcs { get; set; }
    } 

    public class Nodes
    {
        public string Name { get; set; }
        public string List_member { set; get; }
    }

    public class Adjacency_List
    {
        public Nodes node_i { get; set; }
        public Nodes node_j { get; set; }
    }
}
