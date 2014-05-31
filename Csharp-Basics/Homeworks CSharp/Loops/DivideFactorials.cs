using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class DivideFactorials
{
    static void Main()
    {
        //Write a program that calculates N!/K! for given N and K (1<K<N).
        //I will skip comments on this short code. I am using method shown here: http://www.purplemath.com/modules/factorial.htm
        int inputN;
        int inputK;
        Console.WriteLine("Equation N!/K!");
        Console.Write("N: ");
        bool checkIsNNumber = int.TryParse(Console.ReadLine(), out inputN);
        Console.Write("K: ");
        bool checkIsKNumber = int.TryParse(Console.ReadLine(), out inputK);

        if (checkIsKNumber && checkIsNNumber)
        {
            BigInteger result = 1;
            for (int i = inputK+1; i <= inputN; i++)
            {
                result *= i;
            }
            Console.WriteLine("{0}!/{1}! = {2}", inputN, inputK, result);
        }
        else
        {
            Console.WriteLine("Use only numbers!");
        }
    }
}