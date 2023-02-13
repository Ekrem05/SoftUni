Stack<int>greyTiles= new Stack<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<int> whiteTiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Dictionary<string,int>tiles= new();
tiles.Add("Sink", 40);
tiles.Add("Oven", 50);
tiles.Add("Countertop", 60);
tiles.Add("Wall", 70);
List<int>areas= new List<int>() {40,50,60,70};
Dictionary<string, int> tilesForUse = new();
while (true)
{
	int currentWhiteTile = whiteTiles.Peek();
    int currentGreyTile = greyTiles.Peek();
    if (currentGreyTile==currentWhiteTile)
	{
		int largeTile = currentWhiteTile + currentGreyTile;
		if (areas.Contains(largeTile))
		{
			greyTiles.Pop();
			whiteTiles.Dequeue();
			foreach (var location in tiles)
			{
				if (location.Value==largeTile)
				{
					if (!tilesForUse.ContainsKey(location.Key))
					{
						tilesForUse.Add(location.Key, 1);
						break;
					}
					else
					{
						tilesForUse[location.Key]++;

                            break;
                    }
				}
			}
		}
		else
		{
            if (!tilesForUse.ContainsKey("Floor"))
            {
                tilesForUse.Add("Floor", 1);
                
            }
            else
            {
                tilesForUse["Floor"]++;

               
            }
            greyTiles.Pop();
            whiteTiles.Dequeue();
        }
	}
	else
	{
		currentWhiteTile /=  2;
		whiteTiles.Dequeue();
		whiteTiles.Enqueue(currentGreyTile);
		greyTiles.Pop();
		greyTiles.Push(currentGreyTile);
	}
	if (!greyTiles.Any()||!whiteTiles.Any())
	{
		break;
	}
}
if (whiteTiles.Any())
{
	Console.WriteLine("White tiles left: "+string.Join(", ",whiteTiles));
}
else
{
    Console.WriteLine("White tiles left: none");
}
if (greyTiles.Any())
{
    Console.WriteLine("Grey tiles left: " + string.Join(", ", greyTiles));
}
else
{
    Console.WriteLine("Grey tiles left: none");
}
foreach (var item in tilesForUse.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
{
	Console.WriteLine($"{item.Key}: {item.Value}");
}