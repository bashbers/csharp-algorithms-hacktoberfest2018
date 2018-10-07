using csharp_algorithms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bogosort
{
    public class BogoSort
    {
        private readonly IEnumerable<Node> _list;
        public BogoSort(IEnumerable<Node> list)
        {
            this._list = list;
        }
   
        public IEnumerable<Node> Sort()
        {
            Random random = new Random();
            while (!IsSorted())
            {
                int a = random.Next(_list.Count());
                int b = random.Next(_list.Count());
                Swap(_list.ElementAt(a), _list.ElementAt(b));
            }
            return _list;
        }

        public IEnumerable<Node> ReverseSort()
        {
            Random random = new Random();
            while (!IsSorted())
            {
                int a = random.Next(_list.Count());
                int b = random.Next(_list.Count());
                Swap(_list.ElementAt(b), _list.ElementAt(a));
            }
            return _list;
        }

        private void Swap(Node left, Node right)
        {
            int originalLeft = left.Number;
            left.Number = right.Number;
            right.Number = originalLeft;
        }

        private bool IsSorted()
        {
            for (int i = 0; i < _list.Count(); i++)
            {
                Node currentNode = _list.ElementAt(i);
                for (int j = i+1; j < _list.Count(); j++)
                    if (currentNode.Number > _list.ElementAt(j).Number)
                        return false;
            }
            return true;
        }
    }
}
