using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBoxofString
{
    public class Box<T>
    {

        private List<T> values;
        public Box()
        {
            values = new List<T>();
        }
        public void Add(T item)
        {

            values.Add(item);
        }
        public override string ToString()
        {
            StringBuilder sb = new();
                foreach (T item in values)
                {
                sb.AppendLine($"{item.GetType()}: {item}");
                }
            return sb.ToString();
        }
        
    }
}
