using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }

        [MyRange(12,90)]
        
        public int Age { get; private set; }
        [MyRequired]
        public string Name { get; private set; }
    }
}
