int[] array = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

Console.WriteLine(array.Count());
Console.WriteLine(array.Sum());