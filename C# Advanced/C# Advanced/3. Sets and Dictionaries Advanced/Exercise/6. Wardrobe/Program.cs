using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <n; i++)
            {   //Blue -> dress,jeans,hat
                string[] input= Console.ReadLine().Split(new string[] { " -> " },StringSplitOptions.RemoveEmptyEntries);
                string color= input[0];
                string clothing= input[1];
                string[] cloths = clothing.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in cloths)
                {
                    if (!wardrobe.ContainsKey(color))
                        {
                             wardrobe.Add(color, new Dictionary<string,int>());
                        }
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }
                    wardrobe[color][item]++;
                }
     
            }
            string[] itemForSearching = Console.ReadLine().Split(' ');
            string colorForSearch = itemForSearching[0];
            string cloth= itemForSearching[1];
            bool colorFound = false;
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                if (color.Key==colorForSearch)
                {
                    colorFound = true;
                }
                foreach (var clothes in color.Value)
                {
                    if (clothes.Key==cloth&&colorFound)
                    {
                        Console.WriteLine($" * {clothes.Key} - {clothes.Value} (found!)");
                        colorFound = false;
                    }
                    else
                    {
                        Console.WriteLine($" * {clothes.Key} - {clothes.Value}");
                    }
                   
                }
            }
        }
    }
}
