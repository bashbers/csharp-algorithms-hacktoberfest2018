using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csharp_algorithms;
using exponentialsearch;

namespace Tests.search
{
    [TestClass]
    public class ExponentialSearchTest
    {
        [TestMethod]
        public void Search()
        {
            // Setup
            int[] arr = { 0, 1, 10, 13, 16, 20, 22, 28, 31, 39, 45, 55 };
            int searchElem = 10;


            // Search
            var result1 = ExponentialSearch.Search(arr, searchElem);
            searchElem = 11;
            var result2 = ExponentialSearch.Search(arr, searchElem); ;

            // Assert
            Assert.AreEqual(true, result1);
            Assert.AreEqual(false, result2);
        }
    }
}