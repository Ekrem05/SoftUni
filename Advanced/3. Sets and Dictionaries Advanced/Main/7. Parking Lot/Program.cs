using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {   HashSet<string> parkingSlot = new HashSet<string>(); 
            string command=String.Empty;
            while ((command=Console.ReadLine())!="END")
            {
                string[] split = command.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string direction = split[0];
                string carNumber= split[1];
                if (direction=="IN")
                {
                    parkingSlot.Add(carNumber);
                }
                else if (direction=="OUT")
                {
                    parkingSlot.Remove(carNumber);
                }
            }
            if (parkingSlot.Count>0)
            {
            foreach (var item in parkingSlot)
            {
                Console.WriteLine(item);
            }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
           
        }
    }
}
