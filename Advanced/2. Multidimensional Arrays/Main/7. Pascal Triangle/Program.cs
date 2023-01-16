using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long rows=int.Parse(Console.ReadLine());
            long[][]jaggedArray=new long[rows][];
            jaggedArray[0] = new long[1] { 1};
            for (int i = 1; i < rows; i++)
            {
                jaggedArray[i] = new long[i+1];
                for (int k = 0; k < jaggedArray[i].Length; k++)
                {
                    if (jaggedArray[i-1].Length>k)
                    {
                    jaggedArray[i][k] += jaggedArray[i - 1][k];
                    }

                    if ( k>0)
                    {
                        jaggedArray[i][k] += jaggedArray[i - 1][k - 1];
                    }
                        
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int i = 0; i < jaggedArray[row].Length; i++)
                {
                    Console.Write(jaggedArray[row][i] +" ");
                }
                Console.WriteLine();
            }
        }
    }
}
