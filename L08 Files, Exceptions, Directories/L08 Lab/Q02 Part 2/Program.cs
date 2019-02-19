using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Q02_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // As Kenov did it
            var input = "input.txt";

            var inputAsArray = File.ReadAllLines(input);

            var numberedInputAsArray = new List<string>();

            for (int i = 0; i < inputAsArray.Length; i++)
            {
                numberedInputAsArray.Add($"{i}. {inputAsArray[i]}");
            }

            //if (!File.Exists("output.txt"))
            //{
            //    File.Create("output.txt");
            //}

            File.WriteAllLines("output.txt", numberedInputAsArray);
        }
    }
}
