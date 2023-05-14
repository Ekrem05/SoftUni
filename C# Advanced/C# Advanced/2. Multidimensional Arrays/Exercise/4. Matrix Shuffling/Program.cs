using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ratio = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
           string[,] matrix = new string[ratio[0], ratio[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] inputArray = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int k = 0; k < matrix.GetLength(1); k++)
                {

                    matrix[i, k] = inputArray[k];
                }
            }
            string command = string.Empty;
            while ((command=Console.ReadLine())!="END")
            {
                string[] split = command.Split();
                string action= split[0];
                if (action=="swap")
                {
                    int row1 = int.Parse(split[1]);
                    int col1 = int.Parse(split[2]);
                    int row2 = int.Parse(split[3]);
                    int col2 = int.Parse(split[4]);
                    if (row1 >= 0 && row1 < matrix.GetLength(0)&&col1>=0&&col1<matrix.GetLength(1))
                    {
                        if ((row2 >= 0 && row2 < matrix.GetLength(0) && col2 >= 0 && col2 < matrix.GetLength(1)))
                        {
                            string temp = matrix[row1, col1];
                            matrix[row1, col1] = matrix[row2,col2];
                            matrix[row2, col2] = temp;
                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                               
                                for (int k = 0; k < matrix.GetLength(1); k++)
                                {

                                    Console.Write(matrix[i,k]+" ");
                                }
                                Console.WriteLine();
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
