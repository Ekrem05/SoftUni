using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                
                matrix[i] = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray(); 
            }
            for (int i = 0; i < n - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int m = 0; m < matrix[i].Length; m++)
                    {
                        matrix[i][m] *= 2;
                    }
                    for (int m = 0; m < matrix[i + 1].Length; m++)
                    {
                        matrix[i + 1][m] *= 2;
                    }
                }
                else
                {
                    for (int m = 0; m < matrix[i].Length; m++)
                    {
                        matrix[i][m] /= 2;
                    }
                    for (int m = 0; m < matrix[i + 1].Length; m++)
                    {
                        matrix[i + 1][m] /= 2;
                    }
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] split = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string action = split[0];
                if (action == "Add")
                {
                    int row = int.Parse(split[1]);
                    int col = int.Parse(split[2]);
                    int value = int.Parse(split[3]);
                    if (row >= 0 && col < matrix[row].Length && col >= 0 && row < matrix.Length)
                    {
                        matrix[row][col] += value;
                    }

                }
                else if (action == "Subtract")
                {
                    int row = int.Parse(split[1]);
                    int col = int.Parse(split[2]);
                    int value = int.Parse(split[3]);
                    if (row >= 0 && col < matrix[row].Length && col >= 0&&row<matrix.Length)
                    {
                        matrix[row][col] -= value;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < matrix[i].Length; k++)
                {
                    Console.Write(matrix[i][k]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
