using System.Collections.Generic;
using System.Linq;

namespace knapsackproblem
{
    public static class KnapsackProblem
    {
        public static HashSet<Thing> Resolve(IEnumerable<Thing> things, int maxWeight)
        {
            var orderedThings = things
                .OrderByDescending(thing => thing.EvaluationValue)
                .ThenByDescending(thing => thing.Weight)
                .ToArray();

            var currentWeight = 0;
            var result = new HashSet<Thing>();

            foreach (var thing in orderedThings)
            {
                if (maxWeight - currentWeight < thing.Weight) continue;

                currentWeight += thing.Weight;
                result.Add(thing);
                if (maxWeight - currentWeight == 0) break;
            }

            return result;
        }
    }
}
