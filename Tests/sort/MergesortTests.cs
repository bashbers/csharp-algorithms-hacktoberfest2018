using System.Collections.Generic;
using System.Linq;
using csharp_algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MergeSort;

namespace Tests.sort
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void NormalSort()
        {
            //Arrange
            IEnumerable<Node> list = new List<Node>
            {
                new Node(5),
                new Node(1)
            };
            //Act
            MergeSort.MergeSort.Sort(ref list);
            //Assert
            Assert.AreEqual(1, list.ElementAt(0).Number);
            Assert.AreEqual(5, list.ElementAt(1).Number);
        }
    }
}
