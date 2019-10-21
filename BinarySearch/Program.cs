using System;

namespace BinarySearch
{
    class Program
    {
        //метод для рекурсивного бинарного поиска
        static int BinarySearch(int[] array, int searchedValue, int first, int last)
        {
            //границы сошлись
            if (first > last)
            {
                //элемент не найден
                return -1;
            }

            //средний индекс подмассива
            var middle = (first + last) / 2;
            //значение в средине подмассива
            var middleValue = array[middle];

            if (middleValue == searchedValue)
            {
                return middle;
            }
            else
            {
                if (middleValue > searchedValue)
                {
                    //рекурсивный вызов поиска для левого подмассива
                    return BinarySearch(array, searchedValue, first, middle - 1);
                }
                else
                {
                    //рекурсивный вызов поиска для правого подмассива
                    return BinarySearch(array, searchedValue, middle + 1, last);
                }
            }
        }

        //программа для бинарного поиска элемента в упорядоченном массиве
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search");
            Console.Write("Enter elements: ");
            var s = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            var array = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                array[i] = Convert.ToInt32(s[i]);
            }
             
            Array.Sort(array);
            Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", array));

            while (true)
            {
                Console.Write("Enter search element or -777 for exit: ");
                var k = Convert.ToInt32(Console.ReadLine());
                if (k == -777)
                {
                    break;
                }

                var searchResult = BinarySearch(array, k, 0, array.Length - 1);
                if (searchResult < 0)
                {
                    Console.WriteLine("Element {0} wasn't founded", k);
                }
                else
                {
                    Console.WriteLine("Element was founded {0} index :{1}", k, searchResult);
                }
            }

            Console.ReadLine();
        }
    }
}
