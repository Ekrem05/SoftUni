using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            Queue<int> evenQueue = new Queue<int>();
            foreach (var item in array)
            {
                queue.Enqueue(item);
            }
            while (queue.Count > 0)
            {
                int number = queue.Dequeue();
                if (number % 2 == 0)
                {
                    evenQueue.Enqueue(number);

                }

            }
            int count = evenQueue.Count;
            for (int i = 0; i < count; i++)
            {
                if (i != count - 1)
                {
                    Console.Write(evenQueue.Dequeue() + ", ");
                }
                else
                {
                    Console.WriteLine(evenQueue.Dequeue());
                }

            }


        }
    }
}
