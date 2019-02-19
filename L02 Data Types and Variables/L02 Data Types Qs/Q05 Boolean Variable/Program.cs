using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05_Boolean_Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            // True = Yes
            // False = No

            string booleanCheck = Console.ReadLine();

            if (booleanCheck == "True")
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
