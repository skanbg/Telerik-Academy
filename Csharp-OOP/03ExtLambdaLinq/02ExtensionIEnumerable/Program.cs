using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionIEnumerable;

//Implement a set of extension methods for IEnumerable<T> that implement
//the following group functions: sum, product, min, max, average.

class Program
{
    static void Main()
    {
        //List<int> newList = new List<int>() { 1, 2, 3, 4, 5 };
        List<string> newList = new List<string>() { "1","22","333" };

        Console.WriteLine("Elements: {0}", string.Join(", ", newList));
        //Sum
        //Console.WriteLine("Sum of numbers: {0}", newList.Sum());
        //Product
        Console.WriteLine("Product: {0}", newList.Product<int>());
        //Min
        Console.WriteLine("Min: {0}", newList.Min<int>());
        //Max
        Console.WriteLine("Max: {0}", newList.Max<int>());
        //Average
        Console.WriteLine("Average: {0}", newList.Average<int>());
    }
}
