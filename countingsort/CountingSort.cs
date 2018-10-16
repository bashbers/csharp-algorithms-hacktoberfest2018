using System.Collections.Generic;
using System.Linq;
using csharp_algorithms;

namespace countingsort
{
    public class CountingSort
    {
        private readonly IEnumerable<Node> _list;
        private int[] counts;
        private int minVal;
        private int maxVal;

        public CountingSort(IEnumerable<Node> list)
        {
            _list = list;
            GetMinMax();
            counts = new int[maxVal - minVal + 1];
        }

        private void GetMinMax()
        {
            minVal = _list.ElementAt(0).Number;
            maxVal = minVal;

            for (int i = 0; i < _list.Count(); i++)
            {
                int currVal = _list.ElementAt(i).Number;
                if (currVal < minVal)
                {
                    minVal = currVal;
                }
                if (currVal > maxVal)
                {
                    maxVal = currVal;
                }
            }
        }

        private void Swap(Node left, Node right)
        {
            int originalLeft = left.Number;
            left.Number = right.Number;
            right.Number = originalLeft;
        }

        public IEnumerable<Node> Sort()
        {
            int[] sorted = new int[_list.Count()];
            for (int i = 0; i < _list.Count(); i++)
            {
                counts[_list.ElementAt(i).Number - minVal] += 1;
            }

            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] += counts[i - 1];
            }

            for (int i = _list.Count() - 1; i >= 0; i--)
            {
                sorted[counts[_list.ElementAt(i).Number - minVal]--] = _list.ElementAt(i).Number;
            }

            for (int i = 0; i < _list.Count(); i++)
            {
                _list.ElementAt(i).Number = sorted[i];
            }

            return _list;
        }
    }
}
