using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStrings = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string output = "";

            for (int index = inputStrings.Length - 1; index >= 0; index--)
            {
                output += (inputStrings[index] + " ");
            }

            Console.WriteLine(output.TrimEnd());
        }
    }
}
