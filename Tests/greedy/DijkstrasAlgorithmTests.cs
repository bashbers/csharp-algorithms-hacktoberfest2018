using System;
using System.Collections.Generic;
using System.Linq;
using dijkstrasalgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.greedy
{
    [TestClass]
    public class DijkstrasAlgorithmTests
    {
        [TestMethod]
        public void GetShortestPathTest()
        {
            //Arrange
            var nodes = CreateNodeDictionary();
            var expectedPath = new List<string> {"A", "C", "E", "F"};
            const int expectedCost = 10;

            //Act
            var dijkstrasAlgorithm = new DijkstrasAlgorithm(nodes.Values, "A");
            var shortestPath = dijkstrasAlgorithm.GetShortestPath("F");

            //LogAndAssert
            var actualPath = shortestPath.Select(node => node.Id).ToList();
            var expectedPathString = string.Join(" -> ", expectedPath);
            var actualPathString = string.Join(" -> ", actualPath);
            var actualCost = shortestPath[shortestPath.Count - 1].Cost;
            Console.WriteLine($"expected -- Cost: {expectedCost} Path: {expectedPathString}");
            Console.WriteLine($"actual -- Cost: {actualCost} Path: {actualPathString}");
            Assert.AreEqual(expectedCost, actualCost);
            Assert.AreEqual(expectedPath.Count, actualPath.Count);
            Assert.IsTrue(expectedPath.Zip(actualPath, (e, a) => e == a).All(e => e));
        }

        private IReadOnlyDictionary<string, Node> CreateNodeDictionary()
        {
            var node1 = new Node("A");
            var node2 = new Node("B");
            var node3 = new Node("C");
            var node4 = new Node("D");
            var node5 = new Node("E");
            var node6 = new Node("F");

            node1.AddEdge(new Edge(node2, 5));
            node1.AddEdge(new Edge(node3, 4));
            node1.AddEdge(new Edge(node4, 2));

            node2.AddEdge(new Edge(node1, 5));
            node2.AddEdge(new Edge(node6, 6));
            node2.AddEdge(new Edge(node3, 2));

            node3.AddEdge(new Edge(node2, 2));
            node3.AddEdge(new Edge(node1, 4));
            node3.AddEdge(new Edge(node4, 3));
            node3.AddEdge(new Edge(node5, 2));

            node4.AddEdge(new Edge(node1, 2));
            node4.AddEdge(new Edge(node3, 3));
            node4.AddEdge(new Edge(node5, 6));

            node5.AddEdge(new Edge(node4, 6));
            node5.AddEdge(new Edge(node3, 2));
            node5.AddEdge(new Edge(node6, 4));

            node6.AddEdge(new Edge(node2, 6));
            node6.AddEdge(new Edge(node5, 4));

            return new Dictionary<string, Node>
            {
                { node1.Id, node1 },
                { node2.Id, node2 },
                { node3.Id, node3 },
                { node4.Id, node4 },
                { node5.Id, node5 },
                { node6.Id, node6 }
            };
        }

    }
}