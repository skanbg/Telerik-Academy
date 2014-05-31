using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatrixPrinting
{
    //Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)

    //Method filling the empty array like on figure A)
    static int[,] FillMatrixAlwaysStartFromTop(int[,] unfinishedMatrix, int currentRow, int currentCol, int counter, int size)
    {
        if (currentRow >= size && currentCol < size)
        {
            //Every time current row reaches the last index the script is resetting it to the first index and currentCol is incremented
            currentRow = 0;
            currentCol++;
        }

        if (currentCol >= size)
        {
            //This is the breaking condition, that quits the recursion
            return unfinishedMatrix;
        }

        //After the breaking condition and row reset the new value to this element of the matrix is set
        unfinishedMatrix[currentRow, currentCol] = counter;
        //Counter that keeps the current number that will be written in the matrix is incremented
        counter++;
        //CurrentRow is incremented so the new index will be down to the matrix
        currentRow++;

        //Recursion
        return FillMatrixAlwaysStartFromTop(unfinishedMatrix, currentRow, currentCol, counter, size);
    }

    //"Zig-Zag" matrix filling - This is the matrix on figure B)
    static int[,] FillMatrixTopBotomTop(int[,] unfinishedMatrix, int currentRow, int currentCol, int counter, int size, int columnsChangeCounter)
    {
        //ColumnsChangeCounter is variable that keeps the direction.
        //Using the bitwise operator ^ i get 0 if "the current value" and "1" are the same, and 1 if they are different.
        //So i always change the direction this way
        if (((counter - 1) % size) == 0 && (counter - 1) != 0)
        {
            currentCol++;
            columnsChangeCounter = 1 ^ columnsChangeCounter;
            if (columnsChangeCounter == 1)
            {
                //If the value is 1 we are going down
                currentRow++;
            }
            else
            {
                //if different( its 0 ), we are going up
                currentRow--;
            }
        }

        if (counter > (size * size))
        {
            //The breaking condition that escapes the recursion
            return unfinishedMatrix;
        }

        //Filling the array on this position with the current value of counter
        unfinishedMatrix[currentRow, currentCol] = counter;
        //Incrementing counter
        counter++;

        if (columnsChangeCounter == 1)
        {
            //If the value is 1 we are going down
            currentRow++;
        }
        else
        {
            //if different( its 0 ), we are going up
            currentRow--;
        }

        //Recursion
        return FillMatrixTopBotomTop(unfinishedMatrix, currentRow, currentCol, counter, size, columnsChangeCounter);
    }

    //Filling the matrix as shown on figure C)
    static int[,] FillMatrixLeftBotomDiagonal(int[,] unfinishedMatrix, int currentRow, int currentCol, int counter, int size, int lastFirstRow, int lastFirstCol)
    {
        if (currentRow == size && lastFirstRow > 0)
        {
            //If the currentRow reaches the last row of the matrix
            //than the method is still filling the left bottom half of the matrix
            currentCol = 0;
            lastFirstRow--;
            currentRow = lastFirstRow;
        }
        else if (currentCol == size)
        {
            //The top right half of the matrix
            lastFirstCol++;
            currentRow = 0;
            currentCol = lastFirstCol;
        }

        if (counter > (size * size))
        {
            //Breaking condition
            return unfinishedMatrix;
        }

        //Setting the new value to this element of the matrix
        unfinishedMatrix[currentRow, currentCol] = counter;

        //Incrementing
        currentRow++;
        currentCol++;
        counter++;

        //Recursion
        return FillMatrixLeftBotomDiagonal(unfinishedMatrix, currentRow, currentCol, counter, size, lastFirstRow, lastFirstCol);
    }

    //The spiral filling method
    static int[,] FillMatrixSpiral(int[,] unfinishedMatrix, int currentRow, int currentCol, int counter, int size, char fillingDirection)
    {
        if (counter > (size * size))
        {
            //breaking condition
            return unfinishedMatrix;
        }

        //Setting the new value
        unfinishedMatrix[currentRow, currentCol] = counter;

        //Switch statement with iterations and direction changes
        switch (fillingDirection)
        {
            case 'd':
                //If moving down 
                if ((currentRow + currentCol) == (size - 1))
                {
                    //... and the sum of the element indexes(row and col) is equal to the max index of the matrix, than change direction to right
                    fillingDirection = 'r';
                }
                else
                {
                    //Else increment
                    currentRow++;
                    counter++;
                }
                break;
            case 'r':
                //If moving right
                if (currentCol == currentRow)
                {
                    //... and the column and row indexes are equal, than the direction must be changed to "up"
                    fillingDirection = 'u';
                }
                else
                {
                    //Else increment
                    counter++;
                    currentCol++;
                }
                break;
            case 'u':
                //If moving up
                if ((currentRow + currentCol) == (size - 1))
                {
                    //... and the sum of the element indexes(row and col) is equal to the max index of the matrix, than change direction to left
                    fillingDirection = 'l';
                }
                else
                {
                    //else increment/decrement
                    currentRow--;
                    counter++;
                }
                break;
            case 'l':
                //If moving left
                if ((currentCol - currentRow) == 1)
                {
                    //... and the current column index substracted with the current row index gives 1 as result, than the direction is changed to "down"
                    fillingDirection = 'd';
                }
                else
                {
                    //...else increment/decrement
                    currentCol--;
                    counter++;
                }
                break;
        }

        //Recursion
        return FillMatrixSpiral(unfinishedMatrix, currentRow, currentCol, counter, size, fillingDirection);
    }

    //Method used to return StringBuilder with the printed matrix. The method is calculating spaces so the matrix wont displace
    static StringBuilder PrintMatrix(int[,] finishedMatrix, int size, int indexRow, int indexColumn, StringBuilder outputStringBuilder)
    {
        //Getting the value of the array element with the current indexes
        int currentNumberFromMatrix = finishedMatrix[indexRow, indexColumn];
        //Default value of the digits that the above number has
        int numberOfDigits = 1;
        //Copy of the number that the while will use to determine the digits count
        int copyNumberToDivide = currentNumberFromMatrix;
        //The while loop that breaks when no digits left
        while (copyNumberToDivide / 10 > 0)
        {
            //Incrementing the digits count
            numberOfDigits++;
            //Dividing the number by 10
            copyNumberToDivide /= 10;
        }
        //Calculating the needed spaces by substracting the number of digits of the current number from the digits of the max number in the array
        int spacesUsedForThisNumber = ((size * size).ToString().Length + 2) - numberOfDigits;
        //Adding to the stringBuilder the new number
        outputStringBuilder.AppendFormat("{0}{1}", currentNumberFromMatrix, new string(' ', spacesUsedForThisNumber));

        indexColumn++;

        if (indexColumn >= size)
        {
            //When the last number on this row is reached
            indexRow++;
            indexColumn = 0;
            outputStringBuilder.AppendLine();
        }

        if (indexRow <= (size - 1))
        {
            //Recursion
            return PrintMatrix(finishedMatrix, size, indexRow, indexColumn, outputStringBuilder);
        }
        //Returning the matrix
        return outputStringBuilder;
    }

    static void Main()
    {
        //Getting the input data. Check the last rows for Hardcoded tests
        int inputMatrixSize;
        char matrixType = 'a';
        int[,] outputFilledMatrix = null;
        Console.WriteLine("Type the matrix size:");
        //Looping until correct int number is inputed
        while (!int.TryParse(Console.ReadLine(), out inputMatrixSize))
        {
            Console.WriteLine("Input data is not correct! Try again!");
        }
        Console.WriteLine("Thank you! Now choose matrix type(a,b,c,d):");

        //Looping until correct char is inputed and the matrix(outputFilledMatrix declared above) is not undefined
        while (outputFilledMatrix==null)
        {
            switch (Console.ReadLine())
            {
                case "a":
                case "A":
                    matrixType = 'a';
                    outputFilledMatrix = FillMatrixAlwaysStartFromTop(new int[inputMatrixSize, inputMatrixSize], 0, 0, 1, inputMatrixSize);
                    break;
                case "b":
                case "B":
                    matrixType = 'b';
                    outputFilledMatrix = FillMatrixTopBotomTop(new int[inputMatrixSize, inputMatrixSize], 0, 0, 1, inputMatrixSize, 1);
                    break;
                case "c":
                case "C":
                    matrixType = 'c';
                    outputFilledMatrix = FillMatrixLeftBotomDiagonal(new int[inputMatrixSize, inputMatrixSize], (inputMatrixSize - 1), 0, 1, inputMatrixSize, (inputMatrixSize - 1), 0);
                    break;
                case "d":
                case "D":
                    matrixType = 'd';
                    outputFilledMatrix = FillMatrixSpiral(new int[inputMatrixSize, inputMatrixSize], 0, 0, 1, inputMatrixSize, 'd');
                    break;
                default:
                    Console.WriteLine("Unrecognised type of matrix! Use only letters a, b, c or d");
                    break;
            }
        }

        //Clearing the console
        Console.Clear();
        //General information is shown and than the matrix is printed
        Console.WriteLine("You choosed matrix with size: {0} and type '{1}'", inputMatrixSize, matrixType);
        Console.WriteLine(PrintMatrix(outputFilledMatrix, inputMatrixSize, 0, 0, new StringBuilder()));


        //HARDCODED tests with size of 4*4 matrix. Uncomment the int[,] one by one. They are sorted from A to D.
        //Uncomment 288, 291(for example) and 295 row to test the methods without console input data

        //int inputMatrixSize = 4;
        //int[,] outputFilledMatrix = FillMatrixAlwaysStartFromTop(new int[inputMatrixSize, inputMatrixSize], 0, 0, 1, inputMatrixSize);
        //int[,] outputFilledMatrix = FillMatrixTopBotomTop(new int[inputMatrixSize, inputMatrixSize], 0, 0, 1, inputMatrixSize, 1);
        //int[,] outputFilledMatrix = FillMatrixLeftBotomDiagonal(new int[inputMatrixSize, inputMatrixSize], (inputMatrixSize - 1), 0, 1, inputMatrixSize, (inputMatrixSize - 1), 0);
        //int[,] outputFilledMatrix = FillMatrixSpiral(new int[inputMatrixSize, inputMatrixSize], 0, 0, 1, inputMatrixSize, 'd');
        //Console.WriteLine(PrintMatrix(outputFilledMatrix, inputMatrixSize, 0, 0, new StringBuilder()));
    }
}