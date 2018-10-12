using System;

using Predecessor = System.Collections.Generic.Dictionary<string, string>;
using Distance = System.Collections.Generic.Dictionary<string, int>;

namespace bellmanFordAlgorithm
{
    /// <summary>
    /// Algorithm that computes shortest paths from a single source
    /// vertex to all of the other vertices in a weighted digraph.
    /// </summary>
    public class BellmanFordAlgorithm
    {
        /// <summary>
        /// Represents logical infinity - distance to undiscovered vertices.
        /// </summary>
        public const int Inf = int.MaxValue;

        #region Methods
        /// <summary>
        /// Computes shortest paths from source vertex to each of the other vertices.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="detectNegativeCycles"></param>
        /// <returns></returns>
        public static Tuple<Distance, Predecessor> Compute(Graph graph, bool detectNegativeCycles = false)
        {
            var g = graph;
            var distances = new Distance();
            var predecessors = new Predecessor();

            foreach (var v in g.Vertices)
            {
                distances[v] = Inf;
            }
            distances[g.Source] = 0;
            predecessors[g.Source] = null;

            for (int i = 0; i < g.Vertices.Count - 1; i++)
            {
                foreach (var edge in g.Edges)
                {
                    var tmpDistance = distances[edge.Vertex1] + edge.Weight;

                    if (tmpDistance < distances[edge.Vertex2])
                    {
                        distances[edge.Vertex2] = tmpDistance;
                        predecessors[edge.Vertex2] = edge.Vertex1;
                    }
                }
            }

            if (detectNegativeCycles)
            {
                foreach (var edge in g.Edges)
                {
                    if (distances[edge.Vertex1] + edge.Weight < distances[edge.Vertex2])
                        throw new ArgumentException("Graph contains a negative-weight cycle");
                }
            }

            return new Tuple<Distance, Predecessor>(distances, predecessors);
        } 
        #endregion // Methods
    }
}
