using Moq;
using ProductTrackingSystem;
using System.Security.Cryptography.X509Certificates;

namespace StockTrackerTester
{
    public class StockTests
    {
        private List<IProduct>GetProducts()
        {
            Mock<IProduct> sandals = new Mock<IProduct>();
            Mock<IProduct> hat = new Mock<IProduct>();
            Mock<IProduct> glasses = new Mock<IProduct>();
            sandals.SetupAllProperties();
            hat.SetupAllProperties();
            glasses.SetupAllProperties();
            sandals.Object.Name = "Sandals";
            sandals.Object.Price = 20m;
            sandals.Object.Quanity = 10;
            hat.Object.Name = "NikeSport";
            hat.Object.Price = 50m;
            hat.Object.Quanity = 15;
            glasses.Object.Name = "GucciGlasses";
            glasses.Object.Price = 100.93m;
            glasses.Object.Quanity = 5;
            List<IProduct> items = new List<IProduct>() { sandals.Object, hat.Object, glasses.Object };
            return items;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructor()
        {
            List<IProduct> items = GetProducts();
            Stock products = new Stock(items);
            Assert.That(products.Count, Is.EqualTo(3));
            Assert.That(products.Last().Name=="GucciGlasses", Is.True);
        }
        [Test]
        public void TestAddMethod()
        {
            List<IProduct> items = GetProducts();
            Stock products = new Stock(items);
            products.Add(items[2]);
            Assert.That(products.Count, Is.EqualTo(4));

        }
        [Test]
        public void TestContainsMethod()
        {
            List<IProduct> items = GetProducts();
            Stock products = new Stock(items);
            Mock<IProduct> mockProduct = new Mock<IProduct>();
            mockProduct.SetupAllProperties();
            mockProduct.Name= "Test";
            products.Add(mockProduct.Object);
            Assert.That(products.Contains(mockProduct.Object), Is.True);

        }
    }
}