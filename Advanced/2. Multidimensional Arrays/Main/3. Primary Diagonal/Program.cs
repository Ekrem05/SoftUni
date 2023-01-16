using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size=int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                int[] rowValues = Console.ReadLine().
                 Split(' ' ).
                 Select(int.Parse).
                 ToArray();
                for (int k = 0; k < rowValues.Length; k++)
                {
                    matrix[i, k] = rowValues[k];
                }
            }
            int sumDiagonal = 0;
            for (int i = 0; i < size; i++)
            {
                for (int k = i; k <= i; k++)
                {
                    sumDiagonal+= matrix[i, k];
                }
            }
            Console.WriteLine(sumDiagonal);
        }
    }
}
