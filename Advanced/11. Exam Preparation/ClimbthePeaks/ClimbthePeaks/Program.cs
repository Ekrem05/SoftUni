Stack<int> food = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<int> stamina = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<string> peaksToConquer = new();
Dictionary<string, int> peaks = new();
peaks.Add("Vihren", 80);
peaks.Add("Kutelo", 90);
peaks.Add("Banski Suhodol", 100);
peaks.Add("Polezhan", 60);
peaks.Add("Kamenitza", 70);
peaksToConquer.Enqueue("Vihren");
peaksToConquer.Enqueue("Kutelo");
peaksToConquer.Enqueue("Banski Suhodol");
peaksToConquer.Enqueue("Polezhan");
peaksToConquer.Enqueue("Kamenitza");
Dictionary<string, int> conquredPeaks = new();
int requiredSum = 0;
for (int i = 1; i <= 7; i++)
{   
    int sum = food.Peek() + stamina.Peek();
    requiredSum = peaks[peaksToConquer.Peek()];
    bool conqured = sum >= requiredSum;
    if (conqured)
    {        
        food.Pop();
        stamina.Dequeue();
        string name = peaksToConquer.Dequeue();
        conquredPeaks.Add(name, peaks[name]);
    }
    else
    {        
        food.Pop();
        stamina.Dequeue();
    }
    if (!food.Any()&&!stamina.Any())
    {
        break;
    }
    if (!peaksToConquer.Any())
    {
        break;
    }
}
if (!peaksToConquer.Any())
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}
else
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}

if (conquredPeaks.Any())
{
    Console.WriteLine("Conquered peaks:");
foreach (var item in conquredPeaks)
{
    Console.WriteLine(item.Key);
}
}


