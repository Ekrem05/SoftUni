namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        private Person person;

        [SetUp]
        public void SetUp()
        {
            db = new Database();

        }
        [TearDown]
        public void TearDown()
        {
            db = null;
            person = null;
        }
        [Test]
        public void TestAdd()
        {
            db = new Database();
            db.Add(person = new Person(1, "Alex"));
            Assert.That(db.Count, Is.EqualTo(1));
            Person[] people = CreatePeople();
            db = new Database(people);
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(17, "asd")));
        }

        private Person[] CreatePeople()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                people[i] = new Person(i, i.ToString());
            }
            return people;
        }

        [Test]
        public void TestAddException()
        {
            db = new Database();
            db.Add(person = new Person(1, "Alex"));

            Assert.Throws<InvalidOperationException>(() => db.Add(person = new Person(3, "Alex")));
            Assert.Throws<InvalidOperationException>(() => db.Add(person = new Person(1, "AlexSecond")));

       }
        [Test]
        public void RemoveMethod()
        {
            db = new Database(person = new Person(1, "Alex"));
            db.Remove();
            Assert.That(db.Count, Is.EqualTo(0));
            db = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            db.Remove());
        }
        [Test]
        public void FindByUserNameMethod()
        {
            db = new Database(person = new Person(1, "Alex"));
            Person person2 = db.FindByUsername("Alex");
            Assert.That(person2.Id, Is.EqualTo(1));
            

        }
        [Test]
        public void FindByUserNameExceptions()
        {
            db = new Database(person = new Person(1, "Alex"));
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Non-Existing"));
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("alex"));
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));

        }

        [Test]
        public void FindByUserIdMethod()
        {
            db = new Database(person = new Person(1, "Alex"));
            Person person2 = db.FindById(1);
            Assert.That(person2.UserName, Is.EqualTo("Alex"));
        }
        [Test]
        public void FindByUserIdExceptions()
        {
            db = new Database(person = new Person(1, "Alex"));
            Assert.Throws<InvalidOperationException>(() => db.FindById(100));
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1)); 
        }

    }
}