using System;
using System.Diagnostics;

namespace exponentialsearch
{
    public class ExponentialSearch
    {
        /**
         * Exponential Search method which defines a subset range from the 
         * given array and looks for the element in it.
         */
        public static Boolean Search(int[] arr, int elem)
        {
            int last = arr.Length - 1;

            if (last <= 0)
                return false;

            if (arr[0] == elem)
                return true;

            // Find the range in which we will be looking for the element
            int i = 1;
            while (i < last && arr[i] <= elem)
                i *= 2;

            return BinarySearchRecursive(arr, i / 2, Math.Min(i, last), elem);
        }

        /**
         * Binary Search is implemented through a recursive approach. If the
         * the elem is not found at the midIndex, the method is called again
         * with readjusted left or right range.
         */
        public static Boolean BinarySearchRecursive(int[] arr, int leftRange, int rightRange,
            int elem)
        {
            if (leftRange > rightRange)
                return false;

            // Calculate the middle of the range given. This way there is no overflow
            // in case of a larger array. For more info:
            // https://stackoverflow.com/questions/6735259/calculating-mid-in-binary-search
            int midIndex = leftRange + (rightRange - leftRange) / 2;

            // If element found, return index, otherwise adjust left or right range
            if (arr[midIndex] == elem)
                return true;
            else if (elem < arr[midIndex])
                return BinarySearchRecursive(arr, leftRange, midIndex - 1, elem);
            else if (elem > arr[midIndex])
                return BinarySearchRecursive(arr, midIndex + 1, rightRange, elem);
            return false;
        }

        public static Boolean BinarySearchIterative(int[] arr, int leftRange, int rightRange,
            int elem)
        {
            int midIndex = 0;
            while (leftRange <= rightRange)
            {
                midIndex = leftRange + (rightRange - leftRange) / 2;

                if (arr[midIndex] == elem)
                    return true;
                else if (elem < midIndex)
                    rightRange = midIndex - 1;
                else
                    leftRange = midIndex + 1;
            }

            return false;
        }

        public static void Main()
        {

        }
    }
}