using System;
using System.Linq;
using System.Text;
using ExtensionStringbuilder.Substring;

//Implement an extension method Substring(int index, int length) for the class StringBuilder
//that returns new StringBuilder and has the same functionality as Substring in the class String.

class Program
{
    static void Main()
    {
        //Creating new StringBuilder and adding content
        StringBuilder builder = new StringBuilder(100);
        for (int i = 'a'; i <= 'z'; i++)
        {
            builder.Append((char)i);
        }
        //Printing
        Console.WriteLine("Full StringBuilder content: {0}", builder);
        Console.WriteLine("First 3 letters, starting from 0 index: {0}", builder.Substring(0, 3));
    }
}