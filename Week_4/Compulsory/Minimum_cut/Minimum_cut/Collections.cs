using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_cut
{
    public class Graph
    {
        public List<Nodes> Nodes { get; set; }
    }

    public class Nodes
    {
        public string Name { get; set; }
        public List<Nodes> Neighbours { get; set; }
        public string List_member { set; get; }
    }

    public class Neighbours
    {
        public List<Nodes> NeighbouringNodes { get; set; }
    }
}
