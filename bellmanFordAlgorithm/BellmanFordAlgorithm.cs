using System;
using System.Collections.Generic;

using Path = System.Collections.Generic.List<bellmanFordAlgorithm.Graph.Edge>;

namespace bellmanFordAlgorithm
{
    /// <summary>
    /// Algorithm that computes shortest paths from a single source
    /// vertex to all of the other vertices in a weighted digraph.
    /// </summary>
    public class BellmanFordAlgorithm
    {
        #region Nested Classes
        /// <summary>
        /// Shortest paths in a weighted digraph;
        /// </summary>
        public class ShortestPaths
        {
            /// <summary>
            /// Shortest distances from the source vertex for each of the vertices.
            /// </summary>
            public IDictionary<string, int> Distances
            {
                get;
                private set;
            }

            /// <summary>
            /// Shortes paths from the source vertex for each of the vertices.
            /// </summary>
            public IDictionary<string, Path> Paths
            {
                get;
                private set;
            }

            /// <summary>
            /// Creates an (empty) instance of the ShortestPaths.
            /// </summary>
            /// <param name="distances"></param>
            /// <param name="paths"></param>
            public ShortestPaths(IDictionary<string, int> distances, IDictionary<string, Path> paths)
            {
                Distances = distances;
                Paths = paths;
            }
        } 
        #endregion // Nested Classes
        
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
        public static ShortestPaths Compute(Graph graph, bool detectNegativeCycles = false)
        {
            var g = graph;
            var distances = new Dictionary<string, int>();
            var paths = new Dictionary<string, Path>();

            foreach (var v in g.Vertices)
            {
                distances[v] = Inf;
            }
            distances[g.Source] = 0;

            for (int i = 0; i < g.Vertices.Count - 1; i++)
            {
                foreach (var edge in g.Edges)
                {
                    var tmpDistance = distances[edge.Vertex1] + edge.Weight;

                    if (tmpDistance < distances[edge.Vertex2])
                    {
                        distances[edge.Vertex2] = tmpDistance;
                        paths[edge.Vertex2].Add(edge);
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

            return new ShortestPaths(distances, paths);
        } 
        #endregion // Methods
    }
}
