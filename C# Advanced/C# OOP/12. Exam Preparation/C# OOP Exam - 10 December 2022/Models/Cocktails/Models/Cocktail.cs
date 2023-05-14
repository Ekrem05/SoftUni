using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails.Models
{
    public abstract class Cocktail:ICocktail
    {
        private string name;
        private string size;
        private double price;
        public Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public double Price
        {
            get { return price; }
            private set
            {
                if (size == "Large")
                {
                    price = value;
                }
                else if (size == "Middle")
                {
                    price = (value / 3) * 2;
                }
                else if (size == "Small")
                {
                    price = value / 3;
                }
            }
        }

        public string Size
        {
            get { return size; }
            private set { size = value; }
        }

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
        public override string ToString()
        {
            return $"{name} ({size}) - {price:f2} lv";
        }
    }
}
