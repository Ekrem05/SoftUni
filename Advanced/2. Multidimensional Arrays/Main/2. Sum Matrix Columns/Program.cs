using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().
               Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).
               Select(int.Parse).
               ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];
            int[] sum = new int[cols];
            for (int i = 0; i < rows; i++)
            {
                int[] rowValues = Console.ReadLine().
                 Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).
                 Select(int.Parse).
                 ToArray();
                for (int k = 0; k < rowValues.Length; k++)
                {
                    
                    matrix[i, k] = rowValues[k];
                }
            }
            for (int i = 0; i < cols; i++)
            {
                for (int k = 0; k < rows; k++)
                {
                    sum[i]+= matrix[k, i];
                }
            }
            foreach (var item in sum)
            {
                Console.WriteLine(item);
            }
        }
    }
}
