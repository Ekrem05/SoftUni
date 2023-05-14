using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;
        public Family()
        {
            people= new List<Person>(); 
        }
       
        public void AddMember(Person member)
        {
            people.Add(member);
        }
        public Person GetOldestMember
            () {
            return people.MaxBy(p => p.Age);
        
        }
    }
}
