string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
Action<string[],string> printNames = (name,p) =>
{
    for (int i = 0; i < name.Length; i++)
    {
        Console.WriteLine($"{p} {name[i]}");
    }
};
printNames(names,"Gospodin");