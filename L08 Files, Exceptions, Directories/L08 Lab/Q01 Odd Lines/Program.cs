using System;
using System.Collections.Generic;
using System.IO;

namespace Q01_Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {

            var fileInput = "input.txt";

            var lines = File.ReadAllLines(fileInput);

            var arrayOfOutput = new List<string>();

            for (int indexOfLine = 1; indexOfLine < fileInput.Length; indexOfLine += 2)
            {
                arrayOfOutput.Add(lines[indexOfLine]);
            }

            if (!File.Exists("fileOutput.txt"))
            {
                File.Create("fileOutput.txt");
            }
            var fileOutput = "fileOutput.txt";

            File.WriteAllLines(fileOutput, arrayOfOutput);

            var output = File.ReadAllLines(fileOutput);

            foreach (var line in output)
            {
                Console.WriteLine(line);
            }

        }

        // 1st given solution:
        //  string[] text = File.ReadAllLines("input.txt");

        //  for (int i = 1; i<text.Length; i+=2)
        //  {
        //      File.AppendAllText("output.txt", text[i] + Environment.NewLine);
        //  }

        // 2nd given solution:
        //  string[] text = File.ReadAllLines("input.txt");

        //  File.WriteAllLines("output.txt", 
        //                 text.Where((line, index) => index % 2 == 1));

        ////this was the solution I initially wanted, but nope


}
}
