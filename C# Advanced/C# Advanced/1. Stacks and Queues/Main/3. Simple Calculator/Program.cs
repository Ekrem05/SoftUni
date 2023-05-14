using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string input = Console.ReadLine();
            string[] array = input.Split(' ');
            Array.Reverse(array);

            
            foreach (var item in array)
            {
                stack.Push(item);
            }
            int total = 0;
            int current = int.Parse(stack.Pop());
            total += current;
            while (stack.Count>0)
            {  
                if (stack.Peek()=="+")
                {
                    stack.Pop();
                    int number=int.Parse(stack.Pop());
                    total += number;
                }
                else
                {
                    stack.Pop();
                     int number = int.Parse(stack.Pop());
                    total -= number;
                }              
            }
            Console.WriteLine(total);
        }
    }
}
