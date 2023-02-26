int n=int.Parse(Console.ReadLine());
string[,]battleField=new string[n,n];
int row = -1;
int col = -1;
for (int i = 0; i < battleField.GetLength(0); i++)
{
    string rowValues = Console.ReadLine();
   
    for (int k = 0; k < battleField.GetLength(1); k++)
    {
        string value = rowValues[k].ToString();
        battleField[i, k] = value;
        if (value=="S")
        {
            row = i; col=k;
            battleField[row, col] = "-";
        }
    }
}


int hits = 0;
int cruisersDestroied = 0;
while (true)
{
    
    string move=Console.ReadLine();
    
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
    if (battleField[row,col]== "*")
    {
        hits++;
        battleField[row, col] = "-";
        if (hits==3)
        {
            Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{row}, {col}]!");
            break;
        }
    }
    else if (battleField[row,col]== "C")
    {
        cruisersDestroied++;    
        battleField[row, col] = "-";
        if (cruisersDestroied == 3)
        {
            Console.WriteLine($"Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            break;
        }
    }

}
battleField[row, col] = "S";
PrintMatrix(battleField);
void PrintMatrix(string[,] battleField)
{
    for (int i = 0; i < battleField.GetLength(0); i++)
    {
        for (int k = 0; k < battleField.GetLength(1); k++)
        {
            Console.Write(battleField[i,k]);
        }
        Console.WriteLine();
    }
}