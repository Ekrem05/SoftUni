﻿using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
           
            while (true)
            {string command=Console.ReadLine();
                try
                {
                    string result = commandInterpreter.Read(command);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Command");
                }
                
            }
        }
    }
}
