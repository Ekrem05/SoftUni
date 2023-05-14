using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list = new List<T>();
        public int Count { get; private set; }
        public void Add(T element)
        {
            list.Add(element);
            Count++;
        }
        public T Remove()
        {
            Count--;
            T element = list[list.Count - 1];
            list.Remove(element);
            return element;

        }


    }
}
