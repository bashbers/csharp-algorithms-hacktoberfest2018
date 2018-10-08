using System;

namespace csharp_algorithms
{
    public class Node : IComparable, IComparable<Node>
    {
        public int Number { get; set; }

        public Node(int number)
        {
            this.Number = number;
        }

        public int CompareTo(object obj)
        {
            return CompareTo((Node)obj);
        }

        public int CompareTo(Node other)
        {
            if (Number > other.Number) return -1;
            if (Number == other.Number) return 0;
            return 1;
        }
    }
}