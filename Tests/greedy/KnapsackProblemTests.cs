using System;
using System.Collections.Generic;
using System.Linq;
using knapsackproblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.greedy
{
    [TestClass]
    public class KnapsackProblemTests
    {
        [TestMethod]
        public void ResolveTest()
        {
            var maxWeight = 6;
            var result = KnapsackProblem.Resolve(CreateThings(), maxWeight);
            var sumWeight = result.Sum(thing => thing.Weight);
            var sumValue = result.Sum(thing => thing.Value);
            Assert.IsTrue(sumWeight <= maxWeight);

            Console.WriteLine($"SumValue:{sumValue}, SumWeight:{sumWeight}, MaxWeight:{maxWeight}");
            Console.WriteLine("Result[] = {");
            foreach (var thing in result)
            {
                Console.WriteLine($"    Value:{thing.Value}, Weight:{thing.Weight}");
            }
            Console.WriteLine("}");
            
        }

        public IEnumerable<Thing> CreateThings()
        {
            return new[]
            {
                new Thing(4, 7),
                new Thing(5, 8),
                new Thing(1, 1),
                new Thing(3, 2),
            };

        }

    }
}