namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar m4 = new SportCar(100, 500);
            m4.Drive(30);
            System.Console.WriteLine(m4.Fuel);
        }
    }
}
    