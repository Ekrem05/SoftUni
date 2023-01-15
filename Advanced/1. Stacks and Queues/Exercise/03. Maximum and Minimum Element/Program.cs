using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {   Stack<int> stack = new Stack<int>();
            int n=int.Parse(Console.ReadLine());
            for (int i = 0; i <n; i++)
            {
                 int[] query = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int action = query[0];

                if (action==1)
                {
                    int element = query[1];
                    stack.Push(element);
                }
                else if (action==2)
                {
                    stack.Pop();
                }

                else if (action == 3)
                {
                    if (stack.Count>0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    
                }
                else if (action == 4)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
