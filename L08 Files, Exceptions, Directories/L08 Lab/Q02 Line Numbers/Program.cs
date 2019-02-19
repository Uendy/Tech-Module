using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Q02_Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Input.txt";

            var arrayOfInput = File.ReadAllLines(input);

            for (int indexOfLine = 0; indexOfLine < arrayOfInput.Length; indexOfLine++)
            {
                arrayOfInput[indexOfLine] = (indexOfLine + 1).ToString() + ". " + arrayOfInput[indexOfLine]; 
            }

            if (!File.Exists("Output.txt"))
            {
                File.Create("Output.txt");
            }

            var output = "Output.txt";

            File.WriteAllLines(output, arrayOfInput);

            var finalOutput = File.ReadAllText(output);
            Console.WriteLine(finalOutput);
        }
    }
}
