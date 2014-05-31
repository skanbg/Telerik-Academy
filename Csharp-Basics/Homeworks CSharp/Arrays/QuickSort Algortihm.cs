using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class QuickSort
{
    //Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
    static List<int> QuickSortMethod(List<int> unsortedArray, int countIndexes)
    {
        if (unsortedArray.Count <= 1 || countIndexes <= 1)
        {
            return unsortedArray;
        }
        countIndexes--;
        int centerIndex = (unsortedArray.Count - 1) / 2;
        int numberInCenter = unsortedArray[centerIndex];
        List<int> lessNumbers = new List<int>();
        List<int> greaterNumber = new List<int>();

        for (int index = 0; index < unsortedArray.Count; index++)
        {
            if (index != centerIndex)
            {
                if (unsortedArray[index] < unsortedArray[centerIndex])
                {
                    lessNumbers.Add(unsortedArray[index]);
                }
                else if (unsortedArray[index] >= unsortedArray[centerIndex])
                {
                    greaterNumber.Add(unsortedArray[index]);
                }
            }
        }
        List<int> output = new List<int>();
        output.AddRange(QuickSortMethod(lessNumbers, countIndexes));
        output.Add(numberInCenter);
        output.AddRange(QuickSortMethod(greaterNumber, countIndexes));
        return QuickSortMethod(output, countIndexes);
    }

    static void Main()
    {
        List<int> unsorted = new List<int>() { 4, 1, 8, 0, 3, 5, 0, 4, 2, 9 };
        //Sorting the array using the QuickSortMethod algorithm
        List<int> sorted = QuickSortMethod(unsorted, unsorted.Count);
        Console.Write("Sorted array: ");
        foreach (int number in sorted)
        {
            Console.WriteLine("{0}", number);
        }
    }
}