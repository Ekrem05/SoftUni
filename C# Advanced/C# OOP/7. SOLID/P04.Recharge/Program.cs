using System.Collections.Generic;

namespace P04.Recharge
{
    class Program
    {
        static void Main()
        {
            List<IWorker> workers = new List<IWorker>() {
                new Robot("1",10),
                new Employee("2")
                ,
            };
            foreach (var worker in workers)
            {
                worker.Work(2);
            }
            System.Console.WriteLine(string.Join(" ",workers.Capacity));
        }
    }
}
