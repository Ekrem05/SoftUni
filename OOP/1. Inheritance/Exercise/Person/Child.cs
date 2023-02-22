using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Child : Person
    { public override int Age
        {
            get { return base.Age; }
            set
            {
                if (value<=15)
                {
                   base.Age = value;
                } 
            }
        }
        public Child(string name,int age) : base(name,age)
        {
            
        }
    }
}
