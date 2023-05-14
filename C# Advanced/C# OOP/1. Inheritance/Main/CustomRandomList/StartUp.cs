namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList asd=new RandomList();
            asd.Add("12");
            asd.Add("22");
           
            Console.WriteLine( asd.RandomString());
        }
    }
}