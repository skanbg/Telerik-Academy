using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Matrices
{
    //* Write a class Matrix, to holds a matrix of integers.
    //Overload the operators for adding, subtracting and multiplying of matrices,
    //indexer for accessing the matrix content and ToString().

    //Defining fields(variables) as private, because no need to be accessed from outside directly
    private int[,] matrix;
    private int rows;
    private int cols;

    //Creating new empty matrix without assigned elements(numbers)
    public Matrices(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
        this.rows = rows;
        this.cols = cols;
    }

    //When full matrix as array is given, we set to "matrix" field the array and set the rows and cols count to the class fields(variables)
    public Matrices(int[,] matrix)
    {
        this.matrix = matrix;
        this.rows = matrix.GetLength(0);
        this.cols = matrix.GetLength(1);
    }

    //When the class object is tried to be accessed as indexed array
    public int this[int row, int col]
    {
        get
        {
            //When returning(output) the value of the element
            return matrix[row, col];
        }
        set
        {
            //When adding value
            matrix[row, col] = value;
        }
    }

    public static Matrices operator +(Matrices firstMatrix, Matrices secondMatrix)
    {
        //Creating object of type Matrices
        Matrices outputMatrix = new Matrices(firstMatrix.rows, firstMatrix.cols);

        for (int rows = 0; rows < firstMatrix.rows; rows++)
        {
            for (int cols = 0; cols < firstMatrix.cols; cols++)
            {
                outputMatrix[rows, cols] = firstMatrix[rows, cols] + secondMatrix[rows, cols];
            }
        }
        return outputMatrix;
    }

    public static Matrices operator -(Matrices firstMatrix, Matrices secondMatrix)
    {
        Matrices outputMatrix = new Matrices(firstMatrix.rows, firstMatrix.cols);

        for (int rows = 0; rows < firstMatrix.rows; rows++)
        {
            for (int cols = 0; cols < firstMatrix.cols; cols++)
            {
                outputMatrix[rows, cols] = firstMatrix[rows, cols] - secondMatrix[rows, cols];
            }
        }
        return outputMatrix;
    }

    public static Matrices operator *(Matrices firstMatrix, Matrices secondMatrix)
    {
        Matrices outputMatrix = new Matrices(firstMatrix.rows, firstMatrix.cols);

        for (int rows = 0; rows < firstMatrix.rows; rows++)
        {
            for (int cols = 0; cols < firstMatrix.cols; cols++)
            {
                outputMatrix[rows, cols] = firstMatrix[rows, cols] * secondMatrix[rows, cols];
            }
        }
        return outputMatrix;
    }

    public override string ToString()
    {
        StringBuilder printedMatrix = new StringBuilder();
        for (int rows = 0; rows < this.rows; rows++)
        {
            for (int cols = 0; cols < this.cols; cols++)
            {
                int elementValue = this.matrix[rows, cols];
                printedMatrix.AppendFormat(" {0}{1}", elementValue, new string(' ', 5 - (elementValue).ToString().Length));
            }
            printedMatrix.AppendLine();
        }
        return printedMatrix.ToString();
    }

    public int[,] ToArray()
    {
        return this.matrix;
    }
}

class OverloadOperators
{
    static void Main()
    {
        //Hardcoded examples
        int[,] firstMatrix = new int[,] { { 0, 1, 2 }, { 1, 2, 3 }, { 3, 5, 6 } };
        int[,] secondMatrix = new int[,] { { 1, 1, 2 }, { 1, 2, 2 }, { 2, 2, 2 } };

        //Creating objects
        Matrices matrixOne = new Matrices(firstMatrix);
        Matrices matrixTwo = new Matrices(secondMatrix);

        //Example using ToArray - no output
        int[,] exampleOfToArray = (matrixOne - matrixTwo).ToArray();

        Console.WriteLine("The first Matrix: \n{0}", matrixOne);
        Console.WriteLine("The second Matrix: \n{0}", matrixTwo);

        //Adding
        Console.WriteLine("First matrix + second matrix");
        Console.WriteLine(matrixOne + matrixTwo);

        //Substracting
        Console.WriteLine("First matrix - second matrix");
        Console.WriteLine(matrixOne - matrixTwo);

        //Multiplying
        Console.WriteLine("First matrix * second matrix");
        Console.WriteLine(matrixOne * matrixTwo);

    }
}