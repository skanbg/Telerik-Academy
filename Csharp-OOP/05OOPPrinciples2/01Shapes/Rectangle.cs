using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Shapes
{
    class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            : base(width, height,"Rectangle")
        {

        }

        public override double CalculateSurface()
        {
            return Width * Height;
        }
    }
}
