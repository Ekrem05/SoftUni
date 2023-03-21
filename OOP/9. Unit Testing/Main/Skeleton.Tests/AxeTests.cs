using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test_Weapon_Losing_Durability()
        {
            Axe axe = new Axe(20, 100);
            Dummy enemy = new Dummy(100, 0);
            axe.Attack(enemy);
            Assert.That(99, Is.EqualTo(axe.DurabilityPoints));

        }

        [Test]
        public void TestAttackingWithABrokenWeapon()
        {
            Axe axe = new Axe(20,0);
            Dummy enemy = new Dummy(100, 0);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(enemy));

        }
    }
}