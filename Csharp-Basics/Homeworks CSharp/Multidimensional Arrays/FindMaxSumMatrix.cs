using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FindMaxSumMatrix
{
    //Write a program that reads a rectangular matrix of size N x M
    //and finds in it the square 3 x 3 that has maximal sum of its elements.

    //Method used to return the cordinates of the top left element of the sub matrix or sub matrices with max sum
    //Done using recursion and loops
    static List<int> FindSubMatrixWithMaxSum(int[,] mainMatrix, List<int> subMatrixStartingIndexes, int mainMatrixRows, int mainMatrixCols, int subMatrixRows, int subMatrixCols, int lastRow, int lastCol, int currentElementsSum, int currentMaxSum)
    {
        //Breaking condition is "if the last row + 1 is reached". Condition is done like this because of bottom code
        if ((lastRow + subMatrixRows) > mainMatrixRows)
        {
            return subMatrixStartingIndexes;
        }
        //This variable contains the current sum of all elements in the sub matrix. Default values is 0
        int currentNumberSum = 0;
        //The loops that walk the main matrix
        for (int subRowsFromMainMatrix = lastRow; subRowsFromMainMatrix < lastRow + subMatrixRows; subRowsFromMainMatrix++)
        {
            for (int subColsFromMainMatrix = lastCol; subColsFromMainMatrix < lastCol + subMatrixCols; subColsFromMainMatrix++)
            {
                //Adding the current element value to the sum of all elements
                currentNumberSum += mainMatrix[subRowsFromMainMatrix, subColsFromMainMatrix];
            }
        }

        if (currentNumberSum > currentMaxSum)
        {
            //If the current sum of the sub matrix is bigger than the current max sum, than the stringBuilder containing
            //all indexes for now is wiped and the cordinates of this sub matrix is added
            subMatrixStartingIndexes.Clear();
            subMatrixStartingIndexes.Add(lastRow);
            subMatrixStartingIndexes.Add(lastCol);
            //changing to the new max sum
            currentMaxSum = currentNumberSum;
        }
        else if (currentNumberSum == currentMaxSum)
        {
            //Else if we have sub matrix that has the same sum of the elements
            //now we add the cordinates
            subMatrixStartingIndexes.Add(lastRow);
            subMatrixStartingIndexes.Add(lastCol);
        }

        if ((lastCol + subMatrixCols) < mainMatrixCols)
        {
            //If the end of the main matrix is not reached than we increment the starting column(the column where the above loops start
            lastCol++;
        }
        else if ((lastRow + subMatrixRows) <= mainMatrixRows)
        {
            //If the the last column of the main matrix is reached
            //than we reset the column index and increment the row index(so the code will go to the next row of the main matrix)
            lastCol = 0;
            lastRow++;
        }

        //Recursion
        return FindSubMatrixWithMaxSum(mainMatrix, subMatrixStartingIndexes, mainMatrixRows, mainMatrixCols, subMatrixRows, subMatrixCols, lastRow, lastCol, currentElementsSum, currentMaxSum);
    }

    //Method for returning as stringBuilder part(sub matrix) of the main matrix
    static StringBuilder OneSubMatrixWalker(int[,] mainMatrix, StringBuilder returnedMatrix, int startingRow, int startingCol, int currentRow, int currentCol, int rowLength, int colLength)
    {
        //Breaking condition is when the last row is reached and the currentCol is outside of the Main matrix
        if (currentCol >= (startingCol + colLength) && currentRow >= (startingRow + rowLength - 1))
        {
            return returnedMatrix;
        }

        if (currentCol >= (startingCol + colLength))
        {
            //Going on new line of the main matrix and adding new line to the stringBuilder
            currentCol = startingCol;
            currentRow++;
            returnedMatrix.AppendLine();
        }

        int getCurrentElementValue = mainMatrix[currentRow, currentCol];
        currentCol++;

        //Default value of the digits that the above number has
        int numberOfDigits = 1;
        //Copy of the number that the while will use to determine the digits count
        int copyNumberToDivide = getCurrentElementValue;
        //The while loop that breaks when no digits left
        while (copyNumberToDivide / 10 > 0)
        {
            //Incrementing the digits count
            numberOfDigits++;
            //Dividing the number by 10
            copyNumberToDivide /= 10;
        }

        //Calculating the needed spaces by substracting the number of digits of the current number from 5(default number because i dont think bigger than 4 digits number should be inputed)
        int spacesUsedForThisNumber = 5 - numberOfDigits;
        //Adding to the stringBuilder the new number
        returnedMatrix.AppendFormat("{0}{1}", getCurrentElementValue, new string(' ', spacesUsedForThisNumber));

        //Recursion
        return OneSubMatrixWalker(mainMatrix, returnedMatrix, startingRow, startingCol, currentRow, currentCol, rowLength, colLength);
    }

    //Method that joins each of matrices with equal sum
    static StringBuilder SubMatricesPrinting(int[,] mainMatrix, StringBuilder outPutAllMatrices, List<int> subMatrixStartingIndexes, int subMatrixRows, int subMatrixCols, int counter)
    {
        if (subMatrixStartingIndexes.Count == 0)
        {
            //Breaking condition if no cordinates left in the List
            return outPutAllMatrices;
        }

        if (counter>=0)
        {
            //Caption of each sub matrix
            outPutAllMatrices.AppendFormat("Matrix №{0}", counter).AppendLine();
        }

        //Adding the elements of the sub matrix
        outPutAllMatrices.Append(OneSubMatrixWalker(mainMatrix, new StringBuilder(), subMatrixStartingIndexes[0], subMatrixStartingIndexes[1], subMatrixStartingIndexes[0], subMatrixStartingIndexes[1], subMatrixRows, subMatrixCols)).AppendLine();
        //Removing the cordinates(row,column) of the List so no duplicates will be done
        subMatrixStartingIndexes.RemoveRange(0, 2);
        counter++;

        //Recursion
        return SubMatricesPrinting(mainMatrix, outPutAllMatrices, subMatrixStartingIndexes, subMatrixRows, subMatrixCols, counter);
    }

    static void Main()
    {
        ////Hardcode tests
        //int[,] mainMatrix = { { 0, 0, 0, 0, 0, 3 }, { 0, 1, 1, 1, 0, 0 }, { 0, 1, 1, 1, 0, 0 }, { 0, 1, 1, 1, 0, 0 }, { 0, 0, 0, 0, 0, 7 } };
        //int mainMatrixRows = 5;
        //int mainMatrixCols = 6;
        //int subMatrixRows = 3;
        //int subMatrixCols = 3;
        //Console.WriteLine("Hello there. Check the current example matrix:");
        //Console.WriteLine(SubMatricesPrinting(mainMatrix, new StringBuilder(), new List<int> { 0, 0 }, mainMatrixRows, mainMatrixCols, -1));

        //==========IF YOU WISH TO USE THE HARDCODED TEST PUT IN COMMENT EVERYTHING FROM HERE(and uncomment the above comment)

        int[,] mainMatrix;
        int[,] exampleMatrix = { { 0, 0, 0, 0, 0, 3 }, { 0, 1, 1, 1, 0, 0 }, { 0, 1, 1, 1, 0, 0 }, { 0, 1, 1, 1, 0, 0 }, { 0, 0, 0, 0, 0, 7 } };
        int mainMatrixRows = 5;
        int mainMatrixCols = 6;
        int subMatrixRows = 3;
        int subMatrixCols = 3;

        //----------No need to use comments below- Its a simple input data code-----------

        Console.WriteLine("Hello there. Check the current example matrix:");
        Console.WriteLine(SubMatricesPrinting(exampleMatrix, new StringBuilder(), new List<int> { 0, 0 }, mainMatrixRows, mainMatrixCols, -1));
        Console.WriteLine("Do you want to type in the console your matrix(type \"yes\" or \"no\")?");
        //Variables in case of console input
        int inputRows = -1;
        int inputCols = -1;
        switch (Console.ReadLine())
        {
            case "yes":
                Console.WriteLine("OK. How many rows for your matrix?");
                while (!int.TryParse(Console.ReadLine(), out inputRows) && inputRows > 0)
                {
                    Console.WriteLine("Wrong input! Try again!");
                }
                Console.WriteLine("And how many columns for your matrix?");
                while (!int.TryParse(Console.ReadLine(), out inputCols) && inputCols > 0)
                {
                    Console.WriteLine("Wrong input! Try again!");
                }

                mainMatrix = new int[inputRows, inputCols];
                Console.WriteLine("Now you can start filling the elements of the matrix! You can use negative numbers too.");
                for (int i = 0; i < inputRows; i++)
                {
                    Console.WriteLine("Now type all numbers on the {0} row one by one and each on new line(use enter)", i);
                    for (int j = 0; j < inputCols; j++)
                    {
                        int currentInputElementValue = 0;
                        while (!int.TryParse(Console.ReadLine(), out currentInputElementValue))
                        {
                            Console.WriteLine("Wrong input! Try again");
                        }
                        mainMatrix[i, j] = currentInputElementValue;
                    }
                }
                break;
            case "no":
                mainMatrix = exampleMatrix;
                break;
            default:
                Console.WriteLine("Your answer not found. I assume you dont want to input your own matrix.");
                mainMatrix = exampleMatrix;
                break;
        }

        Console.WriteLine("Now please select how many rows do you want to use for the sub matrix(the outputed smaller matrix with max sum) ?");
        subMatrixRows = int.Parse(Console.ReadLine());
        Console.WriteLine("Now the columns count:");
        subMatrixCols = int.Parse(Console.ReadLine());

        //===============================TILL HERE

        List<int> subMatrixWithMaxSum = FindSubMatrixWithMaxSum(mainMatrix, new List<int>(), mainMatrixRows, mainMatrixCols, subMatrixRows, subMatrixCols, 0, 0, 0, int.MinValue);
        if (subMatrixWithMaxSum.Count > 0)
        {
            //If sub matrices are found
            Console.WriteLine("Matrices with max sum:");
            StringBuilder readyToPrintSubMatrices = SubMatricesPrinting(mainMatrix, new StringBuilder(), subMatrixWithMaxSum, subMatrixRows, subMatrixCols, 1);
            Console.WriteLine(readyToPrintSubMatrices);
        }
        else
        {
            Console.WriteLine("Sub matrix with max sum cant be done! Either not enough rows or columns of the matrix!");
        }
    }
}