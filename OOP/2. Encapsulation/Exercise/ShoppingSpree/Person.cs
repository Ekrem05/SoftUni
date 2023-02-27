using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> bagOfProducts;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    name = value;
                }
            }

        }
        public double Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    money = value;
                }
            }
        }
        public List<Product> BagOfProducts { get => bagOfProducts; set => bagOfProducts = value; }
    }
}
