using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Constructor()
        {
            factory = new Factory("TEST", 100);
            Assert.IsNotNull(factory);
            Assert.That(factory.Capacity, Is.EqualTo(100)); 
            Assert.That(factory.Name,Is.EqualTo("TEST"));
            Assert.That(factory.Supplements.Count, Is.EqualTo(0));
            Assert.That(factory.Robots.Count, Is.EqualTo(0));
        }

        [Test]
        public void ProduceRobot()
        {
            factory = new Factory("TEST", 100);
            string expected = $"Robot model: 123M IS: {2}, Price: {20000:f2}";
            Assert.That(factory.ProduceRobot("123M",20000,2),Is.EqualTo($"Produced --> {expected}"));
            Assert.That(factory.Robots[0].Model, Is.EqualTo("123M"));
            Assert.That(factory.Robots[0].InterfaceStandard, Is.EqualTo(2));
            Assert.That(factory.Robots[0].Price, Is.EqualTo(20000));
            Assert.That(factory.Robots.Count, Is.EqualTo(1));


            Factory factory2 = new Factory("TEST", 1);
            factory2.ProduceRobot("123M", 20000, 2);
            Assert.That(factory2.ProduceRobot("123M", 20000, 2), Is.EqualTo($"The factory is unable to produce more robots for this production day!"));
            Assert.That(factory2.Robots.Count, Is.EqualTo(1));
        }
        [Test]
        public void ProduceSupplement()
        {
            factory = new Factory("TEST", 100);
            string expected = $"Supplement: TEST IS: 3";
            Assert.That(factory.ProduceSupplement("TEST", 3), Is.EqualTo(expected));
            Assert.That(factory.Supplements.Count, Is.EqualTo(1));
            Assert.That(factory.Supplements[0].InterfaceStandard, Is.EqualTo(3));
            Assert.That(factory.Supplements[0].Name, Is.EqualTo("TEST"));
        }
        [Test]
        public void UpgradeRobotFirstIf()
        {
            factory = new Factory("TEST", 100);
            Robot robot = new Robot("MODEL1", 1999, 3);
            Supplement supplement = new Supplement("Supp",3);
            robot.Supplements.Add(supplement);
            Assert.That(factory.UpgradeRobot(robot,supplement), Is.EqualTo(false));
            

        }
        [Test]
        public void UpgradeRobotSecondIf()
        {
            factory = new Factory("TEST", 100);
            Robot robot = new Robot("MODEL1", 1999, 1);
            Supplement supplement = new Supplement("Supp", 3);
            Assert.That(factory.UpgradeRobot(robot, supplement), Is.EqualTo(false));
            Assert.That(robot.Supplements.Contains(supplement), Is.EqualTo(false));

        }
        [Test]
        public void UpgradeRobotTrue()
        {
            factory = new Factory("TEST", 100);
            Robot robot = new Robot("MODEL1", 1999, 3);
            Supplement supplement = new Supplement("Supp", 3);
            Assert.That(factory.UpgradeRobot(robot, supplement), Is.EqualTo(true));
            Assert.That(robot.Supplements.Contains(supplement), Is.EqualTo(true));
            Assert.That(robot.Supplements.Count, Is.EqualTo(1));

        }
        [Test]
        public void SellRobot()
        {
            factory = new Factory("TEST", 100);
            Robot robot = new Robot("MODEL2", 3999, 4);
            factory.ProduceRobot("MODEL1", 2999, 3);
            factory.ProduceRobot("MODEL2", 3999, 4);
            factory.ProduceRobot("MODEL3", 4999, 5);
            Assert.That(factory.SellRobot(3999).ToString(), Is.EqualTo("Robot model: MODEL2 IS: 4, Price: 3999.00"));
            Assert.That(factory.SellRobot(2999).ToString(), Is.EqualTo("Robot model: MODEL1 IS: 3, Price: 2999.00"));
        }
    }
}