using System.Collections.Generic;
using System.Linq;
using csharp_algorithms;

namespace bubblesort
{
    public class BubbleSort
    {
        private readonly IEnumerable<Node> _list;
        public BubbleSort(IEnumerable<Node> list)
        {
            this._list = list;
        }

        private void Swap(Node left, Node right)
        {
            int originalLeft = left.Number;
            left.Number = right.Number;
            right.Number = originalLeft;
        }

        public IEnumerable<Node> Sort()
        {
            for (int outer = 0; outer < _list.Count() -1; outer++)
            {
                for (int inner = 0; inner < _list.Count() - outer -1; inner++)
                {
                    Node current = _list.ElementAt(inner);
                    Node next = _list.ElementAt(inner + 1);
                    if (current.Number > next.Number)
                    {
                        Swap(current, next);
                    }
                }
            }
            return _list;
        }

        public IEnumerable<Node> ReverseSort()
        {
            for (int outer = _list.Count() -1; outer >= 0; outer--)
            {
                for (int inner = _list.Count() - 1; inner > 0; inner--)
                {
                    Node current = _list.ElementAt(inner);
                    Node next = _list.ElementAt(inner - 1);
                    if (current.Number < next.Number)
                    {
                        Swap(current, next);
                    }
                }
            }
            return _list;
        }
    }
}
