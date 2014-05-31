using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Shapes
{
    class Triangle : Shape
    {
        public Triangle(double width, double height)
            : base(width, height,"Triangle")
        {

        }

        public override double CalculateSurface()
        {
            return (Height * Width) / 2;
        }
    }
}
