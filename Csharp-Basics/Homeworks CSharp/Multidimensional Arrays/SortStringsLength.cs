using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortStringsLength
{
    //You are given an array of strings.
    //Write a method that sorts the array by the length of its elements (the number of characters composing them).

    //Problem solved using QuickSort algorithm

    //KeyValuePair can store 2 values from different data types. So i stored the string and the length of the string
    //The quicksort algorthm is the same as for numbers. The only difference is that the algortihm sorts the KeyValuePairs
    //of the List by their values. The whole KeyValuePair is moved while sorting, not only the string or the length value
    //I WILL SKIP COMMENTS ON THIS METHOD BECAUSE ITS THE SAME. Just check KeyValuePair if you want more information
    static List<KeyValuePair<string, int>> QuickSort(List<KeyValuePair<string, int>> unsortedArray, int countIndexes)
    {
        if (unsortedArray.Count <= 1 || countIndexes <= 1)
        {
            return unsortedArray;
        }
        countIndexes--;
        int centerIndex = (unsortedArray.Count - 1) / 2;
        int numberInCenter = unsortedArray[centerIndex].Value;
        List<KeyValuePair<string, int>> lessNumbers = new List<KeyValuePair<string, int>>();
        List<KeyValuePair<string, int>> greaterNumber = new List<KeyValuePair<string, int>>();

        for (int index = 0; index < unsortedArray.Count; index++)
        {
            if (index != centerIndex)
            {
                if (unsortedArray[index].Value < unsortedArray[centerIndex].Value)
                {
                    lessNumbers.Add(unsortedArray[index]);
                }
                else if (unsortedArray[index].Value >= unsortedArray[centerIndex].Value)
                {
                    greaterNumber.Add(unsortedArray[index]);
                }
            }
        }
        List<KeyValuePair<string, int>> output = new List<KeyValuePair<string, int>>();
        output.AddRange(QuickSort(lessNumbers, countIndexes));
        output.Add(new KeyValuePair<string, int>(unsortedArray[centerIndex].Key, numberInCenter));
        output.AddRange(QuickSort(greaterNumber, countIndexes));
        return QuickSort(output, countIndexes);
    }

    static void Main()
    {
        //List<List<string>> unsorted = new List<List<string>>() { new List<string>() { "aaa" }, new List<string>() { "bbbbbb" } };
        //List<KeyValuePair<string, int>> unsorted = new List<KeyValuePair<string, int>>() { new KeyValuePair<string, int>("perls",5) };
        
        //Declaring the empty list
        List<KeyValuePair<string, int>> unsorted = new List<KeyValuePair<string, int>>();
        //Getting the input data and filling in the array the string and its length
        Console.WriteLine("How many strings do you want to input?");
        int elementsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < elementsCount; i++)
        {
            string currentInputString = Console.ReadLine();
            unsorted.Add(new KeyValuePair<string, int>(currentInputString, currentInputString.Length));
        }

        //Using the QuickSort method above, sorts the elements and return them back to the array
        unsorted = QuickSort(unsorted,elementsCount);

        //Printing strings on the console
        Console.Write("After QuickSort: ");

        foreach (var item in unsorted)
        {
            Console.Write(" \"{0}\"",item.Key);
        }
        Console.WriteLine();
    }
}