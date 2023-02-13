using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rennovators
{
    internal class Renovator
    {
        private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired = false;

        public Renovator(string name, string type, double rate, int days)
        {
           Name = name;
            Type = type;
            Rate = rate;
            Days = days;

        }

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public double Rate { get => rate; set => rate = value; }
        public int Days { get => days; set => days = value; }
        public bool Hired { get => hired; set => hired = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {name}");
            sb.AppendLine($"--Specialty: {Type}");
            sb.AppendLine($"--Rate per day: {Rate} BGN");
            return sb.ToString().TrimEnd();
        }
    }
}
