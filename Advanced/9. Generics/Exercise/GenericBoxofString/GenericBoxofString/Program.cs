namespace GenericBoxofString
{
    public class StartUp
    {
        static void Main(string[] args)
        { Box<string> box = new();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            { 
                box.Add((Console.ReadLine()));
            }
            Console.WriteLine($"{box.ToString()}");
           
        }
    }
}