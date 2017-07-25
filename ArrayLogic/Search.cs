using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLogic
{
    public static class Search
    {
        /// <summary>
        /// search the position of the element into sorted array
        /// </summary>
        /// <typeparam name="T">type parameter</typeparam>
        /// <param name="element">element value</param>
        /// <param name="array">sorted array</param>
        /// <param name="comparer">comparer</param>
        /// <returns>position of element, -1 if such element dont't exists in array</returns>
        public static int BinarySearch<T>(this T[] array, T element, IComparer<T> comparer)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (comparer.Compare(element, array[middle]) > 0)
                {
                    left = middle + 1;
                }
                else if (comparer.Compare(element, array[middle]) < 0)
                {
                    right = middle - 1;
                }
                else return middle;
            }
            return -1;
        }
    }
}
