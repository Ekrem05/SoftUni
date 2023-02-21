using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings:Stack<string>
    {
        public Stack<string> stack = new Stack<string>();
        public StackOfStrings() { }
        public bool IsEmpty() 
        {
            return stack.Any();
        }
        public Stack<string> AddRange() 
        { 
            Stack<string> stack = new Stack<string>();
            foreach (var item in this.stack)
            {
                stack.Push(item);
            }
            return stack;
        }
    }
}
