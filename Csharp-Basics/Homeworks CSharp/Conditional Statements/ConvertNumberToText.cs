using System;

class ConvertNumberToText
{
    static void Main()
    {
        /*
        * Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
	    0  "Zero"
	    273  "Two hundred seventy three"
	    400  "Four hundred"
	    501  "Five hundred and one"
	    711  "Seven hundred and eleven"
        */

        string[] ZeroToTwelveNumbersToTextArray = new string[21] { "Zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twelve" };
        string[] DecimalNumbersToTextArray = new string[9] { "", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        Console.Write("Please input a number: ");

        int inputNumberContainer;
        bool isItCorrectFormat = int.TryParse(Console.ReadLine(), out inputNumberContainer);

        Console.Write("Your number converted to text looks like this: ");

        if (isItCorrectFormat)
        {
            if (inputNumberContainer <= 20)
            {
                //if its smaller than 20 we get it directly from the array as its index
                Console.WriteLine(ZeroToTwelveNumbersToTextArray[inputNumberContainer]);
            }
            else if (inputNumberContainer > 20 && inputNumberContainer < 100)
            {
                //if its bigger than 20 and smaller than 100 we get the dec by deviding to 10 and checking for text in array
                //same for the last using %
                int getDec = (inputNumberContainer / 10) - 3;
                int getLast = inputNumberContainer % 10;
                Console.Write(DecimalNumbersToTextArray[getDec]);
                if (getLast != 0)
                {
                    Console.Write(" {0}", ZeroToTwelveNumbersToTextArray[getLast]);
                }
                Console.WriteLine();
            }
            else if (inputNumberContainer > 99 && inputNumberContainer < 1000)
            {
                //same as the above codes, but here we check the numbers hundreds by deviding to 100 and checking in the array with the numbers from 0 to 20
                int getHundreds = (inputNumberContainer / 100);
                int getDec = (inputNumberContainer % 100) / 10;
                int getLast = (inputNumberContainer % 100) % 10;

                Console.Write("{0} hundred", ZeroToTwelveNumbersToTextArray[getHundreds]);

                if (getDec == 1)
                {
                    Console.Write(" and {0}", ZeroToTwelveNumbersToTextArray[inputNumberContainer % 100]);
                    //Console.WriteLine(ZeroToTwelveNumbersToTextArray[inputNumberContainer % 100]);
                }
                else if (getDec >= 0)
                {
                    if (getDec >1)
                    {
                        Console.Write(" and {0}", DecimalNumbersToTextArray[getDec]);
                    }

                    if (getLast != 0)
                    {
                        if (getDec <= 0)
                        {
                            Console.Write(" and");
                        }
                        Console.Write(" {0}", ZeroToTwelveNumbersToTextArray[getLast]);
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Number not in range!");
            }
        }
        else
        {
            Console.WriteLine("Not a number!");
        }
        Console.WriteLine();
        Main();
    }
}