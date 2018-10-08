using csharp_algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using linqsort;

namespace Tests.sort
{
    [TestClass]
    public class LinqsortTests
    {
        private readonly LinqSort linqSort;
        private readonly TestDataGenerator testDataGenerator;

        public LinqsortTests()
        {
            linqSort = new LinqSort();
            testDataGenerator = new TestDataGenerator();
        }

        [TestMethod]
        public void OrderBy()
        {
            var testData = testDataGenerator.Generate();
            
            var sorted = linqSort.OrderBy(testData.Copy());

            Assert.AreNotEqual(testData, sorted);
        }

        [TestMethod]
        public void TypedSort()
        {
            var testData = testDataGenerator.Generate();

            var sorted = linqSort.TypedSort(testData.Copy());

            Assert.AreNotEqual(testData, sorted);
        }

        [TestMethod]
        public void GenericSort()
        {
            var testData = testDataGenerator.Generate();

            var sorted = linqSort.GenericSort(testData.Copy());

            Assert.AreNotEqual(testData, sorted);
        }

        [TestMethod]
        public void CheckSortOrdersAreTheSame()
        {
            var testData = testDataGenerator.Generate();

            var genericSorted = linqSort.GenericSort(testData.Copy());
            var orderBySorted = linqSort.OrderBy(testData.Copy());
            var typedSorted = linqSort.TypedSort(testData.Copy());

            Assert.IsTrue(genericSorted.AreSameOrder(orderBySorted));
            Assert.IsTrue(genericSorted.AreSameOrder(typedSorted));
        }

        [TestMethod]
        public void CheckSortOrders()
        {
            var ordered = new Node[] { new Node(-999), new Node(10), new Node(15), new Node(88), new Node(99), new Node(569) };
            var unOrdered = new Node[] { new Node(10), new Node(88), new Node(-999), new Node(15), new Node(569), new Node(99) };

            var genericSorted = linqSort.GenericSort(unOrdered.Copy());
            var orderBySorted = linqSort.OrderBy(unOrdered.Copy());
            var typedSorted = linqSort.TypedSort(unOrdered.Copy());

            Assert.IsTrue(genericSorted.AreSameOrder(ordered));
            Assert.IsTrue(orderBySorted.AreSameOrder(ordered));
            Assert.IsTrue(typedSorted.AreSameOrder(ordered));
        }
    }
}