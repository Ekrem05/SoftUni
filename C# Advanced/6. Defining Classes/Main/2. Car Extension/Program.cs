using _2._Car_Extension;
namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car() 
            {
                Make = "VW",
                Model = "PASSAT",
                Year = 2009,
                FuelQuantity = 200,
                FuelConsumption = 200,               
            };
             car.Drive(2000);
            Console.WriteLine(car.WhoAmI());
          
        }
    }
}
