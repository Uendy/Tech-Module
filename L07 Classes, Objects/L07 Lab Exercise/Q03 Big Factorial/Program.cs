using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Q03_Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            BigInteger sum = 1;

            while (input > 1)
            {
                sum *= input--;
            }

            Console.WriteLine(sum);
        }
    }
}
