using System;
using System.Collections.Generic;
using System.Linq;
using csharp_algorithms;

namespace MergeSort
{
    public class MergeSort
    {
        public static void Sort(ref IEnumerable<Node> array)
        {
            if (array != null && array.Count() > 1)
            {
                int middle = Convert.ToInt32(array.Count() / 2);

                Node[] left = new Node[middle];
                for (int i = 0; i <= left.Count() - 1; i++)
                {
                    left[i] = new Node(array.ElementAt(i).Number);
                }

                Node[] right = new Node[array.Count() - middle];
                for (int i = middle; i <= array.Count() - 1; i++)
                {
                    right[i-middle] = new Node(array.ElementAt(i).Number);
                }

                IEnumerable<Node> leftArray = left;
                IEnumerable<Node> rightArray = right;
                Sort(ref leftArray);
                Sort(ref rightArray);

                array = Merge(ref leftArray, ref rightArray);
            }
        }

        private static IEnumerable<Node> Merge(ref IEnumerable<Node> left, ref IEnumerable<Node> right)
        {
            Node[] newArray = new Node[left.Count() + right.Count()];
            int leftIndex = 0, rightIndex = 0, indexResult = 0;

            while (leftIndex < left.Count() && rightIndex < right.Count())
            {
                if (left.ElementAt(leftIndex).Number < right.ElementAt(rightIndex).Number)
                {
                    newArray[indexResult] = new Node(left.ElementAt(leftIndex).Number);
                    leftIndex += 1;
                } else
                {
                    newArray[indexResult] = new Node(right.ElementAt(rightIndex).Number);
                    rightIndex += 1;
                }
                indexResult += 1;
            }

            while (leftIndex < left.Count())
            {
                newArray[indexResult] = new Node(left.ElementAt(leftIndex).Number);
                leftIndex += 1;
                indexResult += 1;
            }

            while (rightIndex < right.Count())
            {
                newArray[indexResult] = new Node(right.ElementAt(rightIndex).Number);
                rightIndex += 1;
                indexResult += 1;
            }

            return newArray;
        }
    }
}
