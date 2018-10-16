using csharp_algorithms;

namespace quicksort
{
    public static class QuickSort
    {
        public static void Sort(ref Node[] arr) =>
            Sort(ref arr, 0, arr.Length - 1);

        private static void Sort(ref Node[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int pivotIndex = Partition(ref array, leftIndex, rightIndex);

                if (pivotIndex > 1)
                {
                    Sort(ref array, leftIndex, pivotIndex - 1);
                }
                if (pivotIndex + 1 < rightIndex)
                {
                    Sort(ref array, pivotIndex + 1, rightIndex);
                }
            }
        }

        private static int Partition(ref Node[] array, int leftIndex, int rightIndex)
        {
            // Arbitrarily choose the left most element in this set as a pivot
            var pivot = array[leftIndex];

            while (leftIndex < rightIndex)
            {
                // The next two loops are determining the elements in this set
                // that will be evaluated to swap.
                while (array[leftIndex].Number < pivot.Number)
                {
                    leftIndex++;
                }

                while (array[rightIndex].Number > pivot.Number)
                {
                    rightIndex--;
                }

                if (leftIndex < rightIndex)
                {
                    if (array[leftIndex] == array[rightIndex])
                    {
                        // No need to swap anything. Values are the same.
                        return rightIndex;
                    }

                    // Values are not the same. Swap values.
                    var transient = array[leftIndex]; 
                    array[leftIndex] = array[rightIndex];
                    array[rightIndex] = transient;
                }
                else
                {
                    return rightIndex;
                }
            }

            return rightIndex;
        }
    }
}
