string[]names=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
Action<string[]> printNames = (name) =>
{
	for (int i = 0; i < name.Length; i++)
	{
		Console.WriteLine(name[i]);
	}
};
printNames(names);