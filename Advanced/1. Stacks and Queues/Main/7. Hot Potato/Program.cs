using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names=Console.ReadLine().Split(' ');
            Queue<string> queue=new Queue<string>();
            foreach (var item in names)
            {
                queue.Enqueue(item);
            }
            int n = int.Parse(Console.ReadLine());
           
           while(queue.Count> 1) 
            {

                for (int i = 0; i < n-1; i++)
                {
                   string element= queue.Dequeue();
                    queue.Enqueue(element);
                }
              
                    Console.WriteLine("Removed "+ queue.Dequeue() ); 
                           
            }
            Console.WriteLine("Last is "+queue.Dequeue());
        }
    }
}
