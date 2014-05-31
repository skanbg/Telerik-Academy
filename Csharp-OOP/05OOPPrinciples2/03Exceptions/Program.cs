using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Exceptions
{
    /*
   Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range.
   It should hold error message and a range definition [start … end].
   Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime>
   by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].
   */
    class Program
    {
        static void Main()
        {
            InvalidRangeException<int> newIntExc = new InvalidRangeException<int>("Integer must be in range 1-100", 1, 100);
            Console.WriteLine("Enter 2 numbers in range: {0}-{1}", newIntExc.MinValue, newIntExc.MaxValue);
            for (int i = 0; i < 2; i++)
            {
                int inputInt = int.Parse(Console.ReadLine());
                if (inputInt < newIntExc.MinValue || inputInt > newIntExc.MaxValue)
                {
                    throw newIntExc;
                }
                else
                {
                    Console.WriteLine("Correct number");
                }
            }

            //Dates example

            InvalidRangeException<DateTime> newDateExc = new InvalidRangeException<DateTime>("Dates must be in range 1.1.1980 and 31.12.2013", DateTime.Parse("1.1.1980"), DateTime.Parse("31.12.2013"));
            Console.WriteLine("Enter 2 dates in range: {0} and {1}", newDateExc.MinValue, newDateExc.MaxValue);
            for (int i = 0; i < 2; i++)
            {
                DateTime inputDate = DateTime.Parse(Console.ReadLine());
                if (inputDate < newDateExc.MinValue || inputDate > newDateExc.MaxValue)
                {
                    throw newDateExc;
                }
                else
                {
                    Console.WriteLine("Correct date");
                }
            }
        }
    }
}
