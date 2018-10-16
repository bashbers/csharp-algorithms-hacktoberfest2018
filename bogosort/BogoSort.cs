using System;
using System.Collections.Generic;
using System.Linq;
using csharp_algorithms;

namespace bogosort
{
    public class BogoSort
    {
        private readonly IEnumerable<Node> _list;
        public BogoSort(IEnumerable<Node> list)
        {
            _list = list;
        }

        private void Swap(Node left, Node right)
        {
            int originalLeft = left.Number;
            left.Number = right.Number;
            right.Number = originalLeft;
        }

        private bool IsSorted()
        {
            for (int i = 0; i < _list.Count() - 1; i++)
            {
                if (_list.ElementAt(i).Number > _list.ElementAt(i + 1).Number)
                {
                    return false;
                }
            }
            return true;
        }

        private void Shuffle()
        {
            for (int i = 0; i < _list.Count(); i++)
            {
                Random swapper = new Random();

                Node curr = _list.ElementAt(i);
                Node swap = _list.ElementAt(swapper.Next(_list.Count()));
                Swap(curr, swap);
            }
        }

        public IEnumerable<Node> Sort()
        {
            while (!IsSorted())
            {
                Shuffle();
            }
            return _list;
        }
    }
}
