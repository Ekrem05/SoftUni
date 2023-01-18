using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> reservation1 = new HashSet<string>();
            string command = String.Empty;
           Queue<string> queueVip = new Queue<string>();
            while ((command = Console.ReadLine()) != "PARTY")
            {
                reservation1.Add(command);
              
            }
            
            while ((command = Console.ReadLine()) != "END")
            {
                reservation1.Remove(command);

            }
            Console.WriteLine(reservation1.Count() );
            foreach (var item in reservation1)
            {
                char[]guests=item.ToCharArray();
                if (char.IsDigit(guests[0]))
                {
                    queueVip.Enqueue(item.ToString());
                    
                }
                
            }
            foreach (var item in reservation1)
            {
                if (!queueVip.Contains(item))
                {
                    queueVip.Enqueue(item);
                }
                
            }
            foreach (var item in queueVip)
            { 
                Console.WriteLine(item);
            }
        }
    }
}
