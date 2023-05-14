using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string>set1= new HashSet<string>();
            HashSet<string>set2= new HashSet<string>();
           
            int[]input=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();   
            int n = input[0];
            int m= input[1];
            for (int i = 0; i < n; i++)
            {
                set1.Add(Console.ReadLine());
            }
            for (int i = 0; i < m; i++)
            {
                set2.Add(Console.ReadLine());
            }
            foreach (var item in set1)
            {
                if (set2.Contains(item))
                {
                    Console.Write(item+" ");
                }
            }

        }
    }
    }

