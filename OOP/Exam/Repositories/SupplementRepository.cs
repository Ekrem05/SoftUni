using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> supplements;
        public SupplementRepository()
        {
            supplements= new List<ISupplement>();
        }
        public void AddNew(ISupplement model)
        {
           supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            ISupplement sup = supplements.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);
            return sup;

        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            return supplements.AsReadOnly();    
        }

        public bool RemoveByName(string typeName)
        {
            ISupplement sup=supplements.FirstOrDefault(x => x.GetType().Name == typeName);
            return supplements.Remove(sup);
        }
    }
}
