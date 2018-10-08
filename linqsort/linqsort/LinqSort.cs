using csharp_algorithms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace linqsort
{
    public class LinqSort
    {
        private readonly GenericComparer genericComparer;
        private readonly TypedComparer typedComparer;

        public LinqSort()
        {
            genericComparer = new GenericComparer();
            typedComparer = new TypedComparer();
        }

        public Node[] OrderBy(Node[] dataToSort)
        {
            return dataToSort.OrderBy(o => o.Number).ToArray();
        }

        public Node[] GenericSort(Node[] dataToSort)
        {
            Array.Sort(dataToSort, genericComparer);

            return dataToSort;
        }

        public Node[] TypedSort(Node[] dataToSort)
        {
            Array.Sort(dataToSort, typedComparer);

            return dataToSort;
        }

        private class GenericComparer : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                return ((new CaseInsensitiveComparer()).Compare(y, x));
            }
        }

        private class TypedComparer : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                if (x.Number > y.Number)
                {
                    return 1;
                }
                if (x.Number < y.Number)
                {
                    return -1;
                }
                return 0;
            }
        }
    }
}