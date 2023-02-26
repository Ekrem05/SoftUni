using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netCoreVartiant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(new string[]{ " " }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Dictionary<string, List<int>> products = new Dictionary<string, List<int>>()
{
    { "Croissant",new List<int>() { 50, 50 } },
    { "Muffin",new List<int>() { 40, 60 } },
    { "Baguette",new List<int>() { 30, 70 } },
    { "Bagel",new List<int>() { 20, 80 } }
};
            Dictionary<string, int> orders = new Dictionary<string, int>();
            while (true)
            {
                double currentWater = water.Peek();
                double currentFlour = flour.Peek();
                double calculateWaterPer = (currentWater * 100) / (currentFlour + currentWater);
                double flourPer = 100 - calculateWaterPer;
                bool match = false;
                foreach (var item in products)
                {
                    if (item.Value[0] == calculateWaterPer && item.Value[1] == flourPer)
                    {
                        if (!orders.ContainsKey(item.Key))
                        {
                            orders.Add(item.Key, 0);
                        }
                        orders[item.Key]++;
                        water.Dequeue();
                        flour.Pop();
                        match = true;
                    }
                }
                if (match == false)
                {

                    if (!orders.ContainsKey("Croissant"))
                    {
                        orders.Add("Croissant", 0);
                    }
                    orders["Croissant"]++;
                    currentFlour -= currentWater;
                    flour.Pop();
                    flour.Push(currentFlour);
                    water.Dequeue();
                }
                if (!flour.Any() || !water.Any())
                {
                    break;
                }
            }
            foreach (var item in orders.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            if (water.Any())
            {
                Console.WriteLine("Water left: " + string.Join(", ", water));
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flour.Any())
            {
                Console.WriteLine("Flour left: " + string.Join(", ", flour));
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }

        }
    }
}
