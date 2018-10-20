using System.Collections.Generic;
using System.Linq;
using csharp_algorithms;
using gnomesort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.sort
{
    [TestClass]
    public class GnomeSortTest
    {
        [TestMethod]
        public void NormalSort()
        {
            // Arrange
            var list = new List<Node>
            {
                new Node(5),
                new Node(1)
            };
            var b = new GnomeSort(list);

            // Act
            List<Node> result = b.Sort().ToList();

            // Assert
            Assert.AreEqual(1, result.ElementAt(0).Number);
            Assert.AreEqual(5, result.ElementAt(1).Number);
        }

        [TestMethod]
        public void LongerSort()
        {
            // Arrange
            var list = new List<Node>
            {
                new Node(3),
                new Node(5),
                new Node(1),
                new Node(8)
            };
            var b = new GnomeSort(list);

            // Act
            var result = b.Sort().ToList();

            // Assert
            Assert.AreEqual(1, result.ElementAt(0).Number);
            Assert.AreEqual(3, result.ElementAt(1).Number);
            Assert.AreEqual(5, result.ElementAt(2).Number);
            Assert.AreEqual(8, result.ElementAt(3).Number);
        }
    }
}