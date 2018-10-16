using System.Collections.Generic;

namespace dijkstrasalgorithm
{
    public class Node
    {
        public Node(string id)
        {
            Id = id;
        }

        public string Id { get; }
        public HashSet<Edge> Edges { get; } = new HashSet<Edge>();
        public Node PreviousNode { get; set; }
        public bool Visited { get; set; }
        public int Cost { get; set; } = int.MaxValue;

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }
    }
}