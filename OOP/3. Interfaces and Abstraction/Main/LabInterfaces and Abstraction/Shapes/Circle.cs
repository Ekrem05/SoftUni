using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IDrawable
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public void Draw()
        {
            double rIn= this.Radius - 0.4;
            double rOut = this.Radius + 0.4;
            for (double i = Radius; i >= -Radius; --i)
            {
                for (double x = -this.Radius; x <rOut; x+=0.5)
                {
                    double value = x * x + i * i;
                    if (value>=rIn*rIn&&value<=rOut*rOut)
                    {
                        Console.Write("*");
                    }
                    else Console.Write(" ");
                   
                }
                 Console.WriteLine();
            }
        }
    }
}
