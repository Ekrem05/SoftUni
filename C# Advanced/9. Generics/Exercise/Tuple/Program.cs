namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, string> person = new(input1[0] +" " + input1[1], input1[2]);
            string[] input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, double> personBeer = new(input2[0], double.Parse(input2[1]));
            string[] input3 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<double, double> ip = new(double.Parse(input3[0]), double.Parse(input3[1]));
            Console.WriteLine($"{person.Item1} -> {person.Item2}");
            Console.WriteLine($"{personBeer.Item1} -> {personBeer.Item2}");
            Console.WriteLine($"{ip.Item1} -> {ip.Item2}");
        }
    }
}