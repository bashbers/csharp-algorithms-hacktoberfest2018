using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_algorithms;

namespace gnomesort
{
    public class GnomeSort
    {
        private readonly IEnumerable<Node> _list;

        public GnomeSort(IEnumerable<Node> list)
        {
            _list = list;
        }

        private void Swap(Node left, Node right)
        {
            int originalLeft = left.Number;
            left.Number = right.Number;
            right.Number = originalLeft;
        }

        public IEnumerable<Node> Sort()
        {
            var i = 0;
            while (i < _list.Count())
                if (i == 0 || _list.ElementAt(i).Number > _list.ElementAt(i - 1).Number)
                {
                    i++;
                }
                else
                {
                    Swap(_list.ElementAt(i), _list.ElementAt(i - 1));
                    i--;
                }

            return _list;
        }
    }
}
