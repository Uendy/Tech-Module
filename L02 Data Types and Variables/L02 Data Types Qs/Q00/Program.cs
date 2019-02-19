using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q00
{
    public class Method
    {
        static int numbers = 100;

        static void PrintValue()
        {
            Console.WriteLine(++numbers);
        }

        

        static void Main(string[] args)
        {
            PrintValue();

            Console.WriteLine(numbers);
        }
    }
}
