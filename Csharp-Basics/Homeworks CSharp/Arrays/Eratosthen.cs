using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Eratosthen
{
    static void Main()
    {
        //Write a program that finds all prime numbers in the range [1...10 000 000].
        //Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

        Console.WriteLine("Write the last number to get all Prime: ");
        int inputN = int.Parse(Console.ReadLine());
        int[] intContainer = new int[inputN - 1];

        //Filling the array
        for (int i = 0; i < inputN - 1; i++)
        {
            intContainer[i] = i + 2;
        }

        //Using counter i check if all numbers are turned to zeroes or are prime
        int counter = inputN - 1;
        //The current position of the prime number that i am using to divide with
        int currentPosition = 0;
        while (counter > 0)
        {
            //Variable containing the last prime number 
            int tempNumber = intContainer[currentPosition];
            
            //while loop to get number different from Zero
            while (tempNumber == 0 && currentPosition<(inputN-1))
            {
                //break if no numbers left
                if (currentPosition >= (inputN - 1))
                {
                    break;
                }
                //New value to tempNumber, because prime number is found
                tempNumber = intContainer[currentPosition];
                currentPosition++;
                counter--;
            }

            //Loop walking through the numbers and checking if they are devidable by the tempNumber we got above. If they got remainder its prime, if not we change its value to 0
            for (int i = 0; i < inputN - 1; i++)
            {
                if (intContainer[i] != tempNumber && intContainer[i] > 1)
                {
                    if (intContainer[i] % tempNumber == 0)
                    {
                        intContainer[i] = 0;
                        counter--;
                    }
                }
            }
            currentPosition++;
        }

        Console.WriteLine("Prime numbers after the sieve of Eratosthenes algorithm: ");

        foreach (var item in intContainer)
        {
            if (item!=0)
            {
                Console.WriteLine(item);
            }
        }
    }
}