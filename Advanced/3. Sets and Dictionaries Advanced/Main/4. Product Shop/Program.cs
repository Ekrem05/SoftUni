using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shop = new SortedDictionary<string, Dictionary<string, double>>();
            string command = string.Empty;
            while ((command=Console.ReadLine())!="Revision")
            {
                string[] split=command.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string shopName = split[0]; 
                string product = split[1];
                double price = double.Parse(split[2]);
                if (!shop.ContainsKey(shopName))
                {
                    shop.Add(shopName, new Dictionary<string, double>());
                }
                shop[shopName].Add(product, price);


            }
            foreach (var item in shop)
            {
                Console.WriteLine($"{item.Key}-> ");
                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                    
                }
            }
        }

    }
}
