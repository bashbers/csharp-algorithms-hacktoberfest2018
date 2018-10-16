  using System.Collections.Generic;

using System.Linq;

using csharp_algorithms;

namespace binarysearch
{
   public BS
   {
            private readonly IEnumerable<Node> _list;

        public BubbleSort(IEnumerable<Node> list)

        {

            this._list = list;

        }
        public int binary_search( int number)
        {
         int left = 0;
        int right = _list.Count();
        while(left < right )
        {
            Node current = _list.ElementAt( (left + right )/ 2);
            if( current.Number == number )
            {
            return  (left + right )/2 ;            
            }
            else 
            {
                if( number > current.Number)
                {
                    left = (left + right )/2;
                }
                else 
                {
                    right = (left + right )/2;
                }
            }
        }
        return ;
        }
   }

}
