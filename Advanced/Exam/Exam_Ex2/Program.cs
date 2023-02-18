using System.Data;
using System.Numerics;

int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int n = input[0];
int m = input[1];
string[,] playground = new string[n, m];
int rows = 0;
int cols = 0;

for (int i = 0; i < n; i++)
{
    string[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    for (int k = 0; k < m; k++)
    {
        playground[i, k] = row[k].ToString();
        if (playground[i, k] == "B")
        {
            playground[i, k] = "-";
            rows = i;
            cols = k;

        }
       
    }
}
string command = string.Empty;
int peopleTouched = 0;
int movesMade = 0;
int opponentsCount = 3;

while ((command = Console.ReadLine().ToLower()) != "finish")
{bool moved = false;
    
    switch (command.ToLower())
    {
        case "up":
            if (AbleToMove(playground,rows-1,cols))
            {
                rows--;
                moved = true;

            }
            break;
        case "down":
            if (AbleToMove(playground, rows + 1, cols))
            {
                moved = true;
                rows++;
            }
                break;
        case "right":
            if (AbleToMove(playground, rows, cols+1))
            {
                moved = true;
                cols++;
            }
                break;
        case "left":
            if (AbleToMove(playground, rows, cols - 1))
            {
                moved = true;
                cols--;
            }
            break;
    }    
    if (playground[rows, cols] == "O")
    {
        switch (command)
        {
            case "up":
                rows++;
                break;
            case "down":
                rows--;
                break;
            case "right":
                cols--;
                break;
            case "left":
                cols++;
                break;
        }
    }
    else if (playground[rows, cols] == "-")
    {
        if (moved)
        {
            movesMade++;
        }
       
    }
    else if (playground[rows, cols] == "P")
    {
        playground[rows, cols] = "-";
        peopleTouched++;
        opponentsCount--;
        movesMade++;
    }
    if (opponentsCount == 0)
    {
        
        break;
    }
    

    

}
Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {peopleTouched} Moves made: {movesMade}");
bool AbleToMove(string[,]matrix,int rows, int cols)
{
    bool possible = true;
    if (rows < 0 || rows >= matrix.GetLength(0) || cols < 0 || cols >= matrix.GetLength(1)) 
    {
        possible = false;
    }
    return possible;
}