using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.IO.Contracts;

namespace UniversityCompetition.IO
{
    public class FileWriter : IWriter
    {
        public void Write(string message)
        {
            using (StreamWriter streamWriter=new StreamWriter("../../../output.txt", true))
            {
                streamWriter.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter("../../../output.txt", true))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}
