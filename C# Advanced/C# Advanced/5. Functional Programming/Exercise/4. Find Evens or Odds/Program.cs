using System;

int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
string c=Console.ReadLine();

Predicate<int> isEven = number => number % 2 == 0;

Func<int, int, Predicate<int>,string, List<int>> findEvenOrOdd = (start, end, filter,criteria) =>
{List<int> result = new List<int>();
    
    if (criteria=="odd")
	{
		for (int i = start; i <= end; i++)
		{
            if (!isEven(i))
            {
                result.Add(i);
            }
		}
	}
	else
	{
        for (int i = start; i <= end; i++)
        {
            if (isEven(i))
            {
                result.Add(i);
            }
        }
    }
	return result;
};
Console.WriteLine(string.Join(" ", findEvenOrOdd(range[0], range[1],isEven,c)));

