
Func<string, bool> upperCase = (x) => x[0] == char.ToUpper(x[0]) && char.IsLetter(x[0]);
string[] text = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Where(x=>upperCase(x)).ToArray();

foreach (var item in text)
{
    Console.WriteLine(item);
}