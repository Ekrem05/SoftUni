using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {   int n=int.Parse(Console.ReadLine());   
            Dictionary<string,List<decimal>>dic= new Dictionary<string,List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!dic.ContainsKey(name))
                {
                    dic.Add(name, new List<decimal>());
                }
                dic[name].Add(grade);
            }
            foreach (var item in dic)
            {
                Console.Write($"{item.Key} -> ");
                foreach (var value in item.Value)
                {
                    Console.Write($"{value:f2} "); 
                    
                }
                Console.WriteLine($"(avg: {item.Value.Average():f2})");
            }
        }
    }
}
