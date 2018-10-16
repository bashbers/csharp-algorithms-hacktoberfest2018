using csharp_algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibonaccisearch
{
    public class FibonacciSearch
    {
        private readonly IEnumerable<Node> _list;

        public FibonacciSearch(IEnumerable<Node> list)
        {
            //Ordering list in ascending order
            _list = list.OrderBy(n => n.Number);
        }


        public bool Search(Node value)
        {
            var n = _list.Count();

            //Setting first three Fibonacci numbers
            var fib1 = 0;
            var fib2 = 1;
            var fibSum = 1;

            //Searching for the smallest number in Fibonacci sequence that is equal or greater than n
            while (fibSum < n)
            {
                fib2 = fib1;
                fib1 = fibSum;
                fibSum = fib1 + fib2;
            }

            //Setting starting position for searching
            var offset = -1;

            //Searching as long as there are still items in list
            while (fibSum > 1)
            {
                //Checking if index is in bounds of list
                int i = Math.Min(offset + fib2, n - 1);

                //If value at given index is lower or greater than searched one, the offset is updated
                if (_list.ElementAt(i).Number < value.Number)
                {
                    fibSum = fib1;
                    fib1 = fib2;
                    fib2 = fibSum - fib1;
                    offset = i;
                }
                else if (_list.ElementAt(i).Number > value.Number)
                {
                    fibSum = fib2;
                    fib1 = fib1 - fib2;
                    fib2 = fibSum - fib1;
                }
                //If values match methods returns true
                else return true;
            }
            return false;
        }
    }
}
