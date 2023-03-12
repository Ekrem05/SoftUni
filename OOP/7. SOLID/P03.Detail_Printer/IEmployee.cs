using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Detail_Printer
{
    public interface IEmployee
    {
        public string Name { get; set; }
        void Print();
    }
}
