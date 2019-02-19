using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q02_Append_List
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();

            List<string> numbersAsString = values.Split('|').ToList();

            string output = "";

            for (int i = numbersAsString.Count-1; i >= 0; i--)
            {
                output += numbersAsString[i] + " "; 
            }
            Console.WriteLine(output.TrimStart());
        }
    }
}
