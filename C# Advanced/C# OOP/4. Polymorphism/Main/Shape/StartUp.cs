namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           Shape shape=new Circle(30);
           Shape shape1= new Rectangle(10,20);
            Console.WriteLine(shape1.CalculateArea());
            Console.WriteLine(shape1.Draw());
            Console.WriteLine(shape.Draw());

        }
    }
}