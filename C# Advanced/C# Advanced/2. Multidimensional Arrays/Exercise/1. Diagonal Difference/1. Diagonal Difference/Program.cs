using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size=int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                int[] inputArray=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int k = 0; k < size; k++)
                {

                    matrix[i, k] = inputArray[k];
                }
            }
            int primarySum = 0;
            int secondarySum = 0;
            for (int i = 0; i < size; i++)
            {
                primarySum += matrix[i, i];
                secondarySum += matrix[size-1-i, i];
            }
            
            int absoluteValue = Math.Abs(primarySum - secondarySum);
            Console.WriteLine(absoluteValue);
        }
    }
}
