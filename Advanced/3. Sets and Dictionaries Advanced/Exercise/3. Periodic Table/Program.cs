using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> set = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[]chemicals=Console.ReadLine().Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in chemicals)
                {
                    set.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ",set));
        }
    }
}
