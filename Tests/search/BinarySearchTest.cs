using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csharp_algorithms;
using binarysearch;

namespace Tests.search
{
    [TestClass]
    public class BinarySearchTest
    {
        [TestMethod]
        public void Test1()
        {
            var nodes = new List<Node>
            {
                new Node(10),
                new Node(5),
                new Node(3),
                new Node(50),
                new Node(75),
                new Node(81),
                new Node(8),
                new Node(93),
                new Node(573),
                new Node(111),
                new Node(4324),
                new Node(5532),
                new Node(123),
                new Node(1),
                new Node(32),
                new Node(64),
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

            var bsearch = new BinarySearch(nodes);

            var testValue1 = new Node(1);
            var testValue2 = new Node(123123123);
            var testValue3 = new Node(81330);

            var indexValue1 = bsearch.Search(testValue1);
            var indexValue2 = bsearch.Search(testValue2);
            var indexValue3 = bsearch.Search(testValue3);

            Assert.AreEqual(indexValue1,0);
            Assert.IsNull(indexValue2);
            Assert.AreEqual(indexValue3, nodes.Count() - 1);
        }
    }
}
