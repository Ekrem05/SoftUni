using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        private decimal salary;
        private string firstName;
        private string lastName;
        private int age;
        public Person(string firstName, string lastName, int age,decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (value.Length>=3)
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (value.Length >= 3)
                {
                    lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
            }
        }
        public int Age
        {
            get { return age; }
            private set
            {
                if (value>=1)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException($"Age cannot be zero or a negative integer!");
                }
            }
        }
        public decimal Salary 
        {
            get
            {
                return salary;
            }
            private set
            {
                if (value>=650M)
                {
                    salary = value;
                }
                else
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
            }
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
        public void IncreaseSalary(decimal percentage)
        {
            decimal value = Salary * percentage / 100;

            if (Age < 30)
            {
               
                salary += value / 2;
            }
            else
            {
                salary += value;
            }
        }
    }
}
