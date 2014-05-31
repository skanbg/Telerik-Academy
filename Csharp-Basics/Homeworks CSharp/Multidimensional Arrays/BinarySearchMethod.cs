using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinarySearchMethod
{
    //Write a program, that reads from the console an array of N integers and an integer K,
    //sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

    //QuickSort algorithm from the previous homework(no comments on this method)
    static List<int> QuickSort(List<int> unsortedArray, int countIndexes)
    {
        if (unsortedArray.Count <= 1 || countIndexes<= 1)
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
        output.AddRange(QuickSort(lessNumbers, countIndexes));
        output.Add(numberInCenter);
        output.AddRange(QuickSort(greaterNumber, countIndexes));
        return QuickSort(output, countIndexes);
    }

    static void Main()
    {
        List<int> unsorted = new List<int>();
        Console.WriteLine("How many numbers do you want to add to array?");
        int inputArraySize = int.Parse(Console.ReadLine());
        Console.WriteLine("Now type numbers");
        for (int i = 0; i < inputArraySize; i++)
        {
            unsorted.Add(int.Parse(Console.ReadLine()));
        }
        Console.WriteLine("Done! Now tell me which number(K) do you choose?");
        int inputK = int.Parse(Console.ReadLine());
        //Sorting the array using the QuickSort algorithm
        List<int> sorted = QuickSort(unsorted, unsorted.Count);
        //Applying the binarysearch
        int searchQuery = Array.BinarySearch(sorted.ToArray(), inputK);
        //Cases

        if (searchQuery<0)
        {
            int fromBinResultToIndex = ~searchQuery;
            if (fromBinResultToIndex>=inputArraySize)
            {
                Console.WriteLine("The searched number was missing. Number {1} is the largested number. The number before {1} is {0}", sorted[fromBinResultToIndex - 1], inputK);
            }
            else
            {
                Console.WriteLine("Number {0} was missing. The number is smaller than other numbers. The number AFTER(not before because its first) {0} is {1}", inputK ,sorted[fromBinResultToIndex]);
            }
            //The other way was using sorting and BinarySearch again, but its going to be slower than this 
            //unsorted.Add(inputK);
            //sorted = QuickSort(unsorted, unsorted.Count);
            //searchQuery = Array.BinarySearch(sorted.ToArray(), inputK);
        }
        else if (searchQuery==0)
        {
            Console.WriteLine("Number {0} is the first number in the array.", inputK);
        }
        else
        {
            Console.WriteLine("Number {0} is with index {1} and the number before it is {2}", inputK, searchQuery, sorted[searchQuery - 1]);
        }
    }
}