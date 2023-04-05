using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;
        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => weapons;

        public void AddItem(IWeapon model)
        {
           weapons.Add(model);  
        }

        public IWeapon FindByName(string name)
        {
            return weapons.Where(x=>x.GetType().Name== name).FirstOrDefault();  
        }

        public bool RemoveItem(string name)
        {
            return weapons.Remove(FindByName(name));
        }
    }
}
