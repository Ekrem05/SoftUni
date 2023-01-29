using _4._Car_Engine_And_Tires;
namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(2009,1000),
                new Tire(2009, 1000),
                new Tire(2009, 1000),
                new Tire(2009, 1000),
            };
            Engine V8 = new Engine(420, 1500);
            Car bmwM4= new Car("bmw","m4",2009,1000,20,V8,tires);



        }
    }
}
