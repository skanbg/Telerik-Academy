using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinarySearch
{
    static void Main()
    {
        //Write a program that finds the index of given element in a sorted array of integers
        //by using the binary search algorithm (find it in Wikipedia).

        //Hardcoded Test
        //int[] intContainer = { 1, 4, 6, 7, 12, 13, 15, 18, 19, 20, 22, 24 };
        //int searchedNumber = 24;

        Console.WriteLine("How many elements the array will contain?");
        int elementsCount = int.Parse(Console.ReadLine());

        int[] intContainer = new int[elementsCount];
        Console.WriteLine("Please input the elements now:");
        for (int i = 0; i < elementsCount; i++)
        {
            intContainer[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Position of which number do you want: ");
        int searchedNumber = int.Parse(Console.ReadLine());

        int currentNumber = 0;
        int position = 0;
        int leftPosition = 0;
        int rightPosition = intContainer.Length-1;
        while (currentNumber!=searchedNumber)
        {
            //Calculating the center position between the current left and right positions
            int centerPosition = (leftPosition+rightPosition)/2;
            //getting the number on the center position
            currentNumber = intContainer[centerPosition];

            //If the searched number is the left or right element
            if (intContainer[leftPosition]==searchedNumber)
            {
                position = leftPosition;
                break;
            }
            else if (intContainer[rightPosition]==searchedNumber)
            {
                position = rightPosition;
                break;
            }

            //Changing position depending the number on the center position(smaller or greater than the searched number)
            if (currentNumber>searchedNumber)
            {
                rightPosition = centerPosition;
            }
            else if(currentNumber<searchedNumber)
            {
                leftPosition = centerPosition;
            }
            else
            {
                position = centerPosition;
                break;
            }
        }

        Console.WriteLine("Number {0} is on position(index) {1}",searchedNumber,position);
    }
}