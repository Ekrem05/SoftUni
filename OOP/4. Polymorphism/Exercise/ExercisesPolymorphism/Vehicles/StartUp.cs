namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] inputTruck = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] inputBus = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int n =int.Parse(Console.ReadLine());
            Car car = new(double.Parse(inputCar[1]), double.Parse(inputCar[2]), double.Parse(inputCar[3]));
            Truck truck = new(double.Parse(inputTruck[1]), double.Parse(inputTruck[2]), double.Parse(inputTruck[3]));
            Bus bus = new(double.Parse(inputBus[1]), double.Parse(inputBus[2]), double.Parse(inputBus[3]));

            for (int i = 0; i < n; i++)
            {
              string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];
                string vehicles= commands[1];
                try
                {switch (action)
                {
                    case"Drive":
                        if (vehicles=="Car")
                        {
                            car.Drive(double.Parse(commands[2]));
                            
                        }
                        else if (vehicles == "Truck")
                        {
                            truck.Drive(double.Parse(commands[2]));
                        }
                        else if (vehicles == "Bus")
                        {
                            bus.Drive(double.Parse(commands[2]));
                        }
                        break;
                    case "Refuel":
                        if (vehicles == "Car")
                        {
                            car.Refuel(double.Parse(commands[2]));

                        }
                        else if (vehicles == "Truck")
                        {
                            truck.Refuel(double.Parse(commands[2]));
                        }
                        else if (vehicles == "Bus")
                        {
                            bus.Refuel(double.Parse(commands[2]));
                        }
                        break;
                    case "DriveEmpty":
                        bus.DriveEmpty(double.Parse(commands[2]));
                        break;

                }

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");


        }
    }
}