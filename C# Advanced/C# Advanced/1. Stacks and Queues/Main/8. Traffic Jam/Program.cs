using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            string command = "";
            int count = 0;
            while ((command=Console.ReadLine())!="end")
            {
                if (command!="green")
                {
                    string car=command;
                    queue.Enqueue(car);
                }
                else
                {
                    if (queue.Count>=n)
                    {
                        for (int i = 0; i < n; i++)
                         {
                        
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                            count++;
                         }
                    }
                    else
                    {
                        for (int i = 0; i < queue.Count+1; i++)
                        {

                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            count++;
                        }

                    }
                   
                }

            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
