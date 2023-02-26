using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount{ get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }
        public void DriveOrNot(Car car,double km)
        {
            double neededFuel = FuelConsumptionPerKilometer * km;
            if (neededFuel<car.FuelAmount)
            {
                car.FuelAmount -= FuelConsumptionPerKilometer * km;
                car.TravelledDistance += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
