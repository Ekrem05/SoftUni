using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public const decimal CoffeePrice = 3.50m;
        public const double CoffeeMilliliters = 50;
        
        public Coffee(string name,double caffeine)
            : base(name, CoffeePrice, CoffeeMilliliters)
        {
            Caffeine=caffeine;
                   
        }
       
        public double Caffeine { get; set; }

    }
}
