using csharp_algorithms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace insertionSort
{
    public class InsertionSort
    {
        private readonly IEnumerable<Node> _list;
        public InsertionSort(IEnumerable<Node> list)
        {
            this._list = list;
        }

        private IEnumerable<Node> Reverse(IEnumerable<Node> list)
        {
            return list.Reverse();
        }

        public IEnumerable<Node> Sort()
        {
            for(int i = 1; i < _list.Count(); i++)
            {
                Node key = _list.ElementAt(i);
                int j;
                for(j = i - 1; j >= 0 && _list.ElementAt(j).Number > key.Number; j--)
                {
                    _list.ElementAt(j + 1).Number = _list.ElementAt(j).Number;
                }
                _list.ElementAt(j).Number = key.Number;
            }
            return _list;
        }

        public IEnumerable<Node> ReverseSort()
        {
            return Reverse(Sort());
        }
    }
}