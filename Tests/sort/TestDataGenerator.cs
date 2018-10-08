using System;
using System.Collections.Generic;
using System.Linq;
using csharp_algorithms;

namespace Tests.sort
{
    class TestDataGenerator
    {
        private readonly int Min = int.MinValue;
        private readonly int Max = int.MaxValue;
        private readonly Random Random = new Random();

        public Node[] Generate(int entries = 256)
        {
            if (entries <= 2)
            {
                return new Node[0];
            }

            var data = Enumerable
                .Repeat(0, entries)
                .Select(i => new Node(Random.Next(Min, Max)))
                .ToArray();

            return data;
        }        
    }
}
