using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Person
{
    class Program
    {
        static void Main()
        {
            //Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. Override ToString() to display the information of a person and if age is not specified – to say so. Write a program to test this functionality.
            Person johnDoe = new Person("John Doe");
            johnDoe.Age = 5;
            Console.WriteLine(johnDoe);
        }
    }
}
