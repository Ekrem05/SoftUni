using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails.Models
{
    public class Hibernation : Cocktail
    {
        private const double LargeHibernation = 10.50;
        public Hibernation(string name, string size) : base(name, size, LargeHibernation)
        {
        }
    }
}
