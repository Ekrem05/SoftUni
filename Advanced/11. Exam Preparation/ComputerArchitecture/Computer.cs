using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture
{
    public class Computer
    {   private List<CPU> multiprocessor;
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU>Multiprocessor  { get { return multiprocessor; } set { multiprocessor = value;} }
        public int Count { get { return multiprocessor.Count(); } }
        public void Add(CPU cpu)
        {
            if (Count<Capacity)
            {
                multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            bool existence=false;
            foreach (var item in multiprocessor)
            {
                if (item.Brand==brand)
                {
                    existence = true;
                    multiprocessor.Remove(item);
                    break;
                }
            }
            return existence;
        }
        public CPU MostPowerful()
        {
            double maxFreq=double.MinValue;
            CPU result=new CPU();
            foreach (var item in multiprocessor)
            {
                if (item.Frequency >maxFreq)
                {
                    maxFreq= item.Frequency;
                    result=item;
                }
            }
            return result;
        }
        public CPU GetCPU(string brand)
        {
           CPU result = new CPU();
            bool existence=false;   
            foreach (var item in multiprocessor)
            {
                if (item.Brand == brand)
                {
                    existence = true;
                   result=item;
                }
            }
            if (existence)
            {
                return result;
            }
           
                return null;
            
            
        }
        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var cpu in multiprocessor)
            {
                
                sb.AppendLine($"{cpu}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
