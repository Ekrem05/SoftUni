using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int biggest =int.MinValue;
            int quantity = int.Parse(Console.ReadLine());
            int[]orders = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < orders.Length; i++)
            {
                int current= orders[i];
                if (current>biggest)
                {
                    biggest= current;
                }
                queue.Enqueue(current);

            }
            Console.WriteLine(biggest);
            
            while (true)
            {
                
                if (queue.Count > 0)
                {
                    int current = queue.Peek();
                    if (quantity>=current)
                    {
                        queue.Dequeue();
                        quantity -= current;
                    }
                    else
                    {
                        Console.WriteLine("Orders left: " + string.Join(" ", queue));
                        break;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Orders complete");
                    break;
                }
            }
            
            
        }
    }
}
