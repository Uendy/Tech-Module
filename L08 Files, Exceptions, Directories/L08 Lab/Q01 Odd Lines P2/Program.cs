using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Q01_Odd_Lines_P2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "textFile.txt";
            var inputAsArray = File.ReadAllLines(input);

            //File.WriteAllLines("output.txt", inputAsArray.Where((line, index) => index % 2 == 1));
            //much faster, but confusing

            var listOfOddLines = new List<string>();

            for (int indexOfLine = 1; indexOfLine < inputAsArray.Count(); indexOfLine += 2)
            {
                listOfOddLines.Add(inputAsArray[indexOfLine]);
            }

            //if (!File.Exists("output.txt"))
            //{
            //    File.Create("output.txt");
            //}

            File.WriteAllLines("output.txt", listOfOddLines);

            var output = File.ReadAllLines("output.txt");
            foreach (var line in output)
            {
                Console.WriteLine(line);
            }
        }
    }
}
