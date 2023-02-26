using System;
using System.Linq;

namespace _2.Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]ratio=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            char[,] matrix = new char[ratio[0], ratio[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] inputArray = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int k = 0; k < matrix.GetLength(1); k++)
                {

                    matrix[i, k] = inputArray[k];
                }
            }
            int countSquares = 0;
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int k = 0; k < matrix.GetLength(1)-1; k++)
                {
                 
                    if (matrix[i, k] == matrix[i, k + 1] && matrix[i, k] == matrix[i + 1, k] && matrix[i, k] == matrix[i + 1, k + 1])
                    {
                        countSquares++;
                    }

                }
               
            }
            Console.WriteLine(countSquares);
        }
    }
}
