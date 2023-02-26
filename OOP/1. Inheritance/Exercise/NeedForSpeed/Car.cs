using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    { private const double Default_Car_Fuel_Consumption = 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
        public override double FuelConsumption => Default_Car_Fuel_Consumption;
    }
}
