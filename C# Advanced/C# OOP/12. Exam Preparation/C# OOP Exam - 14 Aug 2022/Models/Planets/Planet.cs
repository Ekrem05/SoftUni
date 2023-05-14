using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double millitaryPower;
        private IRepository<IMilitaryUnit> militaryUnits;
        private IRepository<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            militaryUnits = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }
        private double GetMilitaryPower()
        {
            double result = this.militaryUnits.Models.Sum(x => x.EnduranceLevel) + this.weapons.Models.Sum(x => x.DestructionLevel);

            if (this.Army.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                result *= 1.3;
            }
            if (this.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                result *= 1.45;
            }

            return result;
        }
        public double MilitaryPower
        {
            
            get {  return Math.Round(GetMilitaryPower(),3);}           
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => militaryUnits.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            militaryUnits.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {name}");
            sb.AppendLine($"--Budget: {budget} billion QUID");
            if (militaryUnits.Models.Count>0)
            {
                var units = new Queue<string>();

                foreach (var item in this.Army)
                {
                    units.Enqueue(item.GetType().Name);
                }
                sb.AppendLine("--Forces: " + string.Join(", ", militaryUnits.Models.Select(x => x.GetType().Name)));
            }
            else
            {
                sb.AppendLine("--Forces: " + "No units");
            }
            if (weapons.Models.Count > 0)
            {
                sb.AppendLine("--Combat equipment: " + string.Join(", ", weapons.Models.Select(x => x.GetType().Name)));
            }
            else
            {
                sb.AppendLine("--Combat equipment: " + "No weapons");
            }
            sb.AppendLine($"--Military Power: {MilitaryPower} ");
            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount>Budget)
            {
                throw new ArgumentException(ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
        }

        public void TrainArmy()
        {
           militaryUnits.Models.ToList().ForEach(x => { x.IncreaseEndurance(); });
        }
    }
}
