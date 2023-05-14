using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }

        public bool AddChild(Child child)
        {
            bool added=false;
            if (Capacity>Registry.Count)
            {
                Registry.Add(child);
                added=true;
            }
            return added;
        }
        public bool RemoveChild(string childFullName)
        {
            bool removed = false;
            for (int i = 0; i < Registry.Count; i++)
            {   if (Registry[i].FirstName+" "+ Registry[i].LastName==childFullName)
                {
                    Registry.Remove(Registry[i]);
                    removed=true;
                }

            }
            
               
            
            return removed;
        }
        public int ChildrenCount => Registry.Count;
        public Child GetChild(string childFullName)
        {
           
            foreach (var item in Registry)
            {
                if (item.FirstName + " " + item.LastName == childFullName)
                {
                    return item;
                }
            }
            return null;
        }
        public string RegistryReport()
        {
            StringBuilder sb = new();          
            sb.AppendLine(($"Registered children in {Name}:"));
            foreach (var item in Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
