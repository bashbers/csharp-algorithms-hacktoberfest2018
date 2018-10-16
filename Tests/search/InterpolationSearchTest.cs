using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csharp_algorithms;
using interpolationsearch;

namespace Tests.search
{
    [TestClass]
    public class InterpolationSearchTest
    {
        [TestMethod]
        public void Search()
        {
            //Arrange
            List<Node> list = new List<Node>
            {
                new Node(5),
                new Node(1),
                new Node(10),
                new Node(11)
            };
            InterpolationSearch s = new InterpolationSearch(list);
            //Act
            Node searchValue = new Node(11);
            var result1 = s.Search(searchValue);

            searchValue = new Node(12);
            var result2 = s.Search(searchValue);

            //Assert
            Assert.AreEqual(true, result1);
            Assert.AreEqual(false, result2);
        }
    }
}
