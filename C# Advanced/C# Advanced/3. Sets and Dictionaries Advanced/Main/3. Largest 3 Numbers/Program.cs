using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]array=Console.ReadLine().Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray().OrderByDescending(n=>n).ToArray();
            if (array.Length>=3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(array[i]+" ");
                }
            }
            else
            {
                foreach (var item in array)
                {
                Console.Write(item + " ");
                 }
            }
            
        }
    }
}
