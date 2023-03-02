using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get { return height; }private set { height = value; } }
        public double Width { get { return width; } private set { width = value; } }

        public override double CalculateArea()
        {
           return Width* Height;
        }

        public override double CalculatePeimeter()
        {
           return 2*(Width*Height);
        }
        public override string Draw()
        {
            return $"Drawing Rectangle";
        }
    }
}
