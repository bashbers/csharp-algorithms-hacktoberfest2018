using System.Collections.Generic;

namespace bellmanFordAlgorithm
{
    /// <summary>
    /// Weighted oriented graph allowing for negative edge weights.
    /// </summary>
    public class Graph
    {
        #region Nested Classes
        /// <summary>
        /// Edge in a graph.
        /// </summary>
        public class Edge
        {
            /// <summary>
            /// Origin vertex.
            /// </summary>
            public string Vertex1;

            /// <summary>
            /// Destination vertex;
            /// </summary>
            public string Vertex2;

            /// <summary>
            /// Weight of the edge. Can be both positive and negative.
            /// </summary>
            public int Weight;
        }
        #endregion // Nested Classes

        #region Properties
        /// <summary>
        /// Set of vertices of the graph.
        /// </summary>
        public IList<string> Vertices
        {
            get;
            private set;
        }

        /// <summary>
        /// Set of edges of the graph.
        /// </summary>
        public IList<Edge> Edges
        {
            get;
            private set;
        }

        /// <summary>
        /// Source vertex of the graph.
        /// </summary>
        public string Source
        {
            get;
            private set;
        }
        #endregion // Properties

        #region Constructors
        /// <summary>
        /// Creates new instance of the graph.
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="edges"></param>
        /// <param name="source"></param>
        public Graph(IList<string> vertices, IList<Edge> edges, string source)
        {
            Vertices = vertices;
            Edges = edges;
            Source = source;
        }
        #endregion // Constructors
    }
}
