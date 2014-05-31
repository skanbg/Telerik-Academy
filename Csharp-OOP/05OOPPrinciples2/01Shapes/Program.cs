using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Shapes
{
    /*
    Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
    Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure
    (height*width for rectangle and height*width/2 for triangle). Define class Circle and suitable constructor
    so that at initialization height must be kept equal to width and implement the CalculateSurface() method.
    Write a program that tests the behavior of  the CalculateSurface() method for
    different shapes (Circle, Rectangle, Triangle) stored in an array.
    */
    class Program
    {
        static void Main()
        {
            Shape[] shapes = new Shape[3] { new Circle(10), new Rectangle(10, 10), new Triangle(10, 10) };
            foreach (Shape shape in shapes)
            {
                Console.WriteLine("{1} surface = {0}", shape.CalculateSurface(), shape.ShapeType);
            }
        }
    }
}
