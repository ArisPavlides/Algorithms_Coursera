using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_cut
{
    public class Graph
    {
        public List<Nodes> nodes { get; set; }
    }

    public class Nodes
    {
        public string name { get; set; }
        public List<Nodes> Neighbours { get; set; }
    }

    public class Neighbours
    {
        public List<Nodes> NeighbouringNodes { get; set; }
    }
}
