using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MostFrequentNumber
{
    //Write a program that finds the most frequent number in an array. Example:
    //{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
    //I SOLVED THIS PROBLEM USING ALGORITHMS NOT THE BUILD IN FUNCTIONS/METHODS
    static int[] SortArray(int[] unsortedArray)
    {
        //This is the selection sort algorithm
        //Check this helpful and easy to understand(helped me much) blog article if you need help: http://syssboxx.blogspot.com/
        int sortedElementsCount = 0;
        while (sortedElementsCount < unsortedArray.Length)
        {
            int tempMinNumber = int.MaxValue;
            int positionOfTheFoundMinValue = 0;
            for (int i = sortedElementsCount; i < unsortedArray.Length; i++)
            {
                if (unsortedArray[i] < tempMinNumber)
                {
                    positionOfTheFoundMinValue = i;
                    tempMinNumber = unsortedArray[i];
                }
            }
            int tempReplacer = unsortedArray[sortedElementsCount];
            unsortedArray[sortedElementsCount] = tempMinNumber;
            unsortedArray[positionOfTheFoundMinValue] = tempReplacer;
            sortedElementsCount++;
        }
        return unsortedArray;
    }

    static int[] ReturnMostFrequentNumber(int[] sortedArray)
    {
        //If the number is the same as the previous number, repeats are incremented. If repeats exceed maxRepeats, than the repeated number is stored as the most frequent
        int lastNumber = sortedArray[0];
        int repeats = 1;
        int maxRepeats = 0;
        int maxRepeatedNumber = 0;
        for (int i = 1; i < sortedArray.Length; i++)
        {
            if (lastNumber==sortedArray[i])
            {
                repeats++;
            }
            else
            {
                lastNumber = sortedArray[i];
                repeats=1;
            }

            if (repeats>maxRepeats)
            {
                maxRepeatedNumber = sortedArray[i];
                maxRepeats = repeats;
            }
        }
        //Returning array with the count of repeats and the most repeated number
        return new int[] { maxRepeats,maxRepeatedNumber};
    }

    static void Main()
    {
        //Write a program that finds the most frequent number in an array. Example:
        //{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

        //Hardcoded input
        //int[] intContainer = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

        //If you wish to use the hardcode - Comment from here to -------------------
        Console.WriteLine("How many elements the array will contain?");
        int elementsCount = int.Parse(Console.ReadLine());

        int[] intContainer = new int[elementsCount];
        Console.WriteLine("Please input the elements now:");
        for (int i = 0; i < elementsCount; i++)
        {
            intContainer[i] = int.Parse(Console.ReadLine());
        }
        // to here -----------------------------------------------------------------
        int[] printResult = ReturnMostFrequentNumber(SortArray(intContainer));

        if (printResult[0]>1)
        {
            Console.WriteLine("Number {0} is repeated {1} times!", printResult[1], printResult[0]);
        }
        else
        {
            Console.WriteLine("No duplicate numbers!");
        }
    }
}