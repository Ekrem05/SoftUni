using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> map = new Dictionary<string, Dictionary<string, List<string>>>();
           int n =int.Parse(Console.ReadLine());
            for (int i = 0; i <n; i++)
            {
                string[] split = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string continent = split[0];
                string country = split[1];
                string city = split[2];
                if (!map.ContainsKey(continent))
                {
                    map.Add(continent, new Dictionary<string, List<string>>());
                   
                }
                if (!map[continent].ContainsKey(country))
                {
                    map[continent].Add(country, new List<string>());
                }

                map[continent][country].Add(city);


            }
            
            foreach (var item in map)
            {
                Console.WriteLine($"{item.Key}: ");
                foreach (var product in item.Value)
                {
                    Console.WriteLine($"  {product.Key} -> {string.Join(", ",product.Value)}");

                }
            }
        }
    }
}
