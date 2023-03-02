using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public  abstract class Animal
    {
        public string Name { get; set; }
        public string FavoriteFood { get; set; }
        public Animal(string name, string food)
        {
            this.Name = name;
            this.FavoriteFood = food;
        }
        public abstract string ExplainSelf();
        
       
    }
}
