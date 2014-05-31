using System;
using System.Linq;

class LexicographicallComparison
{
    static void Main()
    {
        /*
        Write a program that compares two char arrays lexicographically (letter by letter).
        */

        //Filling the first Array
        Console.WriteLine("How many elements will contain the first array?");
        int elementsCount = int.Parse(Console.ReadLine());

        char[] firstArray = new char[elementsCount];
        Console.WriteLine("Please input the elements now:");
        for (int i = 0; i < elementsCount; i++)
        {
            firstArray[i] = char.Parse(Console.ReadLine());
        }

        //Filling the Second array
        Console.WriteLine("How many elements will contain the second array?");
        int elementsCountSecond = int.Parse(Console.ReadLine());

        char[] secondArray = new char[elementsCountSecond];
        Console.WriteLine("Please input the elements(characters) one by one now:");
        for (int i = 0; i < elementsCountSecond; i++)
        {
            secondArray[i] = char.Parse(Console.ReadLine());
        }

        //If you wish to use my tests, UNCOMMENT EXAMPLES TO TEST THE HOMEWORK

        //The first array is shorter and matches with the first 5 chars from the second array.
        //The first array is lexicographically first because the first array is shorter
        //char[] firstArray = new char[5] { 'a', 'b', 'c', 'd', 'e' };
        //char[] secondArray = new char[8] { 'a', 'b', 'c', 'd', 'e', 'j', 'k', 'i' };

        //Second array is lexicographically first because of the char with index 1
        //char[] firstArray = new char[5] { 'a', 'v', 'c', 'd', 'e' };
        //char[] secondArray = new char[5] { 'a', 'b', 'c', 'd', 'e' };

        //Identical Arrays
        //char[] firstArray = new char[5] { 'a', 'b', 'c', 'd', 'e' };
        //char[] secondArray = new char[5] { 'a', 'b', 'c', 'd', 'e' };

        //Checking the array with minimum length
        int minimumArrayLength = Math.Min(firstArray.Length, secondArray.Length);
        int lexicographicallFirstArray = 0;

        for (int currentCharIndex = 0; currentCharIndex < minimumArrayLength; currentCharIndex++)
        {
            //If no array is leading the comparison
            if (lexicographicallFirstArray == 0)
            {
                //Checking the char order and setting the result to lexicographicallFirstArray the first array (if chars are not the same)
                if (firstArray[currentCharIndex] < secondArray[currentCharIndex])
                {
                    lexicographicallFirstArray = 1;
                }
                else if (firstArray[currentCharIndex] > secondArray[currentCharIndex])
                {
                    lexicographicallFirstArray = 2;
                }
            }
            else
            {
                //Breaking the loop because we already found which array is first
                break;
            }
        }

        if (lexicographicallFirstArray == 1)
        {
            Console.WriteLine("The first array is lexicographically first");
        }
        else if (lexicographicallFirstArray == 2)
        {
            Console.WriteLine("The second array is lexicographically first");
        }
        else
        {
            //If arrays are identical till the smaller array length

            if (firstArray.Length < secondArray.Length)
            {
                //Identical but the first array is shorter
                Console.WriteLine("The first array is lexicographically first");
            }
            else if (firstArray.Length > secondArray.Length)
            {
                //Identical but the second array is shorter
                Console.WriteLine("The second array is lexicographically first");
            }
            else
            {
                //Identical and with the same length
                Console.WriteLine("The two arrays are identical");
            }
        }
    }
}