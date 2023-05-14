namespace SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            try
            {   double number = double.Parse(Console.ReadLine());
                if (number<0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                double result = Math.Sqrt(number);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Goodbye.");
        }
    }
}