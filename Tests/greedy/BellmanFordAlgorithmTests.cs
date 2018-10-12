using bellmanFordAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using Edge = bellmanFordAlgorithm.Graph.Edge;
using Predecessor = System.Collections.Generic.Dictionary<string, string>;
using Distance = System.Collections.Generic.Dictionary<string, int>;

namespace Tests.greedy
{
    [TestClass]
    public class BellmanFordAlgorithmTests
    {
        #region Test Methods
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

        [TestMethod]
        public void NegativeWeightsGraph()
        {
            //Arrange
            var graph = CreateGraph2();
            var expected = CreateShortestPaths2(graph);

            //Act
            var actual = BellmanFordAlgorithm.Compute(graph);

            //Assert
            AssertAlgoResult(graph, expected, actual);
        }

        [TestMethod]
        public void NegativeCircleGraph()
        {
            //Arrange
            var graph = CreateGraph3();

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => BellmanFordAlgorithm.Compute(graph, true));
        }
        #endregion // Test Methods

        #region Helper Methods
        private void AssertAlgoResult(Graph graph, Tuple<Distance, Predecessor> expected, Tuple<Distance, Predecessor> actual)
        {
            Assert.AreEqual(expected.Item1.Count, actual.Item1.Count);
            Assert.AreEqual(expected.Item2.Count, actual.Item2.Count);

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

        /// <summary>
        /// Creates graph with only postive edge weights.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Solution for the first graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates graph with negative edge weights as well (without negative circle).
        /// </summary>
        /// <returns></returns>
        private Graph CreateGraph2()
        {
            var vertices = new List<string>()
            {
                "a", "b", "c", "d", "e", "f"
            };
            var edges = new List<Graph.Edge>()
            {
                new Edge { Vertex1 = "a", Vertex2 = "b", Weight = 10 },
                new Edge { Vertex1 = "a", Vertex2 = "c", Weight = -20 },
                new Edge { Vertex1 = "b", Vertex2 = "d", Weight = 50 },
                new Edge { Vertex1 = "b", Vertex2 = "e", Weight = 10 },
                new Edge { Vertex1 = "c", Vertex2 = "d", Weight = 20 },
                new Edge { Vertex1 = "c", Vertex2 = "e", Weight = 33 },
                new Edge { Vertex1 = "d", Vertex2 = "e", Weight = -20 },
                new Edge { Vertex1 = "d", Vertex2 = "f", Weight = -2 },
                new Edge { Vertex1 = "e", Vertex2 = "f", Weight = 1 },
            };
            return new Graph(vertices, edges, "a");
        }

        /// <summary>
        /// Solution for the second graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        private Tuple<Distance, Predecessor> CreateShortestPaths2(Graph graph)
        {
            var distances = new Distance()
            {
                { "a", 0 },
                { "b", 10 },
                { "c", -20 },
                { "d", 0 },
                { "e", -20 },
                { "f", -19 }
            };
            var predecessors = new Predecessor()
            {
                { "a", null },
                { "b", "a" },
                { "c", "a" },
                { "d", "c" },
                { "e", "d" },
                { "f", "e" }
            };
            return new Tuple<Distance, Predecessor>(distances, predecessors);
        }

        /// <summary>
        /// Creates graph with a negative circle (this graph has no solution, as the algorithm should throw).
        /// </summary>
        /// <returns></returns>
        private Graph CreateGraph3()
        {
            var vertices = new List<string>()
            {
                "a", "b", "c", "d", "e", "f"
            };
            var edges = new List<Graph.Edge>()
            {
                new Edge { Vertex1 = "a", Vertex2 = "b", Weight = 10 },
                new Edge { Vertex1 = "b", Vertex2 = "c", Weight = 1 },
                new Edge { Vertex1 = "c", Vertex2 = "e", Weight = 3 },
                new Edge { Vertex1 = "e", Vertex2 = "d", Weight = -10 },
                new Edge { Vertex1 = "d", Vertex2 = "b", Weight = 4 },
                new Edge { Vertex1 = "e", Vertex2 = "f", Weight = 22 }
            };
            return new Graph(vertices, edges, "a");
        }
        #endregion // Helper Methods
    }
}
