using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sleepsort;

namespace Tests.sort
{
    [TestClass]
    public class SleepSortTests
    {
        private readonly SleepSorter _sorter;

        public SleepSortTests() => _sorter = new SleepSorter();

        [TestMethod]
        public void Sort_EmptyList_EmptyListReturned()
        {
            var emptyList = new List<int>();

            var result = _sorter.Sort(emptyList);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Sort_SinlgeItemList_SameListReturned()
        {
            var list = new List<int> { 1 };

            var result = _sorter.Sort(list);

            Assert.AreEqual(1, result[0]);
        }

        [TestMethod]
        public void Sort_NegativeNumberInList_ExceptionThrown()
        {
            var list = new List<int> { -1, 3, 9 };

            Assert.ThrowsException<ArgumentException>(() => _sorter.Sort(list));
        }

        [TestMethod]
        public void Sort_UnsortedList_SortedListReturned()
        {
            var list = new List<int> { 1, 5, 2, 4, 8, 3, 12, 10 };
            var sortedList = new List<int> { 1, 2, 3, 4, 5, 8, 10, 12 };

            var result = _sorter.Sort(list);

            Assert.AreEqual(sortedList[0], result[0]);
            Assert.AreEqual(sortedList[1], result[1]);
            Assert.AreEqual(sortedList[2], result[2]);
            Assert.AreEqual(sortedList[3], result[3]);
            Assert.AreEqual(sortedList[4], result[4]);
            Assert.AreEqual(sortedList[5], result[5]);
            Assert.AreEqual(sortedList[6], result[6]);
            Assert.AreEqual(sortedList[7], result[7]);
        }
    }
}
