using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Repositories.Models
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private IReadOnlyCollection<IDelicacy> models;
        public DelicacyRepository()
        {
            models=new List<IDelicacy>();
        }
        public IReadOnlyCollection<IDelicacy> Models => models;

        public void AddModel(IDelicacy model)
        {
           Models.ToList().Add(model);
        }
    }
}
