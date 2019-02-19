using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Q03_Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = "Input.txt";
            var outputFile = "Output.txt";

            var dictOfCheckedWords = new Dictionary<string, int>();

            var listOfCheckedWords = Console
                .ReadLine()
                .Split(' ')
                .ToArray();

            foreach (var word in listOfCheckedWords)
            {
                dictOfCheckedWords[word] = 0;
            }

            var inputFileAsLinedStringArray = File.ReadAllLines(inputFile);

            var inputFileAsArray = new List<string>();

            foreach (var line in inputFileAsLinedStringArray)
            {
                var currentSentenceAsArray = line.Split(' ').ToArray();
                foreach (var word in currentSentenceAsArray)
                {
                    // also had trouble splitting string since end of line was \r\n\r...
                    var currentWord = word; // this string refractoring bit to match the dict keys took ages to figure out
                    currentWord = currentWord.ToLower();
                    currentWord = currentWord.Replace(",", "");
                    currentWord = currentWord.Replace("-", "");
                    currentWord = currentWord.Replace(".", "");
                    bool inDict = dictOfCheckedWords.ContainsKey(currentWord);
                    if (inDict)
                    {
                        dictOfCheckedWords[currentWord]++;
                    }
                }
            }

            dictOfCheckedWords = dictOfCheckedWords
                .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, y => y.Value);

            var putInOutputFile = new List<string>();

            foreach (var specialWord in dictOfCheckedWords.Keys)
            {
                var currentString = specialWord + " - " + dictOfCheckedWords[specialWord];
                putInOutputFile.Add(currentString);
            }

            File.WriteAllLines(outputFile, putInOutputFile);
        }
    }
}
