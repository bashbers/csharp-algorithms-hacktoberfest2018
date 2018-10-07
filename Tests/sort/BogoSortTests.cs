using System.Collections.Generic;
using System.Linq;
using bogosort;
using csharp_algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.sort
{
    [TestClass]
    public class BogoSortTests
    {
        [TestMethod]
        public void NormalSort()
        {
            //Arrange
            List<Node> list = new List<Node>
            {
                new Node(5),
                new Node(1)
            };
            BogoSort b = new BogoSort(list);
            //Act
            List<Node> result = b.Sort().ToList();
            //Assert
            Assert.AreEqual(1, result.ElementAt(0).Number);
            Assert.AreEqual(5, result.ElementAt(1).Number);
        }
        [TestMethod]
        public void ReverseSort()
        {
            //Arrange
            List<Node> list = new List<Node>
            {
                new Node(5),
                new Node(1)
            };
            var b = new BogoSort(list);
            //Act
            List<Node> result = b.ReverseSort().ToList();
            //Assert
            Assert.AreEqual(1, result.ElementAt(0).Number);
            Assert.AreEqual(5, result.ElementAt(1).Number);
        }
    }
}