using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize=Console.ReadLine().
                Split(new string[] {", "},StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                int[] rowValues = Console.ReadLine().
                 Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).
                 Select(int.Parse).
                 ToArray();
                for (int k = 0; k < rowValues.Length; k++)
                {
                    sum+= rowValues[k];
                    matrix[i, k] = rowValues[k];
                }
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);

        }
    }
}
