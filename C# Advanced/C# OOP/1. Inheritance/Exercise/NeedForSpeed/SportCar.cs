using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double Default_Sport_Fuel_Consumption = 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
        public override double FuelConsumption => Default_Sport_Fuel_Consumption;
    }
}
