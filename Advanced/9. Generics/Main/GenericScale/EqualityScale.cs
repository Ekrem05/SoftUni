using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T left; 
        private T right;

        public EqualityScale(T left, T right)
        {
            Left = left;
            Right = right;
        }

        public T Left { get => left; set => left = value; }
        public T Right { get => right; set => right = value; }
        public bool AreEqual()
        {
            if(Left.Equals(Right))
            {
                return true;
            }
            return false;
        }
    }
}
