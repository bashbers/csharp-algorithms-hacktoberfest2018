using System;
using System.Collections.Generic;
using System.Linq;
using csharp_algorithms;

namespace binarysearch
{
    public class BinarySearch
    {
        private readonly IEnumerable<Node> _list;

        public BinarySearch(IEnumerable<Node> list)
        {
            //Ordering list in ascending order
            _list = list.OrderBy(n => n.Number);
        }

        //This is nullable int because if we can't find the value inside the list
        //we will return null in order to notify the user.
        public int? Search(Node value)
        {
            int left = 0;
            int right = _list.Count() - 1;
            int mid;

            //We will loop until the search space does not contain any value
            while(left <= right)
            {
                //we find mid in order to compare it to Node value.
                mid = (left + right) / 2;

                //If we find our value return it's index
                if(value.Number == _list.ElementAt(mid).Number)
                {
                    return mid;
                }
                //If our number is smaller than the mid value we're going to shrink our array by getting
                //our right index next to mid index
                else if(value.Number < _list.ElementAt(mid).Number)
                {
                    right = mid - 1;
                }
                //Same as previous step but since this time out value is bigger than the middle one from the array,
                //we are going to search the upper part of the array.
                else
                {
                    left = mid + 1;
                }
            }
            //If we got here, we couldn't find our value inside our array.
            return null;
        }
    }
}
