List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();
string command = string.Empty;
Func<List<string>, Predicate<string>, List<string>> remover = (names, criteria) =>
{
    List<string> result = new List<string>();
    foreach (var name in names)
    {
        if (!criteria(name))
        {
            result.Add(name);
        }
    }

    return result;
};
Func<List<string>, Predicate<string>, List<string>> doubler = (names, criteria) =>
{
    List<string> result = new List<string>();
    foreach (var name in names)
    {
        if (criteria(name))
        {
            result.Add(name);
            result.Add(name);
        }
        else
        {
            result.Add(name);
        }
    }

    return result;
};

while ((command = Console.ReadLine()) != "Party!")
{
    string[] split = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string action = split[0];
    string criteria = split[1];
    string value = split[2];
    switch (action)
    {
        case "Remove":
            if (criteria == "StartsWith")
            {
                names = remover(names, (x) => x.StartsWith(value));
            }
            else if (criteria == "EndsWith")
            {
                names.Where((x) => x.EndsWith(criteria));
            }
            else if (criteria == "Length")
            {
                names.Where(x => x.Length == int.Parse(value));
            }
            break;
        case "Double":
            if (criteria == "StartsWith")
            {
                names = doubler(names, (x) => x.StartsWith(value));
            }
            else if (criteria == "EndsWith")
            {
                names = doubler(names, x => x.EndsWith(value));
            }
            else if (criteria == "Length")
            {
                names = doubler(names, ((x) => x.Length == int.Parse(value)));
            }
            break;
    }

}

if (names.Count > 0)
{
    Console.WriteLine(string.Join(", ", names) + " are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}