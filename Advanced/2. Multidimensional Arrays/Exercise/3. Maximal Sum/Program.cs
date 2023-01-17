using System;
using System.Linq;



namespace _3.Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ratio = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[,] matrix = new int[ratio[0], ratio[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] inputArray = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();
                for (int k = 0; k < matrix.GetLength(1); k++)
                {

                    matrix[i, k] = inputArray[k];
                }
            }
            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;
            for (int i = 0; i < matrix.GetLength(0)-2; i++)
            {
                
                for (int k = 0; k < matrix.GetLength(1)-2; k++)
                {
              
                    int sum= matrix[i, k] + matrix[i, k + 1] + matrix[i, k + 2] + matrix[i + 1, k] + matrix[i + 1, k + 1] 
                        + matrix[i + 1, k + 2] + matrix[i + 2, k] + matrix[i + 2, k + 1] + matrix[i + 2, k + 2];
                    if (sum>maxSum)
                    {
                        maxSum = sum;
                        maxRow= i;
                        maxCol = k;
                    }
                    
                }
            }
            Console.WriteLine("Sum = "+maxSum);
            for (int i = maxRow; i < maxRow+3; i++)
            {
                for (int k = maxCol; k < maxCol+3; k++)
                {
                    Console.Write(matrix[i,k]+" ");
                }
                Console.WriteLine();
            }

        }
    }
}
