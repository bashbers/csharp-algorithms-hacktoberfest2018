using csharp_algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using quicksort;
using System.Collections.Generic;
using System.Linq;

namespace Tests.sort
{
    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        public void QuickSort_Test()
        {
            //Arrange
            var array = new List<Node>
            {
                new Node(5),
                new Node(2),
                new Node(4),
                new Node(3),
                new Node(1)
            }.ToArray();
            
            //Act
            QuickSort.Sort(ref array);
            
            //Assert
            Assert.AreEqual(1, array.ElementAt(0).Number);
            Assert.AreEqual(2, array.ElementAt(1).Number);
            Assert.AreEqual(3, array.ElementAt(2).Number);
            Assert.AreEqual(4, array.ElementAt(3).Number);
            Assert.AreEqual(5, array.ElementAt(4).Number);
        }
    }
}
