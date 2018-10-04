using System.Collections.Generic;
using System.Linq;
using csharp_algorithms;

namespace linearsearch
{
    public class LinearSearch
    {
        private readonly IEnumerable<Node> _list;
        public LinearSearch(IEnumerable<Node> list)
        {
            this._list = list;
        }

        public bool Search(Node value)
        {
            for (int i = 0; i < _list.Count(); i++)
            {
                Node currentValue = _list.ElementAt(i);
                if (currentValue.Number == value.Number)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
