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
        public void LongerSort()
        {
            //Arrange
            List<Node> list = new List<Node>
            {
                new Node(3),
                new Node(5),
                new Node(1),
                new Node(8)
            };
            BogoSort b = new BogoSort(list);

            //Act
            List<Node> result = b.Sort().ToList();

            //Assert
            Assert.AreEqual(1, result.ElementAt(0).Number);
            Assert.AreEqual(3, result.ElementAt(1).Number);
            Assert.AreEqual(5, result.ElementAt(2).Number);
            Assert.AreEqual(8, result.ElementAt(3).Number);
        }
    }
}
