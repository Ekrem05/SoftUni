namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {   Dictionary<string, Car>cars = new Dictionary<string, Car>();
           int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1Km = double.Parse(input[2]);
                Car car= new Car();
                car.Model= model;
                car.FuelAmount= fuelAmount;
                car.FuelConsumptionPerKilometer= fuelConsumptionFor1Km;
                cars.Add(model,car);
            }
            string command=string.Empty;
            while ((command=Console.ReadLine())!="End")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[1];
                double amountOfKm= double.Parse(input[2]);
                cars[model].DriveOrNot(cars[model],amountOfKm);
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Key} {item.Value.FuelAmount:f2} {item.Value.TravelledDistance}");
            }
        }
    }
}