using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03_Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCount = int.Parse(Console.ReadLine());

            decimal sum = 0;

            for (int i = 1; i <= numberCount; i++)
            {
                decimal addition = decimal.Parse(Console.ReadLine());
                sum += addition;
            }

            Console.WriteLine(sum);
        }
    }
}
