using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heapsort
{
    public class HeapSort
    {
        private static int n;

        private int LeftChildIndex(int i)
        {
            return (2 * i) + 1;
        }

        private int RightChildIndex(int i)
        {
            return (2 * i) + 2;
        }

        public int MinimumElementIn(int[] array)
        {
            return array[array.Length - 1];
        }

        public int MaximumElementIn(int[] array)
        {
            return array[0];
        }

        public int[] Sort(int[] array)
        {
            n = array.Length - 1;

            Heapify(ref array);
                                
            return array;       
        }

        private void Heapify(ref int[] array)
        {
            for (int i = n; i >= 0; i--) Heap(ref array, i);
        }

        private void Heap(ref int[] array, int i)
        {
            int left = LeftChildIndex(i); 
            int right = RightChildIndex(i);
            int largest = i; 

            if ((left <= n) && (array[left] > array[largest]))
                largest = left;

            if ((right <= n) && (array[right] > array[largest]))
                largest = right;

            if (largest != i)
            {
                int temp = array[i];
                array[i] = array[largest];
                array[largest] = temp;

                Heap(ref array, largest);
            }
        }       

    }
}
