using System;
using System.Text;

class HeartPrinting
{
    static void Main()
    {
        char symbol = '\u006F';
        Console.OutputEncoding = Encoding.Unicode;

        int[][] heartSizesContainer = { new int[] { 6, 7 }, new int[] { 8, 9 }, new int[] { 9, 11 }, new int[] { 11, 13 }, new int[] { 12, 15 }, new int[] { 14, 17 }, new int[] { 15, 19 }, new int[] { 17, 21 }, new int[] { 18, 23 }, new int[] { 20, 25 }, new int[] { 21, 27 }, new int[] { 23, 29 }, new int[] { 24, 31 } };

        Console.WriteLine("Choose size from 1 to 12: ");
        int heartSize = int.Parse(Console.ReadLine());


        int rowsNumber = heartSizesContainer[heartSize][0];
        int columnsNumber = heartSizesContainer[heartSize][1];
        int defineMiddleWidth = (columnsNumber / 2) + 1;
        int defineMiddleHeight = defineMiddleWidth / 2;
        int defineMiddlePoint = (columnsNumber / 4) + 1;

        float checkIsItOddEven = ((columnsNumber - 1) / 2) % 2;

        for (int i = 1; i < defineMiddlePoint; i++)
        {
            for (int iSecond = 1; iSecond <= columnsNumber; iSecond++)
            {
                if ((checkIsItOddEven == 0) && (i == 1))
                {
                    Console.Write(".");
                }
                else if ((checkIsItOddEven != 0) && (i == 1))
                {
                    int notEmptyColumnNumber1 = (defineMiddleWidth) / 2;
                    int notEmptyColumnNumber2 = notEmptyColumnNumber1 + 1;

                    int notEmptyColumnNumber3 = notEmptyColumnNumber2 + defineMiddleWidth - 2;
                    int notEmptyColumnNumber4 = notEmptyColumnNumber3 + 1;

                    if (iSecond == notEmptyColumnNumber1 || iSecond == notEmptyColumnNumber2 || iSecond == notEmptyColumnNumber3 || iSecond == notEmptyColumnNumber4)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                //Starts the second line printing
                else if (checkIsItOddEven == 0 && i < defineMiddlePoint)
                {

                    int topCord = (defineMiddleWidth / 2) + 1;
                    int topCordRight = topCord + defineMiddleWidth - 1;

                    int printCordLeft1 = topCord - i + 1;
                    int printCordLeft2 = topCord + i - 1;

                    int printCordRight1 = printCordLeft1 + defineMiddleWidth - 1;
                    int printCordRight2 = printCordLeft2 + defineMiddleWidth - 1;
                    if ((iSecond == printCordLeft1 || iSecond == printCordLeft2 || iSecond == printCordRight1 || iSecond == printCordRight2 || iSecond == topCord || iSecond == topCordRight) && i == 2)
                    {
                        Console.Write(symbol);
                    }
                    else if ((iSecond == printCordLeft1 || iSecond == printCordLeft2 || iSecond == printCordRight1 || iSecond == printCordRight2) && i > 2)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                else if ((checkIsItOddEven != 0) && i <= defineMiddlePoint)
                {
                    //If odd - cordinates for the second line
                    int cordFirst1 = defineMiddleHeight - i + 1;
                    int cordFirst2 = defineMiddleHeight + i;

                    int cordSecond1 = cordFirst1 + defineMiddleWidth - 1;
                    int cordSecond2 = cordSecond1 + (i * 2) - 1;
                    if (iSecond == cordFirst1 || iSecond == cordFirst2 || iSecond == cordSecond1 || iSecond == cordSecond2)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
            }
            if (i < defineMiddlePoint)
            {
                Console.WriteLine();
            }
        }
        //the Bottom part of the heart
        int finalLoop = rowsNumber - defineMiddlePoint;
        for (int iThird = 0; iThird <= finalLoop; iThird++)
        {
            for (int iFourth = 1; iFourth <= columnsNumber; iFourth++)
            {
                if ((iFourth == iThird || iFourth == (columnsNumber - iThird + 1)) && iThird > 0)
                {
                    Console.Write(symbol);
                }
                else if (iThird == 0 && (iFourth == columnsNumber || iFourth == 1))
                {
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
        Main();
    }
}