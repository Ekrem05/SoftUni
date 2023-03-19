using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Axe axe = new Axe(20, 100);
            Dummy enemy = new Dummy(100, 0);
            axe.Attack(enemy);
            Assert.That(80,Is.EqualTo(enemy.Health));
        }
        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Axe axe = new Axe(20, 100);
            Dummy enemy = new Dummy(0, 0);

            Assert.Throws<InvalidOperationException>(()=>axe.Attack(enemy));
        }
        [Test]
        public void DeadDummyCanGiveXP()
        {
           
            Dummy enemy = new Dummy(0, 20);
            Assert.AreEqual(enemy.GiveExperience(), 20);

        }
        [Test]
        public void AliveDummyCantGiveXP()
        {
            Axe axe = new Axe(20, 100);
            Dummy enemy = new Dummy(100, 20);
            Assert.Throws<InvalidOperationException>(() => enemy.GiveExperience(),"Alive dummy can give XP");
        }

    }
}