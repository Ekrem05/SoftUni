using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodDoubles
{
    public class Box<T>where T:IComparable<T>
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
        public  int ReturnCountOfTheGreaterOnes(T element)
        {
            int count = 0;
            foreach (T item in values)
            {
                if (item.CompareTo(element)>0)
                {
                    count++;
                }

            }

            return count;
        }

    }
}
