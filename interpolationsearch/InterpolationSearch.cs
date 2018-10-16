using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_algorithms;

namespace interpolationsearch
{
    public class InterpolationSearch
    {
        private readonly IEnumerable<Node> _list;
        public InterpolationSearch(IEnumerable<Node> list)
        {
            //Ordering the List in ascending order
            this._list = list.OrderBy(a=>a.Number);
        }

        public bool Search(Node value)
        {
            var lowIndex = 0;
            int highIndex = _list.Count() - 1;
            int midIndex;

            while (_list.ElementAt(lowIndex).Number < value.Number && _list.ElementAt(highIndex).Number >= value.Number)
            {
                midIndex = lowIndex + ((value.Number - _list.ElementAt(lowIndex).Number) * (highIndex - lowIndex)) / (_list.ElementAt(highIndex).Number - _list.ElementAt(lowIndex).Number);
                if(_list.ElementAt(midIndex).Number < value.Number)
                    lowIndex = midIndex + 1;
                else if(_list.ElementAt(midIndex).Number > value.Number)
                    highIndex = midIndex - 1;
                else
                    return true;
            }

            if (_list.ElementAt(lowIndex).Number == value.Number)
                return true;
            else
                return false;
        }
    }
}
