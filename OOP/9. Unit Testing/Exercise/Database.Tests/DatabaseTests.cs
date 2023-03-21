namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;
        [TearDown]
        public void Dispose()
        {
            db = null;
        }
        [Test]
        public void StoringArraysCapacityTest()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            });
        }
        [Test]
        public void ArrayCapacityShouldBeSixteenTest()
        {
            
                db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Assert.That(16, Is.EqualTo(db.Count));
        }
        [Test]
        public void AddMethodOnlyAddsSixteenElementsTest()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
                db.Add(17);
            });
        }
        [Test]
        public void AddMethodOnlyAddsOnTheNextPosition()
        {
            db = new Database(1, 2, 3);
            db.Add(17);
            int[] copyArray = db.Fetch();
            Assert.That(17, Is.EqualTo(copyArray[3]));
        }
        [Test]
        public void RemoveMethodShoudRemoveTheLastElement()
        {
            db = new Database(1, 2, 3);
            db.Remove();
            int[]copy=db.Fetch();
            Assert.That(2, Is.EqualTo(copy[1]));
        }
        [Test]
        public void RemoveFromAnEmprtArrayTest()
        {
            db = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            db.Remove());
        }
        [Test]
        public void ConstructorShouldStoreIntegersAndStoreThemInTheArray ()
        {
            db = new Database(20,30);
            int count=db.Count;
            Assert.That(2,Is.EqualTo(count));
            
        }
        [Test]
        public void FetchMethod()
        {
            db = new Database(20, 30);
            int[] copy = db.Fetch();
            Assert.That(copy[0] == 20 && copy[1]==30);

        }
    }
}