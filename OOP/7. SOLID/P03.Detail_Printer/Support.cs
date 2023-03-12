using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Detail_Printer
{
    public class Support : Employee, IEmployee
    {
       
        public string SecondName { get; set; }
        public Support(string name, string secondName):base(name) 
        {
            SecondName = secondName;
           
        }

        public new void Print()
        {
            Console.WriteLine($"{Name} {SecondName}");
        }
    }
}
