using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Square_With_Maximum_Sum
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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowValues = Console.ReadLine().
                Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();     
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    int value = rowValues[k];
                    matrix[i, k] = value;
                }
            }
            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol= 0;
          
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                
                for (int k = 0; k < matrix.GetLength(1); k++)
                {int currentSum = 0;
                    if (i>=matrix.GetLength(0)-1||k>=matrix.GetLength(1)-1)
                    {
                        continue;
                    }
                    currentSum += matrix[i,k];
                    currentSum+= matrix[i+1,k];
                    int sum1= matrix[i, k + 1];
                    int sum2=matrix[i+1,k+1];
                    currentSum += sum1;
                    currentSum+= sum2;
                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = i;
                        maxCol = k;
                    }
                }
            }
            Console.WriteLine(matrix[maxRow,maxCol]+" " + matrix[maxRow,maxCol+1]);
            Console.WriteLine(matrix[maxRow+1, maxCol] + " " + matrix[maxRow + 1, maxCol + 1]);
            Console.WriteLine(maxSum);
        }
    }
}
