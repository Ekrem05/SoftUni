using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private string[] unitTypes = new string[3] { "SpaceForces", "StormTroopers", "AnonymousImpactUnit" };
        private string[] weaponTypes = new string[3] { "BioChemicalWeapon", "NuclearWeapon", "SpaceMissiles" };
        private IRepository<IPlanet> planetRepository;
        public Controller()
        {
            planetRepository = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!planetRepository.Models.Any(x=>x.Name==planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (unitTypeName != nameof(AnonymousImpactUnit) &&
                unitTypeName != nameof(SpaceForces) &&
                unitTypeName != nameof(StormTroopers))  
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            if (planetRepository.FindByName(planetName).Army.Any(x=>x.GetType().Name==unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,planetName));
            }
            IMilitaryUnit unit;
            if (unitTypeName== "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else
            {
                unit = new AnonymousImpactUnit();
            }
            IPlanet planet = planetRepository.FindByName(planetName);
            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return string.Format(OutputMessages.UnitAdded,unitTypeName, planetName);

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!planetRepository.Models.Any(x => x.Name == planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (!weaponTypes.Contains(weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            if (planetRepository.FindByName(planetName).Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
           
           
            IWeapon weapon;
            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            planetRepository.FindByName(planetName).Spend(weapon.Price);
            planetRepository.FindByName(planetName).AddWeapon(weapon);
            return string.Format(OutputMessages.WeaponAdded, planetName,weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planetRepository.FindByName(name)!=null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            planetRepository.AddItem(new Planet(name, budget));
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planetRepository.Models.OrderByDescending(x=>x.MilitaryPower).ThenBy(x=>x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet first= planetRepository.FindByName(planetOne);
            IPlanet second = planetRepository.FindByName(planetTwo);
            if (first.MilitaryPower>second.MilitaryPower)
            {
                return WinnerOperations(first, second);
            }
            else if (second.MilitaryPower > first.MilitaryPower)
            {
                return WinnerOperations(second, first);

            }
            else
            {  
                bool firstNuclear = false;
                bool secondNuclear = false;
                if (first.Weapons.Any(x=>x.GetType().Name=="NuclearWeapon"))
                {
                    firstNuclear= true;
                }
                if (second.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    secondNuclear = true;
                }
                if ((firstNuclear&&secondNuclear)||(!firstNuclear&&!secondNuclear))
                {
                    first.Spend(first.Budget / 2);
                    second.Spend(second.Budget / 2);
                    return string.Format(OutputMessages.NoWinner);

                }
                if (firstNuclear&&!secondNuclear)
                {
                    return WinnerOperations(first, second);
                }
                return WinnerOperations(second, first);
            }
        }
        private string WinnerOperations(IPlanet winner, IPlanet looser)
        {

            winner.Spend(winner.Budget / 2);
            winner.Profit(looser.Budget / 2);
            double moreProfit = looser.Army.Select(x => x.Cost).Sum() + looser.Weapons.Select(x => x.Price).Sum();
            winner.Profit(moreProfit);
            planetRepository.RemoveItem(looser.Name);
            return string.Format(OutputMessages.WinnigTheWar, winner.Name, looser.Name);
        }
        public string SpecializeForces(string planetName)
        {
            
            if (planetRepository.FindByName(planetName)==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            IPlanet planet= planetRepository.FindByName(planetName);
            if (planet.Army.Count==0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }
            planet.Spend(1.25);
            planet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded,planetName);
        }
    }
}
