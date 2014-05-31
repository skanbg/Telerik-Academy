using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Shapes
{
    abstract class Shape
    {
        protected double Height { get; set; }
        protected double Width { get; set; }
        public string ShapeType { get; private set; }

        public Shape(double width, double height, string shapeType)
        {
            this.Width = width;
            this.Height = height;
            this.ShapeType = shapeType;
        }

        public abstract double CalculateSurface();
    }
}
