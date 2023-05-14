namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> es = new(10, 10);
            Console.WriteLine(es.AreEqual());
            EqualityScale<string> es2 = new("Pesho","pesho");
            Console.WriteLine(es2.AreEqual());

        }
    }
}