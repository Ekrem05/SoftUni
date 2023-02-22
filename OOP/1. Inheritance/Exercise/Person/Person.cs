using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {   private int age;
        private string name;
        public virtual int Age { get { return this.age;} 
            set { if (value < 0) 
                { return; }               
                else this.age=value ; } }

        public string Name { get => name; set => name = value; }

        public Person(string name, int age)
        {
            Age = age;           
            Name = name;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();
        }

    }
}
