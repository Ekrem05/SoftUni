using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : IDrivable
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private bool fuelTankComparer = false;
        public Car(double fuelQuantity, double fuelConsumption,double cap)
        {
            if (fuelQuantity>cap)
            {
                fuelTankComparer = true;
            }
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = cap;
        }
        public Car()
        {
                
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
            set { fuelConsumption = value + 0.9; }
        }

        public double TankCapacity { get; set; }

        public void Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;
            if (FuelQuantity>=neededFuel)
            {
                fuelQuantity -= neededFuel;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (fuel+FuelQuantity<=TankCapacity)
            {
                FuelQuantity += fuel;
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            
        }
    }
}
