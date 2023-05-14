namespace P04.Recharge
{
    using System;

    public class Employee : Worker,ISleeper,IWorker
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            Console.WriteLine("Sleeping");
        }

        public override void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}
