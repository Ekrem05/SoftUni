namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace WordCount
    {
        public class WordCount
        {
            static void Main()
            {
                string wordPath = @"..\..\..\Files\words.txt";
                string textPath = @"..\..\..\Files\text.txt";
                string outputPath = @"..\..\..\Files\output.txt";

                CalculateWordCounts(wordPath, textPath, outputPath);
            }

            public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
            {
                using (StreamReader wordsReader = new StreamReader(wordsFilePath))
                {
                    string[] wordsToFind = wordsReader.ReadToEnd().Split(' ');
                    StreamReader textReader = new StreamReader(textFilePath);
                    string text=textReader.ReadToEnd().ToLower();
                   List<string>textWords =new List<string>(text.Split(new string[] {" ",".","-",","},StringSplitOptions.RemoveEmptyEntries).ToList());
                    textReader.Close();

                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        Dictionary<string,int> keyValuePairs= new Dictionary<string, int>();
                        for (int i = 0; i < wordsToFind.Length; i++)
                        {
                            if (textWords.Contains(wordsToFind[i]))
                            {
                               int index = textWords.IndexOf(wordsToFind[i]);
                                keyValuePairs.Add(wordsToFind[i], 1);
                                while (textWords.Contains(wordsToFind[i]) == true)
                                {
                                    textWords.Remove(wordsToFind[i]);
                                    if (textWords.Contains(wordsToFind[i]))
                                    {
                                        index = textWords.IndexOf(wordsToFind[i]);
                                        keyValuePairs[wordsToFind[i]]++;
                                    }
                                }
                                

                            }
                        }
                        foreach (var item in keyValuePairs)
                        {
                            writer.WriteLine($"{item.Key} - {item.Value}");
                        }
                        
                    }
                }
            }
            }
        }
    }


