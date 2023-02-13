using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rennovators
{
    internal class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators= new List<Renovator>();  
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => renovators.Count;
        public string AddRenovator(Renovator renovator)
        {
            if (NeededRenovators >Count)
            {
                if (renovator.Name == null || renovator.Type == null || renovator.Name == string.Empty || renovator.Type == string.Empty)
                {
                    return "Invalid renovator's information.";
                }
                else if (renovator.Rate > 350)
                {
                    return "Invalid renovator's rate.";
                }
                else
                {
                    renovators.Add(renovator);
                    return $"Successfully added {renovator.Name} to the catalog.";

                }

            }
            else
            {
                return "Renovators are no more needed.";

            }
        }
        public bool RemoveRenovator(string name)
        {
            int count = 0;
            for (int i = 0; i < renovators.Count; i++)
            {
                if (renovators[i].Name ==name)
                {
                    renovators.Remove(renovators[i]);
                    i--;
                }
            }

            bool exists = count > 0;

            return exists;


        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;
            for (int i = 0; i < renovators.Count; i++)
            {
                if (renovators[i].Type==type)
                {
                    renovators.Remove(renovators[i]);
                    i--;
                    count++;
                }
            }

            return count;
        }
        public Renovator HireRenovator(string name)
        {

            foreach (var item in renovators)
            {
                if (item.Name == name)
                {
                    item.Hired = true;
                    return item;

                }
            }
            return null;
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> hardWorkers = new List<Renovator>();
            foreach (var item in renovators)
            {
                if (item.Days > days)
                {
                    hardWorkers.Add(item);
                }
            }
            return hardWorkers;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var item in renovators)
            {
                if (!item.Hired)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
