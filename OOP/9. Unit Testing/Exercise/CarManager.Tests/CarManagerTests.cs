namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [TearDown]
        public void Tear()
        { car= null; }
        [Test]
        public void TestConstructor()
        {
            car = new Car("BMW","330",15.4,200);
            Assert.IsNotNull(car);
        }
        [Test]
        public void TestPropertiesGetters()
        {
            car = new Car("BMW", "330", 15.4, 200);
            string make = car.Make;
            string model = car.Model;
            double consumption = car.FuelConsumption;
            double capacity = car.FuelCapacity;

            Assert.That(make, Is.EqualTo("BMW"));
            Assert.That(model, Is.EqualTo("330"));
            Assert.That(consumption, Is.EqualTo(15.4));
            Assert.That(capacity, Is.EqualTo(200));
        }
        [Test]
        public void TestPropertiesSetters()
        {
            Assert.Throws<ArgumentException>(() => car = new Car(null, "330", 15.4, 200));
            Assert.Throws<ArgumentException>(() => car = new Car("BMW", null, 15.4, 200));
            Assert.Throws<ArgumentException>(() => car = new Car("BMW", "330", -1, 200));
            Assert.Throws<ArgumentException>(() => car = new Car("BMW", "330", 15.4, -1));
        }
        [Test]
        public void RefuelTest()
        {
            car = new Car("BMW", "330", 15.4, 200);
            car.Refuel(200);
            Assert.That(200, Is.EqualTo(car.FuelAmount));
        }
        [Test]
        public void RefuelExceptionTest()
        {
            car = new Car("BMW", "330", 15.4, 200);
            
            Assert.Throws<ArgumentException>(() => car.Refuel(-1));
        }
        [Test]
        public void DriveTest()
        {
            car = new Car("BMW", "330", 10, 200);
            car.Refuel(200);
            car.Drive(100);
            Assert.That(car.FuelAmount, Is.EqualTo(190));
        }
        [Test]
        public void DriveExceptionTest()
        {
            car = new Car("BMW", "330", 10, 200);            
            
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
           
        }
    }
}