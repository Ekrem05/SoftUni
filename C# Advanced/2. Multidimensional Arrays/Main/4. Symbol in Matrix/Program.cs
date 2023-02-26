using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                char[] rowValues = input.ToCharArray();
                for (int k = 0; k < rowValues.Length; k++)
                {
                    matrix[i, k] = rowValues[k];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            bool found = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i,k]==symbol)
                    {
                        Console.WriteLine($"({i}, {k})");
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
