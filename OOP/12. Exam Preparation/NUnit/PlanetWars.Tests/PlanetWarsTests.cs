using NUnit.Framework;
using System;
using System.ComponentModel;
using System.Linq;
using System.Numerics;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {   
            [Test]
            public void ConstructorsTest()
            {
                Weapon weapon = new Weapon("Ak47", 299, 9);
                Planet planet = new Planet("Mars",1000);
                Assert.That(weapon.DestructionLevel, Is.EqualTo(9));
                Assert.That(weapon.Name, Is.EqualTo("Ak47"));
                Assert.That(weapon.Price, Is.EqualTo(299));
                Assert.That(planet.Name, Is.EqualTo("Mars"));
                Assert.That(planet.Budget, Is.EqualTo(1000));
                Assert.That(planet.Weapons.Count, Is.EqualTo(0));
                Assert.That(weapon.IsNuclear, Is.EqualTo(false));
            }
            [Test]
            public void WeaponValidations()
            {
                Assert.Throws<ArgumentException>(() => { Weapon weapon = new Weapon("Ak47", -1, 10); });
               
            }
            [Test]
            public void PlanetValidations()
            {
                Assert.Throws<ArgumentException>(() => { Planet planet = new Planet(null, 1000); });
                Assert.Throws<ArgumentException>(() => { Planet planet = new Planet(string.Empty, 1000); });
                Assert.Throws<ArgumentException>(() => { Planet planet = new Planet("Mars", -1); });

            }
            [Test]
            public void IncreaseDestructionLevel()
            {
                Weapon weapon = new Weapon("Ak47", 299, 10);
                weapon.IncreaseDestructionLevel();
                Assert.That(weapon.DestructionLevel, Is.EqualTo(11));
                Assert.That(weapon.IsNuclear, Is.EqualTo(true));

            }
            [Test]
            public void PlanetProfit()
            {
                Planet planet = new Planet("Mars", 100);
                planet.Profit(100);
                Assert.That(planet.Budget, Is.EqualTo(200));
            }
            [Test]
            public void SpendFunds()
            {
                Planet planet = new Planet("Mars", 100);
                planet.SpendFunds(99);
                Assert.That(planet.Budget, Is.EqualTo(1));
                Assert.Throws<InvalidOperationException>(() => { planet.SpendFunds(101); });
            }
            [Test]
            public void AddWeapon()
            {
                Planet planet = new Planet("Mars", 100);
                planet.AddWeapon(new Weapon("M4", 4000, 120));
                Assert.That(planet.Weapons.Count, Is.EqualTo(1));
                Assert.That(planet.Weapons.First().Name, Is.EqualTo("M4"));
                Assert.That(planet.Weapons.First().Price, Is.EqualTo(4000));
                Assert.That(planet.Weapons.First().DestructionLevel, Is.EqualTo(120));
                Assert.Throws<InvalidOperationException>(() => { planet.AddWeapon(new Weapon("M4", 4000, 120)); });
            }
            [Test]
            public void RemoveWeapon()
            {
                Planet planet = new Planet("Mars", 100);
                planet.AddWeapon(new Weapon("M4", 4000, 120));
                planet.RemoveWeapon("M4");
                Assert.That(planet.Weapons.Count, Is.EqualTo(0));
                
            }
            [Test]
            public void UpgradeWeapon()
            {
                Planet planet = new Planet("Mars", 100);
                planet.AddWeapon(new Weapon("M4", 4000, 120));
                planet.UpgradeWeapon("M4");
                Assert.That(planet.Weapons.First().DestructionLevel, Is.EqualTo(121));
                Assert.Throws<InvalidOperationException>(() => { planet.UpgradeWeapon("AK47"); });
            }
            [Test]
            public void DestructionOpponent()
            {
                Planet planet = new Planet("Mars", 100);
                planet.AddWeapon(new Weapon("M4", 4000, 120));
                Planet mercury = new Planet("Mercury", 200);               
                Assert.That(planet.DestructOpponent(mercury), Is.EqualTo($"Mercury is destructed!"));
                Assert.Throws<InvalidOperationException>(() => 
                {
                    mercury.AddWeapon(new Weapon("M4", 4000, 120));
                    mercury.AddWeapon(new Weapon("M4", 4000, 120));
                    mercury.AddWeapon(new Weapon("M4", 4000, 120));
                });
                Assert.Throws<InvalidOperationException>(() =>
                {
                    mercury.AddWeapon(new Weapon("M4", 4000, 120));
                   
                });
            }
        }
        

    }
       
    }

