using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        GenericList<int> someList = new GenericList<int>(1);
        someList.Add(1);
        someList.Add(2);
        someList.Add(3);
        someList.Add(4);
        someList.Add(5);
        someList.Add(6);
        //Removing element at given position
        someList.RemoveAt(5);
        Console.WriteLine(someList[4]);

        //Min value and Max value
        Console.WriteLine("Min value in this list is {0} and Max value is {1}",someList.Min(),someList.Max());

        //Find index
        Console.WriteLine("Index of value 3 is {0}",someList.IndexOf(3));

        //Insert at given position
        someList.InsertAt(2,1000);
        Console.WriteLine(someList.ToString());

        //Clearing generic list content
        someList.Clear();
        //Printing generic list content
        Console.WriteLine(someList.ToString());

    }
}