using PlanetWars.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlanetWars.IO
{
    public class FileWriter : IWriter
    {
        public void Write(string message)
        {
            using (StreamWriter writer=new StreamWriter("../../../ouput.txt",true))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../ouput.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
