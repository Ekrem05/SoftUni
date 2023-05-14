using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption  => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual void Drive(double km)
        {
            double liters = km * FuelConsumption;
            if (liters<=Fuel)
            {
                Fuel -= liters;
            }
        }
    }
}
