using bellmanFordAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Path = System.Collections.Generic.List<bellmanFordAlgorithm.Graph.Edge>;
using Edge = bellmanFordAlgorithm.Graph.Edge;

namespace Tests.greedy
{
    [TestClass]
    public class BellmanFordAlgorithmTests
    {
        [TestMethod]
        public void PositiveWeightsGraph()
        {
            //Arrange
            var graph = CreateGraph1();
            var expectedPaths = CreateShortestPaths1(graph);

            //Act
            var actualPaths = BellmanFordAlgorithm.Compute(graph);

            //Assert
            Assert.AreEqual(expectedPaths, actualPaths);
        }

        private Graph CreateGraph1()
        {
            var vertices = new List<string>()
            {
                "a", "b", "c", "d", "e", "f"
            };
            var edges = new List<Graph.Edge>()
            {
                new Edge { Vertex1 = "a", Vertex2 = "b", Weight = 3 },
                new Edge { Vertex1 = "a", Vertex2 = "c", Weight = 1 },
                new Edge { Vertex1 = "b", Vertex2 = "c", Weight = 2 },
                new Edge { Vertex1 = "b", Vertex2 = "d", Weight = 3 },
                new Edge { Vertex1 = "b", Vertex2 = "e", Weight = 6 },
                new Edge { Vertex1 = "c", Vertex2 = "e", Weight = 2 },
                new Edge { Vertex1 = "e", Vertex2 = "f", Weight = 1 },
                new Edge { Vertex1 = "f", Vertex2 = "d", Weight = 1 },
            };
            return new Graph(vertices, edges, "a");
        }

        private BellmanFordAlgorithm.ShortestPaths CreateShortestPaths1(Graph graph)
        {
            var distances = new Dictionary<string, int>()
            {
                { "a", 0 },
                { "b", 3 },
                { "c", 1 },
                { "d", 5 },
                { "e", 3 },
                { "f", 4 }
            };
            var paths = new Dictionary<string, Path>()
            {
                { "b", new List<Edge>() { graph.Edges[1] } },
                { "c", new List<Edge>() { graph.Edges[0] } },
                { "d", new List<Edge>() { graph.Edges[0], graph.Edges[5], graph.Edges[6], graph.Edges[7] } },
                { "e", new List<Edge>() { graph.Edges[0], graph.Edges[5] } },
                { "f", new List<Edge>() { graph.Edges[0], graph.Edges[5], graph.Edges[6] } },
            };
            return new BellmanFordAlgorithm.ShortestPaths(distances, paths);
        }
    }
}
