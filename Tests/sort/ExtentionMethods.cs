using System;
using System.Linq;
using csharp_algorithms;

namespace Tests.sort
{
    internal static class ExtentionMethods
    {
        public static Node[] Copy(this Node[] array)
        {
            Node[] arrayCopy = new Node[array.Length];
            Array.Copy(array, arrayCopy, array.Length);
            return arrayCopy;
        }
                
        public static bool AreSameOrder(this Node[] a, Node[] b)
        {
            if (a == null|| b == null) return false;
            if (a.Count() != b.Count()) return false;

            foreach(var node in a)
            {
                var indexOfNode = Array.IndexOf(a, node);
                if (b[indexOfNode].Number == node.Number)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return a.Count() == b.Count();
        }
    }
}