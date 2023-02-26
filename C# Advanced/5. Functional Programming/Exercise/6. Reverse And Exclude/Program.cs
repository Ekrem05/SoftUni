Func<List<int>, Predicate<int>, List<int>> remover = (numbers, filter) =>
{
    List<int> list = new List<int>();
    for (int i = 0; i < numbers.Count; i++)
    {
        if (!filter(numbers[i]))
        {
            list.Add(numbers[i]);
        }
    }
    return list;
};
Func<List<int>, List<int>> reverser = numbers =>
{
    List<int> list = new List<int>();
    for (int i = numbers.Count - 1; i >= 0; i--)
    {
        list.Add((int)numbers[i]);  
    }
    return list;
};
List<int>list=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse) .ToList(); 
int n=int.Parse(Console.ReadLine());
list=reverser(list);    
list=remover(list,(x=>x%n==0));
Console.WriteLine(String.Join(" ",list));
