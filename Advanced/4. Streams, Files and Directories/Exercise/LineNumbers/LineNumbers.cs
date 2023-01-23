namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder stringBuilder = new();
            string[] lines = File.ReadAllLines(inputFilePath);
            int lineCounter = 0;
            foreach (var line in lines)
            {  
                 lineCounter++;
                int punctuationCount = 0;
                int wordsCount = 0;
                char[]chars= line.ToCharArray();
                foreach (var item in chars)
                {
                    if (Char.IsPunctuation(item))
                    {
                        punctuationCount++;
                    }
                    else if (Char.IsLetter(item))
                    {
                        wordsCount++;
                    }
                }
                stringBuilder.AppendLine($"Line {lineCounter}: {line} ({wordsCount})({punctuationCount})");
             
                

            }  
            File.AppendAllText(outputFilePath, stringBuilder.ToString());
        }
    }
}
