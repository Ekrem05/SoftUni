using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
       

        int[] clothes = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();

      

        int rackCapacity = int.Parse(Console.ReadLine());

        
        Stack<int> stack = new Stack<int>(clothes);

        int racks = 1;
        int currentSum = 0;

        
        while (stack.Count > 0)
        {
            int currentClothes = stack.Pop();
            currentSum += currentClothes;

            if (currentSum > rackCapacity)
            {
                racks++;
                currentSum = currentClothes;
            }
        }

       
        Console.WriteLine(racks);
    }
}
