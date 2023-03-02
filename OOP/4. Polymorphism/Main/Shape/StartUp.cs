namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           Shape shape=new Circle(2);
           Shape shape1= new Rectangle(2,3);
            Console.WriteLine(shape1.CalculateArea());
        }
    }
}