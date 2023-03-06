using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : IDrivable
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private bool fuelTankComparer = false;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                fuelTankComparer = true;
            }
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {

                if (fuelTankComparer)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }

            }

        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value + 1.6; }
        }

        public double TankCapacity { get; set; }

        public void Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;
            if (FuelQuantity >= neededFuel)
            {
                fuelQuantity -= neededFuel;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public void Refuel(double fuel)
        { 
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (fuel + FuelQuantity <= TankCapacity)
                {
                    FuelQuantity += fuel * 0.95;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                }

        }
    }
}
