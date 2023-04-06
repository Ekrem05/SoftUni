using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models.University
{
    public class University : IUniversity
    {
        private string[] categories = new string[3] { "Economical", "Humanity", "Technical" };
        private string name;
        private string category;
        private int capacity;
        private List<int> requiredSubs;
        public University(int id, string name, string category, int capacity, List<int> requiredSubjects)
        {
            Id = id;
            Name = name;
            Category = category;
            Capacity = capacity;
            requiredSubs = new List<int>();
            requiredSubs=requiredSubjects;
        }

        public int Id { get; private set; }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Category
        {
            get {return category; }
            private set
            {
                if (!categories.Contains(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
                category = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityNegative));

                }
                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects => requiredSubs;
    }
}
