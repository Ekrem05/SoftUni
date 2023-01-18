using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double,int>dic = new Dictionary<double,int>();
            double[] array = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray() ;
            foreach (var item in array)
            {
                if (!dic.ContainsKey(item))
                {
                    dic.Add(item, 0);
                }
                dic[item]++;
            }
            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
