using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private List<ISubject> models = new List<ISubject>(); 
        public SubjectRepository()
        {
            models = new List<ISubject>();
        }
        public IReadOnlyCollection<ISubject> Models => models;

        public void AddModel(ISubject model)
        {
            models.Add(model);
        }

        public ISubject FindById(int id)
        {
            ISubject subject = this.models.FirstOrDefault(s => s.Id == id);
            return subject;
        }

        public ISubject FindByName(string name)
        {
            ISubject subject = this.models.FirstOrDefault(s => s.Name == name);
            return subject;
        }
    }
}
