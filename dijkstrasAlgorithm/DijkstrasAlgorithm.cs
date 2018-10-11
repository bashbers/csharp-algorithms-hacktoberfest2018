using System.Collections.Generic;
using System.Linq;

namespace dijkstrasalgorithm
{
    public class DijkstrasAlgorithm
    {
        private readonly IReadOnlyDictionary<string, Node> _nodes;

        public DijkstrasAlgorithm(IEnumerable<Node> nodes, string startId)
        {
            var nodeArray = nodes.ToArray();
            _nodes = nodeArray.ToDictionary(node => node.Id, node => node);
            Resolve(startId);
        }

        public List<Node> GetShortestPath(string endId)
        {
            var currentNode = _nodes[endId];
            var endToStartPath = new List<Node>();

            while (true)
            {
                endToStartPath.Add(currentNode);
                if (currentNode.PreviousNode == null) break;
                currentNode = currentNode.PreviousNode;
            }

            return Enumerable.Reverse(endToStartPath).ToList();
        }

        private void Resolve(string startId)
        {
            _nodes[startId].Cost = 0;
            var destinationNodes = new Queue<Node>();
            destinationNodes.Enqueue(_nodes[startId]);

            do
            {
                var currentNode = destinationNodes.Dequeue();
                if (currentNode.Visited) continue;

                foreach (var edge in currentNode.Edges)
                {
                    var node = edge.Node;
                    var cost = currentNode.Cost + edge.Cost;

                    if (node.Cost > cost)
                    {
                        node.Cost = cost;
                        node.PreviousNode = currentNode;
                    }

                    if (!node.Visited) destinationNodes.Enqueue(node);
                }

                currentNode.Visited = true;
            } while (destinationNodes.Any());
        }
    }
}
