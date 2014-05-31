using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GCDCalculation
{
    static void Main()
    {
        //Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).

        int[] arrayMix = new int[2];
		
		//Console input data
        Console.Write("The first number: ");
        bool checkIsItNumber = int.TryParse(Console.ReadLine(), out arrayMix[0]);
        Console.Write("The second number: ");
        bool checkIsBNumber = int.TryParse(Console.ReadLine(), out arrayMix[1]);

		//If numbers are in correct format
        if (checkIsItNumber && checkIsBNumber)
        {]
            int maxNum = arrayMix.Max();
            int minNum = arrayMix.Min();

            int reminder = maxNum % minNum;

            while (true)
            {
                reminder = maxNum % minNum;
                int multi = maxNum/minNum;
                if (reminder==0)
                {
                    Console.WriteLine(minNum);
                    break;
                }
                else
                {
                    maxNum = minNum;
                    minNum = reminder;
                }
            }
        }
        else
        {
            Console.WriteLine("Use only numbers");
        }
    }
}