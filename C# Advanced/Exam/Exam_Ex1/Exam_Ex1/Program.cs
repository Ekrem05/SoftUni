Queue<int> textile = new(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Stack<int> medicaments = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Dictionary<string, int> items = new() 
{
    {"Patch",30},
    {"Bandage",40},
    {"MedKit",100}
};
Dictionary<string, int> itemsCreated = new();
while (textile.Any()&&medicaments.Any())
{
    int currentTextile = textile.Peek();
    int currentMedicament = medicaments.Peek();
    int sum = currentMedicament + currentTextile;
    bool exists = false;
    foreach (var item in items)
    {
        if (item.Value==sum)
        {
            exists = true;
            if (!itemsCreated.ContainsKey(item.Key))
            {
                itemsCreated.Add(item.Key, 0);
            }
            itemsCreated[item.Key]++;
            textile.Dequeue();
            medicaments.Pop();
        }
        
    }
    if (exists==false)
    {
        if (sum > 100)
        {
            sum -=100;
            if (!itemsCreated.ContainsKey("MedKit"))
            {
                itemsCreated.Add("MedKit", 0);
            }
            itemsCreated["MedKit"]++;
            textile.Dequeue();
            medicaments.Pop();
            int current = medicaments.Pop();
            medicaments.Push(current + sum);
        }
        else
        {
            textile.Dequeue();
            int current = medicaments.Pop();
            medicaments.Push(current + 10);
        }
    }
}
if (!textile.Any() && !medicaments.Any())
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else
{
    if (!textile.Any())
    {
        Console.WriteLine("Textiles are empty.");
    }
    else if (!medicaments.Any())
    {
        Console.WriteLine("Medicaments are empty.");
    }
    
}
foreach (var item in itemsCreated.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}
if (textile.Any())
{
    Console.WriteLine("Textiles left: " + string.Join(", ", textile));
}
if (medicaments.Any())
{
    Console.WriteLine("Medicaments left: "+string.Join(", ",medicaments));
}