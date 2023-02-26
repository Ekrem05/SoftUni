using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text=Console.ReadLine();
            char[] chars=text.ToCharArray();
            Dictionary<char,int> counter=new Dictionary<char,int>();    

            foreach (var item in chars)
            {
                if (!counter.ContainsKey(item))
                {
                    counter.Add(item, 0);
                }
                counter[item]++;    
            }
            counter.OrderBy(x => x);
            foreach (var item in counter.OrderBy(key=>key.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
