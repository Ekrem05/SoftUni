using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double Default_Race_Motorcycle_Fuel_Consumption = 8;
        public RaceMotorcycle(double fuel, int horsePower) : base(fuel, horsePower)
        {
        }
        public override double FuelConsumption => Default_Race_Motorcycle_Fuel_Consumption;
    }
}
