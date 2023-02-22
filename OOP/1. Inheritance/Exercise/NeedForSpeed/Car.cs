using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    { private const double Default_Car_Fuel_Consumption = 3;
        public Car(double fuel, int horsePower) : base(fuel, horsePower)
        {
        }
        public override double FuelConsumption => Default_Car_Fuel_Consumption;
    }
}
