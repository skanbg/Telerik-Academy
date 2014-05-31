using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Shapes
{
    class Circle : Shape
    {
        public Circle(double radius)
            : base(radius, radius, "Circle")
        {

        }

        public override double CalculateSurface()
        {
            return Math.PI * Width * Height;
        }
    }
}
