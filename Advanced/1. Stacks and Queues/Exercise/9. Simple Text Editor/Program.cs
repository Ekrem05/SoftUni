using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _9.Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Stack<string> changes = new Stack<string>();
           StringBuilder text =new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0  ; i <n; i++)
            {
                string[]input=Console.ReadLine().Split(' ');
                int action = int.Parse(input[0]);
                if (action == 1)
                {
                    string someString = input[1];
                    text.Append(someString);
                    changes.Push("1 "+someString);

                }
                else if (action == 2)
                {
                    int count = int.Parse(input[1]);
                    string removed = text.ToString().Substring(text.Length - count, count);
                     text.Remove(text.Length - count, count).ToString();
                    changes.Push("2 "+removed);
                }
                else if (action == 3)
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index-1]);
                }
                else if (action == 4)
                {
                    string poppedAction=changes.Peek();
                    string[] split = poppedAction.Split(' '); 
                    int actionToUndo = int.Parse(split[0]);
                    if (actionToUndo==1)
                    {
                        string appendedText = split[1];
                        text.Replace(appendedText, "");
                        changes.Pop();
                    }
                    else if (actionToUndo == 2)
                    {
                        string removedText = split[1];
                        text.Append(removedText);
                        changes.Pop();
                    }
                   
                }
            }
        }
    }
}
