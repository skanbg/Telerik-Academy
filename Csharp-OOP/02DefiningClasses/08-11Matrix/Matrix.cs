using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Matrix<T>
{
    private readonly int sizeCols;
    private readonly int sizeRows;
    private readonly T[,] matrix;

    public Matrix(int rows, int cols)
    {
        if (cols < 0 || rows < 0 || cols > int.MaxValue || rows > int.MaxValue)
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            this.sizeCols = cols;
            this.sizeRows = rows;
            matrix = new T[rows, cols];
        }
    }

    public T this[int row, int col]
    {
        get
        {
            if (row >= 0 && row < this.sizeRows && col >= 0 && col < this.sizeCols)
            {
                return this.matrix[row, col];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        set
        {
            if (row >= 0 && row < this.sizeRows && col >= 0 && col < this.sizeCols)
            {
                this.matrix[row, col] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    public static bool operator true(Matrix<T> matrix)
    {
        if (matrix == null || matrix.sizeRows == 0 || matrix.sizeCols == 0)
        {
            return false;
        }

        for (int row = 0; row < matrix.sizeRows; row++)
        {
            for (int col = 0; col < matrix.sizeCols; col++)
            {
                if (!matrix[row, col].Equals(default(T)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool operator false(Matrix<T> matrix)
    {
        if (matrix == null || matrix.sizeRows == 0 || matrix.sizeCols == 0)
        {
            return true;
        }

        for (int row = 0; row < matrix.sizeRows; row++)
        {
            for (int col = 0; col < matrix.sizeCols; col++)
            {
                if (!matrix[row, col].Equals(default(T)))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        if (firstMatrix.sizeCols == secondMatrix.sizeCols && firstMatrix.sizeRows == secondMatrix.sizeRows)
        {
            Matrix<T> finalMatrix = new Matrix<T>(firstMatrix.sizeRows, firstMatrix.sizeCols);
            for (int i = 0; i < firstMatrix.sizeRows; i++)
            {
                for (int j = 0; j < firstMatrix.sizeRows; j++)
                {
                    dynamic tempValueOne = firstMatrix[i, j];
                    dynamic tempValueTwo = secondMatrix[i, j];
                    finalMatrix[i, j] = tempValueOne - tempValueTwo;
                }
            }
            return finalMatrix;
        }
        else
        {
            throw new ArgumentException("Matrix sizes mismatch");
        }
    }

    public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        if (firstMatrix.sizeCols == secondMatrix.sizeCols && firstMatrix.sizeRows == secondMatrix.sizeRows)
        {
            Matrix<T> finalMatrix = new Matrix<T>(firstMatrix.sizeRows, firstMatrix.sizeCols);
            for (int i = 0; i < firstMatrix.sizeRows; i++)
            {
                for (int j = 0; j < firstMatrix.sizeRows; j++)
                {
                    dynamic tempValueOne = firstMatrix[i, j];
                    dynamic tempValueTwo = secondMatrix[i, j];
                    finalMatrix[i, j] = tempValueOne + tempValueTwo;
                }
            }
            return finalMatrix;
        }
        else
        {
            throw new ArgumentException("Matrix sizes mismatch");
        }
    }

    public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        if (firstMatrix.sizeCols != secondMatrix.sizeRows)
        {
            throw new ArgumentException("Matrix sizes mismatch");
        }

        Matrix<T> finalMatrix = new Matrix<T>(firstMatrix.sizeRows, firstMatrix.sizeCols);
        for (int i = 0; i < finalMatrix.sizeRows; i++)
        {
            for (int j = 0; j < finalMatrix.sizeCols; j++)
            {
                for (int multiCol = 0; multiCol < firstMatrix.sizeCols; multiCol++)
                {
                    for (int k = 0; k < firstMatrix.sizeCols; k++)
                    {
                        dynamic tempValueOne = firstMatrix[i, j];
                        dynamic tempValueTwo = secondMatrix[i, j];
                        finalMatrix[i, j] += tempValueOne * tempValueTwo;
                    }
                }
            }
        }

        return finalMatrix;
    }
}