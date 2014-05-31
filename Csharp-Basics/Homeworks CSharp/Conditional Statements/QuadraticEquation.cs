using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class QuadraticEquation
{
    /*
    Write a program that enters the coefficients a, b and c of a quadratic equation
	a*x2 + b*x + c = 0
	and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.
    */
    static void Main()
    {
        Console.Write("Input the a:");
        int firstInputNumber = int.Parse(Console.ReadLine());
        Console.Write("Input the b:");
        int secondInputNumber = int.Parse(Console.ReadLine());
        Console.Write("Input the c:");
        int thirdInputNumber = int.Parse(Console.ReadLine());

        int discriminant = secondInputNumber * secondInputNumber - (4 * firstInputNumber * thirdInputNumber);

        if (discriminant < 0)
        {
            Console.WriteLine("No real roots");
        }
        else if (discriminant == 0)
        {
            decimal x1 = (secondInputNumber / (2 * firstInputNumber)) * (-1);
            Console.WriteLine("x is {0}", x1);
        }
        else if (discriminant > 0)
        {
            double x1 = (((-1) * secondInputNumber) + Math.Sqrt(discriminant)) / (2 * firstInputNumber);
            double x2 = (((-1) * secondInputNumber) - Math.Sqrt(discriminant)) / (2 * firstInputNumber);
            Console.WriteLine("x1 is {0} and x2 is {1}", x1, x2);
        }
    }
}