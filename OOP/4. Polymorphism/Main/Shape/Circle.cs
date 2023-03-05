using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle:Shape
    {
        private double radius;
        

        public Circle(double radius)
        {
            Radius= radius;
        }

        public double Radius { get { return radius; } private set { radius = value; } }


        public override double CalculateArea()
        {
            return Math.Pow(Radius,2) * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI*Radius;
        }
        public override string Draw()
        {
            return $"Drawing {this.GetType().Name}";
        }
    }
}
