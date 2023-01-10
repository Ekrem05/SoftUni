using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            input = input.Replace(" ", "");
            char[]chars= input.ToCharArray();
            
            int opening = 0;
            string subString = "";
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i]=='(')
                {
                    stack.Push(i);
                }
                else if (chars[i] == ')')
                {
                    opening = stack.Pop();
                    
                    subString=input.Substring(opening,i-opening+1);
                    Console.WriteLine(subString);
                }
               
            }
        }
    }
}
