using System.Collections.Generic;

using System.Linq;

using csharp_algorithms;

namespace bubblesort

{

    public class InsertionSort

    {

        private readonly IEnumerable<Node> _list;

        public BubbleSort(IEnumerable<Node> list)

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

            for (int outer = 0; outer < _list.Count() -1; outer++)

            {

                 int inner = outer + 1 ;
                 Node current = _list.ElementAt(outer);

                    Node next = _list.ElementAt(inner);
                    Node next_01 = _list.ElementAt(inner -1 );
                    if( current.Number > next.Number)
                    {
                       while(inner -1 )
                       {
                          if( next_01.Number > next.Number)
                          {
                            swap(next_01,next);
                          }
                       }
                    }

            }

            return _list;

        }
}

