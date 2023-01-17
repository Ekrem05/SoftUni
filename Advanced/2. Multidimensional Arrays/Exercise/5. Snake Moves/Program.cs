using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
       
        var dimensions = Console.ReadLine().Split();
        int n = int.Parse(dimensions[0]);
        int m = int.Parse(dimensions[1]);
        string snake = Console.ReadLine();

        
        char[,] matrix = new char[n, m];

       
        int index = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                matrix[row, col] = snake[index % snake.Length];
                index++;
            }
        }

        
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
