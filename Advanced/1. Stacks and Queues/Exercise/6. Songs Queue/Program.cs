using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {    Queue<string> queue=new Queue<string>();
            string input=Console.ReadLine();
            string[]array=input.Split(new string[] {", "},StringSplitOptions.None);
            foreach (var item in array)
            {
                queue.Enqueue(item);
            }
           
            
            while (queue.Count>0)
            {
                string command = Console.ReadLine();
                string[] split = command.Split(' ');
                string action = split[0];   
                if (action=="Play")
                {
                    queue.Dequeue();    
                }
                else if (action=="Add")
                {
                    string[] splitingSong = command.Split(new string[] { "Add " }, StringSplitOptions.None);
                    string song= splitingSong[1];
                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                else if (action=="Show")
                {
                    Console.WriteLine(string.Join(", ",queue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
