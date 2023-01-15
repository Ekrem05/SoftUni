using System;

class TruckTour
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[][] petrolpumps = new int[n][];

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            petrolpumps[i] = new int[] { int.Parse(input[0]), int.Parse(input[1]) };
        }

        int start = truckTour(petrolpumps,n);
        Console.WriteLine(start);
    }

    static int truckTour(int[][] petrolpumps,int n)
    {
        int start = 0, end = 1;
        int currPetrol = petrolpumps[start][0] - petrolpumps[start][1];

        while (end != start || currPetrol < 0)
        {
            while (currPetrol < 0 && start != end)
            {
                currPetrol -= petrolpumps[start][0] - petrolpumps[start][1];
                start = (start + 1) % n;
            }
            currPetrol += petrolpumps[end][0] - petrolpumps[end][1];
            end = (end + 1) % n;
        }
        return start;
    }
}
