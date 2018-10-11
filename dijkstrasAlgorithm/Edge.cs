namespace dijkstrasalgorithm
{
    public class Edge
    {
        public Edge(Node node, int cost)
        {
            Node = node;
            Cost = cost;
        }

        public Node Node { get; }
        public int Cost { get; }
    }
}