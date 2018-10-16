using System.Collections.Generic;
using System.Linq;
using countingsort;
using csharp_algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.sort
{
    [TestClass]
    public class CountingSortTests
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
            CountingSort b = new CountingSort(list);

            //Act
            List<Node> result = b.Sort().ToList();

            //Assert
            Assert.AreEqual(1, result.ElementAt(0).Number);
            Assert.AreEqual(5, result.ElementAt(1).Number);
        }

        [TestMethod]
        public void LargerSort()
        {
            //Arrange
            List<Node> list = new List<Node>
            {
                new Node(3),
                new Node(5),
                new Node(1),
                new Node(-4)
            };
            CountingSort b = new CountingSort(list);

            //Act
            List<Node> result = b.Sort().ToList();

            //Assert
            Assert.AreEqual(-4, result.ElementAt(0).Number);
            Assert.AreEqual(1, result.ElementAt(1).Number);
            Assert.AreEqual(3, result.ElementAt(2).Number);
            Assert.AreEqual(5, result.ElementAt(3).Number);
        }
    }
}
