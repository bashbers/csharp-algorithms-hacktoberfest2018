using heapsort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.sort
{
    [TestClass]
    public class HeapSortTests
    {
        [TestMethod]
        public void SortWithHeap()
        {
            //Arrange
            int[] testArray = { 1, 67, 41, 66, 123, 71, 5, 3, 7, 9, 99 };

            HeapSort heapSort = new HeapSort();
            
            //Act
            var sortedArray = heapSort.Sort(testArray);

            //Assert
            Assert.AreEqual(123,heapSort.MaximumElementIn(sortedArray));
            Assert.AreEqual(1,heapSort.MinimumElementIn(sortedArray));
        }
    }
}
