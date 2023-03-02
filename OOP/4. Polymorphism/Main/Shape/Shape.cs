﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape
    {
        public abstract double CalculatePeimeter();
        public abstract double CalculateArea();
        public virtual string Draw()
        {
            return $"Drawing {this.GetType().Name}";
        }

    }
}
