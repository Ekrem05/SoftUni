using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChristmasPastryShop.Repositories.Models
{
    public class BoothRepository : IRepository<IBooth>
    {
        private IReadOnlyCollection<IBooth> models;
        public BoothRepository()
        {
            models = new List<IBooth>();
        }
        public IReadOnlyCollection<IBooth> Models => models;

        public void AddModel(IBooth model)
        {
            Models.ToList().Add(model);
        }
    }
}
