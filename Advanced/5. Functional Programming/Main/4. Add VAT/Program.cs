double[] values = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(x => x += 0.2 * x).ToArray();
for (int i = 0; i < values.Length; i++)
{
    Console.WriteLine($"{values[i]:f2}");
}