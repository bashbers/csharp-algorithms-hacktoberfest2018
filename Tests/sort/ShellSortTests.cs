using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shellsort;

namespace Tests.sort
{
    [TestClass]
    public class ShellSortTests
    {
        [TestMethod]
        public void SortNormally()
        {
            var array = new[] { 25, 17, 49, 1, 195, 58 };

            var shellSort = new ShellSort(array);

            var result = shellSort.Sort().ToList();

            Assert.AreEqual(1, result.First());
            Assert.AreEqual(195, result.Last());
        }
    }
}
