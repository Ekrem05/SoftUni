List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToList();
string command=string.Empty;
Func<List<int>,List<int>> addOne = (numbers) =>
{
    List<int> result = new List<int>();
    for (int i = 0; i < numbers.Count; i++)
    {
        result.Add(numbers[i]+1);
    }
    return result;
};
Func<List<int>, List<int>> multiply = (numbers) =>
{
    List<int> result = new List<int>();
    for (int i = 0; i < numbers.Count; i++)
    {
        result.Add(numbers[i] * 2);
    }
    return result;
};
Func<List<int>, List<int>> subtract = (numbers) =>
{
    List<int> result = new List<int>();
    for (int i = 0; i < numbers.Count; i++)
    {
        result.Add(numbers[i] -1); ;
    }
    return result;
};
Action<List<int>> printList = (numbers) =>
{
    Console.WriteLine(string.Join(" ",numbers));

    
};
while ((command=Console.ReadLine())!="end")
{
    string action = command;
    switch (action)
    {
        case "add":
            numbers=(addOne(numbers));
            break;
        case "multiply":
            numbers = (multiply(numbers));
            break;
        case "subtract":
            numbers = (subtract(numbers));
            break;
        case "print":
             printList(numbers);
            break;
       
            
    }
}