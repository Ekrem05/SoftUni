namespace LineNumbers 
{ using System; 
    using System.IO;
    using System.IO.IsolatedStorage;
    public class LineNumbers {
        static void Main() 
        { 
            string inputPath = @"..\..\..\Files\input.txt"; 
            string outputPath = @"..\..\..\Files\output.txt";
            RewriteFileWithLineNumbers(inputPath, outputPath); 
        } 
        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath) 
        { 
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string line = reader.ReadLine(); 
                    int lineCounter = 1; 
                    while (line != null) 
                    { writer.WriteLine($"{lineCounter++}. {line}");
                        line = reader.ReadLine(); 
                    } 
                } 
            }
        } 
    } 
}
