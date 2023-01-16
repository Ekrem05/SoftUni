using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[n][];
            for (int i = 0; i < n; i++)
            {
                jaggedArray[i]=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }
            string command = "";
            while ((command=Console.ReadLine())!="END")
            {
                string[]split=command.Split(' ');   
                string action = split[0];
                switch (action)
                {
                    case "Add":
                        int row = int.Parse(split[1]);
                        int col = int.Parse(split[2]);
                        if (row < 0 || col < 0 || row >= jaggedArray.Length || col > jaggedArray[row].Length)
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        else
                        {
                    int valueIncrease = int.Parse(split[3]);
                        jaggedArray[row][col] += valueIncrease;
                        }
                       
                        break;
                    case "Subtract":
                        int row1 = int.Parse(split[1]);
                        int col2 = int.Parse(split[2]);
                        if (row1 < 0 || col2 < 0 || row1 > jaggedArray.Length-1 || col2 > jaggedArray[row1].Length-1)
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        else
                        {
                        int valueDecrease = int.Parse(split[3]);
                        jaggedArray[row1][col2] -= valueDecrease;
                        }
                       
                        break;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < jaggedArray[i].Length; k++)
                {
                    Console.Write(jaggedArray[i][k]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
