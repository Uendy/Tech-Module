using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "a";
            string str2 = "d";

            var result = string.Concat(str1, str2);
            Console.WriteLine(result);
        }
    }
}
