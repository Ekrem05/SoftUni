using P03.Detail_Printer;
using System;

namespace P03.DetailPrinter
{
    public class Employee :IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public void Print()
        {
            Console.WriteLine(this.Name);
        }
    }
}
