using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[]split=args.Split(' ');
            string command = split[0];
            
            Type type=Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(x=>x.Name== $"{command}Command");
            MethodInfo execude=type.GetMethod("Execute");
            ICommand ac =Activator.CreateInstance(type)as ICommand;
            string result = ac.Execute(split.Skip(1).ToArray());
            return result;
            
        }
    }
}
