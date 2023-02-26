using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,int> dic= new Dictionary<int,int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!dic.ContainsKey(number))
                {
                    dic.Add(number, 0);
                }
                dic[number]++;
            }
            foreach (var item in dic)
            {
                if (item.Value%2==0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
