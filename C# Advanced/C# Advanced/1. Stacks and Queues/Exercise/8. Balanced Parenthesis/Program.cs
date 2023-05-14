using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            char[] array=input.ToCharArray();
            Stack<char> stack=new Stack<char>();
            bool balance = true;
            while (balance)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    char current = array[i];
                    if (current=='{'|| current == '[' || current == '(')
                    {
                        stack.Push(current);
                    }
                    char top =stack.Peek();
                     if (current == '}' || current == ']' || current == ')')
                    {
                        if ((top == '{' && current !='}')||(top == '[' && current != ']')||top == '(' && current != ')')
                        {
                            balance = false;
                            break;
                        }
                        else
                        {
                            if (stack.Any())
                            {
                                top = stack.Pop();
                            }
                          ;
                        }
                       
                      
                    }
                    
                }
                if (balance==false)
                {
                    Console.WriteLine("NO");
                    break;
                }
                else
                {
                    if (stack.Any())
                    {
                        Console.WriteLine("NO");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("YES");
                        break;
                    }
                   
                }
               
            }

        }
    }
}
