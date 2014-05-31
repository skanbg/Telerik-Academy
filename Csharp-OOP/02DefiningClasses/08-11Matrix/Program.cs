using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Matrix<int> firstMatrix = new Matrix<int>(10, 10);
        Matrix<int> secondMatrix = new Matrix<int>(10, 10);

        firstMatrix[1, 1] = 200;
        secondMatrix[1, 1] = 3;
        secondMatrix[2, 2] = 3;
        firstMatrix[3, 3] = 3;
        Matrix<int> resultMatrix = firstMatrix + secondMatrix;
        Console.WriteLine(resultMatrix[1, 1]);
        Console.WriteLine(resultMatrix[2, 2]);
    }
}