using Moq;

namespace ProductTrackingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mock<IProduct> sandals = new Mock<IProduct>();         
            sandals.SetupAllProperties();
            sandals.Object.Name = "Sandals";
            Stock products = new Stock(new List<IProduct>() { sandals.Object });
           products.Add(sandals.Object);

        }
    }
}