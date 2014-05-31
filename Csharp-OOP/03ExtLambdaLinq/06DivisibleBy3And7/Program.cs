using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
//Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

class Program
{
    static void Main()
    {
        int[] originalArray = new int[21] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
        //Using lambda and extensions
        int[] lambdaArray = originalArray.Where(x => (x % 3) == 0 && (x % 7) == 0).ToArray();
        Console.WriteLine("Lambda result:");
        foreach (int number in lambdaArray)
        {
            Console.WriteLine(number);
        }
        //Using Linq
        Console.WriteLine("Linq result:");
        int[] linqArray = (from numbers in originalArray where (numbers % 3) == 0 && (numbers % 7) == 0 select numbers).ToArray();
        foreach (int number in linqArray)
        {
            Console.WriteLine(number);
        }
    }
}