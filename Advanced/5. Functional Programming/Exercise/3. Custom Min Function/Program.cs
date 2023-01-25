int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
Func<int[], int> findSmallest = (numbers) =>
{
    int min = int.MaxValue;
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i]<min)
        {
            min = numbers[i];
        }
    }
    return min; 
};
Console.WriteLine(findSmallest(input));