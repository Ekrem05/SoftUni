using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {   Stack<int> stack = new Stack<int>();
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = input[0];
            int s = input[1];
            int x = input[2];
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }
            bool contains=stack.Contains(x);
            if (contains)
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count>0)
                {
                Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
                
                
            }
                  
        }
    }
}
