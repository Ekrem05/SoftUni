using P03.Detail_Printer;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            DetailsPrinter print = new(new List<IEmployee>()
            {
                new Employee("gisho"),
                new Manager("pesho",new string[]{"Word.doc" }),
                new Support("Ahmed","Ahmedov")
            });
            print.PrintDetails();
        }
    }
}
