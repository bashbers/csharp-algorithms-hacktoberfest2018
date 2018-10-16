using System.Collections.Generic;
using System.Linq;
using csharp_algorithms;
using System;

namespace jumpsearch
{
    public class JumpSearch
    {
        private readonly IEnumerable<Node> _list;
        public JumpSearch(IEnumerable<Node> list)
        {
            //Ordering the List in ascending order
            this._list = list.OrderBy(a=>a.Number);
        }

        public bool Search(Node value)
        {
            var listLength = _list.Count();

            // At first finding the Step Value based on the length of the list
            var jumpStep = (int)Math.Floor(Math.Sqrt(listLength));

            //Based of the Step value finding the value is present or not
            var prevStep = 0;
            while(_list.ElementAt(Math.Min(jumpStep, listLength) - 1).Number < value.Number)
            {
                prevStep = jumpStep;
                jumpStep += (int)Math.Floor(Math.Sqrt(listLength));
                if (prevStep >= listLength)
                    return false;
            }

            //Then we are doing a linear search from teh last Step Value which is less than the searched vale
            while (_list.ElementAt(prevStep).Number < value.Number)
            {
                prevStep++;
                if (prevStep == Math.Min(jumpStep, listLength))
                    return false;
            }

            //Returing true if the Value is present
            if (_list.ElementAt(prevStep).Number == value.Number)
                return true;

            return false;
        }
    }
}
