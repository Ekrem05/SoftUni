﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Fish : MainDish
    {    public const double FishGrams = 22;
        public Fish(string name, decimal price) : base(name, price, FishGrams)
        {

        }
       
    }
}
