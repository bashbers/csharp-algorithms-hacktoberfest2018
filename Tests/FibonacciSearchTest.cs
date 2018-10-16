using System;
using System.Collections.Generic;
using System.Linq;
using csharp_algorithms;
using fibonaccisearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FibonacciSearchTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var nodes = new List<Node>
            {
                new Node(1),
                new Node(21),
                new Node(13),
                new Node(91),
                new Node(100),
                new Node(81),
                new Node(42),
                new Node(12),
                new Node(11),
                new Node(211),
                new Node(113),
                new Node(911),
                new Node(10),
                new Node(811),
                new Node(412),
                new Node(2),
                new Node(83),
                new Node(43),
                new Node(23),
                new Node(131),
                new Node(231),
                new Node(133),
                new Node(913),
                new Node(1003),
                new Node(81330),
                new Node(4233),
                new Node(233),
                new Node(1033)
            };

            var fibonacciSearch = new FibonacciSearch(nodes);

            var testValueTrue = new Node(42);
            var testValueFalse = new Node(111);
            var testValueLastPosition = new Node(81330);

            var resultTrue = fibonacciSearch.Search(testValueTrue);
            var resultFalse = fibonacciSearch.Search(testValueFalse);
            var resultLastPosition = fibonacciSearch.Search(testValueLastPosition);

            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
            Assert.IsTrue(resultLastPosition);
        }
    }
}
