using System;

namespace InterviewProblemSet
{
    public class ArrayFunctions
    {
        /// <summary>
        /// Merges two sorted arrays and preserves any duplicates.
        /// Runtime (and space) complexity is O(array1.Length + array2.Length)
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns>a new merged and sorted array</returns>
        public int[] MergeSortedArrays(int[] array1, int[] array2)
        {
            var mergedArray = new int[array1.Length + array2.Length];
            int currArray1Index = 0, currArray2Index = 0, currMergedIndex = 0;
            while (currMergedIndex < mergedArray.Length)
            {
                if (currArray2Index == array2.Length || 
                    ((currArray1Index < array1.Length) && (array1[currArray1Index] < array2[currArray2Index])))
                {
                    mergedArray[currMergedIndex] = array1[currArray1Index];
                    currArray1Index++;
                }
                else
                {
                    mergedArray[currMergedIndex] = array2[currArray2Index];
                    currArray2Index++;
                }
                currMergedIndex++;
            }
            return mergedArray;
        }

        /// <summary>
        /// A function that takes a list of integers and returns the maximum product that can be derived 
        /// from any three integers in the list. An ArgumentException is thrown for any input values 
        /// that will not produce a valid Int32 product
        /// 
        /// Runtime complexity on average is O(Nlog(N)) where N = the length of the array.  This is due to the call to Array.Sort
        /// which uses a Quicksort algorithm
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int GetMaxProductOf3Elements(int[] array)
        {
            if (array.Length < 3)
            {
                throw new ArgumentException("Need at least 3 array elements");
            }

            Array.Sort(array);

            try
            {
                var max1 = checked(array[array.Length - 1] * array[array.Length - 2] * array[array.Length - 3]);

                if (array.Length == 3)
                {
                    return max1;
                }

                // The largest and 2 smallest
                var max2 = checked(array[array.Length - 1] * array[0] * array[1]);

                return Math.Max(max1, max2);
            }
            catch (System.OverflowException e)
            {
                throw new ArgumentException("product is an invalid integer value");
            }
        }
    }
}