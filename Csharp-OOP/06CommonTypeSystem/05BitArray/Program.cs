using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05BitArray
{
    class Program
    {
        static void Main()
        {
            //Define a class BitArray64 to hold 64 bit values inside an ulong value. Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
            BitArray64 testNum1 = new BitArray64(10);
            BitArray64 testNum2 = new BitArray64(10);
            Console.WriteLine(testNum1 == testNum2);
            Console.WriteLine(testNum1 != testNum2);
            Console.WriteLine(testNum1[62]);
            Console.WriteLine(testNum1.GetHashCode());
            Console.WriteLine(testNum2.GetHashCode());
        }
    }
}
