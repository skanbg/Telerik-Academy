using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortAsc
{
    static void Main()
    {
        //Sorting an array means to arrange its elements in increasing order.
        //Write a program to sort an array. Use the "selection sort" algorithm:
        //Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

        Console.WriteLine("How many elements the array will contain?");
        int elementsCount = int.Parse(Console.ReadLine());

        //int[] intContainer = new int[elementsCount];
        //Using the list array i write the input numbers, because i want to delete elemets from it later
        List<int> intContainer = new List<int>();
        Console.WriteLine("Please input the elements now:");
        for (int i = 0; i < elementsCount; i++)
        {
            intContainer.Add(int.Parse(Console.ReadLine()));
        }

        List<int> resultContainer = new List<int>();

        //using the build in function/method of the lists(.min)
        for (int i = 0; i < elementsCount; i++)
        {
            //Finding the number with Min value
            int elementToRemove = intContainer.Min();
            //Adding that number to the result array
            resultContainer.Add(elementToRemove);
            //Removing the number from the original array so it wont duplicate
            intContainer.Remove(elementToRemove);
        }

        //Printing the result
        Console.Write("Sorted Array: {");
        for (int i = 0; i < resultContainer.Count; i++)
        {
            if (i == 0)
            {
                Console.Write(resultContainer[i]);
            }
            else
            {
                Console.Write(", {0}", resultContainer[i]);
            }
        }
        Console.WriteLine("}");
    }
}