using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
           string[,] wall = new string[size, size];
            int row = -1;
            int col = -1;
            int holes = 0;
            int steelRods = 0;
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                for (int rows = 0; rows < size; rows++)
                {
                    wall[i, rows] = input[rows].ToString();
                    if (wall[i, rows] == "V")
                    {
                        row = i;
                        col = rows;
                        wall[i, rows] = "*";
                        holes++;
                    }
                }
            }
            string move = string.Empty;
            bool electrocuted = false;
            while ((move = Console.ReadLine()) != "End")
            {
                switch (move)
                {
                    case "up":
                        row--;
                        break;
                    case "down":
                        row++;
                        break;
                    case "right":
                        col++;
                        break;
                    case "left":
                        col--;
                        break;

                }
                if (row>=0&&col>=0&&row<wall.GetLength(0)&&col<wall.GetLength(1))
                {
                    if (wall[row, col] == "R")
                {
                    switch (move)
                    {
                        case "up":
                            row++;
                            break;
                        case "down":
                            row--;
                            break;
                        case "right":
                            col--;
                            break;
                        case "left":
                            col++;
                            break;

                    }
                    Console.WriteLine("Vanko hit a rod!");
                    steelRods++;
                }
                else if (wall[row, col] == "C")
                {
                    wall[row, col] = "E";
                    holes++;
                    electrocuted = true;
                    break;
                }
                else if (wall[row, col] == "*")
                {
                    Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
                }
                else
                {
                    wall[row, col] = "*";
                    holes++;
                }
                }
                else
                {
                    switch (move)
                    {
                        case "up":
                            row++;
                            break;
                        case "down":
                            row--;
                            break;
                        case "right":
                            col--;
                            break;
                        case "left":
                            col++;
                            break;

                    }
                }
                
            }
            if (!electrocuted)
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {steelRods} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");


            }
            if (wall[row, col] != "E")
            {
                wall[row, col] = "V";
            }
            PrintMatrix(wall);


        }

        public static void PrintMatrix(string[,] battleField)
        {
            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                for (int k = 0; k < battleField.GetLength(1); k++)
                {
                    Console.Write(battleField[i, k]);
                }
                Console.WriteLine();
            }
        }
    }

    
}

