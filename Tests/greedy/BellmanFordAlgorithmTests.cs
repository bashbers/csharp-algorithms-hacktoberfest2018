using bellmanFordAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Edge = bellmanFordAlgorithm.Graph.Edge;
using Predecessor = System.Collections.Generic.Dictionary<string, string>;
using Distance = System.Collections.Generic.Dictionary<string, int>;

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
            var expected = CreateShortestPaths1(graph);

            //Act
            var actual = BellmanFordAlgorithm.Compute(graph);

            //Assert
            AssertAlgoResult(graph, expected, actual);
        }

        private void AssertAlgoResult(Graph graph, Tuple<Distance, Predecessor> expected, Tuple<Distance, Predecessor> actual)
        {
            foreach (var vertex in graph.Vertices)
            {
                int expectedDistance = expected.Item1[vertex];
                int actualDistance = actual.Item1[vertex];
                Assert.AreEqual(expectedDistance, actualDistance,
                    $"Distance from source for vertex '{vertex}': Expected={expectedDistance} Actual={actualDistance}");

                string expectedPred = expected.Item2[vertex];
                string actualPred = actual.Item2[vertex];
                Assert.AreEqual(expectedPred, actualPred,
                    $"Predecessor for vertex '{vertex}': Expected='{expectedPred}' Actual='{actualPred}'");
            }
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

        private Tuple<Distance, Predecessor> CreateShortestPaths1(Graph graph)
        {
            var distances = new Distance()
            {
                { "a", 0 },
                { "b", 3 },
                { "c", 1 },
                { "d", 5 },
                { "e", 3 },
                { "f", 4 }
            };
            var predecessors = new Predecessor()
            {
                { "a", null },
                { "b", "a" },
                { "c", "a" },
                { "d", "f" },
                { "e", "c" },
                { "f", "e" }
            };
            return new Tuple<Distance, Predecessor>(distances, predecessors);
        }
    }
}
