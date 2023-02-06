using GenericCountMethodDoubles;
namespace GenericCountMethodStrings
{
    public class StartUp 
    {
        static void Main(string[] args)
        {   Box<double> box=new Box<double>();
            int times = int.Parse(Console.ReadLine());
          
            for (int i = 0; i < times; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }
            double element = (double.Parse(Console.ReadLine()));
            Console.WriteLine(box.ReturnCountOfTheGreaterOnes( element));

        }
       


       
    }
}