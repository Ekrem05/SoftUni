using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            foreach (var item in input)
            {
                stack.Push(item);
            }
            string command = "";
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] array = command.Split(' ');
                string action = array[0];
                if (action.ToLower() == "add")
                {
                    int number1 = int.Parse(array[1]);
                    int number2 = int.Parse(array[2]);
                    stack.Push(number1);
                    stack.Push(number2);
                }
                else if (action.ToLower() == "remove")
                {
                    int n = int.Parse(array[1]);
                    if (stack.Count > n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            int sum = 0;
            while (stack.Count>0)
            {
                sum +=stack.Pop();
            }
           
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
