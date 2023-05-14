namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
             StringBuilder sb = new();
            using (StreamReader reader= new(inputFilePath))
            {
               
                string line = reader.ReadLine();
                int lineCounter = 0;
                while (line!=null)
                {
                    if (lineCounter%2==0)
                    {
                                              
                        line = ReplaceSymbols(line);
                        line = ReverseLine(line);
                        sb.AppendLine(line);
                    }
                    line = reader.ReadLine();
                    lineCounter++;
                }
            }
            return sb.ToString();
        }

       

        private static string ReplaceSymbols(string line)
        {
            StringBuilder sb = new(line);
            string[] symbolsForReplacing = { "-", ",", ".", "!","?" };
           
            foreach (var symbol in symbolsForReplacing)
            {
                sb.Replace(symbol, "@");
            }
            return sb.ToString();
        }
         private static string ReverseLine(string line)
        {
            string[] split = line.Split(" ").Reverse().ToArray();
            return string.Join(" ", split);
         }
     }
}
