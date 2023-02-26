namespace RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrixRoute = new string[n,n];
            
            string[,]carPosition= new string[n,n];
            string raceCar= (Console.ReadLine());
            int kmMade = 0;
            for (int rows = 0; rows < n; rows++)
            {
                string[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int cols = 0; cols < row.Length; cols++)
                {
                    matrixRoute[rows, cols] = row[cols];
                }
            }
            string command = string.Empty;
            int carCol = 0;
            int carRow= 0;
            bool finish = false;
            while ((command = Console.ReadLine())!="End")
            {
                switch (command)
                {
                    case "down":
                        carRow++;
                          break;
                    case "up":
                        carRow--;
                        break;
                    case "left":
                        carCol--;
                        break;
                    case "right":
                        carCol++;
                        break;

                }
                if (matrixRoute[carRow, carCol] == ".")
                {
                    kmMade += 10;
                }
                else if(matrixRoute[carRow, carCol] == "T")
                {
                    matrixRoute[carRow, carCol] = ".";
                    int[]coordinates=TunelEndCoordinates(matrixRoute);
                    carRow=coordinates[0];
                    carCol = coordinates[1];
                    kmMade += 30;
                    matrixRoute[carRow, carCol] = ".";
                }
                else if (matrixRoute[carRow, carCol] == "F")
                {
                    
                    kmMade += 10;
                    Console.WriteLine($"Racing car {raceCar} finished the stage!");
                    finish = true;
                    break;
                }
            }
            matrixRoute[carRow, carCol] = "C";
            if (!finish)
            {
                Console.WriteLine($"Racing car {raceCar} DNF.");
            }
            Console.WriteLine($"Distance covered {kmMade} km.");
            PrintMatrix(matrixRoute);
        }
        static int[]TunelEndCoordinates(string[,]matrix)
        {
            int[] result = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int l = 0; l < matrix.GetLength(1); l++)
                {
                    if (matrix[i,l]=="T")
                    {
                        result[0] = i;
                        result[1]=l;
                    }
                }
            }
            return result;
        }
        static void PrintMatrix(string[,]matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int l = 0; l < matrix.GetLength(1); l++)
                {
                    Console.Write($"{matrix[i,l]}");
                }
                Console.WriteLine();
            }
        }
    }
}