using System.Collections.Generic;
using System.Linq;
using csharp_algorithms;
namespace Selectionsort
{
    public class SelectionSort
    {
        private readonly IEnumerable<Node> _list;
        public SelectionSort(IEnumerable<Node> list)
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
            for (int outer = 0; outer < _list.Count(); outer++)
            {
                Node outerItem = _list.ElementAt(outer);
                for (int inner = outer + 1; inner < _list.Count(); inner++)
                {
                    Node innerItem = _list.ElementAt(inner);
                    if (outerItem.Number > innerItem.Number)
                    {
                        Swap(outerItem, innerItem);
                    }
                }
            }
            return _list;
        }
        public IEnumerable<Node> ReverseSort()
        {
            for (int outer = _list.Count() - 1; outer > 0; outer--)
            {
                Node outerItem = _list.ElementAt(outer);
                for (int inner = outer - 1; inner >= 0; inner--)
                {
                    Node innerItem = _list.ElementAt(inner);
                    if (outerItem.Number < innerItem.Number)
                    {
                        Swap(outerItem, innerItem);
                    }
                }
            }
            return _list;
        }
    }
}