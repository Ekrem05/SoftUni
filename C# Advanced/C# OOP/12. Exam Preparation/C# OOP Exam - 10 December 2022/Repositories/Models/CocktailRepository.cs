using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Repositories.Models
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> models;
        public CocktailRepository()
        {
            models = new List<ICocktail>();
        }
        public IReadOnlyCollection<ICocktail> Models => models;

        public void AddModel(ICocktail model)
        {
            models.Add(model);
        }
    }
}
